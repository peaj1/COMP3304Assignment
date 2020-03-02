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
        getImageDelegate _getImageInstance;
        IDrawImage _drawImage;
        IList<String> pathfilenames;
        

        public Form1()
        {
            _imageMemory = new ImageMemory();
            _getImageInstance = _imageMemory.getImage;
            _drawImage = new DrawImage();
            pathfilenames = new List<String>();


            InitializeComponent();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Image image = _drawImage.NextImage(pictureBox1.Width, pictureBox1.Height, pathfilenames, _getImageInstance);
            pictureBox1.Image = image;

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            Image image = _drawImage.PrevImage(pictureBox1.Width, pictureBox1.Height, pathfilenames, _getImageInstance);
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
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
