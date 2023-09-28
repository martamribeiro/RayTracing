using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Material
    {
        //rgb color
        private Color3 color;
        //light percentages:
        private float ambientLight;
        private float diffuseLight; 
        private float specularLight; 
        private float refractedLight; 
        //refractive index
        private float refractiveIndex;
        
        //read only

        public Color3 Color
        {
            get { return color; }
        }
        public float AmbientLight
        {
            get { return ambientLight; }
        }
        public float DiffuseLight
        {
            get { return diffuseLight; }
        }
        public float SpecularLight
        {
            get { return specularLight; }
        }
        public float RefractedLight
        {
            get { return refractedLight; }
        }
        public float RefractiveIndex
        {
            get { return refractiveIndex; }
        }

        public Material(Color3 color, float ambientLight, float diffuseLight, float specularLight, float refractedLight, float refractiveIndex)
        {
            this.color = color;
            this.ambientLight = ambientLight;
            this.diffuseLight = diffuseLight;
            this.specularLight = specularLight;
            this.refractedLight = refractedLight;
            this.refractiveIndex = refractiveIndex;
        }
    }
}
