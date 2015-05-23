namespace Magnavox_Odyssey_Emulator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBoxCartridge = new System.Windows.Forms.GroupBox();
            this.groupBoxOverlay = new System.Windows.Forms.GroupBox();
            this.groupBoxRun = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCart = new System.Windows.Forms.Button();
            this.pictureBoxRun = new System.Windows.Forms.PictureBox();
            this.buttonOverlay = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSettings = new System.Windows.Forms.PictureBox();
            this.groupBoxCartridge.SuspendLayout();
            this.groupBoxOverlay.SuspendLayout();
            this.groupBoxRun.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxCartridge
            // 
            this.groupBoxCartridge.Controls.Add(this.buttonCart);
            this.groupBoxCartridge.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxCartridge.Location = new System.Drawing.Point(214, 8);
            this.groupBoxCartridge.Name = "groupBoxCartridge";
            this.groupBoxCartridge.Size = new System.Drawing.Size(183, 154);
            this.groupBoxCartridge.TabIndex = 44;
            this.groupBoxCartridge.TabStop = false;
            this.groupBoxCartridge.Text = "Cartridge";
            // 
            // groupBoxOverlay
            // 
            this.groupBoxOverlay.Controls.Add(this.buttonOverlay);
            this.groupBoxOverlay.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxOverlay.Location = new System.Drawing.Point(9, 8);
            this.groupBoxOverlay.Name = "groupBoxOverlay";
            this.groupBoxOverlay.Size = new System.Drawing.Size(183, 154);
            this.groupBoxOverlay.TabIndex = 45;
            this.groupBoxOverlay.TabStop = false;
            this.groupBoxOverlay.Text = "Overlay";
            // 
            // groupBoxRun
            // 
            this.groupBoxRun.Controls.Add(this.pictureBoxRun);
            this.groupBoxRun.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRun.Location = new System.Drawing.Point(418, 8);
            this.groupBoxRun.Name = "groupBoxRun";
            this.groupBoxRun.Size = new System.Drawing.Size(183, 154);
            this.groupBoxRun.TabIndex = 46;
            this.groupBoxRun.TabStop = false;
            this.groupBoxRun.Text = "Run";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.groupBoxCartridge);
            this.panel1.Controls.Add(this.groupBoxRun);
            this.panel1.Controls.Add(this.groupBoxOverlay);
            this.panel1.Location = new System.Drawing.Point(105, 329);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 174);
            this.panel1.TabIndex = 47;
            // 
            // buttonCart
            // 
            this.buttonCart.Image = global::Magnavox_Odyssey_Emulator.Properties.Resources.buttonCart1_Image;
            this.buttonCart.Location = new System.Drawing.Point(13, 39);
            this.buttonCart.Name = "buttonCart";
            this.buttonCart.Size = new System.Drawing.Size(160, 100);
            this.buttonCart.TabIndex = 37;
            this.buttonCart.UseVisualStyleBackColor = true;
            this.buttonCart.Click += new System.EventHandler(this.buttonCart_Click);
            // 
            // pictureBoxRun
            // 
            this.pictureBoxRun.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRun.Image")));
            this.pictureBoxRun.Location = new System.Drawing.Point(44, 38);
            this.pictureBoxRun.Name = "pictureBoxRun";
            this.pictureBoxRun.Size = new System.Drawing.Size(94, 100);
            this.pictureBoxRun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRun.TabIndex = 32;
            this.pictureBoxRun.TabStop = false;
            this.pictureBoxRun.Click += new System.EventHandler(this.pictureBoxRunEmulator_Click);
            this.pictureBoxRun.MouseEnter += new System.EventHandler(this.pictureBoxRunEmulator_MouseEnter);
            this.pictureBoxRun.MouseLeave += new System.EventHandler(this.pictureBoxRunEmulator_MouseLeave);
            // 
            // buttonOverlay
            // 
            this.buttonOverlay.BackgroundImage = global::Magnavox_Odyssey_Emulator.Properties.Resources.none;
            this.buttonOverlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonOverlay.Location = new System.Drawing.Point(17, 38);
            this.buttonOverlay.Name = "buttonOverlay";
            this.buttonOverlay.Size = new System.Drawing.Size(160, 100);
            this.buttonOverlay.TabIndex = 38;
            this.buttonOverlay.UseVisualStyleBackColor = true;
            this.buttonOverlay.Click += new System.EventHandler(this.buttonOverlay_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(430, 114);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(12, 132);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(207, 37);
            this.pictureBox4.TabIndex = 42;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBoxSettings
            // 
            this.pictureBoxSettings.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBoxSettings.Image = global::Magnavox_Odyssey_Emulator.ResourcesGraphics.odysseyMachine;
            this.pictureBoxSettings.Location = new System.Drawing.Point(417, -2);
            this.pictureBoxSettings.Name = "pictureBoxSettings";
            this.pictureBoxSettings.Size = new System.Drawing.Size(416, 255);
            this.pictureBoxSettings.TabIndex = 16;
            this.pictureBoxSettings.TabStop = false;
            this.pictureBoxSettings.Click += new System.EventHandler(this.pictureBoxSettings_Click);
            this.pictureBoxSettings.MouseLeave += new System.EventHandler(this.pictureBoxSettings_MouseLeave);
            this.pictureBoxSettings.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSettings_MouseMove);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 560);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBoxSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "MagnaVox Odyssey Emulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxCartridge.ResumeLayout(false);
            this.groupBoxOverlay.ResumeLayout(false);
            this.groupBoxRun.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSettings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxSettings;
        private System.Windows.Forms.PictureBox pictureBoxRun;
        private System.Windows.Forms.Button buttonCart;
        private System.Windows.Forms.Button buttonOverlay;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBoxCartridge;
        private System.Windows.Forms.GroupBox groupBoxOverlay;
        private System.Windows.Forms.GroupBox groupBoxRun;
        private System.Windows.Forms.Panel panel1;
    }
}

