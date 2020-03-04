using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageManipulationTool
{
    class CollectImages:ICollectImages
    {

        public CollectImages()
        {
        }


        public void OpenFiles(loadDelegate load)
        {

            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = true;

            IList<String> tempPathFiles = new List<String>();

            if (file.ShowDialog() == DialogResult.OK)
            {
                foreach (String filePath in file.FileNames)
                {
                    tempPathFiles.Add(filePath); 
                }

                IList<String> newPathList = load(tempPathFiles);
                
            }
        }
    }

    
}
