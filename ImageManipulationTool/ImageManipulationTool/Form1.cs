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
        //DECLARE _imageMemory of type IModel
        //DECLARE _drawImage of type IDrawImage
        //DECLARE _CollectImages of type ICollectImages
        IModel _imageMemory;
        IDrawImage _drawImage;
        ICollectImages _collectImages;

        //DECLARE getImageInstance Delegate of type getImageDelegate
        //DECLARE loadInstance Delegate of type loadDelegate
        getImageDelegate getImageInstance;
        loadDelegate loadInstance;

        ImageFacade _imageFacade;

        /// <summary>
        /// Main method of Form1 class which initialises the other class instances and the delegate variables
        /// </summary>
        public Form1()
        {
            //INITIALISE _imageMemory as ImageMemory class
            //INITIALISE _drawImage as DrawImage class
            //INITIALISE _collectImages as CollectImages class
            _imageMemory = new ImageMemory();
            _drawImage = new DrawImage();
            _collectImages = new CollectImages();
            _imageFacade = new ImageFacade();

            //INITIALISE getImageInstance as _imageMemory.getImage method
            //INITIALISE loadInstance as _imageMemory.load method
            getImageInstance = _imageMemory.getImage;
            loadInstance = _imageMemory.load;
          
            //RUN InitializeComponent method for User Interface
            InitializeComponent();
        }

        /// <summary>
        /// Runs when the next button on the form is clicked
        /// </summary>
        private void BtnNext_Click(object sender, EventArgs e)
        {
            //CREATE local variable called image of type Image
            //RUN PrevImage method in DrawImage class
            //PARAMETER width of picture box
            //PARAMETER height of picture box
            //PARAMETER getImageInstance delegate to ImageMemory.getImage method
            //make image equal the return of DrawImage.PrevImage method
           

            //change picture box image to local image variable
            pictureBox1.Image = _imageFacade.NextImage(pictureBox1.Width, pictureBox1.Height);

        }

        /// <summary>
        /// Runs when previous button on the form is clicked
        /// </summary>
        private void BtnPrevious_Click(object sender, EventArgs e)
        {
            //CREATE local variable called image of type Image
            //RUN PrevImage method in DrawImage class
            //PARAMETER width of picture box
            //PARAMETER height of picture box
            //PARAMETER getImageInstance delegate to ImageMemory.getImage method
            //make image equal the return of DrawImage.PrevImage method
            Image image = _drawImage.PrevImage(pictureBox1.Width, pictureBox1.Height, loadInstance, getImageInstance);

            //change picture box image to local image variable
            pictureBox1.Image = image;

        }
        /// <summary>
        /// Runs when the load button on the form is clicked
        /// </summary>
        private void BtnLoad_Click(object sender, EventArgs e)
        {
            //RUN OpenFiles method in CollectImages class
            //PARAMETER loadInstance delegate to ImageMemory.load method
            _collectImages.OpenFiles(loadInstance);
        }
    }
}
