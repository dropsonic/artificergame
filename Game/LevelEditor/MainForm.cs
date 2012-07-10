using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace LevelEditor
{
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
            builder.AddTextures(Directory.GetFiles(GetParent(Environment.CurrentDirectory, 2) + "\\Content (Runtime Build)\\Textures\\Materials"));
            string buildError = builder.Build();

            if (!string.IsNullOrEmpty(buildError))
            {
                MessageBox.Show(buildError, "Error");
            }

            foreach (string material in Directory.GetFiles(Environment.CurrentDirectory+"\\Content\\Textures\\Materials"))
            {
                materialBox.Items.Add(Path.GetFileName(material).Split('.')[0]);
            }

            

        }
    }
}
