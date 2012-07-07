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

namespace LevelEditor
{
    public partial class MainForm : Form
    {
        ContentBuilder builder;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            builder = new ContentBuilder(ContentManagerService.GetContentPath());
            builder.Add(Environment.CurrentDirectory+"\\q3.jpg" , "texture", null, "TextureProcessor");
            // Build this new model data.
            string buildError = builder.Build();

            if (string.IsNullOrEmpty(buildError))
            {
                // If the build succeeded, use the ContentManager to
                // load the temporary .xnb file that we just created.
                xnaScreen.texture = ContentManagerService.GetContentManagerService().Content.Load<Texture2D>("texture");
            }
            else
            {
                // If the build failed, display an error message.
                MessageBox.Show(buildError, "Error");
            }
        }

    }
}
