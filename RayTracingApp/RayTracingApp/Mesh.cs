using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Mesh : Object3D
    {
        // A List of Triangles that make up the Mesh
        private List<Triangle> triangles = new List<Triangle>();

        // The Transformation to be applied to all the Mesh's Triangles
        private Transformation transformation = new Transformation();

        // Getters
        public List<Triangle> Triangles { get { return triangles; } }

        public Transformation Transformation { get { return transformation; } }

        // Empty Constructor, defaults the Transformation to the Identity Matrix
        public Mesh() { }

        // Constructor using only the Transformation 
        public Mesh(Transformation transformation) {
            this.transformation = transformation;
        }

        // Constructor with both a List of Triangles and the given Transformation
        public Mesh(List<Triangle> triangles, Transformation transformation) 
        {
            this.triangles = triangles;
            this.transformation = transformation;
        }

        // Adds the given Triangle to the Mesh
        public void AddTriangle(Triangle triangle)
        {
            this.triangles.Add(triangle);
        }

        // Returns True if the Ray intersects with the Mesh 
        public override bool Intersect(Ray ray, ref Hit hit) 
        {
            bool intersected = false;
            
            foreach (Triangle triangle in triangles)
                if (triangle.Intersect(ray, ref hit))
                    intersected = true;

            return intersected;
        }
    }
}
