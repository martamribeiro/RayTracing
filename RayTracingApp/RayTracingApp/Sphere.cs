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
        private Transformation transformation = new Transformation();

        // Getters
        public Material Material { get { return material; } }

        public Transformation Transformation { get { return transformation; } }

        // Constructor without the Transformation, defaults to using the Identity Transformation
        public Sphere(Material material)
        {
            this.material = material;
        }

        // Constructor
        public Sphere(Material material, Transformation transformation) 
        { 
            this.material = material;
            this.transformation = transformation;
        }

        // TODO: Third Stage of the assignment 
        // Returns True if the Ray intersects with the Box
        public override bool Intersect(Ray ray, out Hit hit)
        {
            hit = new Hit();
            return false;
        }
    }
}
