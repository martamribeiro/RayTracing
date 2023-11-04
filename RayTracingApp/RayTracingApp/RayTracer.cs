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
                Parser.ParseScene(openFile.FileName);
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
                    color += light.Intensity * hit.Material.Color * hit.Material.AmbientLight;

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
                            color += light.Intensity * hit.Material.Color * hit.Material.DiffuseLight * cosTheta;
                    }

                    if (rec > 0)
                    {
                        Vector3 r;
                        float cosThetaV = -(ray.Direction.Dot(hit.Normal));

                        //cálculo da componente de reflexão especular
                        if (hit.Material.SpecularLight > 0.0)
                        {
                            r = ray.Direction + 2.0f * cosThetaV * hit.Normal;
                            r = r.Normalize();

                            Ray reflectedRay = new Ray(r, hit.Point + 8.0E-6f * hit.Normal);

                            //chamar o raytracer recursivamente
                            Color3 reflectedColor = TraceRay(reflectedRay, rec - 1);

                            color = color + hit.Material.Color * (hit.Material.SpecularLight + (1.0 - hit.Material.SpecularLight) * Math.Pow(1.0 - cosThetaV, 5)) * reflectedColor;
                        }

                        //cálculo da componente de refração
                        if (hit.Material.RefractedLight > 0.0)
                        {
                            float eta = 1.0f / hit.Material.RefractiveIndex;

                            float cosThetaR = (float)Math.Sqrt(1.0f - eta * eta * (1.0f - cosThetaV));

                            if (cosThetaV < 0.0)
                            {
                                eta = hit.Material.RefractiveIndex;
                                cosThetaR = -cosThetaR;
                            }

                            r = eta * ray.Direction + (eta * cosThetaV - cosThetaR) * hit.Normal;
                            r = r.Normalize();

                            Ray refractedRay = new Ray(r, hit.Point);

                            Color3 refractedColor = TraceRay(refractedRay, rec - 1);
                            color = color + hit.Material.Color * hit.Material.RefractedLight * refractedColor;
                        }

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
                    int rec = 2;

                    if (j == 199 - 50 && i == 50)
                        Debug.Assert(true);

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