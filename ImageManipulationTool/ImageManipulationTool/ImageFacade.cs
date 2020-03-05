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
    class ImageFacade
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
        getImageInstance = _imageMemory.getImage;
            loadInstance = _imageMemory.load;
        }

        public Image NextImage(int Width, int Height)
        {
            Image image = _drawImage.NextImage(Width, Height, loadInstance, getImageInstance);

            return image;
        }

        public Image PrevImage(int Width, int Height)
        {
            Image image = _drawImage.PrevImage(Width, Height, loadInstance, getImageInstance);

            return image;
        }

        public Image LoadImage(int Width, int Height)
        {
            _collectImages.OpenFiles(loadInstance);

            Image image = _drawImage.LoadImage(Width, Height, loadInstance, getImageInstance);

            return image;
        }

    }
}
