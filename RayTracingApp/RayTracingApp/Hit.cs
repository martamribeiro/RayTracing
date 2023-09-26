using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Hit
    {
        //distance from the origin of the ray to the point of intersection
        private float t;
        //hit color
        private Color3 color;

        //read only
        public float T
        {
            get { return t; }
        }
        public Color3 Color
        {
            get { return color; }
        }

        public Hit(float t, Color3 color)
        {
            this.t = t;
            this.color = color;
        }

        //modifier
        public void Modifier(float t, Color3 color)
        {
            this.t = t;
            this.color = color;
        }

        //DUVIDA: material e normal estao comentados no TR-02 (pag.13) e TR-01 (pag.58)
        //adiciono ou nao ???

    }
}
