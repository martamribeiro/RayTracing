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
            this.transformation = transformation;

            Vector3 vmin = new Vector3(-1, -1, -1);
            Vector3 vmax = new Vector3(1, 1, 1);

            bounds[0] = vmin;
            bounds[1] = vmax;
        }

        // Returns True if the Ray intersects with the Box
        public override bool Intersect(Ray ray, ref Hit hit)
        {
            float tnear, tfar;
            float t1, t2;

            // Calculate intersection for X axis
            if (ray.Direction.X == 0 && (ray.Origin.X < bounds[0].X || ray.Origin.X > bounds[0].X))
                return false;

            tnear = (bounds[0].X - ray.Origin.X) / ray.Direction.X;
            tfar = (bounds[1].X - ray.Origin.X) / ray.Direction.X;

            if (tnear > tfar)
                swap(ref tnear, ref tfar);

            if (tnear > tfar || tfar < 0)
                return false;

            // Calculate intersection for Y axis
            if (ray.Direction.Y == 0 && (ray.Origin.Y < bounds[0].Y || ray.Origin.Y > bounds[0].Y))
                return false;

            t1 = (bounds[0].Y - ray.Origin.Y) / ray.Direction.Y;
            t2 = (bounds[1].Y - ray.Origin.Y) / ray.Direction.Y;

            if (t1 > t2)
                swap(ref t1, ref t2);

            if (t1 > tnear)
                tnear = t1;

            if (t2 < tfar)
                tfar = t2;

            if (tnear > tfar || tfar < 0)
                return false;

            // Calculate intersection for Z axis
            if (ray.Direction.Z == 0 && (ray.Origin.Z < bounds[0].Z || ray.Origin.Z > bounds[0].Z))
                return false;

            t1 = (bounds[0].Z - ray.Origin.Z) / ray.Direction.Z;
            t2 = (bounds[1].Z - ray.Origin.Z) / ray.Direction.Z;

            if (t1 > t2)
                swap(ref t1, ref t2);

            if (t1 > tnear)
                tnear = t1;

            if (t2 < tfar)
                tfar = t2;

            if (tnear > tfar || tfar < 0)
                return false;

            // Update Hit if this is the closest intersection
            if (tnear > 1.0E-6 && tnear < hit.Tmin)
            {
                Vector3 p = ray.Origin + ray.Direction * tnear;
                Vector3 norm = CalculateNormal(p);

                hit = new Hit(tnear, this.Material.Color, true, this.material, p, norm, tnear);
            }

            return true;
        }

        public Vector3 CalculateNormal(Vector3 point)
        {

            Vector3 center = (this.bounds[0] + this.bounds[1]) / 2.0f;
            Vector3 size = (this.bounds[0] - this.bounds[1]) / 2.0f;
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

            return normal;
        }

    private void swap(ref float t0, ref float t1)
        {
            float tmp = t0;
            t0 = t1;
            t1 = tmp;
        }
    }
}
