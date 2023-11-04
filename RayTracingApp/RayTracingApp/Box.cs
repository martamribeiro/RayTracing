using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace RayTracingApp
{
    internal class Box : Object3D
    {
        // The Box's material
        private Material material;

        private Vector3[] bounds = new Vector3[2];

        // Getters
        public Material Material { get { return material; } }

        public Transformation Transformation { get {  return transformation; } }

        // Constructor without the Transformation, defaults to using the Identity Transformation
        public Box(Material material) : this(material, new Transformation()) {}

        // Constructor
        public Box(Material material, Transformation transformation)
        {
            this.material = material;

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransTransposed = this.inverseTransformation.Transpose();

            Vector3 vmin = new Vector3(-0.5f, -0.5f, -0.5f);
            Vector3 vmax = new Vector3(0.5f, 0.5f, 0.5f);

            bounds[0] = vmin;
            bounds[1] = vmax;
        }

        // Returns True if the Ray intersects with the AABB Box
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            // Global Ray to Local
            Vector3 rayLocalDir = toLocalVec(ray.Direction);
            rayLocalDir = rayLocalDir.Normalize();

            Vector3 rayLocalOrig = toLocalPoint(ray.Origin);

            float tnear, tfar;
            float t1, t2;

            // Calculate intersection for X axis
            if (rayLocalDir.X == 0 && (rayLocalOrig.X < bounds[0].X || rayLocalOrig.X > bounds[0].X))
                return false;

            tnear = (bounds[0].X - rayLocalOrig.X) / rayLocalDir.X;
            tfar = (bounds[1].X - rayLocalOrig.X) / rayLocalDir.X;

            if (tnear > tfar)
                swap(ref tnear, ref tfar);

            if (tnear > tfar || tfar < 0)
                return false;

            // Calculate intersection for Y axis
            if (rayLocalDir.Y == 0 && (rayLocalOrig.Y < bounds[0].Y || rayLocalOrig.Y > bounds[0].Y))
                return false;

            t1 = (bounds[0].Y - rayLocalOrig.Y) / rayLocalDir.Y;
            t2 = (bounds[1].Y - rayLocalOrig.Y) / rayLocalDir.Y;

            if (t1 > t2)
                swap(ref t1, ref t2);

            if (t1 > tnear)
                tnear = t1;

            if (t2 < tfar)
                tfar = t2;

            if (tnear > tfar || tfar < 0)
                return false;

            // Calculate intersection for Z axis
            if (rayLocalDir.Z == 0 && (rayLocalOrig.Z < bounds[0].Z || rayLocalOrig.Z > bounds[0].Z))
                return false;

            t1 = (bounds[0].Z - rayLocalOrig.Z) / rayLocalDir.Z;
            t2 = (bounds[1].Z - rayLocalOrig.Z) / rayLocalDir.Z;

            if (t1 > t2)
                swap(ref t1, ref t2);

            if (t1 > tnear)
                tnear = t1;

            if (t2 < tfar)
                tfar = t2;

            if (tnear > tfar || tfar < 0)
                return false;

            Vector3 p = rayLocalOrig + rayLocalDir * tnear;
            Vector3 pGlobal = toGlobalPoint(p);
            float tGlobal = (pGlobal - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 1.0E-6 && tGlobal < hit.Tmin)
            {
                Vector3 norm = CalculateNormal(p);
                norm = toGlobalNorm(norm);

                hit = new Hit(tGlobal, this.Material.Color, true, this.material, pGlobal, norm, tGlobal);
            }

            return true;
        }

        // Calculates the normal on a given point
        public Vector3 CalculateNormal(Vector3 point)
        {
            float x = Math.Abs(point.X);
            float y = Math.Abs(point.Y);
            float z = Math.Abs(point.Z);

            if ((x > y) && (x > z))
                return new Vector3(point.X, 0.0f, 0.0f).Normalize();

            if ((y > x) && (y > z))
                return new Vector3(0.0f, point.Y, 0.0f).Normalize();

            return new Vector3(0.0f, 0.0f, point.Z).Normalize();
        }

        // Swaps the two given values (Utils function)
        private void swap(ref float t0, ref float t1)
        {
            float tmp = t0;
            t0 = t1;
            t1 = tmp;
        }

        public void updateBounds(Vector3 minBound, Vector3 maxBound)
        {
            bounds[0] = minBound;
            bounds[1] = maxBound;
        }
    }
}
