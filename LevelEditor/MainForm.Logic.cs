using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FarseerTools;
using LevelEditor;
using Color = Microsoft.Xna.Framework.Color;
using System.Drawing;

namespace LevelEditor
{
    public partial class MainForm : Form
    {
        private void UpdatePreview()
        {
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem != null)
            {
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
                {
                    case ObjectType.Arc:
                        previewScreen.SetArcPreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(arcDegrees.Value.ToString()), int.Parse(arcSides.Value.ToString()), float.Parse(arcRadius.Value.ToString()));
                        break;
                    case ObjectType.Capsule:
                        previewScreen.SetCapsulePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(capsuleHeight.Value.ToString()), float.Parse(capsuleBottomRadius.Value.ToString()), int.Parse(capsuleBottomEdges.Value.ToString()), float.Parse(capsuleTopRadius.Value.ToString()), int.Parse(capsuleTopEdges.Value.ToString()));
                        break;
                    case ObjectType.Circle:
                        previewScreen.SetCirclePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(circleRadius.Value.ToString()));
                        break;
                    case ObjectType.CustomShape:

                        break;
                    case ObjectType.Ellipse:
                        previewScreen.SetEllipsePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(ellipseXRadius.Value.ToString()), float.Parse(ellipseYRadius.Value.ToString()), int.Parse(ellipseNumberOfEdges.Value.ToString()));
                        break;
                    case ObjectType.Gear:
                        previewScreen.SetGearPreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(gearRadius.Value.ToString()), int.Parse(gearNumberOfTeeth.Value.ToString()), float.Parse(gearTipPercentage.Value.ToString()), float.Parse(gearToothHeight.Value.ToString()));
                        break;
                    case ObjectType.Rectangle:
                        previewScreen.SetRectanglePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(rectangleWidth.Value.ToString()), float.Parse(rectangleHeight.Value.ToString()));
                        break;
                    case ObjectType.RoundedRectangle:
                        previewScreen.SetRoundedRectanglePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()], float.Parse(materialScale.Value.ToString()),
                            float.Parse(roundedRectangleWidth.Value.ToString()), float.Parse(roundedRectangleHeight.Value.ToString()), float.Parse(roundedRectangleXRadius.Value.ToString()), float.Parse(roundedRectangleYRadius.Value.ToString()), int.Parse(roundedRectangleSegments.Value.ToString()));
                        break;
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
                    assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(destFile));
                    materialBox.Items.Add(filename);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

        #region Status
        private enum StatusType
        {
            Undefined,
            Ready,
            Error
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
        #endregion
    }
}
