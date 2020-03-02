﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ImageManipulationTool
{
    public delegate Image getImageDelegate(String key, int frameWidth, int frameHeight);

    public delegate IList<String> loadDelegate(IList<String> pathfileparam);

    public delegate IList<String> fetchListDelegate();
}
