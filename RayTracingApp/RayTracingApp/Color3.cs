using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Color3
    {
        private double colR;
        private double colG;
        private double colB;

        //read only
        public double ColR
        {
            get { return colR; }
        }
        public double ColG
        {
            get { return colG; }
        }
        public double ColB
        {
            get { return colB; }
        }

        public Color3(double colR, double colG, double colB)
        {
            //rgb color
            this.colR = colR;
            this.colG = colG;
            this.colB = colB;
        }

        public void CheckRange()
        {
            // limit R, G and B in the interval [0.0, 1.0]
            //become 0 if less than 0 and become 1 if more than 1
            colR = Math.Max(0.0, Math.Min(1.0, colR));
            colG = Math.Max(0.0, Math.Min(1.0, colG));
            colB = Math.Max(0.0, Math.Min(1.0, colB));
        }
    }
}
