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
        public List<String> pathfilenames;
        byte[] photoBytes;
        Size size;

        public ImageMemory()
        {
            pathfilenames = new List<String>();
        }

        public IList<String> load(IList<String> pathfileparam)
        {
            
                pathfilenames.AddRange(pathfileparam);

            return pathfilenames;
        }

        public Image getImage(String key, int frameWidth, int frameHeight)
        {
            photoBytes = File.ReadAllBytes(key);
            size = new Size(frameWidth, frameHeight);



            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {

                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Save(outStream);

                    }

                    return Image.FromStream(outStream);
                }
            }
        }

        public IList<String> fetchPathList()
        {

            return pathfilenames;
        }
    }

}
