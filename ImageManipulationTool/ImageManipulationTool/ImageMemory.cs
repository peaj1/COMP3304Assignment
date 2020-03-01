using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ImageManipulationTool
{
    
    class ImageMemory
    {
        byte[] photoBytes;

        public ImageMemory()
        {
        }

        public Image loadImage(String filePath, Size imageSize)
        {
            photoBytes = File.ReadAllBytes(filePath);
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                {
                    imageFactory.Load(inStream)
                                .Resize(imageSize);
                }

                return(Image.FromStream(inStream));
            }

        }
    }

}
