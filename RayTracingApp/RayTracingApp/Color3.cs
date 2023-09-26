using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Color3
    {
        public double ColR { get; }
        public double ColG { get; }
        public double ColB { get; }

        public Color3(double colR, double colG, double colB)
        {
            //rgb color
            ColR = colR;
            ColG = colG;
            ColB = colB;
        }
    }
}
