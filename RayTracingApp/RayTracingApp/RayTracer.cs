using System.Diagnostics;
using System.Globalization;

namespace RayTracingApp
{
    public partial class RayTracer : Form
    {
        public RayTracer()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //open text file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = @"C:\txt";
            openFile.Title = "Browse Text Files Only";
            openFile.Filter = "Text Files Only (*.txt) | *.txt";
            openFile.DefaultExt = "txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Scene.Instance.resetScene();
                // Used to recognize the "." as the decimal separator
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

                //read file content
                string[] lines = File.ReadAllLines(openFile.FileName);

                //section lines
                List<string> currentSectionLines = new List<string>();
                List<List<string>> sections = new List<List<string>>();

                //parsing
                foreach (string line in lines)
                {
                    string trimmedLine = line.Trim();

                    //if empty
                    if (string.IsNullOrEmpty(trimmedLine))
                    {
                        //ígnore
                        continue;
                    }

                    //add line to current section
                    currentSectionLines.Add(trimmedLine);

                    //if section ended
                    if (trimmedLine.EndsWith("}"))
                    {
                        if (currentSectionLines.First() == "Material" || currentSectionLines.First() == "Transformation")
                        {
                            //process section
                            ProcessSection(currentSectionLines);
                        }
                        else
                        {
                            sections.Add(currentSectionLines);
                        }

                        //create a new list and go to next section
                        currentSectionLines = new List<string>();
                    }
                }

                foreach (List<string> section in sections)
                {
                    if (section.Count() > 0)
                    {
                        ProcessSection(section);
                    }
                }

