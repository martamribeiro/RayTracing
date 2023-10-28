using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Vector3
    {
        private float x;
        private float y;
        private float z;

        //read only
        public float X
        {
            get { return x; }
        }
        public float Y
        {
            get { return y; }
        }
        public float Z
        {
            get { return z; }
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //vector operations

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        //multiply/divide by scalar

        public static Vector3 operator *(Vector3 v, float scalar)
        {
            return new Vector3(v.X * scalar, v.Y * scalar, v.Z * scalar);
        }

        public static Vector3 operator *(float scalar, Vector3 v)
        {
            return v * scalar;
        }

        public static Vector3 operator /(Vector3 v, float scalar)
        {
            if (scalar == 0)
                throw new ArgumentException("Division by zero is not allowed.");

            return new Vector3(v.X / scalar, v.Y / scalar, v.Z / scalar);
        }

        //methods

        public float Length()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public Vector3 Normalize()
        {
            float length = Length();
            if (length == 0)
                throw new InvalidOperationException("Cannot normalize a zero-length vector.");

            return new Vector3(x / length, y / length, z / length);
        }

        public Vector3 changeX(float x)
        {
            return new Vector3(x, this.y, this.z);
        }

        public Vector3 changeY(float y)
        {
            return new Vector3(this.x, y, this.z);
        }

        public Vector3 changeZ(float z)
        {
            return new Vector3(this.x, this.y, z);
        }

        //scalar product

        public float Dot(Vector3 other)
        {
            return x * other.X + y * other.Y + z * other.Z;
        }

        //vetorial product

        public Vector3 Cross(Vector3 other)
        {
            return new Vector3(
                y * other.Z - z * other.Y,
                z * other.X - x * other.Z,
                x * other.Y - y * other.X
            );
        }

    }
}
