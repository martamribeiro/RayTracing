using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal class Scene
    {
        private List<Material> materials = new List<Material>();
        private List<Transformation> transformations = new List<Transformation>();
        private List<Object3D> objects = new List<Object3D>();
        private List<Light> lights = new List<Light>();
        private Camera camera = null;
        
        // Constructor
        public Scene() {}

        public void addCamera(Camera camera) { this.camera = camera; }

        public void addMaterial(Material material) { this.materials.Add(material); }

        public void addTransformation(Transformation transformation) { this.transformations.Add(transformation);}

        public void addObject(Object3D object) { this.objects.Add(object); }

        public void addLight(Light light) { this.lights.Add(light); }
    }
}
