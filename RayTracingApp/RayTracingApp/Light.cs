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

        private Transformation inverseTransformation;

        private Transformation invTransfTransposed;

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
            this.intensity = intensity;

            Transformation? fullTrans = Scene.Instance.Camera!.Transformation * transformation;

            this.transformation = (fullTrans != null) ? fullTrans : transformation;
            this.inverseTransformation = this.transformation.Inverse();
            this.invTransfTransposed = this.inverseTransformation.Transpose();
        }
    }
}
