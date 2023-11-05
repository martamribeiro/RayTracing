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
        private Color3 ambientColor;
        private Color3 diffuseColor;
        private Color3 refractedColor;
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
        public Color3 AmbientColor
        {
            get { return ambientColor; }
        }
        public Color3 DiffuseColor
        {
            get { return diffuseColor; }
        }
        public Color3 RefractedColor
        {
            get { return refractedColor; }
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
            this.ambientColor = color * ambientLight;
            this.diffuseColor = color * diffuseLight;
            this.refractedColor = color * refractedLight;
        }
    }
}
