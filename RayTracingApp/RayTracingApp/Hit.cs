using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Hit
    {
        
        //hit color
        public Color3 color { get; set; }
        //material
        public Material material { get; set; }
        //normal
        public Vector3 vector3 { get; set; }
    }
}
