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

        // The Box's Transformation 
        private Transformation transformation;
        private Transformation inverseTransformation;
        private Transformation invTransfTransposed;

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
            this.invTransfTransposed = this.inverseTransformation.Transpose();

            Vector3 vmin = new Vector3(-0.5f, -0.5f, -0.5f);
            Vector3 vmax = new Vector3(0.5f, 0.5f, 0.5f);

            bounds[0] = vmin;
            bounds[1] = vmax;
        }

        // Returns True if the Ray intersects with the AABB Box
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            // Global Ray to Local
            Vector3 direction = ray.Direction;
            Vector4 rayHomDir = Vector4.CartesianToHomogeneous(direction, 0.0f);
            Vector4 rayLocalDirHom = inverseTransformation.ApplyTransformation(rayHomDir);
            Vector3 rayLocalDir = Vector4.HomogeneousToCartesian(rayLocalDirHom);
            rayLocalDir = rayLocalDir.Normalize();

            Vector3 origin = ray.Origin;
            Vector4 rayHomOrig = Vector4.CartesianToHomogeneous(origin, 1.0f);
            Vector4 rayLocalOrigHom = inverseTransformation.ApplyTransformation(rayHomOrig);
            Vector3 rayLocalOrig = Vector4.HomogeneousToCartesian(rayLocalOrigHom);

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
            Vector4 pHom = Vector4.CartesianToHomogeneous(p, 1.0f);
            Vector4 pHomGlobal = transformation.ApplyTransformation(pHom);
            Vector3 pGlobal = Vector4.HomogeneousToCartesian(pHomGlobal);

            float tGlobal = (pGlobal - ray.Origin).Dot(ray.Direction);

            // Update Hit if this is the closest intersection
            if (tGlobal > 1.0E-6 && tGlobal < hit.Tmin)
            {
                Vector3 norm = CalculateNormal(p);

                hit = new Hit(tGlobal, this.Material.Color, true, this.material, p, norm, tGlobal);
            }

            return true;
        }

        // Calculates the normal on a given point
        public Vector3 CalculateNormal(Vector3 point)
        {
            Vector3 center = (this.bounds[0] + this.bounds[1]) / 2.0f;
            Vector3 offset = point - center;

            offset = new Vector3(Math.Abs(offset.X), Math.Abs(offset.Y), Math.Abs(offset.Z));

            Vector3 normal = new Vector3(0.0f, 0.0f, 0.0f);

            if (offset.X >= offset.Y && offset.X >= offset.Z)
            {
                normal = new Vector3(Math.Sign(point.X - center.X), 0, 0);
            }
            else if (offset.Y >= offset.X && offset.Y >= offset.Z)
            {
                normal = new Vector3(0, Math.Sign(point.Y - center.Y), 0);
            }
            else if (offset.Z >= offset.X && offset.Z >= offset.Y)
            {
                normal = new Vector3(0, 0, Math.Sign(point.Z - center.Z));
            }

            return normal.Normalize();
        }

        // Swaps the two given values (Utils function)
        private void swap(ref float t0, ref float t1)
        {
            float tmp = t0;
            t0 = t1;
            t1 = tmp;
        }
    }
}
