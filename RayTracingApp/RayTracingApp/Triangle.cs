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

        private Transformation transformation;

        private Transformation inverseTransformation;

        private Transformation invTransfTransposed;

        private Vector3 normal;

        public Triangle(Vector3 vertA, Vector3 vertB, Vector3 vertC, Material material, Transformation transformation)
        {
            this.verticeA = vertA;
            this.verticeB = vertB;  
            this.verticeC = vertC;
            this.material = material;

            Transformation? fullTrans = transformation * Scene.Instance.Camera!.Transformation;

            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransfTransposed = this.inverseTransformation.Transpose();

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

        // Returns True if the Ray intersects with the Triangle
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            // Global Ray to Local
            Vector4 rayHomDir = Vector4.CartesianToHomogeneous(ray.Direction, 0.0f);
            Vector4 rayLocalDirHom = inverseTransformation.ApplyTransformation(rayHomDir);
            Vector3 rayLocalDir = Vector4.HomogeneousToCartesian(rayLocalDirHom);
            rayLocalDir = rayLocalDir.Normalize();

            Vector4 rayHomOrig = Vector4.CartesianToHomogeneous(ray.Origin, 1.0f);
            Vector4 rayLocalOrigHom = inverseTransformation.ApplyTransformation(rayHomOrig);
            Vector3 rayLocalOrig = Vector4.HomogeneousToCartesian(rayLocalOrigHom);

            // Check if the ray is parallel to the plan
            if (Math.Abs(normal.Dot(rayLocalDir)) < 1.0E-6) 
                return false;

            // Calculate the point where the ray intersects the triangle's plane
            Vector3 w = verticeA - rayLocalOrig;
            
            float t = w.Dot(this.normal) / rayLocalDir.Dot(this.normal);

            if (t < 0.0f)
                return false;

            Vector3 intP = rayLocalOrig + t * rayLocalDir;

            // Check if point P is inside or outside the triangle
            Vector3 c;

            // Edge AB
            Vector3 edgeAB = verticeB - verticeA;
            Vector3 vpAB = intP - verticeA;
            c = edgeAB.Cross(vpAB);

            if (normal.Dot(c) < 0.0f)
                return false;

            // Edge BC
            Vector3 edgeBC = verticeC - verticeB;
            Vector3 vpBC = intP - verticeB;
            c = edgeBC.Cross(vpBC);

            if (normal.Dot(c) < 0.0f)
                return false;

            // Edge AC
            Vector3 edgeAC = verticeA - verticeC;
            Vector3 vpAC = intP - verticeC;
            c = edgeAC.Cross(vpAC);

            if (normal.Dot(c) < 0.0f)
                return false;

            // Transform everything to global coordinates
            Vector4 homP = Vector4.CartesianToHomogeneous(intP, 1.0f);
            Vector4 transformedPoint = transformation.ApplyTransformation(homP);
            Vector3 globalP = Vector4.HomogeneousToCartesian(transformedPoint);

            Vector4 normHom = Vector4.CartesianToHomogeneous(normal, 0.0f);
            Vector4 globalNormHom = invTransfTransposed.ApplyTransformation(normHom);
            Vector3 globalNorm = Vector4.HomogeneousToCartesian(globalNormHom);

            // Update Hit if this is the closest intersection
            if (t > 1.0E-6 && t < hit.Tmin)
                hit = new Hit(t, material.Color, true, material, globalP, globalNorm, t);

            return true;
        }
    }
}
