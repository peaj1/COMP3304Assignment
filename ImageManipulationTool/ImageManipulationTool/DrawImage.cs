using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{

    /// <summary>
    /// CLASS to draw the image, passes image values to form class, implements IDrawImage interface
    /// Authors: Jude Mallett & Jon Pearson
    /// </summary>
    class DrawImage :IDrawImage
    {

        
        //DECLARE _currentImage variable of type int
        int _currentImage;

        /// <summary>
        /// Main method of Draw image which initialises _currentImage to 0 when an instance of DrawImage is created
        /// </summary>
        public DrawImage()
        {
            //Initialise _currentImage variable to 0
            _currentImage = 0;
        }

        ///<summary>
        ///Display next image stored within list when user presses the next image button
        ///</summary>
        ///<returns>key for the next image in the list and passes this to the form class</returns>
        ///<param name="frameWidth">value for the width of the frame the image is being stored in</param>
        ///<param name="frameHeight">value for the height of the frame the image is being stored in</param>
        ///<param name="loadInstance">Delegate to load function in imageMemory class</param>
        ///<param name="getImageParam">send values for image to be displayed to the getImageDelegate</param>
        public Image NextImage(int frameWidth, int frameHeight, LoadDelegate loadInstance, GetImageDelegate getImageParam)
        {
            //DECLARE image of type Image to be populated and returned
            Image image;

            //DECLARE list to read the values of the position of the images
            IList<String> tempList = new List<String>();

            //populate tempList with the List in ImageMemory
            tempList = loadInstance(tempList);

            //if the retrieved list is not empty run this code
            //else if the retrieved list is empty create an empty image to be returned
            if (tempList.Count > 0)
            {
                //If current image is last in list, reset image displayed to the first in the list
                //else increase current image by one
                if (_currentImage == tempList.Count - 1)
                {
                    //set _currentImage to 0
                    _currentImage = 0;
                }
                else
                {
                    //add one to _currentImage
                    _currentImage++;
                }

                //pass list position and frame dimensions of the next image to getImageDelegate
                image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);
            }
            else
            {
                //set image to a new blank bitmap image
                image = new Bitmap(10,10);
            }

                //return image to where function was called
                return image;
        }

        ///<summary>
        ///Display previous image stored within list when user clicks previous image button
        ///</summary>
        ///<returns>key for previous image in list and passes this to the form class</returns>
        ///<param name="frameWidth">value for the width of the frame the image is being stored in</param>
        ///<param name="frameHeight">value for the height of the frame the image is being stored in</param>
        ///<param name="load">Delegate to load function in imageMemory class</param>
        ///<param name="getImageParam">send values for image to be displayed to the getImageDelegate</param>
        public Image PrevImage(int frameWidth, int frameHeight, LoadDelegate load, GetImageDelegate getImageParam)
        {
            //DECLARE image of type Image to be populated and returned
            Image image;
            
            //DECLARE list to read value of position of the images
            IList<String> tempList = new List<String>();

            //populate tempList with the List in ImageMemory
            tempList = load(tempList);

            //if the retrieved list is not empty run this code
            //else if the retrieved list is empty create an empty image to be returned
            if (tempList.Count > 0)
            {
                //if current image is first in list, reset image displayed to last in list
                //else increase current image by one
                if (_currentImage == 0)
                {
                    //set _currentImage to the length of tempList
                    _currentImage = tempList.Count - 1;
                }
                else
                {
                    //minus one from _currentImage
                    _currentImage--;
                }
                //pass list position and frame dimensions of prev image to getImageParam delegate
                image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);
            }
            else
            {
                //set image variable to be blank bitmap image
                image = new Bitmap(10, 10);
            }

            //returns image to where function was called
            return image;
        }


        /// <summary>
        /// Loads the image into the image variable from the image list passed from ImageMemory and returns the image
        /// </summary>
        /// <param name="frameWidth">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="frameHeight">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="load">Delegate for list of images stored</param>
        /// <param name="getImageParam">getImageDelegate for info about image being displayed</param>
        /// <returns>image as an Image object</returns>
        public Image LoadImage(int frameWidth, int frameHeight, LoadDelegate load, GetImageDelegate getImageParam)
        {
            //INSTANTIATE tempList by making it a new List<String>
            IList<String> tempList = new List<String>();

            //populate tempList with the List in ImageMemory
            tempList = load(tempList);

            //Set image variable to the getImageParam method and pass the list and frame width and height
            Image image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);

            //return image as type Image
            return image;
        }
    }
}
