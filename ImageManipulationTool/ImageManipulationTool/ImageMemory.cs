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
        ISupportedImageFormat format;
        Size size;

        public ImageMemory()
        {
            photoBytes = File.ReadAllBytes("FishAssets/AnglerFish_Lit.png");
            //format = new JpegFormat { Quality = 70 };
            size = new Size(150, 150);

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                {
                    imageFactory.Load(inStream)
                                .Resize(size);
                                //.Format(format);
                }
            }
        }
    }
}
