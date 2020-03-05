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
    /// <summary>
    /// Class for the form, displays each of the controls onto the form and places images onto the form
    /// </summary>
    public partial class Form1 : Form
    {

        //DECLARE _imageFacade as type interface IImageFacade
        IImageFacade _imageFacade;

        /// <summary>
        /// Main method of Form1 class which initialises the other class instances and the delegate variables
        /// </summary>
        public Form1()
        {
 
            //INITIALISE _imageFacade as ImageFacade class
            _imageFacade = new ImageFacade();

          
            //RUN InitializeComponent method for User Interface
            InitializeComponent();
        }

        /// <summary>
        /// Runs when the next button on the form is clicked
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            
            //change picture box image to Image passed from ImageFacade class
            pictureBox1.Image = _imageFacade.NextImage(pictureBox1.Width, pictureBox1.Height);

        }

        /// <summary>
        /// Runs when previous button on the form is clicked
        /// </summary>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {

           //change picture box image to Image passed from ImageFacade class
            pictureBox1.Image = _imageFacade.PrevImage(pictureBox1.Width, pictureBox1.Height);

        }
        /// <summary>
        /// Runs when the load button on the form is clicked
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            //load in picures and change picture box image to image passed from ImageFacade class
            pictureBox1.Image = _imageFacade.LoadImage(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
