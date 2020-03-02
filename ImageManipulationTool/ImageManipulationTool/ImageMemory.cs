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
    
    class ImageMemory: IModel
    {
        public IList<String> files;
        byte[] photoBytes;
        Size size;

        public ImageMemory()
        {
            files = new List<String>();
        }

        public IList<String> load(IList<String> pathfilenames)
        {
            files = pathfilenames;
            return files;
        }

        public Image getImage(String key, int frameWidth, int frameHeight)
        {
            photoBytes = File.ReadAllBytes(key);
            size = new Size(frameWidth, frameHeight);
            var resizeMode = ImageProcessor.Imaging.ResizeMode.Max;
            var r = new ImageProcessor.Imaging.ResizeLayer(size, resizeMode);

            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {

                        imageFactory.Load(inStream)
                                    .Resize(r)
                                    .Save(outStream);

                    }

                    return Image.FromStream(outStream);
                }
            }
        }
    }

}
