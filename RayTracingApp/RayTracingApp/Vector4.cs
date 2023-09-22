using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Vector4
    {
        //similar to Vector3, but with extra coordenate w

        private float x;
        private float y;
        private float z;
        private float w;

        //read only
        public float X => x;
        public float Y => y;
        public float Z => z;
        public float W => w;

        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        //convertion methods

        //type should be 1 for points and 0 for vectors
        public static Vector4 CartesianToHomogeneous(Vector3 cartesian, float type)
        {
            if ((type != 0.0f) && (type != 1.0f)) //if invalid w value
                throw new InvalidOperationException("Cannot convert for homogeneous coordinates with w different from 0 or 1.");

            return new Vector4(cartesian.X, cartesian.Y, cartesian.Z, type);
        }

        public static Vector3 HomogeneousToCartesian(Vector4 homogeneous)
        {
            if (homogeneous.W == 0.0f) //if vector
            {
                float xCartesian = homogeneous.X;
                float yCartesian = homogeneous.Y;
                float zCartesian = homogeneous.Z;
                return new Vector3(xCartesian, yCartesian, zCartesian);
            } else if (homogeneous.W == 1.0f) //if point
            {
                float xCartesian = homogeneous.X / homogeneous.W;
                float yCartesian = homogeneous.Y / homogeneous.W;
                float zCartesian = homogeneous.Z / homogeneous.W;
                return new Vector3(xCartesian, yCartesian, zCartesian);
            }
            //if invalid w value
            throw new InvalidOperationException("Cannot convert from homogeneous coordinates with w different from 0 or 1.");
        }

    }
}
