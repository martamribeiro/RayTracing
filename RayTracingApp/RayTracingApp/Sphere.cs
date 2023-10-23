using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Sphere : Object3D
    {
        // The Sphere's Material
        private Material material;

        // The Transformation applied to the Sphere
        private Transformation transformation;

        // The Sphere's center point
        private Vector3 centerPoint;

        // The Sphere's radious
        private float radious;

        // Getters
        public Material Material { get { return material; } }

        public Transformation Transformation { get { return transformation; } }

        public Vector3 Center { get { return centerPoint; } }

        public float Radious { get { return radious; } }

        // Constructor without the Transformation, defaults to using the Identity Transformation
        public Sphere(Material material) : this(material, new Transformation()) {}

        // Constructor
        public Sphere(Material material, Transformation transformation) 
        { 
            this.material = material;
            this.transformation = transformation;

            this.centerPoint = new Vector3(0.0f, 0.0f, 0.0f);
            this.radious = 1.0f;
        }

        // TODO: Third Stage of the assignment 
        // Returns True if the Ray intersects with the Box
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            float t = (centerPoint - ray.Origin).Dot(ray.Direction);

            if (t < 0.0f)
                return false;

            Vector3 p =  ray.Origin + ray.Direction * t;

            float y = (centerPoint - p).Length();

            if (y > radious)
                return false;

            float x = (float)Math.Sqrt(Math.Pow(radious, 2) + Math.Pow(y, 2));
            float t1 = t - x;
            float t2 = t + x;

            float tnear = (t1 > t2) ? t2 : t1;

            // Update Hit if this is the closest intersection
            if (tnear > 1.0E-6 && tnear < hit.Tmin)
            {
                Vector3 intP = ray.Origin + ray.Direction * tnear;
                Vector3 norm = intP / intP.Length();

                hit = new Hit(tnear, this.Material.Color, true, this.material, intP, norm, tnear);
            }

            return true;
        }
    }
}
