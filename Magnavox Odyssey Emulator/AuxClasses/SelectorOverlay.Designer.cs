namespace Magnavox_Odyssey_Emulator.AuxClasses
{
    partial class SelectorOverlay
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
            this.components = new System.ComponentModel.Container();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxOverlaySettings = new System.Windows.Forms.GroupBox();
            this.labelOverlayName = new System.Windows.Forms.Label();
            this.groupBoxCartridge = new System.Windows.Forms.GroupBox();
            this.labelNum = new System.Windows.Forms.Label();
            this.numericUpDownCartridgeNum = new System.Windows.Forms.NumericUpDown();
            this.checkBoxAsociate = new System.Windows.Forms.CheckBox();
            this.groupBoxOpacity = new System.Windows.Forms.GroupBox();
            this.checkBoxOpacityEnabled = new System.Windows.Forms.CheckBox();
            this.labelOpaqueColor = new System.Windows.Forms.Label();
            this.pictureBoxOpaqueColor = new System.Windows.Forms.PictureBox();
            this.buttonPickOpaqueColor = new System.Windows.Forms.Button();
            this.pictureBoxOverlayPreview = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBoxCreateOverlay = new System.Windows.Forms.GroupBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.labelNoteInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDragAndDropInfo = new System.Windows.Forms.Label();
            this.labelSelectAnOverlay = new System.Windows.Forms.Label();
            this.labelEdit = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBoxOverlaySettings.SuspendLayout();
            this.groupBoxCartridge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCartridgeNum)).BeginInit();
            this.groupBoxOpacity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpaqueColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlayPreview)).BeginInit();
            this.groupBoxCreateOverlay.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.LabelWrap = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(6, 44);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(716, 296);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBoxOverlaySettings
            // 
            this.groupBoxOverlaySettings.Controls.Add(this.progressBar1);
            this.groupBoxOverlaySettings.Controls.Add(this.labelOverlayName);
            this.groupBoxOverlaySettings.Controls.Add(this.groupBoxCartridge);
            this.groupBoxOverlaySettings.Controls.Add(this.groupBoxOpacity);
            this.groupBoxOverlaySettings.Controls.Add(this.pictureBoxOverlayPreview);
            this.groupBoxOverlaySettings.Location = new System.Drawing.Point(6, 381);
            this.groupBoxOverlaySettings.Name = "groupBoxOverlaySettings";
            this.groupBoxOverlaySettings.Size = new System.Drawing.Size(487, 283);
            this.groupBoxOverlaySettings.TabIndex = 1;
            this.groupBoxOverlaySettings.TabStop = false;
            this.groupBoxOverlaySettings.Text = "Overlay Settings";
            // 
            // labelOverlayName
            // 
            this.labelOverlayName.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOverlayName.Location = new System.Drawing.Point(134, 31);
            this.labelOverlayName.Name = "labelOverlayName";
            this.labelOverlayName.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelOverlayName.Size = new System.Drawing.Size(323, 26);
            this.labelOverlayName.TabIndex = 8;
            this.labelOverlayName.Text = "Overlay Name";
            this.labelOverlayName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxCartridge
            // 
            this.groupBoxCartridge.Controls.Add(this.labelNum);
            this.groupBoxCartridge.Controls.Add(this.numericUpDownCartridgeNum);
            this.groupBoxCartridge.Controls.Add(this.checkBoxAsociate);
            this.groupBoxCartridge.Location = new System.Drawing.Point(16, 169);
            this.groupBoxCartridge.Name = "groupBoxCartridge";
            this.groupBoxCartridge.Size = new System.Drawing.Size(93, 84);
            this.groupBoxCartridge.TabIndex = 7;
            this.groupBoxCartridge.TabStop = false;
            this.groupBoxCartridge.Text = "Cartrdidge";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(2, 57);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(32, 13);
            this.labelNum.TabIndex = 5;
            this.labelNum.Text = "Num:";
            // 
            // numericUpDownCartridgeNum
            // 
            this.numericUpDownCartridgeNum.Location = new System.Drawing.Point(50, 54);
            this.numericUpDownCartridgeNum.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDownCartridgeNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCartridgeNum.Name = "numericUpDownCartridgeNum";
            this.numericUpDownCartridgeNum.Size = new System.Drawing.Size(37, 20);
            this.numericUpDownCartridgeNum.TabIndex = 2;
            this.numericUpDownCartridgeNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCartridgeNum.ValueChanged += new System.EventHandler(this.numericUpDownCartridgeNum_ValueChanged);
            // 
            // checkBoxAsociate
            // 
            this.checkBoxAsociate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxAsociate.Location = new System.Drawing.Point(0, 19);
            this.checkBoxAsociate.Name = "checkBoxAsociate";
            this.checkBoxAsociate.Size = new System.Drawing.Size(88, 23);
            this.checkBoxAsociate.TabIndex = 6;
            this.checkBoxAsociate.Text = "Asociate";
            this.checkBoxAsociate.UseVisualStyleBackColor = true;
            this.checkBoxAsociate.CheckedChanged += new System.EventHandler(this.checkBoxAsociate_CheckedChanged);
            // 
            // groupBoxOpacity
            // 
            this.groupBoxOpacity.Controls.Add(this.checkBoxOpacityEnabled);
            this.groupBoxOpacity.Controls.Add(this.labelOpaqueColor);
            this.groupBoxOpacity.Controls.Add(this.pictureBoxOpaqueColor);
            this.groupBoxOpacity.Controls.Add(this.buttonPickOpaqueColor);
            this.groupBoxOpacity.Location = new System.Drawing.Point(16, 31);
            this.groupBoxOpacity.Name = "groupBoxOpacity";
            this.groupBoxOpacity.Size = new System.Drawing.Size(93, 115);
            this.groupBoxOpacity.TabIndex = 2;
            this.groupBoxOpacity.TabStop = false;
            this.groupBoxOpacity.Text = "Opacity";
            // 
            // checkBoxOpacityEnabled
            // 
            this.checkBoxOpacityEnabled.AutoSize = true;
            this.checkBoxOpacityEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxOpacityEnabled.Location = new System.Drawing.Point(6, 19);
            this.checkBoxOpacityEnabled.Name = "checkBoxOpacityEnabled";
            this.checkBoxOpacityEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkBoxOpacityEnabled.TabIndex = 2;
            this.checkBoxOpacityEnabled.Text = "Enabled";
            this.checkBoxOpacityEnabled.UseVisualStyleBackColor = true;
            this.checkBoxOpacityEnabled.CheckedChanged += new System.EventHandler(this.checkBoxOpacityEnabled_CheckedChanged);
            // 
            // labelOpaqueColor
            // 
            this.labelOpaqueColor.AutoSize = true;
            this.labelOpaqueColor.Location = new System.Drawing.Point(6, 48);
            this.labelOpaqueColor.Name = "labelOpaqueColor";
            this.labelOpaqueColor.Size = new System.Drawing.Size(75, 13);
            this.labelOpaqueColor.TabIndex = 0;
            this.labelOpaqueColor.Text = "Opaque Color:";
            // 
            // pictureBoxOpaqueColor
            // 
            this.pictureBoxOpaqueColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOpaqueColor.Location = new System.Drawing.Point(9, 67);
            this.pictureBoxOpaqueColor.Name = "pictureBoxOpaqueColor";
            this.pictureBoxOpaqueColor.Size = new System.Drawing.Size(29, 29);
            this.pictureBoxOpaqueColor.TabIndex = 2;
            this.pictureBoxOpaqueColor.TabStop = false;
            // 
            // buttonPickOpaqueColor
            // 
            this.buttonPickOpaqueColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonPickOpaqueColor.Image = global::Magnavox_Odyssey_Emulator.Properties.Resources.pickColor;
            this.buttonPickOpaqueColor.Location = new System.Drawing.Point(46, 67);
            this.buttonPickOpaqueColor.Name = "buttonPickOpaqueColor";
            this.buttonPickOpaqueColor.Size = new System.Drawing.Size(29, 29);
            this.buttonPickOpaqueColor.TabIndex = 3;
            this.buttonPickOpaqueColor.UseVisualStyleBackColor = true;
            this.buttonPickOpaqueColor.Click += new System.EventHandler(this.buttonPickOpaqueColor_Click);
            // 
            // pictureBoxOverlayPreview
            // 
            this.pictureBoxOverlayPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxOverlayPreview.Location = new System.Drawing.Point(137, 60);
            this.pictureBoxOverlayPreview.Name = "pictureBoxOverlayPreview";
            this.pictureBoxOverlayPreview.Size = new System.Drawing.Size(320, 200);
            this.pictureBoxOverlayPreview.TabIndex = 4;
            this.pictureBoxOverlayPreview.TabStop = false;
            this.pictureBoxOverlayPreview.Click += new System.EventHandler(this.pictureBoxOverlayPreview_Click);
            this.pictureBoxOverlayPreview.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOverlayPreview_MouseMove);
            // 
            // groupBoxCreateOverlay
            // 
            this.groupBoxCreateOverlay.Controls.Add(this.labelNote);
            this.groupBoxCreateOverlay.Controls.Add(this.labelNoteInfo);
            this.groupBoxCreateOverlay.Controls.Add(this.panel1);
            this.groupBoxCreateOverlay.Location = new System.Drawing.Point(499, 381);
            this.groupBoxCreateOverlay.Name = "groupBoxCreateOverlay";
            this.groupBoxCreateOverlay.Size = new System.Drawing.Size(185, 282);
            this.groupBoxCreateOverlay.TabIndex = 2;
            this.groupBoxCreateOverlay.TabStop = false;
            this.groupBoxCreateOverlay.Text = "Create Overlay";
            // 
            // labelNote
            // 
            this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(17, 218);
            this.labelNote.Name = "labelNote";
            this.labelNote.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelNote.Size = new System.Drawing.Size(155, 15);
            this.labelNote.TabIndex = 3;
            this.labelNote.Text = "NOTE:";
            // 
            // labelNoteInfo
            // 
            this.labelNoteInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoteInfo.Location = new System.Drawing.Point(17, 238);
            this.labelNoteInfo.Name = "labelNoteInfo";
            this.labelNoteInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelNoteInfo.Size = new System.Drawing.Size(164, 43);
            this.labelNoteInfo.TabIndex = 2;
            this.labelNoteInfo.Text = "Image will be converted to 256 Color bitmap and resized to 320x200.";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelDragAndDropInfo);
            this.panel1.Location = new System.Drawing.Point(41, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(106, 100);
            this.panel1.TabIndex = 1;
            // 
            // labelDragAndDropInfo
            // 
            this.labelDragAndDropInfo.AllowDrop = true;
            this.labelDragAndDropInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDragAndDropInfo.Location = new System.Drawing.Point(-2, 0);
            this.labelDragAndDropInfo.Name = "labelDragAndDropInfo";
            this.labelDragAndDropInfo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelDragAndDropInfo.Size = new System.Drawing.Size(101, 96);
            this.labelDragAndDropInfo.TabIndex = 0;
            this.labelDragAndDropInfo.Text = "Drag and Drop Image files here to create a new overlay";
            this.labelDragAndDropInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelDragAndDropInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.labelDragAndDropInfo_DragDrop);
            this.labelDragAndDropInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.labelDragAndDropInfo_DragEnter);
            // 
            // labelSelectAnOverlay
            // 
            this.labelSelectAnOverlay.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectAnOverlay.Location = new System.Drawing.Point(6, 9);
            this.labelSelectAnOverlay.Name = "labelSelectAnOverlay";
            this.labelSelectAnOverlay.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelSelectAnOverlay.Size = new System.Drawing.Size(678, 26);
            this.labelSelectAnOverlay.TabIndex = 9;
            this.labelSelectAnOverlay.Text = "SELECT AN OVERLAY";
            this.labelSelectAnOverlay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEdit
            // 
            this.labelEdit.AutoSize = true;
            this.labelEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelEdit.Location = new System.Drawing.Point(7, 352);
            this.labelEdit.Name = "labelEdit";
            this.labelEdit.Size = new System.Drawing.Size(37, 13);
            this.labelEdit.TabIndex = 10;
            this.labelEdit.Text = "[+]Edit";
            this.labelEdit.Click += new System.EventHandler(this.labelEdit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(138, 31);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(319, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Value = 100;
            this.progressBar1.Visible = false;
            // 
            // SelectorOverlay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 673);
            this.Controls.Add(this.labelEdit);
            this.Controls.Add(this.labelSelectAnOverlay);
            this.Controls.Add(this.groupBoxCreateOverlay);
            this.Controls.Add(this.groupBoxOverlaySettings);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectorOverlay";
            this.Text = "Overlay Selector";
            this.Load += new System.EventHandler(this.SelectorOverlay_Load);
            this.groupBoxOverlaySettings.ResumeLayout(false);
            this.groupBoxCartridge.ResumeLayout(false);
            this.groupBoxCartridge.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCartridgeNum)).EndInit();
            this.groupBoxOpacity.ResumeLayout(false);
            this.groupBoxOpacity.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpaqueColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlayPreview)).EndInit();
            this.groupBoxCreateOverlay.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBoxOverlaySettings;
        private System.Windows.Forms.Label labelOpaqueColor;
        private System.Windows.Forms.GroupBox groupBoxCartridge;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.NumericUpDown numericUpDownCartridgeNum;
        private System.Windows.Forms.CheckBox checkBoxAsociate;
        private System.Windows.Forms.GroupBox groupBoxOpacity;
        private System.Windows.Forms.CheckBox checkBoxOpacityEnabled;
        private System.Windows.Forms.PictureBox pictureBoxOpaqueColor;
        private System.Windows.Forms.Button buttonPickOpaqueColor;
        private System.Windows.Forms.PictureBox pictureBoxOverlayPreview;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.GroupBox groupBoxCreateOverlay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDragAndDropInfo;
        private System.Windows.Forms.Label labelOverlayName;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Label labelNoteInfo;
        private System.Windows.Forms.Label labelSelectAnOverlay;
        private System.Windows.Forms.Label labelEdit;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}