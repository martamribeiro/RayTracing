using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Image
    {
        public int ResX { get; set; }
        public int ResY { get; set; }
        public double CorR { get; set; }
        public double CorG { get; set; }
        public double CorB { get; set; }

        public Image(int resX, int resY, double corR, double corG, double corB)
        {
            //resolução
            ResX = resX;
            ResY = resY;
            //cor rgb
            CorR = corR;
            CorG = corG;
            CorB = corB;
        }
    }