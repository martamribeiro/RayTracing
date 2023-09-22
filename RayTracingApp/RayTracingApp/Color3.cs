using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Color3
    {
        public double ColR { get; set; }
        public double ColG { get; set; }
        public double ColB { get; set; }

        public Color3(double colR, double colG, double colB)
        {
            //rgb color
            ColR = colR;
            ColG = colG;
            ColB = colB;
        }
    }
}
