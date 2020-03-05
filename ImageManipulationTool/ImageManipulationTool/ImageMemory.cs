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
    /// <summary>
    /// ImageMemory class which Implements the Imodel Interface
    /// This class allows the user to load a reference to collected images into memory as Strings and to reaccess them using a closed memory stream as images
    /// </summary>
    class ImageMemory: IModel
    {
        //DECLARE pathFileNames of type List<String>
        List<String> _pathFileNames;

        /// <summary>
        /// Main method for the ImageMemory class
        /// run when an instance of Image memory is created
        /// used to initialise a List called _pathFileNames which will be used to store file paths of collected images
        /// </summary>
        public ImageMemory()
        {
            //INITIALISE pathfilenames as List of Strings
            _pathFileNames = new List<String>();
        }

        
        ///<summary>
        ///METHOD to Add collected images into Memory and to return all images that are in memory
        ///</summary>
        ///<returns>List of Strings containing references to collected file paths</returns>
        ///<param name="pathFileParam">a list of Strings holding new file paths to be added to memory</param>
        public IList<String> load(IList<String> pathFileParam)
        {
            //Append pathFileParam List to _pathFileNames list
            _pathFileNames.AddRange(pathFileParam);

            //return full list of memorised files
            return _pathFileNames;
        }


        ///<summary>
        ///METHOD to fetch and close a memory stream of an image from the filepath editing the size and allowing the image to be rendered where the method is called
        ///</summary>
        ///<returns>Image type containing the edited image to be rendered</returns>
        ///<param name="key">String holding the file path that needs to be opened, edited and displayed</param>
        ///<param name="frameWidth">int holding the width of the Picturebox that the image will be resized to</param>
        ///<param name="height">int holding the height of the Picturebox that the image will be resized to</param>
        public Image getImage(String key, int frameWidth, int frameHeight)
        {
            //DECLARE local variable called photoBytes of type byte[]
            //DECLARE local variable called size of type Size
            byte[] photoBytes;
            Size size;
            
            //INITIALISE photoBytes to read data from the inputted file path called 'Key'
            //INITIALISE size to a new size made from the inputted 'frameWidth' and 'frameHeight' intergers
            photoBytes = File.ReadAllBytes(key);
            size = new Size(frameWidth, frameHeight);
            
            //Create and close a Memory Stream from the photoBytes variable
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    //create an imageFactory using ImageProcessors inbuilt ImageFactory method to load and resize the image from the inStream so that it can be used
                    using (ImageFactory imageFactory = new ImageFactory())
                    {

                        imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Save(outStream);

                    }

                    //return the resized image from the outStream before the memory stream is closed
                    return Image.FromStream(outStream);
                }
            }
        }

    }

}
