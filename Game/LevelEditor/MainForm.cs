using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using FarseerTools;

namespace LevelEditor
{
    using Color = Microsoft.Xna.Framework.Color;
    using System.Reflection;
    public partial class MainForm : Form
    {
        ContentBuilder builder;
        readonly Dictionary<string, Color> colorDictionary = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static).Where((prop) => prop.PropertyType == typeof(Color))
                .ToDictionary(prop => prop.Name, prop => (Color)prop.GetValue(null, null));
        
        public MainForm()
        {
            InitializeComponent();
            this.materialScale.Increment = 0.1M;
            this.shapeParametersControl.SelectedTab = this.emptyTab;
            
        }

        string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(),--nesting);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / 100);
            
            builder = new ContentBuilder(ContentService.GetContentPath());
            //source for textures
            builder.AddMaterials(Directory.GetFiles(GetParent(Environment.CurrentDirectory, 2) + "\\Content (Runtime Build)\\Textures\\Materials"));
            string buildError = builder.Build();

            if (!string.IsNullOrEmpty(buildError))
            {
                MessageBox.Show(buildError, "Error");
            }
            
            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                materialBox.Items.Add(Path.GetFileName(material).Split('.')[0]);
            }

            foreach (ObjectType obj in Enum.GetValues(typeof(ObjectType)))
            {
                shapeBox.Items.Add(obj);
            }

            foreach (string colorName in colorDictionary.Keys)
            {
                colorBox.Items.Add(colorName);
            }

            levelScreen.message = "Level";
            objectScreen.message = "GameObject";
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            
            if (sender == shapeBox)
            {
                this.shapeParameters.Text = "Shape Parameters - " + shapeBox.SelectedItem.ToString();
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
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
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem!=null)
            {
                switch ((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()))
                {
                    case ObjectType.Arc:
                        previewScreen.SetArcPreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(arcDegrees.Value.ToString()),int.Parse(arcSides.Value.ToString()),float.Parse(arcRadius.Value.ToString()));
                        break;
                    case ObjectType.Capsule:
                        previewScreen.SetCapsulePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(capsuleHeight.Value.ToString()), float.Parse(capsuleBottomRadius.Value.ToString()), int.Parse(capsuleBottomEdges.Value.ToString()), float.Parse(capsuleTopRadius.Value.ToString()), int.Parse(capsuleTopEdges.Value.ToString()));
                        break;
                    case ObjectType.Circle:
                        previewScreen.SetCirclePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(circleRadius.Value.ToString()));
                        break;
                    case ObjectType.CustomShape:

                        break;
                    case ObjectType.Ellipse:
                        previewScreen.SetEllipsePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(ellipseXRadius.Value.ToString()),float.Parse(ellipseYRadius.Value.ToString()),int.Parse(ellipseNumberOfEdges.Value.ToString()));
                        break;
                    case ObjectType.Gear:
                        previewScreen.SetGearPreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(gearRadius.Value.ToString()),int.Parse(gearNumberOfTeeth.Value.ToString()),float.Parse(gearTipPercentage.Value.ToString()),float.Parse(gearToothHeight.Value.ToString()));
                        break;
                    case ObjectType.Rectangle:
                        previewScreen.SetRectanglePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(rectangleWidth.Value.ToString()),float.Parse(rectangleHeight.Value.ToString()));
                        break;
                    case ObjectType.RoundedRectangle:
                        previewScreen.SetRoundedRectanglePreview(materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Value.ToString()),
                            float.Parse(roundedRectangleWidth.Value.ToString()),float.Parse(roundedRectangleHeight.Value.ToString()),float.Parse(roundedRectangleXRadius.Value.ToString()),float.Parse(roundedRectangleYRadius.Value.ToString()),int.Parse(roundedRectangleSegments.Value.ToString()));
                        break;
                 
                }
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                previewScreen.FrameTimer.Enabled = false;
                levelScreen.FrameTimer.Enabled = false;
                objectScreen.FrameTimer.Enabled = false;
            }
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                previewScreen.FrameTimer.Enabled = true;
                levelScreen.FrameTimer.Enabled = true;
                objectScreen.FrameTimer.Enabled = true;
            }
        }


    }
}
