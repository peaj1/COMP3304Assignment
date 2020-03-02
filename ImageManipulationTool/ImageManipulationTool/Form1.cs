using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;
using System.Diagnostics;

namespace ImageManipulationTool
{
    public partial class Form1 : Form
    {
        IModel _imageMemory;
        int currentImage;
        IList<String> pathfilenames;

        public Form1()
        {
            _imageMemory = new ImageMemory();
            InitializeComponent();
            currentImage = 0;
            pathfilenames = new List<String>();

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if(currentImage == pathfilenames.Count - 1)
            {
                currentImage = 0;
            } else
            {
                currentImage++;
            }

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Image image = _imageMemory.getImage(pathfilenames[currentImage], width,height);

            pictureBox1.Image = image;

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            if(currentImage == 0)
            {
                currentImage = pathfilenames.Count - 1;
            }
            else
            {
                currentImage--;
            }

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Image image = _imageMemory.getImage(pathfilenames[currentImage], width, height);

            pictureBox1.Image = image;

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;

            if(file.ShowDialog() == DialogResult.OK)
            {
                foreach (String filePath in file.FileNames)
                {
                    pathfilenames.Add(filePath);
                }
            }

            //_imageMemory.load(pathfilenames);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Image image = _imageMemory.getImage(pathfilenames[currentImage], width, height);

            pictureBox1.Image = image;
        }
    }
}
