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
        ImageMemory _imageMemory;
        String path;
        public Form1()
        {
            _imageMemory = new ImageMemory();
            InitializeComponent();

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog() ==DialogResult.OK)
            {
                path = file.FileName;
            }
            var image = _imageMemory.loadImage(path, new Size(150,150));

            pictureBox1.Image = image;
        }
    }
}
