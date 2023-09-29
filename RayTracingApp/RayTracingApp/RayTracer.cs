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
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                // Used to recognize the "." as the decimal separator
                CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

                //read file content
                string[] lines = File.ReadAllLines(openFile.FileName);

                //section lines
                List<string> currentSectionLines = new List<string>();

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
                        //process section
                        ProcessSection(currentSectionLines);

                        //clear list and go to next section
                        currentSectionLines.Clear();
                    }
                }
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
        }

        private void ProcessMaterialSection(List<string> sectionLines)
        {
            //process the material section here
        }

        private void ProcessCameraSection(List<string> sectionLines)
        {
            //process the camera section here
        }

        private void ProcessLightSection(List<string> sectionLines)
        {
            //process the light section here
        }

        private void ProcessTrianglesSection(List<string> sectionLines)
        {
            //process the triangles section here
        }

        private void ProcessBoxSection(List<string> sectionLines)
        {
            //process the box section here
        }

        private void ProcessSphereSection(List<string> sectionLines)
        {
            //process the sphere section here
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}