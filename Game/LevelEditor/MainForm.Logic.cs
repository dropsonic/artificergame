﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarseerTools;
using LevelEditor;
using System.Drawing;
using System.Threading;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Factories;
using FarseerPhysics.Common.Decomposition;
using Color = Microsoft.Xna.Framework.Color;
using Path = System.IO.Path;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace LevelEditor
{
    public partial class MainForm : Form
    {
        string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(), --nesting);
        }

        private void SetPreview()
        {
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem != null)
            {
                Vertices shapeVertices = null;
                Texture2D previewTexture = null;
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
                {
                    case ObjectType.Arc:
                        shapeVertices = PolygonTools.CreateArc(MathHelper.ToRadians(float.Parse(arcDegrees.Value.ToString())), int.Parse(arcSides.Value.ToString()), float.Parse(arcRadius.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Capsule:
                        shapeVertices = PolygonTools.CreateCapsule(float.Parse(capsuleHeight.Value.ToString()), float.Parse(capsuleBottomRadius.Value.ToString()), int.Parse(capsuleBottomEdges.Value.ToString()), float.Parse(capsuleTopRadius.Value.ToString()), int.Parse(capsuleTopEdges.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Gear:
                        shapeVertices = PolygonTools.CreateGear(float.Parse(gearRadius.Value.ToString()), int.Parse(gearNumberOfTeeth.Value.ToString()), float.Parse(gearTipPercentage.Value.ToString()), float.Parse(gearToothHeight.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Rectangle:
                        shapeVertices = PolygonTools.CreateRectangle(float.Parse(rectangleWidth.Value.ToString()), float.Parse(rectangleHeight.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.RoundedRectangle:
                        shapeVertices = PolygonTools.CreateRoundedRectangle(float.Parse(roundedRectangleWidth.Value.ToString()), float.Parse(roundedRectangleHeight.Value.ToString()), float.Parse(roundedRectangleXRadius.Value.ToString()), float.Parse(roundedRectangleYRadius.Value.ToString()), int.Parse(roundedRectangleSegments.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Ellipse:
                        shapeVertices = PolygonTools.CreateEllipse(float.Parse(ellipseXRadius.Value.ToString()), float.Parse(ellipseYRadius.Value.ToString()), int.Parse(ellipseNumberOfEdges.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.EllipseTexture(float.Parse(ellipseXRadius.Value.ToString()), float.Parse(ellipseYRadius.Value.ToString()), materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Circle:
                        shapeVertices = PolygonTools.CreateCircle(float.Parse(circleRadius.Value.ToString()), AssetCreator.CircleSegments);
                        previewTexture = ContentService.GetContentService().AssetCreator.CircleTexture(float.Parse(circleRadius.Value.ToString()), materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.CustomShape:
                        if (shapeFromTextureBox.SelectedItem == null) break;
                        if (useOriginalTextureCheck.Checked)
                            ContentService.GetContentService().AssetCreator.ShapeFromTexture(shapeFromTextureBox.SelectedItem.ToString(), float.Parse(customShapeScale.Value.ToString()), colorDictionary[colorBox.SelectedItem.ToString()], out previewTexture, out shapeVertices);
                        else
                            ContentService.GetContentService().AssetCreator.ShapeFromTexture(shapeFromTextureBox.SelectedItem.ToString(), float.Parse(customShapeScale.Value.ToString()), materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()), out previewTexture, out shapeVertices);
                        break;
                    default:
                         throw new Exception("Unknown Shape");
                        
                }
                if (shapeVertices != null && previewTexture != null)
                {
                    float? previousDensity = currentObject[0].Body.Density;
                    currentObject[0].Body.FixtureList.Clear();
                    FixtureFactory.AttachCompoundPolygon(EarclipDecomposer.ConvexPartition(shapeVertices), previousDensity == null ? 1f : (float)previousDensity, currentObject[0].Body);
                    currentObject[0].Sprite = new Sprite(previewTexture);
                    previewScreen.PreviewGameObject = currentObject[0];
                }
            }
        }

        /// <summary>
        /// Загружает custom-материал.
        /// </summary>
        private void LoadMaterial()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Load Material";

            fileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    string filename = Path.GetFileName(fileDialog.FileName).Split('.')[0];
                    string sourceFile = fileDialog.FileName;
                    string destFile = "Content\\" + ContentService.GetMaterial(Path.GetFileName(fileDialog.FileName));

                    File.Copy(sourceFile, destFile);
                    _assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(destFile));
                    materialBox.Items.Add(filename);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

        /// <summary>
        /// Загружает текстуру для создания формы.
        /// </summary>
        private void LoadShape()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.Title = "Load Shape";

            fileDialog.Filter = "Image Files (*.jpg;*.png)|*.jpg;*.png|" +
                                "All Files (*.*)|*.*";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    string filename = Path.GetFileName(fileDialog.FileName).Split('.')[0];
                    string sourceFile = fileDialog.FileName;
                    string destFile = "Content\\" + ContentService.GetShape(Path.GetFileName(fileDialog.FileName));

                    File.Copy(sourceFile, destFile);
                    _assetCreator.LoadShape(filename, ContentService.GetContentService().LoadTexture(destFile));
                    shapeFromTextureBox.Items.Add(filename);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

                

        /// <summary>
        /// Переключает видимость вкладки параметров фигуры в зависимости от типа фигуры.
        /// </summary>
        /// <param name="shapeType">Тип фигуры.</param>
        private void SwitchShapeParametersTab(ObjectType shapeType)
        {
            this.shapeParameters.Text = "Shape Parameters - " + shapeType.ToString();
            switch (shapeType)
            {
                case ObjectType.Arc:
                    this.shapeParametersControl.SelectedTab = this.arcTab;
                    break;
                case ObjectType.Capsule:
                    this.shapeParametersControl.SelectedTab = this.capsuleTab;
                    break;
                case ObjectType.Circle:
                    this.shapeParametersControl.SelectedTab = this.circleTab;
                    break;
                case ObjectType.CustomShape:
                    this.shapeParametersControl.SelectedTab = this.customShapeTab;
                    break;
                case ObjectType.Ellipse:
                    this.shapeParametersControl.SelectedTab = this.ellipseTab;
                    break;
                case ObjectType.Gear:
                    this.shapeParametersControl.SelectedTab = this.gearTab;
                    break;
                case ObjectType.Rectangle:
                    this.shapeParametersControl.SelectedTab = this.rectangleTab;
                    break;
                case ObjectType.RoundedRectangle:
                    this.shapeParametersControl.SelectedTab = this.roundedRectangleTab;
                    break;
            }
        }

        private bool CheckCapsuleParams(decimal height, decimal bottomRadius, decimal topRadius)
        {
            return !((height <= bottomRadius * 2) || (height <= topRadius * 2));
        }

        private bool CheckRoundedRectangleParams(decimal side, decimal radius)
        {
            return !(side < radius * 2);
        }

        #region Status
        private enum StatusType
        {
            Undefined,
            Ready,
            Error,
            Warning
        }

        private StatusType _status = StatusType.Undefined;

        private void ShowErrorStatus(Exception ex)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.Tomato;
            toolStripStatusLabel.Image = SystemIcons.Error.ToBitmap();
            toolStripStatusLabel.Text = String.Format("Error: {0} ({1}, source: {2}).", ex.Message, ex.GetType().Name, ex.Source);
            _status = StatusType.Error;
        }

        private void ShowReadyStatus()
        {
            if (_status != StatusType.Ready)
            {
                toolStripStatusLabel.BackColor = System.Drawing.Color.LimeGreen;
                toolStripStatusLabel.Text = "Ready.";
                toolStripStatusLabel.Image = null;
                _status = StatusType.Ready;
            }
        }

        private void ShowWarningStatus(string message)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.Orange;
            toolStripStatusLabel.Image = SystemIcons.Warning.ToBitmap();
            toolStripStatusLabel.Text = message;
            _status = StatusType.Warning;
        }
        #endregion
    }
}