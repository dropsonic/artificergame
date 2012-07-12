﻿using System;
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
            
        }

        string GetParent(string path, int nesting)
        {
            return nesting == 0 ? path : GetParent(Directory.GetParent(path).ToString(),--nesting);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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
            if (materialBox.SelectedItem != null && colorBox.SelectedItem != null && shapeBox.SelectedItem!=null)
                previewScreen1.SetPreview((ObjectType)Enum.Parse(typeof(ObjectType), shapeBox.SelectedItem.ToString()), materialBox.SelectedItem.ToString(), colorDictionary[colorBox.SelectedItem.ToString()],float.Parse(materialScale.Text));
            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                previewScreen1.FrameTimer.Enabled = false;
                levelScreen.FrameTimer.Enabled = false;
                objectScreen.FrameTimer.Enabled = false;
            }
            if (WindowState == FormWindowState.Normal || WindowState == FormWindowState.Maximized)
            {
                previewScreen1.FrameTimer.Enabled = true;
                levelScreen.FrameTimer.Enabled = true;
                objectScreen.FrameTimer.Enabled = true;
            }
        }
    }
}
