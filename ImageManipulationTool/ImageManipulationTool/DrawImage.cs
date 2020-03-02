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
        int currentImage;

        public DrawImage()
        {
            currentImage = 0;
        }
        
        public Image NextImage(int frameWidth, int frameHeight, IList<String> pathfilenames, getImageDelegate getImageParam)
        {

            if (currentImage == pathfilenames.Count - 1)
            {
                currentImage = 0;
            }
            else
            {
                currentImage++;
            }

            Image image = getImageParam(pathfilenames[currentImage], frameWidth, frameHeight);

            return image;
        }

        public Image PrevImage(int frameWidth, int frameHeight, IList<String> pathfilenames, getImageDelegate getImageParam)
        {
            if (currentImage == 0)
            {
                currentImage = pathfilenames.Count - 1;
            }
            else
            {
                currentImage--;
            }

            Image image = getImageParam(pathfilenames[currentImage], frameWidth, frameHeight);

            return image;
        }
    }
}
