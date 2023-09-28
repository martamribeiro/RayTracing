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
            //process the image section here
        }

        private void ProcessTransformationSection(List<string> sectionLines)
        {
            //process the transformation section here
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