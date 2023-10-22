using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracingApp
{
    internal sealed class Scene
    {
        private static readonly Lazy<Scene> instance = new Lazy<Scene>(() => new Scene());

        public static Scene Instance { get { return instance.Value; } }

        private Scene() 
        {
            this.materials = new List<Material>();
            this.transformations = new List<Transformation>();
            this.objects = new List<Object3D>();
            this.lights = new List<Light>();
        }

        private List<Material> materials;
        private List<Transformation> transformations;
        private List<Object3D> objects;
        private List<Light> lights;
        private Image? image;
        private Camera? camera;

        //read only
        public List<Material> Materials { get { return materials; } }

        public List<Transformation> Transformations { get { return transformations; } }

        public List<Object3D> Objects { get { return objects; } }

        public List<Light> Lights { get { return lights; } }

        public Image? Image { get { return image; } }

        public Camera? Camera { get { return camera; } }

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
