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
        IDrawImage _drawImage;
        CollectImages _collectImages;

        getImageDelegate getImageInstance;
        loadDelegate loadInstance;
        fetchListDelegate fetchListInstance;


        public Form1()
        {
            _imageMemory = new ImageMemory();
            _drawImage = new DrawImage();
            _collectImages = new CollectImages();

            getImageInstance = _imageMemory.getImage;
            loadInstance = _imageMemory.load;
            fetchListInstance = _imageMemory.fetchPathList;



            InitializeComponent();
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            Image image = _drawImage.NextImage(pictureBox1.Width, pictureBox1.Height, fetchListInstance, getImageInstance);
            pictureBox1.Image = image;

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            Image image = _drawImage.PrevImage(pictureBox1.Width, pictureBox1.Height, fetchListInstance, getImageInstance);
            pictureBox1.Image = image;

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            _collectImages.OpenFiles(loadInstance);
        }
    }
}
