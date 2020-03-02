using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{
    interface IDrawImage
    {
        Image NextImage(int frameWidth, int frameHeight, IList<String> pathfilenames, getImageDelegate getImageParam);

        Image PrevImage(int frameWidth, int frameHeight, IList<String> pathfilenames, getImageDelegate getImageParam);
    }
}
