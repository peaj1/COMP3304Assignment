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
        /// 
        /// </summary>
        /// <param name="load"></param>
        void OpenFiles(loadDelegate load);
    }
}
