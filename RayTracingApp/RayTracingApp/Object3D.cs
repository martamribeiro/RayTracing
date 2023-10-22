using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal abstract class Object3D
    {
        public abstract bool Intersect(Ray ray, out Hit hit);
    }
}
