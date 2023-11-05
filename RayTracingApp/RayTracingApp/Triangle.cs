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

        public Triangle(Vector3 vertA, Vector3 vertB, Vector3 vertC, Material material, Transformation transformation)
        {
            this.verticeA = vertA;
            this.verticeB = vertB;  
            this.verticeC = vertC;
            this.material = material;

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

            this.originalTransformation = transformation;
            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransTransposed = this.inverseTransformation.Transpose();

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

            /*
            // Compute t
            float d = -normal.Dot(verticeA);
            float t = -(normal.Dot(rayLocalOrig) + d) / normal.Dot(rayLocalDir);

            if (t < 0.0f)
                return false;

            
            // Compute the intersection point
            Vector3 intP = rayLocalOrig + t * rayLocalDir;

            // Check if point P is inside or outside the triangle
            Vector3 c;

            // Edge AB
            Vector3 edge0 = verticeB - verticeA;
            Vector3 vp0 = intP - verticeA;
            c = edge0.Cross(vp0);

            if (normal.Dot(c) < 0.0f)
                return false;

            // Edge BC
            Vector3 edge1 = verticeC - verticeB;
            Vector3 vp1 = intP - verticeB;
            c = edge1.Cross(vp1);

            if (normal.Dot(c) < 0.0f)
                return false;

            // Edge AC
            Vector3 edge2 = verticeA - verticeC;
            Vector3 vp2 = intP - verticeC;
            c = edge2.Cross(vp2);

            if (normal.Dot(c) < 0.0f)
                return false;
            */

            Vector3 edge1 = verticeB - verticeA;
            Vector3 edge2 = verticeC - verticeA;

            Vector3 crossRayDirEdge2 = rayLocalDir.Cross(edge2);

            float det = edge1.Dot(crossRayDirEdge2);

            if (det > -1.0E-6 && det < 3.0E-5)
                return false;

            float inv_det = 1.0f / det;

            Vector3 origMinusVertA = rayLocalOrig - verticeA;
            float baryU = origMinusVertA.Dot(crossRayDirEdge2) * inv_det;

            if (baryU < 0.0f || baryU > 1.0f)
                return false;

            Vector3 crossOrigMinusVertAEdge1 = origMinusVertA.Cross(edge1);
            float baryV = rayLocalDir.Dot(crossOrigMinusVertAEdge1) * inv_det;

            if (baryV < 0.0f || baryU + baryV > 1.0f)
                return false;

            float t = edge2.Dot(crossOrigMinusVertAEdge1) * inv_det;

            Vector3 intP = rayLocalOrig + t * rayLocalDir;

            // Transform everything to global coordinates
            Vector3 globalP = toGlobalPoint(intP);

            Vector3 globalNorm = toGlobalNorm(normal);

            float tGlobal = (globalP - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 3.0E-5 && tGlobal < hit.Tmin)
                hit = new Hit(tGlobal, material.Color, true, material, globalP, globalNorm, tGlobal);

            return true;
        }
    }
}
