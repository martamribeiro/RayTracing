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

        public static Color3 operator +(Color3 c1, Color3 c2)
        {
            return new Color3(c1.ColR + c2.ColR, c1.ColG + c2.ColG, c1.ColB + c2.ColB);
        }

        public static Color3 operator *(Color3 c1, Color3 c2)
        {
            return new Color3(c1.ColR * c2.ColR, c1.ColG * c2.ColG, c1.ColB * c2.ColB);
        }

        public static Color3 operator *(Color3 c, double scalar)
        {
            return new Color3(c.ColR * scalar, c.ColG * scalar, c.ColB * scalar);
        }

        public static Color3 operator *(double scalar, Color3 c)
        {
            return c * scalar;
        }
        
        public static Color3 operator /(Color3 c, int divisor)
        {
            if (divisor == 0)
            {
                throw new ArgumentException("Division by zero is not allowed.");
            }
            return new Color3(c.ColR / divisor, c.ColG / divisor, c.ColB / divisor);
        }

    }
}
