using System;
using System.Collections.Generic;
using System.Drawing;
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
        //true only if interseption is found
        private bool found;
        //material of intersepted object
        private Material material;
        //interception point
        private Vector3 point;
        //normal to the plane tangent to the surface of the object at the point of point intersection
        private Vector3 normal;
        //min value of distance t found at the moment
        private float tmin;

        //read only
        public float T
        {
            get { return t; }
        }
        public Color3 Color
        {
            get { return color; }
        }
        public bool Found
        {
            get { return found; }
        }
        public Material Material
        {
            get { return material; }
        }
        public Vector3 Point
        {
            get { return point; }
        }
        public Vector3 Normal
        {
            get { return normal; }
        }
        public float Tmin
        {
            get { return tmin; }
        }

        public Hit(float t, Color3 color, bool found, Material material, Vector3 point, Vector3 normal, float tmin) : this(t, color)
        {
            this.t = t;
            this.color = color;
            this.found = found;
            this.material = material;
            this.point = point;
            this.normal = normal;
            this.tmin = tmin;
        }

        //segundo slides
        /*public Hit(float t, Color3 color)
        {
            this.t = t;
            this.color = color;
        }*/

        //DUVIDA: porquê adicionar o destrutor??
        ~Hit()
        {

        }

        //modifier
        public void Modifier(float t, Color3 color)
        {
            this.t = t;
            this.color = color;
        }

    }
}
