using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Camera
    {
        // Transformation applied to the Camera
        private Transformation transformation;

        private double distance;

        // Field of View
        private double fov;

        //Getters
        public Transformation Transformation
        {
            get { return this.transformation; }
        }

        public double Distance
        {
            get { return this.distance; }
            set { this.distance = value; }
        }

        public double Fov
        {
            get { return this.fov; }
            set { this.fov = value; }
        }

        public Camera(Transformation transformation, double distance, double fov)
        {
            this.transformation = transformation;
            this.distance = distance;
            this.fov = fov;
        }
    }
}
