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
        //DECLARE pathFileNames of type List<String>
        List<String> _pathFileNames;

        public ImageMemory()
        {
            //INITIALISE pathfilenames as List of Strings
            _pathFileNames = new List<String>();
        }

        //METHOD to Add collected images into Memory called load
        //PARAMETER pathFileParam
        public IList<String> load(IList<String> pathFileParam)
        {
            //Append pathFileParam List to _pathFileNames list
            _pathFileNames.AddRange(pathFileParam);

            //return _pathFileNames
            return _pathFileNames;
        }

        public Image getImage(String key, int frameWidth, int frameHeight)
        {

            //DECLARE local variable called photoBytes of type byte[]
            //DECLARE local variable called size of type Size
            byte[] photoBytes;
            Size size;

            
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

            return _pathFileNames;
        }
    }

}
