using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.DataFormats;

namespace RayTracingApp
{
    internal class Sphere : Object3D
    {
        // The Sphere's Material
        private Material material;

        // The Transformation applied to the Sphere
        private Transformation transformation;

        private Transformation inverseTransformation;

        private Transformation invTransfTransposed;

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

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransfTransposed = this.inverseTransformation.Transpose();

            this.centerPoint = new Vector3(0.0f, 0.0f, 0.0f);
            this.radious = 1.0f;
        }

        // Returns True if the Ray intersects with the Box
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            // Global Ray to Local
            Vector3 rayLocalDir = toLocalVec(ray.Direction);
            rayLocalDir = rayLocalDir.Normalize();

            Vector3 rayLocalOrig = toLocalPoint(ray.Origin);

            float t = (centerPoint - rayLocalOrig).Dot(rayLocalDir);

            if (t < 0.0f)
                return false;

            Vector3 p = rayLocalOrig + rayLocalDir * t;

            float y = (centerPoint - p).Length();

            if (y > radious)
                return false;

            float x = (float)Math.Sqrt(Math.Pow(radious, 2) + Math.Pow(y, 2));
            float t1 = t - x;
            float t2 = t + x;

            float tnear = (t1 > t2) ? t2 : t1;

            // Convert to Global Coordinates
            Vector3 intP = rayLocalOrig + rayLocalDir * tnear;
            Vector3 globalP = toGlobalPoint(intP);

            float tGlobal = (globalP - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 1.0E-6 && tGlobal < hit.Tmin)
            {
                // Get the Global Normal
                Vector3 norm = intP / intP.Length();
                Vector3 globalNorm = toGlobalNorm(norm);

                hit = new Hit(tGlobal, this.Material.Color, true, this.material, globalP, globalNorm, tGlobal);
            }

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
