using System;
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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LevelEditor.Helpers;

namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;
    using Path = System.IO.Path;
    using FarseerPhysics.Dynamics.Joints;

    public partial class MainForm : Form
    {
        enum MouseToolState
        {
            Default, PlaceObject, EditPreviewObject, PlaceJoint, EditJoint, SelectObjectPart, SelectObject, MouseJoint
        }

        enum MouseEvents
        {
            Click,Up,Down,Move
        }
        
   
        private void FindPreSimulationObject(PropertyGrid grid)
        {
            if (grid.SelectedObject != null && grid.SelectedObject.GetType() == typeof(Body))
            {
                propertyGrid.SelectedObject = CommonHelpers.FindBody(((Body)propertyGrid.SelectedObject).Position,_objectLevelManager.GameLevel.World);
            }
            //здесь будут джоинт, геймобжекты, геймобжектпарты
        }


        private void CreatePreview()
        {
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem != null)
            {
                Vertices shapeVertices = null;
                Texture2D previewTexture = null;
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
                {
                    case ObjectType.Arc:
                        shapeVertices = PolygonTools.CreateArc(MathHelper.ToRadians(float.Parse(arcDegrees.Value.ToString())), int.Parse(arcSides.Value.ToString()), float.Parse(arcRadius.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Capsule:
                        shapeVertices = PolygonTools.CreateCapsule(float.Parse(capsuleHeight.Value.ToString()), float.Parse(capsuleBottomRadius.Value.ToString()), int.Parse(capsuleBottomEdges.Value.ToString()), float.Parse(capsuleTopRadius.Value.ToString()), int.Parse(capsuleTopEdges.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Gear:
                        shapeVertices = PolygonTools.CreateGear(float.Parse(gearRadius.Value.ToString()), int.Parse(gearNumberOfTeeth.Value.ToString()), float.Parse(gearTipPercentage.Value.ToString()), float.Parse(gearToothHeight.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Rectangle:
                        shapeVertices = PolygonTools.CreateRectangle(float.Parse(rectangleWidth.Value.ToString()), float.Parse(rectangleHeight.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.RoundedRectangle:
                        shapeVertices = PolygonTools.CreateRoundedRectangle(float.Parse(roundedRectangleWidth.Value.ToString()), float.Parse(roundedRectangleHeight.Value.ToString()), float.Parse(roundedRectangleXRadius.Value.ToString()), float.Parse(roundedRectangleYRadius.Value.ToString()), int.Parse(roundedRectangleSegments.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Ellipse:
                        shapeVertices = PolygonTools.CreateEllipse(float.Parse(ellipseXRadius.Value.ToString()), float.Parse(ellipseYRadius.Value.ToString()), int.Parse(ellipseNumberOfEdges.Value.ToString()));
                        previewTexture = ContentService.GetContentService().AssetCreator.EllipseTexture(float.Parse(ellipseXRadius.Value.ToString()), float.Parse(ellipseYRadius.Value.ToString()), materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.Circle:
                        shapeVertices = PolygonTools.CreateCircle(float.Parse(circleRadius.Value.ToString()), AssetCreator.CircleSegments);
                        previewTexture = ContentService.GetContentService().AssetCreator.CircleTexture(float.Parse(circleRadius.Value.ToString()), materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()));
                        break;
                    case ObjectType.CustomShape:
                        if (shapeFromTextureBox.SelectedItem == null) break;
                        if (useOriginalTextureCheck.Checked)
                            ContentService.GetContentService().AssetCreator.ShapeFromTexture(shapeFromTextureBox.SelectedItem.ToString(), float.Parse(customShapeScale.Value.ToString()), _colorDictionary[colorBox.SelectedItem.ToString()], out previewTexture, out shapeVertices);
                        else
                            ContentService.GetContentService().AssetCreator.ShapeFromTexture(shapeFromTextureBox.SelectedItem.ToString(), float.Parse(customShapeScale.Value.ToString()), materialBox.SelectedItem.ToString(), _colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()), out previewTexture, out shapeVertices);
                        break;
                    default:
                         throw new Exception("Unknown Shape");
                        
                }
                if (shapeVertices != null && previewTexture != null)
                {
                    float? previousDensity = _objectLevelManager.PreviewObject[0].Body.Density;
                    _objectLevelManager.PreviewObject[0].Body.FixtureList.Clear();
                    FixtureFactory.AttachCompoundPolygon(EarclipDecomposer.ConvexPartition(shapeVertices), previousDensity == null ? 1f : (float)previousDensity, _objectLevelManager.PreviewObject[0].Body);
                    _objectLevelManager.PreviewObject[0].Sprite = new Sprite(previewTexture);
                    previewScreen.PreviewGameObject = _objectLevelManager.PreviewObject[0];
                    
                    editCurrentObjectAction.Checked = true;
                    SetMouseToolButtonsState(editCurrentObjectAction);
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

        private void ChangeMouseToolState()
        {
            if (selectObjectPartAction.Checked)
            {
                _levelScreenCursor = Cursors.Hand;
                _mouseToolState = MouseToolState.SelectObjectPart;
            }
            else if (selectObjectAction.Checked)
            {
                _levelScreenCursor = Cursors.Hand;
                _mouseToolState = MouseToolState.SelectObject;
            }
            else if (addPreviewObjectAction.Checked)
            {
                _levelScreenCursor = Cursors.Cross;
                _mouseToolState = MouseToolState.PlaceObject;
            }
            else if (useMouseJointAction.Checked)
            {
                _levelScreenCursor = Cursors.Cross;
                _mouseToolState = MouseToolState.MouseJoint;
            }
            else if (editCurrentObjectAction.Checked)
            {
                _levelScreenCursor = Cursors.Arrow;
                _mouseToolState = MouseToolState.EditPreviewObject;
            }
            else if (editJointAction.Checked)
            {
                _levelScreenCursor = Cursors.Arrow;
                _mouseToolState = MouseToolState.EditJoint;
            }
            else if (addNewJointAction.Checked)
            {
                _levelScreenCursor = Cursors.Cross;
                _mouseToolState = MouseToolState.PlaceJoint;
            }
            else
            {
                _levelScreenCursor = Cursors.Arrow;
                _mouseToolState = MouseToolState.Default;
            }
        }

        private void SetMouseToolButtonsState(Crad.Windows.Forms.Actions.Action toolButton)
        {
            bool tempCheck = toolButton.Checked;
            editJointAction.Checked = addNewJointAction.Checked = editCurrentObjectAction.Checked = selectObjectPartAction.Checked = selectObjectAction.Checked = addPreviewObjectAction.Checked = useMouseJointAction.Checked = false;
            toolButton.Checked = tempCheck;

            HandlePreviewDisplay();
            HandleJointCreation();
            ChangeMouseToolState();
        }


        private void HandleJointCreation()
        {
            if (addNewJointAction.Checked)
            {
                if (jointsBox.SelectedItem != null)
                {
                    _jointHelper = new JointCreationHelper((JointType)Enum.Parse(typeof(JointType), jointsBox.SelectedItem.ToString()), _objectLevelManager.GameLevel.World);
                    ShowTooltipStatus(_jointHelper.CurrentStateMessage);
                }
            }
            else
            {
                _jointHelper = null;
                ShowReadyStatus();
            }
        }

        private void HandlePreviewDisplay()
        {
            if (addPreviewObjectAction.Checked)
            {
                if (_objectLevelManager.PreviewObject[0].Sprite.Texture != null)
                {
                    levelScreen.PreviewGameObject = _objectLevelManager.PreviewObject;
                    //levelScreen.DrawCurrentGameObject = addPreviewObjectAction.Checked;
                }
                else
                {
                    addPreviewObjectAction.Checked = false;
                    ShowWarningStatus("Необходимо установить текстуру.");
                }
            }
            else
            {
                levelScreen.PreviewGameObject = null;
            }
            if (editCurrentObjectAction.Checked||addPreviewObjectAction.Checked)
            {
                propertyGrid.SelectedObject = _objectLevelManager.PreviewObject[0].Body;
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

        #region Load Dialogs
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
        #endregion

        #region Status
        private enum StatusType
        {
            Undefined,
            Ready,
            Error,
            Warning,
            Simulation,
            Tooltip
        }

        private StatusType _status = StatusType.Undefined;

        private ImageList _statusImages = new ImageList();

        private void InitializeStatusStrip()
        {
            _statusImages.Images.Add(StatusType.Error.ToString(), SystemIcons.Error);
            _statusImages.Images.Add(StatusType.Warning.ToString(), SystemIcons.Warning);
            _statusImages.Images.Add(StatusType.Simulation.ToString(), LevelEditor.Properties.Resources.simulationStatusImage);
            _statusImages.Images.Add(StatusType.Tooltip.ToString(), SystemIcons.Information);
        }

        private void ShowErrorStatus(Exception ex)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.Tomato;
            toolStripStatusLabel.Image = _statusImages.Images[StatusType.Error.ToString()];//SystemIcons.Error.ToBitmap();
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

        /// <summary>
        /// Скрывает все ошибки и предупреждения и показывает текущий статус.
        /// </summary>
        private void ShowCurrentNormalStatus()
        {
            if (_objectLevelManager.Simulator.State == SimulationState.Simulation || _objectLevelManager.Simulator.State == SimulationState.Paused)
                ShowSimulationStatus();
            else
                ShowReadyStatus();
        }

        private void ShowSimulationStatus()
        {
            ShowSimulationStatus(_objectLevelManager.Simulator.SimulationSpeed, _objectLevelManager.Simulator.State);
        }

        private void ShowSimulationStatus(float simulationSpeed, SimulationState state)
        {
            simulationSpeedToolStripLabel.Text = String.Format("{0:0.00}x", simulationSpeed);

            if (state == SimulationState.Stopped)
                return;

            toolStripStatusLabel.BackColor = System.Drawing.Color.CornflowerBlue;
            toolStripStatusLabel.Image = null;
            if (state == SimulationState.Simulation)
                toolStripStatusLabel.Text = String.Format("Simulating ({0:0.##}x time)...", simulationSpeed);
            else
                toolStripStatusLabel.Text = String.Format("Simulation paused ({0:0.##}x time)...", simulationSpeed);

            toolStripStatusLabel.Image = _statusImages.Images[StatusType.Simulation.ToString()];
            _status = StatusType.Simulation;
        }

        private void ShowWarningStatus(string message)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.Orange;
            toolStripStatusLabel.Image = _statusImages.Images[StatusType.Warning.ToString()];
            toolStripStatusLabel.Text = message;
            _status = StatusType.Warning;
        }

        private void ShowTooltipStatus(string message)
        {
            toolStripStatusLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            toolStripStatusLabel.Image = _statusImages.Images[StatusType.Tooltip.ToString()];
            toolStripStatusLabel.Text = message;
            _status = StatusType.Tooltip;
        }
        #endregion
    }
}
