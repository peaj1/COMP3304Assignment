using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManipulationTool
{
    interface ICollectImages
    {
        /// <summary>
        /// Open windows file explorer and add selected image references to list
        /// </summary>
        /// <param name="load">Delegate for the load function in ImageMemory</param>
        void OpenFiles(loadDelegate load);
    }
}
