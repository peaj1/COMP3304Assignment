using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{
    /// <summary>
    /// Interface called IDrawImage to be used to allow access of the NextImage and PrevImage functions of the DrawImage class
    /// </summary>
    interface IDrawImage
    {
        /// <summary>
        /// Get information for next image selected, return to form class
        /// </summary>
        /// <param name="frameWidth">The width of the frame (in pixels) it is to occupy</param>
        /// <param name="frameHeight">The height of the frame (in pixels) it is to occupy</param>
        /// <param name="load">Delegate for list of images stored </param>
        /// <param name="getImageParam">getImageDelegate for info about image being displayed</param>
        Image NextImage(int frameWidth, int frameHeight, LoadDelegate load, GetImageDelegate getImageParam);
        
        /// <summary>
        /// Get information for previous image selected, return to form class
        /// </summary>
        /// <param name="frameWidth">The width of the frame (in pixels) it is to occupy</param>
        /// <param name="frameHeight">The height of the frame (in pixels) it is to occupy</param>
        /// <param name="load">Delegate for list of images stored</param>
        /// <param name="getImageParam">getImageDelegate for info about image being displayed</param>
        Image PrevImage(int frameWidth, int frameHeight, LoadDelegate load, GetImageDelegate getImageParam);

        /// <summary>
        /// Loads the image into the image variable from the image list passed from ImageMemory and returns the image
        /// </summary>
        /// <param name="frameWidth">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="frameHeight">Width of the frame (in pixels) it is to occupy</param>
        /// <param name="load">Delegate for list of images stored</param>
        /// <param name="getImageParam">getImageDelegate for info about image being displayed</param>
        /// <returns>image as an Image object</returns>
        Image LoadImage(int frameWidth, int frameHeight, LoadDelegate load, GetImageDelegate getImageParam);
    }
}
