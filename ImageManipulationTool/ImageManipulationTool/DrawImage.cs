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
        
        public Image NextImage(int frameWidth, int frameHeight, fetchListDelegate fetchListParam, getImageDelegate getImageParam)
        {

            IList<String> tempList = fetchListParam();


            if (currentImage == tempList.Count - 1)
            {
                currentImage = 0;
            }
            else
            {
                currentImage++;
            }

            Image image = getImageParam(tempList[currentImage], frameWidth, frameHeight);

            return image;
        }

        public Image PrevImage(int frameWidth, int frameHeight, fetchListDelegate fetchListParam, getImageDelegate getImageParam)
        {
            IList<String> tempList = fetchListParam();

            if (currentImage == 0)
            {
                currentImage = tempList.Count - 1;
            }
            else
            {
                currentImage--;
            }

            Image image = getImageParam(tempList[currentImage], frameWidth, frameHeight);

            return image;
        }
    }
}
