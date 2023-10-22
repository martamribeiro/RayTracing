using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Box : Object3D
    {
        // The Box's material
        private Material material;

        // The Box's Transformation 
        private Transformation transformation = new Transformation();

        // Getters
        public Material Material { get { return material; } }

        public Transformation Transformation { get {  return transformation; } }

        // Constructor without the Transformation, defaults to using the Identity Transformation
        public Box(Material material)
        {
            this.material = material;
        }

        // Constructor
        public Box(Material material, Transformation transformation)
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
