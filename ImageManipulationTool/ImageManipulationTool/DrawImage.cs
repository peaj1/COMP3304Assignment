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
    /// </summary>
    class DrawImage :IDrawImage
    {

        
        //DECLARE _currentImage variable
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
        public Image NextImage(int frameWidth, int frameHeight, loadDelegate loadInstance, getImageDelegate getImageParam)
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
                    _currentImage = 0;
                }
                else
                {
                    _currentImage++;
                }

                //pass list position and frame dimensions of the next image to getImageDelegate
                image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);
            }
            else
            {
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
        public Image PrevImage(int frameWidth, int frameHeight, loadDelegate load, getImageDelegate getImageParam)
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
                    _currentImage = tempList.Count - 1;
                }
                else
                {
                    _currentImage--;
                }
                //pass list position and frame dimensions of prev image to getImageParam delegate
                image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);
            }
            else
            {
                image = new Bitmap(10, 10);
            }

            //returns image to where function was called
            return image;
        }
    }
}
