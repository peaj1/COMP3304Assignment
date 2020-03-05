using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{
    class DrawImage:IDrawImage
    {
        int _currentImage;

        public DrawImage()
        {
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
            //DECLARE list to read the values of the position of the images
            IList<String> tempList = new List<String>();

            //Populate the list with the image references
            tempList = loadInstance(tempList);

            //If current image is last in list, reset image displayed to the first in the list
            if (_currentImage == tempList.Count - 1)
            {
                _currentImage = 0;
            }
            else
            {
                //add one onto current list item value
                _currentImage++;
            }

            //pass list position and frame dimensions of the next image to getImageDelegate
            Image image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);

            //return image to form class
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
            //DECLARE list to read value of position of the images
            IList<String> tempList = new List<String>();

            //populate list with image reference
            tempList = load(tempList);

            //if current image is first in list, reset image displayed to last in list
            if (_currentImage == 0)
            {
                _currentImage = tempList.Count - 1;
            }
            else
            {
                //minus one from current list item to display previous item in list
                _currentImage--;
            }
            //pass list position and frame dimensions of prev image to getImageDelegate
            Image image = getImageParam(tempList[_currentImage], frameWidth, frameHeight);

            //returns image to form class
            return image;
        }
    }
}
