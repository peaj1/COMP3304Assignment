﻿using System;
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
        ImageMemory _imageMemory;
        public Form1()
        {
            _imageMemory = new ImageMemory();
            InitializeComponent();

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
