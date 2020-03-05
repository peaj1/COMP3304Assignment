using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;
using System.Diagnostics;

namespace ImageManipulationTool
{
    /// <summary>
    /// Facade for the program, to hide complex functionality and provide a
    ///  simple interface which the user can use to access the system, implements the IImageFacade interface
    ///  Authors: Jude Mallett & Jon Pearson
    /// </summary>
    class ImageFacade : IImageFacade
    {

        //DECLARE _imageMemory of type IModel
        //DECLARE _drawImage of type IDrawImage
        //DECLARE _CollectImages of type ICollectImages
        IModel _imageMemory;
        IDrawImage _drawImage;
        ICollectImages _collectImages;

        //DECLARE getImageInstance Delegate of type getImageDelegate
        //DECLARE loadInstance Delegate of type loadDelegate
        GetImageDelegate _getImageInstance;
        LoadDelegate _loadInstance;


        /// <summary>
        /// Main Method for the ImageFacade class which implements the IImageFacade interface
        /// Run whenever the form buttons are clicked
        /// used to step through each image in the list
        /// </summary>
        public ImageFacade()
        {
            //INITIALISE _imageMemory as ImageMemory class
            //INITIALISE _drawImage as DrawImage class
            //INITIALISE _collectImages as CollectImages class
            _imageMemory = new ImageMemory();
            _drawImage = new DrawImage();
            _collectImages = new CollectImages();

        //INITIALISE getImageInstance as _imageMemory.getImage method
        //INITIALISE loadInstance as _imageMemory.load method
        _getImageInstance = _imageMemory.GetImage;
            _loadInstance = _imageMemory.Load;
        }

        /// <summary>
        /// Gets value for next image stored in the list and passes image to the form
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>the image to the form</returns>
        public Image NextImage(int width, int height)
        {
            //DECLARE image of type Image & set image variable to the image object returned from the _drawImage class
            Image image = _drawImage.NextImage(width, height, _loadInstance, _getImageInstance);

            //return object of type Image to place the method was called from
            return image;
        }

        /// <summary>
        /// Gets value for previous image stored in the list and passes image to the form
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>the image to the form</returns>
        public Image PrevImage(int width, int height)
        {
            //DECLARE image of type Image & set image variable to the image object returned from the _drawImage class
            Image image = _drawImage.PrevImage(width, height, _loadInstance, _getImageInstance);

            //return object of type Image to place the method was called from
            return image;
        }

        /// <summary>
        /// calls Open Files function and passes the image to the form
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>the image to the form</returns>
        public Image LoadImage(int width, int height)
        {   
            //Calls the OpenFiles method from the _collectImages class
            _collectImages.OpenFiles(_loadInstance);

            //DECLARE image of type Image & set image variable to the image object returned from the _drawImage class
            Image image = _drawImage.LoadImage(width, height, _loadInstance, _getImageInstance);

            //return object of type Image to place the method was called from
            return image;
        }

    }
}
