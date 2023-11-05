using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RayTracingApp
{
    internal class Mesh : Object3D
    {
        // A List of Triangles that make up the Mesh
        private List<Triangle> triangles;

        private Box boundingBox;

        // Getters
        public List<Triangle> Triangles { get { return triangles; } }

        public Transformation Transformation { get { return transformation; } }

        // Empty Constructor, defaults the Transformation to the Identity Matrix
        public Mesh() : this(new List<Triangle>(), new Transformation()) { }

        // Constructor using only the Transformation 
        public Mesh(Transformation transformation) : this(new List<Triangle>(), transformation) {}

        // Constructor with both a List of Triangles and the given Transformation
        public Mesh(List<Triangle> triangles, Transformation transformation) 
        {
            this.triangles = triangles;

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransTransposed = this.inverseTransformation.Transpose();

            Color3 white = new Color3(1f, 1f, 1f);
            Material boxMat = new Material(white, 1f, 1f, 1f, 1f, 1f);
            boundingBox = new Box(boxMat, transformation);
        }

        // Adds the given Triangle to the Mesh
        public void AddTriangle(Triangle triangle)
        {
            this.triangles.Add(triangle);
        }

        // Returns True if the Ray intersects with the Mesh 
        public override bool Intersect(Ray ray, ref Hit hit) 
        {
            Hit boxHit = new Hit();

            boundingBox.Intersect(ray, ref boxHit);

            if (!boxHit.Found)
                return false;

            bool intersected = false;
            
            foreach (Triangle triangle in triangles)
                if (triangle.Intersect(ray, ref hit))
                    intersected = true;

            return intersected;
        }

        public void updateBoundingBox(Vector3 minBound, Vector3 maxBound)
        {
            boundingBox.updateBounds(minBound, maxBound);
        }
    }
}
