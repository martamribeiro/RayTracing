namespace RayTracingApp
{
    partial class RayTracer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sceneContainer = new Panel();
            progressBar = new ProgressBar();
            statusStrip1 = new StatusStrip();
            loadButton = new Button();
            groupImageResolution = new GroupBox();
            imageResolutionVertical = new NumericUpDown();
            labelImageResolutionVertical = new Label();
            imageResolutionHorizontal = new NumericUpDown();
            labelImageResolutionHorizontal = new Label();
            saveImageButton = new Button();
            exitButton = new Button();
            groupRenderer = new GroupBox();
            rendererRecursionDepth = new NumericUpDown();
            labelRendererRecursionDepth = new Label();
            startButton = new Button();
            groupCamera = new GroupBox();
            cameraFieldOfView = new NumericUpDown();
            labelCameraFieldOfView = new Label();
            cameraDistance = new NumericUpDown();
            labelCameraDistance = new Label();
            labelRayTracer = new Label();
            groupTransformation = new GroupBox();
            labelTransformationCenterZ = new Label();
            labelTransformationCenterY = new Label();
            transformationCenterZ = new NumericUpDown();
            transformationCenterY = new NumericUpDown();
            transformationCenterX = new NumericUpDown();
            labelTransformationCenterX = new Label();
            transformationOrientationVertical = new NumericUpDown();
            labelTransformationOrientation = new Label();
            labelTransformationOrientationVertical = new Label();
            labelTransformationCenter = new Label();
            transformationOrientationHorizontal = new NumericUpDown();
            labelTransformationOrientationHorizontal = new Label();
            groupLight = new GroupBox();
            lightRefraction = new CheckBox();
            lightSpecularReflection = new CheckBox();
            lightDiffuseReflection = new CheckBox();
            lightAmbientReflection = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            groupBox1 = new GroupBox();
            AAHigh = new RadioButton();
            AAMedium = new RadioButton();
            AALow = new RadioButton();
            AAOff = new RadioButton();
            groupImageResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imageResolutionVertical).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageResolutionHorizontal).BeginInit();
            groupRenderer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rendererRecursionDepth).BeginInit();
            groupCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cameraFieldOfView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cameraDistance).BeginInit();
            groupTransformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)transformationCenterZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transformationCenterY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transformationCenterX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transformationOrientationVertical).BeginInit();
            ((System.ComponentModel.ISupportInitialize)transformationOrientationHorizontal).BeginInit();
            groupLight.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // sceneContainer
            // 
            sceneContainer.BackColor = SystemColors.ControlLightLight;
            sceneContainer.Location = new Point(332, 56);
            sceneContainer.Name = "sceneContainer";
            sceneContainer.Size = new Size(450, 450);
            sceneContainer.TabIndex = 0;
            sceneContainer.Paint += sceneContainer_Paint;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(332, 25);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(450, 25);
            progressBar.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 570);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(787, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // loadButton
            // 
            loadButton.Location = new Point(23, 64);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(298, 32);
            loadButton.TabIndex = 2;
            loadButton.Text = "Load...";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // groupImageResolution
            // 
            groupImageResolution.Controls.Add(imageResolutionVertical);
            groupImageResolution.Controls.Add(labelImageResolutionVertical);
            groupImageResolution.Controls.Add(imageResolutionHorizontal);
            groupImageResolution.Controls.Add(labelImageResolutionHorizontal);
            groupImageResolution.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupImageResolution.Location = new Point(332, 512);
            groupImageResolution.Name = "groupImageResolution";
            groupImageResolution.Size = new Size(248, 54);
            groupImageResolution.TabIndex = 3;
            groupImageResolution.TabStop = false;
            groupImageResolution.Text = "Image Resolution";
            // 
            // imageResolutionVertical
            // 
            imageResolutionVertical.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            imageResolutionVertical.Location = new Point(192, 21);
            imageResolutionVertical.Maximum = new decimal(new int[] { 450, 0, 0, 0 });
            imageResolutionVertical.Name = "imageResolutionVertical";
            imageResolutionVertical.Size = new Size(46, 23);
            imageResolutionVertical.TabIndex = 6;
            // 
            // labelImageResolutionVertical
            // 
            labelImageResolutionVertical.AutoSize = true;
            labelImageResolutionVertical.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelImageResolutionVertical.Location = new Point(139, 23);
            labelImageResolutionVertical.Name = "labelImageResolutionVertical";
            labelImageResolutionVertical.Size = new Size(45, 15);
            labelImageResolutionVertical.TabIndex = 5;
            labelImageResolutionVertical.Text = "Vertical";
            // 
            // imageResolutionHorizontal
            // 
            imageResolutionHorizontal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            imageResolutionHorizontal.Location = new Point(78, 21);
            imageResolutionHorizontal.Maximum = new decimal(new int[] { 450, 0, 0, 0 });
            imageResolutionHorizontal.Name = "imageResolutionHorizontal";
            imageResolutionHorizontal.Size = new Size(46, 23);
            imageResolutionHorizontal.TabIndex = 4;
            // 
            // labelImageResolutionHorizontal
            // 
            labelImageResolutionHorizontal.AutoSize = true;
            labelImageResolutionHorizontal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelImageResolutionHorizontal.Location = new Point(8, 23);
            labelImageResolutionHorizontal.Name = "labelImageResolutionHorizontal";
            labelImageResolutionHorizontal.Size = new Size(62, 15);
            labelImageResolutionHorizontal.TabIndex = 0;
            labelImageResolutionHorizontal.Text = "Horizontal";
            // 
            // saveImageButton
            // 
            saveImageButton.Location = new Point(586, 526);
            saveImageButton.Name = "saveImageButton";
            saveImageButton.Size = new Size(95, 32);
            saveImageButton.TabIndex = 4;
            saveImageButton.Text = "Save Image...";
            saveImageButton.UseVisualStyleBackColor = true;
            saveImageButton.Click += saveImageButton_Click;
            // 
            // exitButton
            // 
            exitButton.Location = new Point(687, 526);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(93, 32);
            exitButton.TabIndex = 5;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // groupRenderer
            // 
            groupRenderer.Controls.Add(rendererRecursionDepth);
            groupRenderer.Controls.Add(labelRendererRecursionDepth);
            groupRenderer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupRenderer.Location = new Point(23, 512);
            groupRenderer.Name = "groupRenderer";
            groupRenderer.Size = new Size(170, 54);
            groupRenderer.TabIndex = 7;
            groupRenderer.TabStop = false;
            groupRenderer.Text = "Renderer";
            // 
            // rendererRecursionDepth
            // 
            rendererRecursionDepth.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            rendererRecursionDepth.Location = new Point(112, 19);
            rendererRecursionDepth.Name = "rendererRecursionDepth";
            rendererRecursionDepth.Size = new Size(46, 23);
            rendererRecursionDepth.TabIndex = 4;
            // 
            // labelRendererRecursionDepth
            // 
            labelRendererRecursionDepth.AutoSize = true;
            labelRendererRecursionDepth.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelRendererRecursionDepth.Location = new Point(7, 23);
            labelRendererRecursionDepth.Name = "labelRendererRecursionDepth";
            labelRendererRecursionDepth.Size = new Size(94, 15);
            labelRendererRecursionDepth.TabIndex = 0;
            labelRendererRecursionDepth.Text = "Recursion Depth";
            // 
            // startButton
            // 
            startButton.Location = new Point(199, 526);
            startButton.Name = "startButton";
            startButton.Size = new Size(108, 32);
            startButton.TabIndex = 8;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // groupCamera
            // 
            groupCamera.Controls.Add(cameraFieldOfView);
            groupCamera.Controls.Add(labelCameraFieldOfView);
            groupCamera.Controls.Add(cameraDistance);
            groupCamera.Controls.Add(labelCameraDistance);
            groupCamera.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupCamera.Location = new Point(3, 6);
            groupCamera.Name = "groupCamera";
            groupCamera.Size = new Size(284, 54);
            groupCamera.TabIndex = 7;
            groupCamera.TabStop = false;
            groupCamera.Text = "Camera";
            // 
            // cameraFieldOfView
            // 
            cameraFieldOfView.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cameraFieldOfView.Location = new Point(223, 21);
            cameraFieldOfView.Name = "cameraFieldOfView";
            cameraFieldOfView.Size = new Size(46, 23);
            cameraFieldOfView.TabIndex = 6;
            // 
            // labelCameraFieldOfView
            // 
            labelCameraFieldOfView.AutoSize = true;
            labelCameraFieldOfView.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCameraFieldOfView.Location = new Point(138, 23);
            labelCameraFieldOfView.Name = "labelCameraFieldOfView";
            labelCameraFieldOfView.Size = new Size(74, 15);
            labelCameraFieldOfView.TabIndex = 5;
            labelCameraFieldOfView.Text = "Field of View";
            // 
            // cameraDistance
            // 
            cameraDistance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cameraDistance.Location = new Point(78, 21);
            cameraDistance.Name = "cameraDistance";
            cameraDistance.Size = new Size(46, 23);
            cameraDistance.TabIndex = 4;
            // 
            // labelCameraDistance
            // 
            labelCameraDistance.AutoSize = true;
            labelCameraDistance.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelCameraDistance.Location = new Point(18, 23);
            labelCameraDistance.Name = "labelCameraDistance";
            labelCameraDistance.Size = new Size(52, 15);
            labelCameraDistance.TabIndex = 0;
            labelCameraDistance.Text = "Distance";
            // 
            // labelRayTracer
            // 
            labelRayTracer.AutoSize = true;
            labelRayTracer.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            labelRayTracer.Location = new Point(91, 13);
            labelRayTracer.Name = "labelRayTracer";
            labelRayTracer.Size = new Size(144, 37);
            labelRayTracer.TabIndex = 9;
            labelRayTracer.Text = "RayTracer";
            // 
            // groupTransformation
            // 
            groupTransformation.Controls.Add(labelTransformationCenterZ);
            groupTransformation.Controls.Add(labelTransformationCenterY);
            groupTransformation.Controls.Add(transformationCenterZ);
            groupTransformation.Controls.Add(transformationCenterY);
            groupTransformation.Controls.Add(transformationCenterX);
            groupTransformation.Controls.Add(labelTransformationCenterX);
            groupTransformation.Controls.Add(transformationOrientationVertical);
            groupTransformation.Controls.Add(labelTransformationOrientation);
            groupTransformation.Controls.Add(labelTransformationOrientationVertical);
            groupTransformation.Controls.Add(labelTransformationCenter);
            groupTransformation.Controls.Add(transformationOrientationHorizontal);
            groupTransformation.Controls.Add(labelTransformationOrientationHorizontal);
            groupTransformation.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupTransformation.Location = new Point(3, 66);
            groupTransformation.Name = "groupTransformation";
            groupTransformation.Size = new Size(284, 118);
            groupTransformation.TabIndex = 8;
            groupTransformation.TabStop = false;
            groupTransformation.Text = "Transformation";
            // 
            // labelTransformationCenterZ
            // 
            labelTransformationCenterZ.AutoSize = true;
            labelTransformationCenterZ.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTransformationCenterZ.Location = new Point(198, 88);
            labelTransformationCenterZ.Name = "labelTransformationCenterZ";
            labelTransformationCenterZ.Size = new Size(14, 15);
            labelTransformationCenterZ.TabIndex = 18;
            labelTransformationCenterZ.Text = "Z";
            // 
            // labelTransformationCenterY
            // 
            labelTransformationCenterY.AutoSize = true;
            labelTransformationCenterY.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTransformationCenterY.Location = new Point(113, 88);
            labelTransformationCenterY.Name = "labelTransformationCenterY";
            labelTransformationCenterY.Size = new Size(14, 15);
            labelTransformationCenterY.TabIndex = 17;
            labelTransformationCenterY.Text = "Y";
            // 
            // transformationCenterZ
            // 
            transformationCenterZ.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            transformationCenterZ.Location = new Point(220, 86);
            transformationCenterZ.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            transformationCenterZ.Name = "transformationCenterZ";
            transformationCenterZ.Size = new Size(46, 23);
            transformationCenterZ.TabIndex = 16;
            // 
            // transformationCenterY
            // 
            transformationCenterY.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            transformationCenterY.Location = new Point(135, 86);
            transformationCenterY.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            transformationCenterY.Name = "transformationCenterY";
            transformationCenterY.Size = new Size(46, 23);
            transformationCenterY.TabIndex = 14;
            // 
            // transformationCenterX
            // 
            transformationCenterX.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            transformationCenterX.Location = new Point(48, 86);
            transformationCenterX.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            transformationCenterX.Name = "transformationCenterX";
            transformationCenterX.Size = new Size(46, 23);
            transformationCenterX.TabIndex = 12;
            // 
            // labelTransformationCenterX
            // 
            labelTransformationCenterX.AutoSize = true;
            labelTransformationCenterX.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTransformationCenterX.Location = new Point(26, 88);
            labelTransformationCenterX.Name = "labelTransformationCenterX";
            labelTransformationCenterX.Size = new Size(14, 15);
            labelTransformationCenterX.TabIndex = 11;
            labelTransformationCenterX.Text = "X";
            // 
            // transformationOrientationVertical
            // 
            transformationOrientationVertical.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            transformationOrientationVertical.Location = new Point(220, 39);
            transformationOrientationVertical.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            transformationOrientationVertical.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            transformationOrientationVertical.Name = "transformationOrientationVertical";
            transformationOrientationVertical.Size = new Size(46, 23);
            transformationOrientationVertical.TabIndex = 10;
            // 
            // labelTransformationOrientation
            // 
            labelTransformationOrientation.AutoSize = true;
            labelTransformationOrientation.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTransformationOrientation.Location = new Point(18, 19);
            labelTransformationOrientation.Name = "labelTransformationOrientation";
            labelTransformationOrientation.Size = new Size(67, 15);
            labelTransformationOrientation.TabIndex = 6;
            labelTransformationOrientation.Text = "Orientation";
            // 
            // labelTransformationOrientationVertical
            // 
            labelTransformationOrientationVertical.AutoSize = true;
            labelTransformationOrientationVertical.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTransformationOrientationVertical.Location = new Point(167, 41);
            labelTransformationOrientationVertical.Name = "labelTransformationOrientationVertical";
            labelTransformationOrientationVertical.Size = new Size(45, 15);
            labelTransformationOrientationVertical.TabIndex = 9;
            labelTransformationOrientationVertical.Text = "Vertical";
            // 
            // labelTransformationCenter
            // 
            labelTransformationCenter.AutoSize = true;
            labelTransformationCenter.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTransformationCenter.Location = new Point(18, 65);
            labelTransformationCenter.Name = "labelTransformationCenter";
            labelTransformationCenter.Size = new Size(41, 15);
            labelTransformationCenter.TabIndex = 5;
            labelTransformationCenter.Text = "Center";
            // 
            // transformationOrientationHorizontal
            // 
            transformationOrientationHorizontal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            transformationOrientationHorizontal.Location = new Point(93, 39);
            transformationOrientationHorizontal.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            transformationOrientationHorizontal.Minimum = new decimal(new int[] { 360, 0, 0, int.MinValue });
            transformationOrientationHorizontal.Name = "transformationOrientationHorizontal";
            transformationOrientationHorizontal.Size = new Size(46, 23);
            transformationOrientationHorizontal.TabIndex = 8;
            // 
            // labelTransformationOrientationHorizontal
            // 
            labelTransformationOrientationHorizontal.AutoSize = true;
            labelTransformationOrientationHorizontal.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            labelTransformationOrientationHorizontal.Location = new Point(23, 41);
            labelTransformationOrientationHorizontal.Name = "labelTransformationOrientationHorizontal";
            labelTransformationOrientationHorizontal.Size = new Size(62, 15);
            labelTransformationOrientationHorizontal.TabIndex = 7;
            labelTransformationOrientationHorizontal.Text = "Horizontal";
            // 
            // groupLight
            // 
            groupLight.Controls.Add(lightRefraction);
            groupLight.Controls.Add(lightSpecularReflection);
            groupLight.Controls.Add(lightDiffuseReflection);
            groupLight.Controls.Add(lightAmbientReflection);
            groupLight.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            groupLight.Location = new Point(3, 189);
            groupLight.Name = "groupLight";
            groupLight.Size = new Size(284, 79);
            groupLight.TabIndex = 9;
            groupLight.TabStop = false;
            groupLight.Text = "Light";
            // 
            // lightRefraction
            // 
            lightRefraction.AutoSize = true;
            lightRefraction.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lightRefraction.Location = new Point(152, 47);
            lightRefraction.Name = "lightRefraction";
            lightRefraction.Size = new Size(80, 19);
            lightRefraction.TabIndex = 3;
            lightRefraction.Text = "Refraction";
            lightRefraction.UseVisualStyleBackColor = true;
            // 
            // lightSpecularReflection
            // 
            lightSpecularReflection.AutoSize = true;
            lightSpecularReflection.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lightSpecularReflection.Location = new Point(152, 22);
            lightSpecularReflection.Name = "lightSpecularReflection";
            lightSpecularReflection.Size = new Size(127, 19);
            lightSpecularReflection.TabIndex = 2;
            lightSpecularReflection.Text = "Specular Reflection";
            lightSpecularReflection.UseVisualStyleBackColor = true;
            // 
            // lightDiffuseReflection
            // 
            lightDiffuseReflection.AutoSize = true;
            lightDiffuseReflection.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lightDiffuseReflection.Location = new Point(13, 47);
            lightDiffuseReflection.Name = "lightDiffuseReflection";
            lightDiffuseReflection.Size = new Size(119, 19);
            lightDiffuseReflection.TabIndex = 1;
            lightDiffuseReflection.Text = "Diffuse Reflection";
            lightDiffuseReflection.UseVisualStyleBackColor = true;
            // 
            // lightAmbientReflection
            // 
            lightAmbientReflection.AutoSize = true;
            lightAmbientReflection.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lightAmbientReflection.Location = new Point(13, 22);
            lightAmbientReflection.Name = "lightAmbientReflection";
            lightAmbientReflection.Size = new Size(128, 19);
            lightAmbientReflection.TabIndex = 0;
            lightAmbientReflection.Text = "Ambient Reflection";
            lightAmbientReflection.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(23, 102);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(302, 404);
            tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(groupCamera);
            tabPage1.Controls.Add(groupTransformation);
            tabPage1.Controls.Add(groupLight);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(294, 376);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Scene";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(groupBox1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(294, 376);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Quality";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AAHigh);
            groupBox1.Controls.Add(AAMedium);
            groupBox1.Controls.Add(AALow);
            groupBox1.Controls.Add(AAOff);
            groupBox1.Location = new Point(8, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(280, 58);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Anti Aliasing";
            // 
            // AAHigh
            // 
            AAHigh.AutoSize = true;
            AAHigh.Location = new Point(221, 22);
            AAHigh.Name = "AAHigh";
            AAHigh.Size = new Size(51, 19);
            AAHigh.TabIndex = 3;
            AAHigh.Text = "High";
            AAHigh.UseVisualStyleBackColor = true;
            // 
            // AAMedium
            // 
            AAMedium.AutoSize = true;
            AAMedium.Location = new Point(137, 22);
            AAMedium.Name = "AAMedium";
            AAMedium.Size = new Size(70, 19);
            AAMedium.TabIndex = 2;
            AAMedium.Text = "Medium";
            AAMedium.UseVisualStyleBackColor = true;
            // 
            // AALow
            // 
            AALow.AutoSize = true;
            AALow.Location = new Point(69, 21);
            AALow.Name = "AALow";
            AALow.Size = new Size(47, 19);
            AALow.TabIndex = 1;
            AALow.Text = "Low";
            AALow.UseVisualStyleBackColor = true;
            // 
            // AAOff
            // 
            AAOff.AutoSize = true;
            AAOff.Checked = true;
            AAOff.Location = new Point(6, 22);
            AAOff.Name = "AAOff";
            AAOff.Size = new Size(42, 19);
            AAOff.TabIndex = 0;
            AAOff.TabStop = true;
            AAOff.Text = "Off";
            AAOff.UseVisualStyleBackColor = true;
            // 
            // RayTracer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 592);
            Controls.Add(tabControl1);
            Controls.Add(progressBar);
            Controls.Add(labelRayTracer);
            Controls.Add(startButton);
            Controls.Add(groupRenderer);
            Controls.Add(exitButton);
            Controls.Add(saveImageButton);
            Controls.Add(groupImageResolution);
            Controls.Add(loadButton);
            Controls.Add(statusStrip1);
            Controls.Add(sceneContainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RayTracer";
            Text = "Form1";
            groupImageResolution.ResumeLayout(false);
            groupImageResolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imageResolutionVertical).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageResolutionHorizontal).EndInit();
            groupRenderer.ResumeLayout(false);
            groupRenderer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rendererRecursionDepth).EndInit();
            groupCamera.ResumeLayout(false);
            groupCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cameraFieldOfView).EndInit();
            ((System.ComponentModel.ISupportInitialize)cameraDistance).EndInit();
            groupTransformation.ResumeLayout(false);
            groupTransformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)transformationCenterZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)transformationCenterY).EndInit();
            ((System.ComponentModel.ISupportInitialize)transformationCenterX).EndInit();
            ((System.ComponentModel.ISupportInitialize)transformationOrientationVertical).EndInit();
            ((System.ComponentModel.ISupportInitialize)transformationOrientationHorizontal).EndInit();
            groupLight.ResumeLayout(false);
            groupLight.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel sceneContainer;
        private ProgressBar progressBar;
        private StatusStrip statusStrip1;
        private Button loadButton;
        private GroupBox groupImageResolution;
        private NumericUpDown imageResolutionVertical;
        private Label labelImageResolutionVertical;
        private NumericUpDown imageResolutionHorizontal;
        private Label labelImageResolutionHorizontal;
        private Button saveImageButton;
        private Button exitButton;
        private GroupBox groupRenderer;
        private NumericUpDown rendererRecursionDepth;
        private Label labelRendererRecursionDepth;
        private Button startButton;
        private GroupBox groupCamera;
        private NumericUpDown cameraFieldOfView;
        private Label labelCameraFieldOfView;
        private NumericUpDown cameraDistance;
        private Label labelCameraDistance;
        private Label labelRayTracer;
        private GroupBox groupTransformation;
        private Label labelTransformationCenter;
        private GroupBox groupLight;
        private CheckBox lightAmbientReflection;
        private NumericUpDown transformationOrientationVertical;
        private Label labelTransformationOrientation;
        private Label labelTransformationOrientationVertical;
        private NumericUpDown transformationOrientationHorizontal;
        private Label labelTransformationOrientationHorizontal;
        private CheckBox lightRefraction;
        private CheckBox lightSpecularReflection;
        private CheckBox lightDiffuseReflection;
        private Label labelTransformationCenterZ;
        private Label labelTransformationCenterY;
        private NumericUpDown transformationCenterZ;
        private NumericUpDown transformationCenterY;
        private NumericUpDown transformationCenterX;
        private Label labelTransformationCenterX;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox1;
        private RadioButton AALow;
        private RadioButton AAOff;
        private RadioButton AAHigh;
        private RadioButton AAMedium;
    }
}