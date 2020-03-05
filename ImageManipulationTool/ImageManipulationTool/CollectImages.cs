using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManipulationTool
{
    ///<summary>
    ///Class used to collect images using a windows explorer User Interface.
    ///Then to pass collected files to ImageMemory class for storage, implements ICollectImages interface 
    ///Authors: Jude Mallett & Jon Pearson
    ///</summary>
    class CollectImages :ICollectImages
    {

        ///<summary>
        ///METHOD to open the file explorer and add each filepath to a list
        ///</summary>
        ///<param name="load">Delegate</param>
        public void OpenFiles(LoadDelegate load)
        {
            //Open File explorer
            OpenFileDialog file = new OpenFileDialog();

            //Allow user to select multiple files at once
            file.Multiselect = true;
            //Add filter to block non-image type files
            file.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            //Declaration of list used to store file path's of images
            IList<String> tempPathFiles = new List<String>();

            //If Explorer returns a result, add each selected image to list
            if (file.ShowDialog() == DialogResult.OK)
            {
                //Loops through each image selected
                foreach (String filePath in file.FileNames)
                {
                    //add image path to list
                    tempPathFiles.Add(filePath); 
                }
                //pass list to loadDelegate
                IList<String> newPathList = load(tempPathFiles);
                
            }
        }
    }

    
}
