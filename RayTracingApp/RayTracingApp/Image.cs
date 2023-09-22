using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Image
    {
        public int ResX { get; set; }
        public int ResY { get; set; }
        public Color3 Color { get; set; }

        public Image(int resX, int resY, Color3 color)
        {
            //resolution
            ResX = resX;
            ResY = resY;
            //rgb color
            Color = color;
        }
    }
}