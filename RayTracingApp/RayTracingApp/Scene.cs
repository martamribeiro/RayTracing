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
        private Image image = null;
        private Camera camera = null;
        
        // Constructor
        public Scene() {}

        public void AddCamera(Camera camera) { this.camera = camera; }

        public void AddImage(Image image) { this.image = image; }

        public void AddMaterial(Material material) { this.materials.Add(material); }

        public void AddTransformation(Transformation transformation) { this.transformations.Add(transformation);}

        public void AddObject(Object3D newObject) { this.objects.Add(newObject); }

        public void AddLight(Light light) { this.lights.Add(light); }

        public Material GetMaterialByIndex(int index) { return this.materials[index];}

        public Transformation GetTransformationByIndex(int index) { return this.transformations[index];}
    }
}
