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
            Vector4 rayHomDir = Vector4.CartesianToHomogeneous(ray.Direction, 0.0f);
            Vector4 rayLocalDirHom = inverseTransformation.ApplyTransformation(rayHomDir);
            Vector3 rayLocalDir = Vector4.HomogeneousToCartesian(rayLocalDirHom);
            rayLocalDir = rayLocalDir.Normalize();

            Vector4 rayHomOrig = Vector4.CartesianToHomogeneous(ray.Origin, 1.0f);
            Vector4 rayLocalOrigHom = inverseTransformation.ApplyTransformation(rayHomOrig);
            Vector3 rayLocalOrig = Vector4.HomogeneousToCartesian(rayLocalOrigHom);

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

            // Update Hit if this is the closest intersection
            if (tnear > 1.0E-6 && tnear < hit.Tmin)
            {
                Vector3 intP = rayLocalOrig + rayLocalDir * tnear;
                Vector3 norm = intP / intP.Length();

                // Transform everything to global coordinates
                Vector4 homP = Vector4.CartesianToHomogeneous(intP, 1.0f);
                Vector4 transformedPoint = transformation.ApplyTransformation(homP);
                Vector3 globalP = Vector4.HomogeneousToCartesian(transformedPoint);

                Vector4 normHom = Vector4.CartesianToHomogeneous(norm, 0.0f);
                Vector4 globalNormHom = invTransfTransposed.ApplyTransformation(normHom);
                Vector3 globalNorm = Vector4.HomogeneousToCartesian(globalNormHom);

                hit = new Hit(tnear, this.Material.Color, true, this.material, globalP, globalNorm, tnear);
            }

            return true;
        }
    }
}
