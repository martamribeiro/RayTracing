using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Light
    {
        // Transformation applied to the Camera
        private Transformation transformation;

        private Color3 intensity;

        //Getters
        public Transformation Transformation
        {
            get { return this.transformation; }
        }

        public Color3 Intensity
        {
            get { return this.intensity; }
        }

        public Light(Transformation transformation, Color3 intensity)
        {
            this.transformation = transformation;
            this.intensity = intensity;
        }
    }
}