                Debug.WriteLine("Finished Constructing Scene");
            }
        }

        //process each section
        private void ProcessSection(List<string> sectionLines)
        {
            switch (sectionLines.First())
            {
                case "Image":
                    ProcessImageSection(sectionLines);
                    break;
                case "Transformation":
                    ProcessTransformationSection(sectionLines);
                    break;
                case "Material":
                    ProcessMaterialSection(sectionLines);
                    break;
                case "Camera":
                    ProcessCameraSection(sectionLines);
                    break;
                case "Light":
                    ProcessLightSection(sectionLines);
                    break;
                case "Triangles":
                    ProcessTrianglesSection(sectionLines);
                    break;
                case "Box":
                    ProcessBoxSection(sectionLines);
                    break;
                case "Sphere":
                    ProcessSphereSection(sectionLines);
                    break;
                default:
                    //unkwnown section
                    break;
            }
        }

        private void ProcessImageSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Image
             * {
             * horizontal vertical
             * red green blue
             * }
             */

            // Get the resolution strings by spliting the corresponding line
            string[] resolutionStrings = sectionLines[2].Split(' ');

            // Get the color strings by spliting the corresponding line
            string[] colorStrings = sectionLines[3].Split(' ');

            // Construct the color. Need to convert the Strings to Doubles
            Color3 color = new Color3(Convert.ToDouble(colorStrings[0]), Convert.ToDouble(colorStrings[1]), Convert.ToDouble(colorStrings[2]));

            // Construct the Image using the Color and by converting the resolution strings to Int
            Image image = new Image(Convert.ToInt32(resolutionStrings[0]), Convert.ToInt32(resolutionStrings[1]), color);

            Scene.Instance.AddImage(image);
        }

        private void ProcessTransformationSection(List<string> sectionLines)
        {
            /* The SectionLines Format (All lines are optional):
             * Transformation
             * {
             * T x y z 
             * Rx angle
             * Ry angle
             * Rz angle
             * S x y z
             * }
             */

            // Constructs the Identity Transformation
            Transformation transformation = new Transformation();

            // For every line between the second and last lines
            for (int i = 2; i < sectionLines.Count - 1; i++)
            {
                string[] splitedLine = sectionLines[i].Split(" ");

                switch (splitedLine[0])
                {
                    case "T": // Translation
                        transformation = transformation.Translate(Convert.ToDouble(splitedLine[1]), Convert.ToDouble(splitedLine[2]), Convert.ToDouble(splitedLine[3]));
                        break;
                    case "Rx": // Rotate in the X axis
                        transformation = transformation.RotateX(Convert.ToDouble(splitedLine[1]));
                        break;
                    case "Ry": // Rotate in the Y axis
                        transformation = transformation.RotateY(Convert.ToDouble(splitedLine[1]));
                        break;
                    case "Rz": // Rotate in the Z axis
                        transformation = transformation.RotateZ(Convert.ToDouble(splitedLine[1]));
                        break;
                    case "S": // Scale
                        transformation = transformation.Scale(Convert.ToDouble(splitedLine[1]), Convert.ToDouble(splitedLine[2]), Convert.ToDouble(splitedLine[3]));
                        break;
                    default:
                        //unkwnown
                        break;
                }
            }

            Scene.Instance.AddTransformation(transformation);
        }

        private void ProcessMaterialSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Material
             * {
             * red green blue
             * ambient diffuse specular refraction refraction_index
             * }
             */

            // Get the color strings by spliting the corresponding line
            string[] colorStrings = sectionLines[2].Split(' ');

            // Construct the color. Need to convert the Strings to Doubles
            Color3 color = new Color3(Convert.ToDouble(colorStrings[0]), Convert.ToDouble(colorStrings[1]), Convert.ToDouble(colorStrings[2]));

            string[] coefficientsStrings = sectionLines[3].Split(' ');

            Material material = new Material(
                color,
                (float)Convert.ToDouble(coefficientsStrings[0]),
                (float)Convert.ToDouble(coefficientsStrings[1]),
                (float)Convert.ToDouble(coefficientsStrings[2]),
                (float)Convert.ToDouble(coefficientsStrings[3]),
                (float)Convert.ToDouble(coefficientsStrings[4])
                );

            Scene.Instance.AddMaterial(material);
        }

        private void ProcessCameraSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Camera
             * {
             * transformation
             * distance
             * fov
             * }
             */

            Transformation transformation = Scene.Instance.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Camera camera = new Camera(transformation, Convert.ToDouble(sectionLines[3]), Convert.ToDouble(sectionLines[4]));

            Scene.Instance.AddCamera(camera);
        }

        private void ProcessLightSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Light
             * {
             * transformation
             * red green blue
             * }
             */

            // Get the Transformation index and the corresponding Transformation (stored in the scene)
            Transformation transformation = Scene.Instance.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            // Get the color strings by spliting the corresponding line
            string[] colorStrings = sectionLines[3].Split(' ');

            // Construct the color. Need to convert the Strings to Doubles
            Color3 color = new Color3(Convert.ToDouble(colorStrings[0]), Convert.ToDouble(colorStrings[1]), Convert.ToDouble(colorStrings[2]));

            Light light = new Light(transformation, color);

            Scene.Instance.AddLight(light);
        }

        private void ProcessTrianglesSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Triangles
             * {
             * Transformation (index)
             * Material (index)
             * x1 y1 z1
             * x2 y2 z2
             * x3 y3 z3
             * Material (index)
             * x4 y4 z4
             * x5 y5 z5
             * x6 y6 z6
             * ( . . . )
             * }
             */

            Transformation transformation = Scene.Instance.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));
            Mesh mesh = new Mesh(transformation);
            
            Vector3 minBound = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
            Vector3 maxBound = new Vector3(float.MinValue, float.MinValue, float.MinValue);

            for (int i = 3; i < sectionLines.Count - 1; i += 4)
            {
                Material material = Scene.Instance.GetMaterialByIndex(Convert.ToInt32(sectionLines[i]));

                List<Vector3> vertices = new List<Vector3>();

                for (int j = 1; j <= 3; j++)
                {
                    string[] coordinates = sectionLines[i + j].Split(' ');

                    Vector3 vertex = new Vector3(
                        (float)Convert.ToDouble(coordinates[0]),
                        (float)Convert.ToDouble(coordinates[1]),
                        (float)Convert.ToDouble(coordinates[2])
                        );

                    vertices.Add(vertex);
                }

                Triangle triangle = new Triangle(vertices[0], vertices[1], vertices[2], material, transformation);
                mesh.AddTriangle(triangle);

                for (int j = 0; j < 3; j++)
                {
                    if (minBound.X > vertices[j].X)
                        minBound = minBound.changeX(vertices[j].X);

                    if (minBound.Y > vertices[j].Y)
                        minBound = minBound.changeY(vertices[j].Y);

                    if (minBound.Z > vertices[j].Z)
                        minBound = minBound.changeZ(vertices[j].Z);
                }

                for (int j = 0; j < 3; j++)
                {
                    if (maxBound.X < vertices[j].X)
                        maxBound = maxBound.changeX(vertices[j].X);

                    if (maxBound.Y < vertices[j].Y)
                        maxBound = maxBound.changeY(vertices[j].Y);

                    if (maxBound.Z < vertices[j].Z)
                        maxBound = maxBound.changeZ(vertices[j].Z);
                }
            }

            mesh.updateBoundingBox(minBound, maxBound);
            Scene.Instance.AddObject(mesh);
        }

        private void ProcessBoxSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Box
             * {
             * Transformation (index)
             * Material (index)
             * }
             */

            Transformation transformation = Scene.Instance.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Material material = Scene.Instance.GetMaterialByIndex(Convert.ToInt32(sectionLines[3]));

            Box box = new Box(material, transformation);

            Scene.Instance.AddObject(box);
        }

        private void ProcessSphereSection(List<string> sectionLines)
        {
            /* The SectionLines Format:
             * Sphere
             * {
             * Transformation (index)
             * Material (index)
             * }
             */

            Transformation transformation = Scene.Instance.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Material material = Scene.Instance.GetMaterialByIndex(Convert.ToInt32(sectionLines[3]));

            Sphere sphere = new Sphere(material, transformation);

            Scene.Instance.AddObject(sphere);
        }

        private Color3 TraceRay(Ray ray, int rec)
        {
            Hit hit = new Hit();

            foreach (Object3D currObject in Scene.Instance.Objects)
                currObject.Intersect(ray, ref hit);

            if (hit.Found)
            {
                Color3 color = new Color3(0.0, 0.0, 0.0);
                foreach (Light light in Scene.Instance.Lights)
                {
                    //cálculo da componente de luz ambiente
                    color = color + (light.Intensity * hit.Material.Color * hit.Material.AmbientLight);

                    //cálculo da componente de reflexão difusa

                    Vector3 l = Vector4.Subtract(light.Transformation.ApplyTransformation(new Vector4(0.0f, 0.0f, 0.0f, 1.0f)), hit.Point);
                    float tLight = l.Length();
                    l = l.Normalize();
                    double cosTheta = hit.Normal.Dot(l);
            
                    if (cosTheta > 0.0)
                    {
                        Ray shadowRay = new Ray(l, hit.Point + 8.0E-6f * hit.Normal);
                        Hit shadowHit = new Hit();

                        shadowHit.Tmin = tLight;

                        foreach (Object3D currObject in Scene.Instance.Objects) 
                        {
                            currObject.Intersect(shadowRay, ref shadowHit);

                            if (shadowHit.Found)
                                break;
                        }


                        if (!shadowHit.Found)
                            color = color + (light.Intensity * hit.Material.Color * hit.Material.DiffuseLight * cosTheta);
                    }

                }
                return color / Scene.Instance.Lights.Count;
                //return hit.Material.Color;
            }

            return Scene.Instance.Image!.Color;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            sceneContainer.Invalidate();
        }

        private void sceneContainer_Paint(object sender, PaintEventArgs e)
        {
            if (Scene.Instance.Camera == null)
                return;

            //object Graphics to draw on the panel
            Graphics g = e.Graphics;

            //raytracer
            double distance = Scene.Instance.Camera.Distance;
            Vector3 origin = new Vector3(0, 0, (float)distance);

            double fieldOfView = Scene.Instance.Camera.Fov * Math.PI / 180.0;
            double height = 2.0 * distance * Math.Tan(fieldOfView / 2.0);

            if (Scene.Instance.Image == null)
                return;

            int Vres = Scene.Instance.Image.ResY;
            int Hres = Scene.Instance.Image.ResX;
            double width = height * Hres / Vres;
            double s = height / Vres;

            //Hres -> horizontal resolution Vres -> vertical resolution
            for (int j = 0; j < Vres; j++)
            {
                for (int i = 0; i < Hres; i++)
                {
                    //P.x, P.y and P.z for the center of the pixel[i][j]
                    double P_x = (i + 0.5) * s - width / 2.0;
                    double P_y = -(j + 0.5) * s + height / 2.0;
                    double P_z = 0.0; // the projection plane is plane z = 0.0
                    //direction vector
                    Vector3 direction = new Vector3((float)P_x, (float)P_y, (float)-distance);
                    //normalize the direction vector
                    direction = direction.Normalize();
                    //construct the ray
                    Ray ray = new Ray(direction, origin);
                    //max level of recursivity
                    int rec = 1;
                    //call traceRay() function
                    Color3 color = TraceRay(ray, rec);
                    //check range R G B need to be between 0 and 1
                    color.CheckRange();
                    //convert color format
                    int red = (int)(255.0 * color.ColR);
                    int green = (int)(255.0 * color.ColG);
                    int blue = (int)(255.0 * color.ColB);
                    Color pixelColor = Color.FromArgb(red, green, blue);
                    SolidBrush pixelBrush = new SolidBrush(pixelColor);
                    //draw a 1x1 pixel on panel
                    g.FillRectangle(pixelBrush, i, j, 1, 1);
                }

            }
        }

        private void labelRayTracer_Click(object sender, EventArgs e)
        {

        }

        private void RayTracer_Load(object sender, EventArgs e)
        {

        }
    }
}