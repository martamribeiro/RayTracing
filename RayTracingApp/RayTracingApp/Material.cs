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
        public Color3 color { get; set; }
        //light percentages:
        public float ambientLight { get; set; } 
        public float diffuseLight { get; set; } 
        public float specularLight { get; set; } 
        public float refractedLight { get; set; } 
        //refractive index
        public float refractiveIndex { get; set; } 

        public Material(Color3 color, float ambientLight, float diffuseLight, floar specularLight, float refractedLight, float refractiveIndex)
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
