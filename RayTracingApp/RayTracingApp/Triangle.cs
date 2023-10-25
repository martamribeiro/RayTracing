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

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

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
            Vector3 rayLocalDir = toLocalVec(ray.Direction);
            rayLocalDir = rayLocalDir.Normalize();

            Vector3 rayLocalOrig = toLocalPoint(ray.Origin);

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
            Vector3 globalP = toGlobalPoint(intP);

            Vector3 globalNorm = toGlobalNorm(normal);

            float tGlobal = (globalP - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 1.0E-6 && tGlobal < hit.Tmin)
                hit = new Hit(tGlobal, material.Color, true, material, globalP, globalNorm, tGlobal);

            return true;
        }

        // Converts the given Global Point to the Local Coordinate system of the Object
        public Vector3 toLocalPoint(Vector3 point)
        {
            Vector4 homoPoint = Vector4.CartesianToHomogeneous(point, 1.0f);
            Vector4 localHomoPoint = inverseTransformation.ApplyTransformation(homoPoint);
            Vector3 localPoint = Vector4.HomogeneousToCartesian(localHomoPoint);

            return localPoint;
        }

        // Converts the given Global Vector to the Local Coordinate system of the Object
        public Vector3 toLocalVec(Vector3 vec)
        {
            Vector4 homoVec = Vector4.CartesianToHomogeneous(vec, 0.0f);
            Vector4 localHomoVec = inverseTransformation.ApplyTransformation(homoVec);

            return Vector4.HomogeneousToCartesian(localHomoVec);
        }

        // Converts the given Local Point to the Global Coordinate system
        public Vector3 toGlobalPoint(Vector3 point)
        {
            Vector4 homoPoint = Vector4.CartesianToHomogeneous(point, 1.0f);
            Vector4 globalHomoPoint = transformation.ApplyTransformation(homoPoint);

            return Vector4.HomogeneousToCartesian(globalHomoPoint);
        }

        // Converts the given Local Vector to the Global Coordinate system
        public Vector3 toGlobalVec(Vector3 vec)
        {
            Vector4 homoVec = Vector4.CartesianToHomogeneous(vec, 0.0f);
            Vector4 globalHomoVec = transformation.ApplyTransformation(homoVec);

            return Vector4.HomogeneousToCartesian(globalHomoVec);
        }

        // Converts the given Local Normal to the Global Coordinate System
        public Vector3 toGlobalNorm(Vector3 norm)
        {
            Vector4 normHom = Vector4.CartesianToHomogeneous(norm, 0.0f);
            Vector4 globalNormHom = invTransfTransposed.ApplyTransformation(normHom);
            Vector3 globalNorm = Vector4.HomogeneousToCartesian(globalNormHom);

            return globalNorm.Normalize();
        }
    }
}
