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
    using GameLogic;

    public partial class MainForm : Form
    {
        enum MouseToolState
        {
            Default, PlaceObject, EditPreviewObject, PlaceJoint, AttachFixture, SelectObjectPart, SelectObject, MouseJoint
        }

        enum MouseEvents
        {
            Click,Up,Down,Move
        }


        private void SwitchToSimulation()
        {
            if (propertyGrid.SelectedObject != null)
            {
                if (propertyGrid.SelectedObject.GetType() == typeof(Body))
                {
                    propertyGrid.SelectedObject = CommonHelpers.FindBody(((Body)propertyGrid.SelectedObject).Position, _objectLevelManager.GameLevel.World);
                }
                else if (propertyGrid.SelectedObject.GetType() == typeof(GameObject))
                {
                    propertyGrid.SelectedObject = CommonHelpers.FindGameObject(((GameObject)propertyGrid.SelectedObject)[0].Body.Position, _objectLevelManager.GameLevel);
                }
                else if (propertyGrid.SelectedObject.GetType() == typeof(GameObjectPart))
                {
                    propertyGrid.SelectedObject = CommonHelpers.FindGameObjectPart(((GameObjectPart)propertyGrid.SelectedObject).Body.Position, _objectLevelManager.GameLevel);
                }
                else if (propertyGrid.SelectedObject is Joint)
                {
                    /*
                    //находим индект нужного нам джоинта в списке
                    Joint selectedJoint = ((Joint)propertyGrid.SelectedObject);
                    JointEdge iterator = selectedJoint.BodyA.JointList;
                    int jointIndex = 0;
                    do
                    {
                       if (selectedJoint == iterator.Joint)
                            break;
                       jointIndex++;
                    } while ((iterator=iterator.Next)!=null);

                    //находим джоинт с найденным индексом в списке джоинтов нового боди
                    JointEdge newJointList = CommonHelpers.FindBody(selectedJoint.BodyA.Position, _objectLevelManager.GameLevel.World).JointList;
                    int index = 0;
                    do
                    {
                        if (jointIndex == index)
                        {
                            propertyGrid.SelectedObject = newJointList.Joint;
                            break;
                        }
                        index++;
                    } while ((newJointList = newJointList.Next) != null);
                     */
                    UpdateCreatedJointList();
                }

            }
        }

        private void UpdateCreatedJointList()
        {
            bool wasSelected = false;
            int selectedIndex = 0;
            if (createdJointsList.SelectedItem!=null)
            {
                wasSelected = true;
                selectedIndex= createdJointsList.SelectedIndex;
            }

            createdJointsList.Items.Clear();
            foreach (Joint joint in _objectLevelManager.GameLevel.Joints)
            {
                createdJointsList.Items.Insert(0, joint);
            }

            if (wasSelected)
                createdJointsList.SelectedIndex = selectedIndex;
        }


        private void CreatePreview()
        {
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem != null)
            {
                Dictionary<string,object> shapeParameters = new Dictionary<string,object>();
                shapeParameters.Add(ShapeParametersKeys.Material,materialBox.SelectedItem.ToString());
                shapeParameters.Add(ShapeParametersKeys.MaterialScale,float.Parse(materialScale.Value.ToString()));
                shapeParameters.Add(ShapeParametersKeys.Color, _colorDictionary[colorBox.SelectedItem.ToString()]);
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
                {
                    case ObjectType.Arc:
                        shapeParameters.Add(ShapeParametersKeys.ArcDegrees,float.Parse(arcDegrees.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.ArcRadius,float.Parse(arcRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.ArcSides,int.Parse(arcSides.Value.ToString()));
                        break;
                    case ObjectType.Capsule:
                        shapeParameters.Add(ShapeParametersKeys.CapsuleHeight,float.Parse(capsuleHeight.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CapsuleBottomRadius,float.Parse(capsuleBottomRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CapsuleBottomEdges,int.Parse(capsuleBottomEdges.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CapsuleTopRadius,float.Parse(capsuleTopRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CapsuleTopEdges,int.Parse(capsuleTopEdges.Value.ToString()));
                        break;
                    case ObjectType.Gear:
                        shapeParameters.Add(ShapeParametersKeys.GearRadius,float.Parse(gearRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.GearNumberOfTeeth,int.Parse(gearNumberOfTeeth.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.GearTipPercentage,float.Parse(gearTipPercentage.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.GearToothHeigt,float.Parse(gearToothHeight.Value.ToString()));
                        break;
                    case ObjectType.Rectangle:
                        shapeParameters.Add(ShapeParametersKeys.RectangleWidth,float.Parse(rectangleWidth.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.RectangleHeight,float.Parse(rectangleHeight.Value.ToString()));
                        break;
                    case ObjectType.RoundedRectangle:
                        shapeParameters.Add(ShapeParametersKeys.RoundedRectangleHeight,float.Parse(roundedRectangleWidth.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.RoundedRectangleWidth,float.Parse(roundedRectangleHeight.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.RoundedRectangleXRadius,float.Parse(roundedRectangleXRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.RoundedRectangleYRadius,float.Parse(roundedRectangleYRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.RoundedRectangleSegments,int.Parse(roundedRectangleSegments.Value.ToString()));
                        break;
                    case ObjectType.Ellipse:
                        shapeParameters.Add(ShapeParametersKeys.EllipseXRadius,float.Parse(ellipseXRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.EllipseYRadius,float.Parse(ellipseYRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.EllipseNumberOfEdges,int.Parse(ellipseNumberOfEdges.Value.ToString()));
                        break;
                    case ObjectType.Circle:
                        shapeParameters.Add(ShapeParametersKeys.CircleRadius,float.Parse(circleRadius.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CircleSegments,AssetCreator.CircleSegments);
                        break;
                    case ObjectType.CustomShape:
                        if (shapeFromTextureBox.SelectedItem == null) break;
                        shapeParameters.Add(ShapeParametersKeys.CustomObjectScale,float.Parse(customShapeScale.Value.ToString()));
                        shapeParameters.Add(ShapeParametersKeys.CustomObjectShape,shapeFromTextureBox.SelectedItem.ToString());
                        shapeParameters.Add(ShapeParametersKeys.CustomObjectUseOriginalTexture, useOriginalTextureCheck.Checked);
                        break;
                    default:
                         throw new Exception("Unknown Shape");
                        
                }

                Vertices shapeVertices;
                Texture2D previewTexture;
                TextureFromDictionary(shapeParameters,(ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()), out previewTexture, out shapeVertices);
                if (shapeVertices != null && previewTexture != null)
                {
                    float? previousDensity = _objectLevelManager.PreviewObject[0].Body.Density;

                    _objectLevelManager.PreviewObject[0].Body.FixtureList.Clear();

                    FixtureFactory.AttachCompoundPolygon(EarclipDecomposer.ConvexPartition(shapeVertices), 
                                                         previousDensity == null ? 1f : (float)previousDensity, 
                                                         _objectLevelManager.PreviewObject[0].Body);

                    _objectLevelManager.PreviewObject[0].Sprites[0] = new Sprite(previewTexture);

                    _objectLevelManager.PreviewVertices = shapeVertices;

                    previewScreen.PreviewGameObject = _objectLevelManager.PreviewObject[0];

                    
                    editCurrentObjectAction.Checked = true;
                    SetMouseToolButtonsState(editCurrentObjectAction);
                }
            }
        }

        class ShapeParametersKeys
        {
            public const string Material = "Material";
            public const string Color = "Color";
            public const string MaterialScale = "MaterialScale";

            public const string ArcDegrees = "ArcDegrees";
            public const string ArcSides = "ArSides";
            public const string ArcRadius = "ArcRadius";

            public const string CapsuleHeight = "CapsuleHeight";
            public const string CapsuleBottomRadius = "CapsuleBottomRadius";
            public const string CapsuleBottomEdges = "CapsuleBottomEdges";
            public const string CapsuleTopRadius = "CapsuleTopRadius";
            public const string CapsuleTopEdges = "CapsuleTopEdges";

            public const string GearRadius = "GearRadius";
            public const string GearNumberOfTeeth = "GearNumberOfTeeth";
            public const string GearTipPercentage = "GearTipPercentage";
            public const string GearToothHeigt = "GearToothHeigt";

            public const string RectangleHeight = "RectangleHeight";
            public const string RectangleWidth = "RectangleWidth";

            public const string RoundedRectangleWidth = "RoundedRectangleWidth";
            public const string RoundedRectangleHeight = "RoundedRectangleHeight";
            public const string RoundedRectangleXRadius = "RoundedRectangleXRadius";
            public const string RoundedRectangleYRadius = "RoundedRectangleYRadius";
            public const string RoundedRectangleSegments = "RoundedRectangleSegments";

            public const string EllipseXRadius = "EllipseXRadius";
            public const string EllipseYRadius = "EllipseYRadius";
            public const string EllipseNumberOfEdges = "EllipseNumberOfEdges";

            public const string CircleRadius = "CircleRadius";
            public const string CircleSegments = "CircleSegments";

            public const string CustomObjectShape = "CustomObjectShape";
            public const string CustomObjectScale = "CustomObjectScale";
            public const string CustomObjectUseOriginalTexture = "CustomObjectUseOriginalTexture";

        }

        private void TextureFromDictionary(Dictionary<string,object> shapeParam, ObjectType objectType, out Texture2D texture)
        {
            Vertices vert;
            TextureFromDictionary(shapeParam, objectType, out texture, out vert);
        }
        private void TextureFromDictionary(Dictionary<string,object> shapeParam, ObjectType objectType, out Texture2D texture, out Vertices shapeVertices)
        {
            shapeVertices = null;
            texture = null;
            switch (objectType)
            {
                case ObjectType.Arc:
                    shapeVertices = PolygonTools.CreateArc(MathHelper.ToRadians((float)shapeParam[ShapeParametersKeys.ArcDegrees]), (int)shapeParam[ShapeParametersKeys.ArcSides], (float)shapeParam[ShapeParametersKeys.ArcRadius]);
                    texture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.Capsule:
                    shapeVertices = PolygonTools.CreateCapsule((float)shapeParam[ShapeParametersKeys.CapsuleHeight], (float)shapeParam[ShapeParametersKeys.CapsuleBottomRadius], (int)shapeParam[ShapeParametersKeys.CapsuleBottomEdges], (float)shapeParam[ShapeParametersKeys.CapsuleTopRadius], (int)shapeParam[ShapeParametersKeys.CapsuleTopEdges]);
                    texture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.Gear:
                    shapeVertices = PolygonTools.CreateGear((float)shapeParam[ShapeParametersKeys.GearTipPercentage], (int)shapeParam[ShapeParametersKeys.GearNumberOfTeeth], (float)shapeParam[ShapeParametersKeys.GearTipPercentage], (float)shapeParam[ShapeParametersKeys.GearToothHeigt]);
                    texture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.Rectangle:
                    shapeVertices = PolygonTools.CreateRectangle((float)shapeParam[ShapeParametersKeys.RectangleWidth], (float)shapeParam[ShapeParametersKeys.RectangleHeight]);
                    texture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.RoundedRectangle:
                    shapeVertices = PolygonTools.CreateRoundedRectangle((float)shapeParam[ShapeParametersKeys.RoundedRectangleWidth], (float)shapeParam[ShapeParametersKeys.RoundedRectangleHeight], (float)shapeParam[ShapeParametersKeys.RoundedRectangleXRadius], (float)shapeParam[ShapeParametersKeys.RoundedRectangleYRadius], (int)shapeParam[ShapeParametersKeys.RoundedRectangleSegments]);
                    texture = ContentService.GetContentService().AssetCreator.TextureFromVertices(shapeVertices, (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.Ellipse:
                    shapeVertices = PolygonTools.CreateEllipse((float)shapeParam[ShapeParametersKeys.EllipseXRadius], (float)shapeParam[ShapeParametersKeys.EllipseYRadius], (int)shapeParam[ShapeParametersKeys.EllipseNumberOfEdges]);
                    texture = ContentService.GetContentService().AssetCreator.EllipseTexture((float)shapeParam[ShapeParametersKeys.EllipseXRadius], (float)shapeParam[ShapeParametersKeys.EllipseYRadius], (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.Circle:
                    shapeVertices = PolygonTools.CreateCircle((float)shapeParam[ShapeParametersKeys.CircleRadius], (int)shapeParam[ShapeParametersKeys.CircleSegments]);
                    texture = ContentService.GetContentService().AssetCreator.CircleTexture((float)shapeParam[ShapeParametersKeys.CircleRadius], (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale]);
                    break;
                case ObjectType.CustomShape:
                    if ((bool)shapeParam[ShapeParametersKeys.CustomObjectUseOriginalTexture])
                        ContentService.GetContentService().AssetCreator.ShapeFromTexture((string)shapeParam[ShapeParametersKeys.CustomObjectShape], (float)shapeParam[ShapeParametersKeys.CustomObjectScale], (Color)shapeParam[ShapeParametersKeys.Color], out texture, out shapeVertices);
                    else
                        ContentService.GetContentService().AssetCreator.ShapeFromTexture((string)shapeParam[ShapeParametersKeys.CustomObjectShape], (float)shapeParam[ShapeParametersKeys.CustomObjectScale], (string)shapeParam[ShapeParametersKeys.Material], (Color)shapeParam[ShapeParametersKeys.Color], (float)shapeParam[ShapeParametersKeys.MaterialScale], out texture, out shapeVertices);
                    break;
                default:
                    throw new Exception("Unknown Shape");
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
            else if (attachFixture.Checked)
            {
                _levelScreenCursor = Cursors.NoMove2D;
                _mouseToolState = MouseToolState.AttachFixture;
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
            attachFixture.Checked = addNewJointAction.Checked = editCurrentObjectAction.Checked = selectObjectPartAction.Checked = selectObjectAction.Checked = addPreviewObjectAction.Checked = useMouseJointAction.Checked = false;
            toolButton.Checked = tempCheck;
            //TODO: выделить нижестоящие handle функции в одну с деревом, чтобы статусы друг друга не перекрывали.
            ShowReadyStatus();
            HandlePreviewDisplay();
            HandleJointCreation();
            HandleFixtureAttachment();
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
            }
        }

        private void HandlePreviewDisplay()
        {
            if (addPreviewObjectAction.Checked)
            {
                if (_objectLevelManager.PreviewObject[0].Sprites[0].Texture != null)
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
                if(attachFixture.Checked && _attachmentHelper!=null && _attachmentHelper.ShowPreview)
                    levelScreen.PreviewGameObject = _objectLevelManager.PreviewObject;
                else
                    levelScreen.PreviewGameObject = null;
            }
            if (editCurrentObjectAction.Checked||addPreviewObjectAction.Checked)
            {
                propertyGrid.SelectedObject = _objectLevelManager.PreviewObject[0].Body;
            }
        }

        private void HandleFixtureAttachment()
        {
            if (attachFixture.Checked)
            {
                if (_attachmentHelper == null)
                {
                    if (_attachmentHelper == null)
                        _attachmentHelper = new FixtureAttachmentHelper(_objectLevelManager.PreviewVertices,_objectLevelManager.PreviewObject[0].Body, _objectLevelManager.GameLevel.World);
                    ShowTooltipStatus(_attachmentHelper.StatusMessage);
                }
            }
            else
            {
                _attachmentHelper = null;
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
