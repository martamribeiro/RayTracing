using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace RayTracingApp
{
    public partial class RayTracer : Form
    {
        private int rec;
        private Bitmap renderedImage = null;
        private Semaphore paintSemaphore = new Semaphore(1, 1);

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

            //default field values
            cameraDistance.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Distance;
            cameraFieldOfView.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Fov;

            transformationOrientationVertical.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Transformation.Rotation.X;
            transformationOrientationHorizontal.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Transformation.Rotation.Z;
            transformationCenterX.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Transformation.Translation.X;
            transformationCenterY.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Transformation.Translation.Y;
            transformationCenterZ.Value = (decimal)RayTracingApp.Scene.Instance.Camera.Transformation.Translation.Z;

            rendererRecursionDepth.Value = 2;
            lightAmbientReflection.Checked = true;
            lightRefraction.Checked = true;
            lightSpecularReflection.Checked = true;
            lightDiffuseReflection.Checked = true;

            imageResolutionHorizontal.Value = RayTracingApp.Scene.Instance.Image.ResX;
            imageResolutionVertical.Value = RayTracingApp.Scene.Instance.Image.ResY;
        }

        private Color3 TraceRay(Ray ray, int rec)
        {
            Hit hit = new Hit();

            foreach (Object3D currObject in RayTracingApp.Scene.Instance.Objects)
                currObject.Intersect(ray, ref hit);

            if (hit.Found)
            {
                Color3 color = new Color3(0.0, 0.0, 0.0);

                foreach (Light light in RayTracingApp.Scene.Instance.Lights)
                {

                    if (lightAmbientReflection.Checked == true)
                    {
                        //c�lculo da componente de luz ambiente
                        color += light.Intensity * hit.Material.AmbientColor;
                    }
                    if (lightDiffuseReflection.Checked == true)
                    {
                        //c�lculo da componente de reflex�o difusa
                        Vector3 l = Vector4.Subtract(light.Transformation.ApplyTransformation(new Vector4(0.0f, 0.0f, 0.0f, 1.0f)), hit.Point);
                        float tLight = l.Length();
                        l = l.Normalize();
                        double cosTheta = hit.Normal.Dot(l);

                        if (cosTheta > 0.0)
                        {
                            Ray shadowRay = new Ray(l, hit.Point + 8.0E-6f * hit.Normal);
                            Hit shadowHit = new Hit();

                            shadowHit.Tmin = tLight;

                            foreach (Object3D currObject in RayTracingApp.Scene.Instance.Objects)
                            {
                                currObject.Intersect(shadowRay, ref shadowHit);

                                if (shadowHit.Found)
                                    break;
                            }


                            if (!shadowHit.Found)
                                color += light.Intensity * hit.Material.DiffuseColor * cosTheta;
                        }
                    }

                    if (rec > 0)
                    {
                        Vector3 r;
                        float cosThetaV = -(ray.Direction.Dot(hit.Normal));

                        if (lightSpecularReflection.Checked == true)
                        {
                            //c�lculo da componente de reflex�o especular
                            if (hit.Material.SpecularLight > 0.0)
                            {
                                r = ray.Direction + 2.0f * cosThetaV * hit.Normal;
                                r = r.Normalize();

                                Ray reflectedRay = new Ray(r, hit.Point + 8.0E-5f * hit.Normal);

                                //chamar o raytracer recursivamente
                                Color3 reflectedColor = TraceRay(reflectedRay, rec - 1);

                                //color = color + hit.Material.Color * hit.Material.SpecularLight * reflectedColor;
                                color = color + hit.Material.Color * (hit.Material.SpecularLight + (1.0 - hit.Material.SpecularLight) * Math.Pow(1.0 - cosThetaV, 5)) * reflectedColor;
                            }
                        }

                        if (lightRefraction.Checked == true)
                        {
                            //c�lculo da componente de refra��o
                            if (hit.Material.RefractedLight > 0.0)
                            {
                                float eta = 1.0f / hit.Material.RefractiveIndex;

                                float cosThetaR = (float)Math.Sqrt(1.0f - eta * eta * (1.0f - cosThetaV * cosThetaV));

                                if (cosThetaV < 0.0)
                                {
                                    eta = hit.Material.RefractiveIndex;
                                    cosThetaR = -cosThetaR;
                                }

                                r = eta * ray.Direction + (eta * cosThetaV - cosThetaR) * hit.Normal;
                                r = r.Normalize();

                                Ray refractedRay = new Ray(r, hit.Point + 8.0E-5f * r);

                                Color3 refractedColor = TraceRay(refractedRay, rec - 1);
                                color = color + hit.Material.RefractedColor * refractedColor;
                            }
                        }

                    }

                }
                return color / RayTracingApp.Scene.Instance.Lights.Count;
                //return hit.Material.Color;
            }

            return RayTracingApp.Scene.Instance.Image!.Color;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (RayTracingApp.Scene.Instance.Camera != null)
            {
                rec = 2;
                //ver valores UI
                RayTracingApp.Scene.Instance.Camera.Distance = (double)cameraDistance.Value;
                RayTracingApp.Scene.Instance.Camera.Fov = (double)cameraFieldOfView.Value;

                Transformation cameraTransformation = new Transformation();
                cameraTransformation = cameraTransformation.Translate((double)transformationCenterX.Value, (double)transformationCenterY.Value, (double)transformationCenterZ.Value);
                cameraTransformation = cameraTransformation.RotateX((double)transformationOrientationVertical.Value);
                cameraTransformation = cameraTransformation.RotateZ((double)transformationOrientationHorizontal.Value);

                RayTracingApp.Scene.Instance.Camera.Transformation = cameraTransformation;

                foreach (Object3D obj in RayTracingApp.Scene.Instance.Objects)
                    obj.recalcTransformations();

                foreach (Light light in RayTracingApp.Scene.Instance.Lights)
                    light.recalcTransformations();

                rec = (int)rendererRecursionDepth.Value;

                RayTracingApp.Scene.Instance.Image!.ResX = (int)imageResolutionHorizontal.Value;
                RayTracingApp.Scene.Instance.Image!.ResY = (int)imageResolutionVertical.Value;
            }

            //inicializa o painel novamente para iniciar o processo de pintura
            sceneContainer.Invalidate();
        }

        private void sceneContainer_Paint(object sender, PaintEventArgs e)
        {
            if (RayTracingApp.Scene.Instance.Camera == null)
                return;

            int Vres = RayTracingApp.Scene.Instance.Image.ResY;
            int Hres = RayTracingApp.Scene.Instance.Image.ResX;

            progressBar.Minimum = 0;
            progressBar.Value = 0;
            progressBar.Maximum = Vres * Hres;

            renderedImage = new Bitmap(Hres, Vres);

            int AAValue = GetAAValue();

            Thread trd = new Thread(new ThreadStart(() => { Paint(AAValue); }));
            trd.Name = "Child";

            trd.Start();
            Paint(AAValue);
            trd.Join();

            e.Graphics.DrawImage(renderedImage, 0, 0);
        }

        private int GetAAValue()
        {
            if (AAOff.Checked)
                return 2;

            if (AALow.Checked)
                return 3;

            if (AAMedium.Checked)
                return 4;

            return 5;
        }

        private void Paint(int AAValue)
        {
            if (RayTracingApp.Scene.Instance.Camera == null)
                return;

            //object Graphics to draw on the panel
            //Graphics g = e.Graphics;

            //raytracer
            double distance = RayTracingApp.Scene.Instance.Camera.Distance;
            Vector3 origin = new Vector3(0, 0, (float)distance);

            double fieldOfView = RayTracingApp.Scene.Instance.Camera.Fov * Math.PI / 180.0;
            double height = 2.0 * distance * Math.Tan(fieldOfView / 2.0);

            if (RayTracingApp.Scene.Instance.Image == null)
                return;

            int Vres = RayTracingApp.Scene.Instance.Image.ResY;
            int Hres = RayTracingApp.Scene.Instance.Image.ResX;
            double width = height * Hres / Vres;
            double s = height / Vres;

            int start = Thread.CurrentThread.Name == "Child" ? 1 : 0;

            paintSemaphore.WaitOne();
            using (Graphics g = Graphics.FromImage(renderedImage))
            {
                paintSemaphore.Release();
                //Hres -> horizontal resolution Vres -> vertical resolution
                for (int j = start; j < Vres; j += 2)
                {
                    for (int i = 0; i < Hres; i++)
                    {
                        Color3 color = new Color3(0, 0, 0);

                        float pixelDivision = 1.0f / AAValue;

                        for (int k = 1; k < AAValue; k++)
                        {
                            for (int l = 1; l < AAValue; l++)
                            {
                                //P.x, P.y and P.z for the center of the pixel[i][j]
                                double P_x = (i + pixelDivision * k) * s - width / 2.0;
                                double P_y = -(j + pixelDivision * l) * s + height / 2.0;
                                double P_z = 0.0; // the projection plane is plane z = 0.0

                                //direction vector
                                Vector3 direction = new Vector3((float)P_x, (float)P_y, (float)-distance);

                                //normalize the direction vector
                                direction = direction.Normalize();
                                //construct the ray
                                Ray ray = new Ray(direction, origin);

                                //call traceRay() function
                                color += TraceRay(ray, rec);
                            }
                        }

                        color = color / (int)Math.Pow((AAValue - 1), 2);

                        //check range R G B need to be between 0 and 1
                        color.CheckRange();

                        //convert color format
                        int red = (int)(255.0 * color.ColR);
                        int green = (int)(255.0 * color.ColG);
                        int blue = (int)(255.0 * color.ColB);
                        Color pixelColor = Color.FromArgb(red, green, blue);

                        SolidBrush pixelBrush = new SolidBrush(pixelColor);

                        paintSemaphore.WaitOne();

                        //draw a 1x1 pixel on panel
                        g.FillRectangle(pixelBrush, i, j, 1, 1);

                        paintSemaphore.Release();

                        UpProgressBar();
                    }
                }
            }
        }

        private void UpProgressBar()
        {
            if (progressBar.InvokeRequired)
                progressBar.BeginInvoke(() => { UpProgressBar(); });
            else
                progressBar.Value += 1;
        }

        private void saveImageButton_Click(object sender, EventArgs e)
        {
            if (renderedImage == null)
            {
                MessageBox.Show("There is no content to save.", "Warning");
                return;
            }

            //Save the already rendered image
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files|*.png";
            saveFileDialog.Title = "Save Image";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                renderedImage.Save(saveFileDialog.FileName);
                MessageBox.Show("Image successfully saved.", "Success");
            }
        }
    }
}