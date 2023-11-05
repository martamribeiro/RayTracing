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
            this.invTransTransposed = this.inverseTransformation.Transpose();

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

            float a = rayLocalDir.Dot(rayLocalDir);
            float b = 2 * rayLocalDir.Dot(rayLocalOrig);
            float c = rayLocalOrig.Dot(rayLocalOrig) - 1;

            if (Math.Pow(b, 2) < (4 * a * c))
                return false;

            float d = (float)Math.Sqrt(Math.Pow(b, 2) - (4 * a * c));
            float t1 = (-b + d) / (2 * a);
            float t2 = (-b - d) / (2 * a);

            float tnear = (t1 > t2) ? t2 : t1;

            // Convert to Global Coordinates
            Vector3 intP = rayLocalOrig + rayLocalDir * tnear;
            Vector3 globalP = toGlobalPoint(intP);

            float tGlobal = (globalP - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 1.0E-6 && tGlobal < hit.Tmin)
            {
                // Get the Global Normal
                Vector3 norm = intP.Normalize();
                Vector3 globalNorm = toGlobalNorm(norm);

                hit = new Hit(tGlobal, this.Material.Color, true, this.material, globalP, globalNorm, tGlobal);
            }

            return true;
        }
    }
}
