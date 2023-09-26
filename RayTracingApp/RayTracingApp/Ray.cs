using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Ray
    {
        //ray direction
        private Vector3 direction;
        //ray origin
        private Vector3 origin;

        //read only
        public Vector3 Direction
        {
            get { return direction; }
        }
        public Vector3 Origin
        {
            get { return origin; }
        }

        public Ray(Vector3 direction, Vector3 origin)
        {
            this.direction = direction;
            this.origin = origin;
        }

        //to copy other Ray objects
        public Ray(Ray other)
        {
            direction = new Vector3(other.Direction.X, other.Direction.Y, other.Direction.Z);
            origin = new Vector3(other.Origin.X, other.Origin.Y, other.Origin.Z);
        }

        public Vector3 PointAtParameter(float t)
        {
            return origin + direction * t;
        }

    }
}
