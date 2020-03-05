using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulationTool
{
    /// <summary>
    /// Interface to allow access to the NextImage, PrevImage and LoadImage methods in the ImageFacade class
    /// </summary>
    interface IImageFacade
    {
        /// <summary>
        /// Displays the next image stored in the list
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>Next image in the list</returns>
        Image NextImage(int width, int height);

        /// <summary>
        /// Displays the previous image stored in the list
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>Previous image in the list</returns>
        Image PrevImage(int width, int height);

        /// <summary>
        /// loads images into a list as strings and displays the first image in the list
        /// </summary>
        /// <param name="width">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="height">Height of the frame (in pixels) it is to occupy</param>
        /// <returns>List of images and first image in list to be displayed</returns>   
        Image LoadImage(int width, int height);
    }
}
