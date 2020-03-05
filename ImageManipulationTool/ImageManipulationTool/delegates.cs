using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <param name="frameWidth">The width (in pixels) of the frame it is to occupy </param>
    /// <param name="frameHeight">The height (in pixels) of the frame it is to occupy</param>
    /// <returns>Image information </returns>
    public delegate Image getImageDelegate(String key, int frameWidth, int frameHeight);


    /// <summary>
    /// Delegate for the load function in the imageMemory class
    /// </summary>
    /// <param name="pathfileparam">List to store path files</param>
    /// <returns>Image list to imageMemory class</returns>
    public delegate IList<String> loadDelegate(IList<String> pathfileparam);
}
