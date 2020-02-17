using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System.IO;

namespace ImageManipulationTool
{
    public partial class Form1 : Form
    {

        ImageFactory _imageFactory;
        public Form1()
        {
            InitializeComponent();
            
            byte[] photoBytes = File.ReadAllBytes("FishAssets/AnglerFish_Lit.png");
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            Size size = new Size(150, 150);
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (_imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        _imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Format(format)
                                    .Save(outStream);

                        
                    }
                    
                }
            }

        }

        private void BtnNext_Click(object sender, EventArgs e)
        {

        }

        private void BtnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
           
        }
    }
}
