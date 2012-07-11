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
    public partial class MainForm : Form
    {
        ContentBuilder builder;
        
        public MainForm()
        {
            InitializeComponent();
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

             // Get all of the public static properties
            System.Reflection.PropertyInfo[] properties = typeof(Color).GetProperties(System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.Static);
            foreach(System.Reflection.PropertyInfo propertyInfo in properties)
            {
                // Check to make sure the property has a get method, and returns type "Color"
                if (propertyInfo.GetGetMethod() != null && propertyInfo.PropertyType == typeof(Color))
                { 
                    colorBox.Items.Add(propertyInfo.Name);
                }
            }
        }

        private void HandlePreview(object sender, EventArgs e)
        {
            previewScreen.SetPreview(ObjectType.Rectangle, materialBox.SelectedItem.ToString(), Color.White);
        }
    }
}
