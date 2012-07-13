using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FarseerTools;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace LevelEditor
{
    public partial class MainForm : Form
    {
        AssetCreator assetCreator;
        readonly Dictionary<string, Color> colorDictionary = typeof(Color).GetProperties(BindingFlags.Public | BindingFlags.Static).Where((prop) => prop.PropertyType == typeof(Color))
                .ToDictionary(prop => prop.Name, prop => (Color)prop.GetValue(null, null));
        
        public MainForm()
        {
            InitializeComponent();
            Initialize();

            BlendState state = new BlendState();
          }

        private void Initialize()
        {
            ConvertUnits.SetDisplayUnitToSimUnitRatio((float)levelScreen.Size.Height / 100);
            //
            //set component parameters
            //
            this.shapeParametersControl.SelectedTab = this.emptyTab;
            levelScreen.message = "Level";
            objectScreen.message = "GameObject";

            ShowReadyStatus();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            //
            //load assetCreator Materials
            //
            assetCreator = ContentService.GetContentService().AssetCreator;
            foreach (string material in Directory.GetFiles("Content\\" + ContentService.GetMaterial()))
            {
                string filename = System.IO.Path.GetFileName(material).Split('.')[0];
                assetCreator.LoadMaterial(filename, ContentService.GetContentService().LoadTexture(material));
                materialBox.Items.Add(filename);
            }

            foreach (ObjectType obj in Enum.GetValues(typeof(ObjectType)))
            {
                shapeBox.Items.Add(obj);
            }
            
            foreach (string colorName in colorDictionary.Keys)
            {
                colorBox.Items.Add(colorName);
            }
        }

        string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(),--nesting);
        }

        private void ShapeParameterSwitch(object sender, EventArgs e)
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

            shapeBox.Focus();

            HandlePreview(sender,e);
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            try 
            { 
                UpdatePreview();
                ShowReadyStatus();
            }
            catch (Exception ex) 
            { 
                ShowErrorStatus(ex);
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

        private void loadMaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMaterial();
                ShowReadyStatus();
            }
            catch (Exception ex)
            {
                ShowErrorStatus(ex);
            }
        }
    }
}
