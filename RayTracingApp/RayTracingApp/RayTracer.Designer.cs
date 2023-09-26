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
            this.sceneContainer = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadButton = new System.Windows.Forms.Button();
            this.groupImageResolution = new System.Windows.Forms.GroupBox();
            this.imageResolutionVertical = new System.Windows.Forms.NumericUpDown();
            this.labelImageResolutionVertical = new System.Windows.Forms.Label();
            this.imageResolutionHorizontal = new System.Windows.Forms.NumericUpDown();
            this.labelImageResolutionHorizontal = new System.Windows.Forms.Label();
            this.saveImageButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.groupRenderer = new System.Windows.Forms.GroupBox();
            this.rendererRecursionDepth = new System.Windows.Forms.NumericUpDown();
            this.labelRendererRecursionDepth = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.groupCamera = new System.Windows.Forms.GroupBox();
            this.cameraFieldOfView = new System.Windows.Forms.NumericUpDown();
            this.labelCameraFieldOfView = new System.Windows.Forms.Label();
            this.cameraDistance = new System.Windows.Forms.NumericUpDown();
            this.labelCameraDistance = new System.Windows.Forms.Label();
            this.labelRayTracer = new System.Windows.Forms.Label();
            this.groupTransformation = new System.Windows.Forms.GroupBox();
            this.labelTransformationCenterZ = new System.Windows.Forms.Label();
            this.labelTransformationCenterY = new System.Windows.Forms.Label();
            this.transformationCenterZ = new System.Windows.Forms.NumericUpDown();
            this.transformationCenterY = new System.Windows.Forms.NumericUpDown();
            this.transformationCenterX = new System.Windows.Forms.NumericUpDown();
            this.labelTransformationCenterX = new System.Windows.Forms.Label();
            this.transformationOrientationVertical = new System.Windows.Forms.NumericUpDown();
            this.labelTransformationOrientation = new System.Windows.Forms.Label();
            this.labelTransformationOrientationVertical = new System.Windows.Forms.Label();
            this.labelTransformationCenter = new System.Windows.Forms.Label();
            this.transformationOrientationHorizontal = new System.Windows.Forms.NumericUpDown();
            this.labelTransformationOrientationHorizontal = new System.Windows.Forms.Label();
            this.groupLight = new System.Windows.Forms.GroupBox();
            this.lightRefraction = new System.Windows.Forms.CheckBox();
            this.lightSpecularReflection = new System.Windows.Forms.CheckBox();
            this.lightDiffuseReflection = new System.Windows.Forms.CheckBox();
            this.lightAmbientReflection = new System.Windows.Forms.CheckBox();
            this.sceneContainer.SuspendLayout();
            this.groupImageResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageResolutionVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResolutionHorizontal)).BeginInit();
            this.groupRenderer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rendererRecursionDepth)).BeginInit();
            this.groupCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFieldOfView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDistance)).BeginInit();
            this.groupTransformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationOrientationVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationOrientationHorizontal)).BeginInit();
            this.groupLight.SuspendLayout();
            this.SuspendLayout();
            // 
            // sceneContainer
            // 
            this.sceneContainer.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.sceneContainer.Controls.Add(this.progressBar);
            this.sceneContainer.Location = new System.Drawing.Point(378, 28);
            this.sceneContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sceneContainer.Name = "sceneContainer";
            this.sceneContainer.Size = new System.Drawing.Size(512, 459);
            this.sceneContainer.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(512, 31);
            this.progressBar.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 578);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(914, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(26, 85);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(325, 43);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Load...";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // groupImageResolution
            // 
            this.groupImageResolution.Controls.Add(this.imageResolutionVertical);
            this.groupImageResolution.Controls.Add(this.labelImageResolutionVertical);
            this.groupImageResolution.Controls.Add(this.imageResolutionHorizontal);
            this.groupImageResolution.Controls.Add(this.labelImageResolutionHorizontal);
            this.groupImageResolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupImageResolution.Location = new System.Drawing.Point(378, 495);
            this.groupImageResolution.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupImageResolution.Name = "groupImageResolution";
            this.groupImageResolution.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupImageResolution.Size = new System.Drawing.Size(283, 72);
            this.groupImageResolution.TabIndex = 3;
            this.groupImageResolution.TabStop = false;
            this.groupImageResolution.Text = "Image Resolution";
            // 
            // imageResolutionVertical
            // 
            this.imageResolutionVertical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imageResolutionVertical.Location = new System.Drawing.Point(219, 28);
            this.imageResolutionVertical.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imageResolutionVertical.Name = "imageResolutionVertical";
            this.imageResolutionVertical.Size = new System.Drawing.Size(53, 27);
            this.imageResolutionVertical.TabIndex = 6;
            // 
            // labelImageResolutionVertical
            // 
            this.labelImageResolutionVertical.AutoSize = true;
            this.labelImageResolutionVertical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelImageResolutionVertical.Location = new System.Drawing.Point(159, 31);
            this.labelImageResolutionVertical.Name = "labelImageResolutionVertical";
            this.labelImageResolutionVertical.Size = new System.Drawing.Size(58, 20);
            this.labelImageResolutionVertical.TabIndex = 5;
            this.labelImageResolutionVertical.Text = "Vertical";
            // 
            // imageResolutionHorizontal
            // 
            this.imageResolutionHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.imageResolutionHorizontal.Location = new System.Drawing.Point(89, 28);
            this.imageResolutionHorizontal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.imageResolutionHorizontal.Name = "imageResolutionHorizontal";
            this.imageResolutionHorizontal.Size = new System.Drawing.Size(53, 27);
            this.imageResolutionHorizontal.TabIndex = 4;
            // 
            // labelImageResolutionHorizontal
            // 
            this.labelImageResolutionHorizontal.AutoSize = true;
            this.labelImageResolutionHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelImageResolutionHorizontal.Location = new System.Drawing.Point(9, 31);
            this.labelImageResolutionHorizontal.Name = "labelImageResolutionHorizontal";
            this.labelImageResolutionHorizontal.Size = new System.Drawing.Size(79, 20);
            this.labelImageResolutionHorizontal.TabIndex = 0;
            this.labelImageResolutionHorizontal.Text = "Horizontal";
            // 
            // saveImageButton
            // 
            this.saveImageButton.Location = new System.Drawing.Point(669, 511);
            this.saveImageButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveImageButton.Name = "saveImageButton";
            this.saveImageButton.Size = new System.Drawing.Size(109, 43);
            this.saveImageButton.TabIndex = 4;
            this.saveImageButton.Text = "Save Image...";
            this.saveImageButton.UseVisualStyleBackColor = true;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(784, 511);
            this.exitButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(106, 43);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // groupRenderer
            // 
            this.groupRenderer.Controls.Add(this.rendererRecursionDepth);
            this.groupRenderer.Controls.Add(this.labelRendererRecursionDepth);
            this.groupRenderer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupRenderer.Location = new System.Drawing.Point(26, 495);
            this.groupRenderer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupRenderer.Name = "groupRenderer";
            this.groupRenderer.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupRenderer.Size = new System.Drawing.Size(194, 72);
            this.groupRenderer.TabIndex = 7;
            this.groupRenderer.TabStop = false;
            this.groupRenderer.Text = "Renderer";
            // 
            // rendererRecursionDepth
            // 
            this.rendererRecursionDepth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rendererRecursionDepth.Location = new System.Drawing.Point(128, 25);
            this.rendererRecursionDepth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rendererRecursionDepth.Name = "rendererRecursionDepth";
            this.rendererRecursionDepth.Size = new System.Drawing.Size(53, 27);
            this.rendererRecursionDepth.TabIndex = 4;
            // 
            // labelRendererRecursionDepth
            // 
            this.labelRendererRecursionDepth.AutoSize = true;
            this.labelRendererRecursionDepth.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRendererRecursionDepth.Location = new System.Drawing.Point(8, 31);
            this.labelRendererRecursionDepth.Name = "labelRendererRecursionDepth";
            this.labelRendererRecursionDepth.Size = new System.Drawing.Size(118, 20);
            this.labelRendererRecursionDepth.TabIndex = 0;
            this.labelRendererRecursionDepth.Text = "Recursion Depth";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(227, 511);
            this.startButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(123, 43);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // groupCamera
            // 
            this.groupCamera.Controls.Add(this.cameraFieldOfView);
            this.groupCamera.Controls.Add(this.labelCameraFieldOfView);
            this.groupCamera.Controls.Add(this.cameraDistance);
            this.groupCamera.Controls.Add(this.labelCameraDistance);
            this.groupCamera.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupCamera.Location = new System.Drawing.Point(26, 136);
            this.groupCamera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCamera.Name = "groupCamera";
            this.groupCamera.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupCamera.Size = new System.Drawing.Size(325, 72);
            this.groupCamera.TabIndex = 7;
            this.groupCamera.TabStop = false;
            this.groupCamera.Text = "Camera";
            // 
            // cameraFieldOfView
            // 
            this.cameraFieldOfView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cameraFieldOfView.Location = new System.Drawing.Point(255, 28);
            this.cameraFieldOfView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraFieldOfView.Name = "cameraFieldOfView";
            this.cameraFieldOfView.Size = new System.Drawing.Size(53, 27);
            this.cameraFieldOfView.TabIndex = 6;
            // 
            // labelCameraFieldOfView
            // 
            this.labelCameraFieldOfView.AutoSize = true;
            this.labelCameraFieldOfView.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCameraFieldOfView.Location = new System.Drawing.Point(158, 31);
            this.labelCameraFieldOfView.Name = "labelCameraFieldOfView";
            this.labelCameraFieldOfView.Size = new System.Drawing.Size(95, 20);
            this.labelCameraFieldOfView.TabIndex = 5;
            this.labelCameraFieldOfView.Text = "Field of View";
            // 
            // cameraDistance
            // 
            this.cameraDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cameraDistance.Location = new System.Drawing.Point(89, 28);
            this.cameraDistance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cameraDistance.Name = "cameraDistance";
            this.cameraDistance.Size = new System.Drawing.Size(53, 27);
            this.cameraDistance.TabIndex = 4;
            // 
            // labelCameraDistance
            // 
            this.labelCameraDistance.AutoSize = true;
            this.labelCameraDistance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCameraDistance.Location = new System.Drawing.Point(21, 31);
            this.labelCameraDistance.Name = "labelCameraDistance";
            this.labelCameraDistance.Size = new System.Drawing.Size(66, 20);
            this.labelCameraDistance.TabIndex = 0;
            this.labelCameraDistance.Text = "Distance";
            // 
            // labelRayTracer
            // 
            this.labelRayTracer.AutoSize = true;
            this.labelRayTracer.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRayTracer.Location = new System.Drawing.Point(104, 17);
            this.labelRayTracer.Name = "labelRayTracer";
            this.labelRayTracer.Size = new System.Drawing.Size(175, 46);
            this.labelRayTracer.TabIndex = 9;
            this.labelRayTracer.Text = "RayTracer";
            // 
            // groupTransformation
            // 
            this.groupTransformation.Controls.Add(this.labelTransformationCenterZ);
            this.groupTransformation.Controls.Add(this.labelTransformationCenterY);
            this.groupTransformation.Controls.Add(this.transformationCenterZ);
            this.groupTransformation.Controls.Add(this.transformationCenterY);
            this.groupTransformation.Controls.Add(this.transformationCenterX);
            this.groupTransformation.Controls.Add(this.labelTransformationCenterX);
            this.groupTransformation.Controls.Add(this.transformationOrientationVertical);
            this.groupTransformation.Controls.Add(this.labelTransformationOrientation);
            this.groupTransformation.Controls.Add(this.labelTransformationOrientationVertical);
            this.groupTransformation.Controls.Add(this.labelTransformationCenter);
            this.groupTransformation.Controls.Add(this.transformationOrientationHorizontal);
            this.groupTransformation.Controls.Add(this.labelTransformationOrientationHorizontal);
            this.groupTransformation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupTransformation.Location = new System.Drawing.Point(26, 216);
            this.groupTransformation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupTransformation.Name = "groupTransformation";
            this.groupTransformation.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupTransformation.Size = new System.Drawing.Size(325, 157);
            this.groupTransformation.TabIndex = 8;
            this.groupTransformation.TabStop = false;
            this.groupTransformation.Text = "Transformation";
            // 
            // labelTransformationCenterZ
            // 
            this.labelTransformationCenterZ.AutoSize = true;
            this.labelTransformationCenterZ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationCenterZ.Location = new System.Drawing.Point(226, 117);
            this.labelTransformationCenterZ.Name = "labelTransformationCenterZ";
            this.labelTransformationCenterZ.Size = new System.Drawing.Size(18, 20);
            this.labelTransformationCenterZ.TabIndex = 18;
            this.labelTransformationCenterZ.Text = "Z";
            // 
            // labelTransformationCenterY
            // 
            this.labelTransformationCenterY.AutoSize = true;
            this.labelTransformationCenterY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationCenterY.Location = new System.Drawing.Point(129, 117);
            this.labelTransformationCenterY.Name = "labelTransformationCenterY";
            this.labelTransformationCenterY.Size = new System.Drawing.Size(17, 20);
            this.labelTransformationCenterY.TabIndex = 17;
            this.labelTransformationCenterY.Text = "Y";
            // 
            // transformationCenterZ
            // 
            this.transformationCenterZ.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformationCenterZ.Location = new System.Drawing.Point(251, 115);
            this.transformationCenterZ.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transformationCenterZ.Name = "transformationCenterZ";
            this.transformationCenterZ.Size = new System.Drawing.Size(53, 27);
            this.transformationCenterZ.TabIndex = 16;
            // 
            // transformationCenterY
            // 
            this.transformationCenterY.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformationCenterY.Location = new System.Drawing.Point(154, 115);
            this.transformationCenterY.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transformationCenterY.Name = "transformationCenterY";
            this.transformationCenterY.Size = new System.Drawing.Size(53, 27);
            this.transformationCenterY.TabIndex = 14;
            // 
            // transformationCenterX
            // 
            this.transformationCenterX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformationCenterX.Location = new System.Drawing.Point(55, 115);
            this.transformationCenterX.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transformationCenterX.Name = "transformationCenterX";
            this.transformationCenterX.Size = new System.Drawing.Size(53, 27);
            this.transformationCenterX.TabIndex = 12;
            // 
            // labelTransformationCenterX
            // 
            this.labelTransformationCenterX.AutoSize = true;
            this.labelTransformationCenterX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationCenterX.Location = new System.Drawing.Point(30, 117);
            this.labelTransformationCenterX.Name = "labelTransformationCenterX";
            this.labelTransformationCenterX.Size = new System.Drawing.Size(18, 20);
            this.labelTransformationCenterX.TabIndex = 11;
            this.labelTransformationCenterX.Text = "X";
            // 
            // transformationOrientationVertical
            // 
            this.transformationOrientationVertical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformationOrientationVertical.Location = new System.Drawing.Point(251, 52);
            this.transformationOrientationVertical.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transformationOrientationVertical.Name = "transformationOrientationVertical";
            this.transformationOrientationVertical.Size = new System.Drawing.Size(53, 27);
            this.transformationOrientationVertical.TabIndex = 10;
            // 
            // labelTransformationOrientation
            // 
            this.labelTransformationOrientation.AutoSize = true;
            this.labelTransformationOrientation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationOrientation.Location = new System.Drawing.Point(21, 25);
            this.labelTransformationOrientation.Name = "labelTransformationOrientation";
            this.labelTransformationOrientation.Size = new System.Drawing.Size(87, 20);
            this.labelTransformationOrientation.TabIndex = 6;
            this.labelTransformationOrientation.Text = "Orientation";
            // 
            // labelTransformationOrientationVertical
            // 
            this.labelTransformationOrientationVertical.AutoSize = true;
            this.labelTransformationOrientationVertical.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationOrientationVertical.Location = new System.Drawing.Point(191, 55);
            this.labelTransformationOrientationVertical.Name = "labelTransformationOrientationVertical";
            this.labelTransformationOrientationVertical.Size = new System.Drawing.Size(58, 20);
            this.labelTransformationOrientationVertical.TabIndex = 9;
            this.labelTransformationOrientationVertical.Text = "Vertical";
            // 
            // labelTransformationCenter
            // 
            this.labelTransformationCenter.AutoSize = true;
            this.labelTransformationCenter.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationCenter.Location = new System.Drawing.Point(21, 87);
            this.labelTransformationCenter.Name = "labelTransformationCenter";
            this.labelTransformationCenter.Size = new System.Drawing.Size(54, 20);
            this.labelTransformationCenter.TabIndex = 5;
            this.labelTransformationCenter.Text = "Center";
            // 
            // transformationOrientationHorizontal
            // 
            this.transformationOrientationHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.transformationOrientationHorizontal.Location = new System.Drawing.Point(106, 52);
            this.transformationOrientationHorizontal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.transformationOrientationHorizontal.Name = "transformationOrientationHorizontal";
            this.transformationOrientationHorizontal.Size = new System.Drawing.Size(53, 27);
            this.transformationOrientationHorizontal.TabIndex = 8;
            // 
            // labelTransformationOrientationHorizontal
            // 
            this.labelTransformationOrientationHorizontal.AutoSize = true;
            this.labelTransformationOrientationHorizontal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTransformationOrientationHorizontal.Location = new System.Drawing.Point(26, 55);
            this.labelTransformationOrientationHorizontal.Name = "labelTransformationOrientationHorizontal";
            this.labelTransformationOrientationHorizontal.Size = new System.Drawing.Size(79, 20);
            this.labelTransformationOrientationHorizontal.TabIndex = 7;
            this.labelTransformationOrientationHorizontal.Text = "Horizontal";
            // 
            // groupLight
            // 
            this.groupLight.Controls.Add(this.lightRefraction);
            this.groupLight.Controls.Add(this.lightSpecularReflection);
            this.groupLight.Controls.Add(this.lightDiffuseReflection);
            this.groupLight.Controls.Add(this.lightAmbientReflection);
            this.groupLight.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupLight.Location = new System.Drawing.Point(26, 381);
            this.groupLight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLight.Name = "groupLight";
            this.groupLight.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupLight.Size = new System.Drawing.Size(325, 105);
            this.groupLight.TabIndex = 9;
            this.groupLight.TabStop = false;
            this.groupLight.Text = "Light";
            // 
            // lightRefraction
            // 
            this.lightRefraction.AutoSize = true;
            this.lightRefraction.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lightRefraction.Location = new System.Drawing.Point(174, 63);
            this.lightRefraction.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightRefraction.Name = "lightRefraction";
            this.lightRefraction.Size = new System.Drawing.Size(99, 24);
            this.lightRefraction.TabIndex = 3;
            this.lightRefraction.Text = "Refraction";
            this.lightRefraction.UseVisualStyleBackColor = true;
            // 
            // lightSpecularReflection
            // 
            this.lightSpecularReflection.AutoSize = true;
            this.lightSpecularReflection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lightSpecularReflection.Location = new System.Drawing.Point(174, 29);
            this.lightSpecularReflection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightSpecularReflection.Name = "lightSpecularReflection";
            this.lightSpecularReflection.Size = new System.Drawing.Size(159, 24);
            this.lightSpecularReflection.TabIndex = 2;
            this.lightSpecularReflection.Text = "Specular Reflection";
            this.lightSpecularReflection.UseVisualStyleBackColor = true;
            // 
            // lightDiffuseReflection
            // 
            this.lightDiffuseReflection.AutoSize = true;
            this.lightDiffuseReflection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lightDiffuseReflection.Location = new System.Drawing.Point(15, 63);
            this.lightDiffuseReflection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightDiffuseReflection.Name = "lightDiffuseReflection";
            this.lightDiffuseReflection.Size = new System.Drawing.Size(149, 24);
            this.lightDiffuseReflection.TabIndex = 1;
            this.lightDiffuseReflection.Text = "Diffuse Reflection";
            this.lightDiffuseReflection.UseVisualStyleBackColor = true;
            // 
            // lightAmbientReflection
            // 
            this.lightAmbientReflection.AutoSize = true;
            this.lightAmbientReflection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lightAmbientReflection.Location = new System.Drawing.Point(15, 29);
            this.lightAmbientReflection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lightAmbientReflection.Name = "lightAmbientReflection";
            this.lightAmbientReflection.Size = new System.Drawing.Size(159, 24);
            this.lightAmbientReflection.TabIndex = 0;
            this.lightAmbientReflection.Text = "Ambient Reflection";
            this.lightAmbientReflection.UseVisualStyleBackColor = true;
            // 
            // RayTracer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.groupLight);
            this.Controls.Add(this.groupTransformation);
            this.Controls.Add(this.labelRayTracer);
            this.Controls.Add(this.groupCamera);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupRenderer);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.saveImageButton);
            this.Controls.Add(this.groupImageResolution);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.sceneContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RayTracer";
            this.Text = "Form1";
            this.sceneContainer.ResumeLayout(false);
            this.groupImageResolution.ResumeLayout(false);
            this.groupImageResolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageResolutionVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageResolutionHorizontal)).EndInit();
            this.groupRenderer.ResumeLayout(false);
            this.groupRenderer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rendererRecursionDepth)).EndInit();
            this.groupCamera.ResumeLayout(false);
            this.groupCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFieldOfView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDistance)).EndInit();
            this.groupTransformation.ResumeLayout(false);
            this.groupTransformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationCenterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationOrientationVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transformationOrientationHorizontal)).EndInit();
            this.groupLight.ResumeLayout(false);
            this.groupLight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}