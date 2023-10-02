using System.Diagnostics;
using System.Globalization;

namespace RayTracingApp
{
    public partial class RayTracer : Form
    {
        private Scene scene;

        public RayTracer()
        {
            this.scene = new Scene();
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
            if(openFile.ShowDialog() == DialogResult.OK)
            {
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
                        } else {
                            sections.Add(currentSectionLines);
                        }
                        
                        //create a new list and go to next section
                        currentSectionLines = new List<string>();
                    }
                }

                foreach (List<string> section in sections)
                {
                    if (section.Count() > 0) {
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

            this.scene.AddImage(image);
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

            this.scene.AddTransformation(transformation);
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

            this.scene.AddMaterial(material);
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

            Transformation transformation = this.scene.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Camera camera = new Camera(transformation, Convert.ToDouble(sectionLines[3]), Convert.ToDouble(sectionLines[4]));

            this.scene.AddCamera(camera);
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
            Transformation transformation = this.scene.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            // Get the color strings by spliting the corresponding line
            string[] colorStrings = sectionLines[3].Split(' ');

            // Construct the color. Need to convert the Strings to Doubles
            Color3 color = new Color3(Convert.ToDouble(colorStrings[0]), Convert.ToDouble(colorStrings[1]), Convert.ToDouble(colorStrings[2]));

            Light light = new Light(transformation, color);

            this.scene.AddLight(light);
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

            Transformation transformation = this.scene.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));
            Mesh mesh = new Mesh(transformation);

            for (int i = 3; i < sectionLines.Count - 1; i += 4)
            {
                Material material = this.scene.GetMaterialByIndex(Convert.ToInt32(sectionLines[i]));

                List<Vector3> vertices = new List<Vector3>();

                for (int j = 1; j <= 3; j++)
                {
                    string[] coordinates = sectionLines[i + j].Split(' ');

                    Vector3 vertex = new Vector3(
                        (float) Convert.ToDouble(coordinates[0]),
                        (float) Convert.ToDouble(coordinates[1]),
                        (float) Convert.ToDouble(coordinates[2])
                        );

                    vertices.Add(vertex);
                }

                Triangle triangle = new Triangle(vertices[0], vertices[1], vertices[2], material);
                mesh.AddTriangle(triangle);
            }

            this.scene.AddObject(mesh);
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

            Transformation transformation = this.scene.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Material material = this.scene.GetMaterialByIndex(Convert.ToInt32(sectionLines[3]));

            Box box = new Box(material, transformation);

            this.scene.AddObject(box);
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

            Transformation transformation = this.scene.GetTransformationByIndex(Convert.ToInt32(sectionLines[2]));

            Material material = this.scene.GetMaterialByIndex(Convert.ToInt32(sectionLines[3]));

            Sphere sphere = new Sphere(material, transformation);

            this.scene.AddObject(sphere);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}