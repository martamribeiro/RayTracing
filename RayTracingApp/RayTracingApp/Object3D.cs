using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal abstract class Object3D
    {
        protected Transformation transformation;
        protected Transformation inverseTransformation;
        protected Transformation invTransTransposed;

        public abstract bool Intersect(Ray ray, ref Hit hit);

        // Converts the given Global Point to the Local Coordinate system of the Object
        public Vector3 toLocalPoint(Vector3 point)
        {
            return toLocal(point, 1.0f);
        }

        // Converts the given Global Vector to the Local Coordinate system of the Object
        public Vector3 toLocalVec(Vector3 vec)
        {
            return toLocal(vec, 0.0f);
        }

        private Vector3 toLocal(Vector3 vec, float n)
        {
            Vector4 homoVec = Vector4.CartesianToHomogeneous(vec, n);
            Vector4 localHomoVec = inverseTransformation.ApplyTransformation(homoVec);

            return Vector4.HomogeneousToCartesian(localHomoVec);
        }

        // Converts the given Local Point to the Global Coordinate system
        public Vector3 toGlobalPoint(Vector3 point)
        {
            return toGlobal(point, 1.0f);
        }

        // Converts the given Local Vector to the Global Coordinate system
        public Vector3 toGlobalVec(Vector3 vec)
        {
            return toGlobal(vec, 0.0f);
        }

        private Vector3 toGlobal(Vector3 vec, float n)
        {
            Vector4 homoVec = Vector4.CartesianToHomogeneous(vec, n);
            Vector4 globalHomoVec = transformation.ApplyTransformation(homoVec);

            return Vector4.HomogeneousToCartesian(globalHomoVec);
        }

        // Converts the given Local Normal to the Global Coordinate System
        public Vector3 toGlobalNorm(Vector3 norm)
        {
            Vector4 normHom = Vector4.CartesianToHomogeneous(norm, 0.0f);
            Vector4 globalNormHom = invTransTransposed.ApplyTransformation(normHom);
            Vector3 globalNorm = Vector4.HomogeneousToCartesian(globalNormHom);

            return globalNorm.Normalize();
        }
    }
}
