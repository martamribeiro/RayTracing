using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Triangle : Object3D
    {
        private Vector3 verticeA;
        
        private Vector3 verticeB;

        private Vector3 verticeC;

        private Material material;

        private Vector3 normal;

        public Triangle(Vector3 vertA, Vector3 vertB, Vector3 vertC, Material material)
        {
            this.verticeA = vertA;
            this.verticeB = vertB;  
            this.verticeC = vertC;
            this.material = material;

            this.normal = CalculateNormal();
        }

        // Calculates the triangle Normal and returns a Vector3 with the result
        public Vector3 CalculateNormal()
        {
            Vector3 edgeAB = (verticeB - verticeA);
            Vector3 edgeAC = (verticeC - verticeA);

            Vector3 normal = edgeAB.Cross(edgeAC); 

            return normal.Normalize();
        }

        // TODO: Third Stage of the assignment 
        // Returns True if the Ray intersects with the Triangle
        public override bool Intersect(Ray ray, Hit hit, float tmin)
        {
            return false; 
        }
    }
}
