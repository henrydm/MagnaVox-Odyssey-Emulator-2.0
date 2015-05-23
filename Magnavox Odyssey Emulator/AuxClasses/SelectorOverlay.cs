using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Magnavox_Odyssey_Emulator.AuxClasses
{
    public partial class SelectorOverlay : Form
    {
        #region Definitions
        public Overlay SelectedOverlay;
        private bool _selectingColor;
        public bool None;
        private bool _isModifyngInterface;
        private bool _expanded;
        private List<ToolTip> _currentTooltips;
        #endregion

        //Constructor
        public SelectorOverlay(Overlay overlay)
        {
            _currentTooltips = new List<ToolTip>();
            InitializeComponent();
        }


        #region Form Events
        private void SelectorOverlay_Load(object sender, EventArgs e)
        {
            _expanded = false;
            this.Size = new Size(740, 403);
            this.listView1.View = View.LargeIcon;
            this.imageList1.ImageSize = new Size(96, 60);
            SetLanguageToUI();
            SetVoidValuesToUI();
            LoadOverlays();

        }

        private void labelDragAndDropInfo_DragDrop(object sender, DragEventArgs e)
        {
            var file = ((String[])e.Data.GetData(DataFormats.FileDrop))[0];

            progressBar1.Visible = true;

            var bw = new BackgroundWorker();
            bw.DoWork += (o, c) => { c.Result = CreateOverlay(file); };
            bw.RunWorkerCompleted += (o, c) =>
            {
                progressBar1.Visible = false;
                this.Focus();
                var ov = c.Result as Overlay;

                if (ov != null && ov.IsValid())
                {

                    MessageBox.Show(this, Path.GetFileNameWithoutExtension(file) + " overlay generated OK");

                    LoadOverlays();
                }

                else

                    MessageBox.Show(this, Path.GetFileNameWithoutExtension(file) + " overlay generated ERROR");

                this.Focus();
            };
            bw.RunWorkerAsync();

        }
        private void labelDragAndDropInfo_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listView1_SelectedChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                if (listView1.SelectedItems[0].Tag != null)
                {
                    SelectedOverlay = listView1.SelectedItems[0].Tag as Overlay;
                    None = false;
                }
                else
                {
                    SelectedOverlay = null;
                    None = true;
                }
            else
            {
                SelectedOverlay = null;
                None = false;
            }


            SetValuesToUI();
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBoxOpacityEnabled_CheckedChanged(object sender, EventArgs e)
        {
            buttonPickOpaqueColor.Enabled = checkBoxOpacityEnabled.Checked;
            if (checkBoxOpacityEnabled.Checked)
            {
                pictureBoxOpaqueColor.BackColor = SelectedOverlay.Image.GetPixel(0, 0);
            }
            else
            {
                pictureBoxOpaqueColor.BackColor = SelectorOverlay.DefaultBackColor;

            }

            if (_isModifyngInterface) return;

            SelectedOverlay.Opacity = checkBoxOpacityEnabled.Checked;
            SelectedOverlay.Save();
        }
        private void checkBoxAsociate_CheckedChanged(object sender, EventArgs e)
        {
            if (_isModifyngInterface) return;
            if (SelectedOverlay == null) return;
            SelectedOverlay.Asociate = checkBoxAsociate.Checked;
            SelectedOverlay.Save();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonPickOpaqueColor_Click(object sender, EventArgs e)
        {
            _selectingColor = true;
            pictureBoxOverlayPreview.Cursor = Cursors.Cross;

        }

        private void pictureBoxOverlayPreview_Click(object sender, EventArgs e)
        {
            if (!_selectingColor) return;
            if (SelectedOverlay == null) return;

            _selectingColor = false;


            progressBar1.Visible = true;
            this.Refresh();

            pictureBoxOverlayPreview.Cursor = Cursors.Default;

            var bw = new BackgroundWorker();
            bw.DoWork += (o, c) => { SelectedOverlay.SetOpaqueColor(pictureBoxOpaqueColor.BackColor); };
            bw.RunWorkerCompleted += (o, c) => { progressBar1.Visible = false; this.Focus(); };
            bw.RunWorkerAsync();




        }
        private void pictureBoxOverlayPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_selectingColor) return;
            if (SelectedOverlay == null) return;
            pictureBoxOpaqueColor.BackColor = SelectedOverlay.Image.GetPixel(e.X, e.Y);

        }

        private void numericUpDownCartridgeNum_ValueChanged(object sender, EventArgs e)
        {
            if (_isModifyngInterface) return;
            if (SelectedOverlay == null) return;
            SelectedOverlay.Cartridge = Convert.ToByte(numericUpDownCartridgeNum.Value);
            SelectedOverlay.Save();
        }

        private void labelEdit_Click(object sender, EventArgs e)
        {
            if (!_expanded)
            {
                labelEdit.Text = "[-]" + Language.StringEdit;
                this.Size = new Size(740, 697);
            }
            else
            {
                labelEdit.Text = "[+]" + Language.StringEdit;
                this.Size = new Size(740, 403);
            }
            _expanded = !_expanded;
        }
        #endregion


        #region Private Functions

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetWindowPlacement(IntPtr hWnd,
                           ref WINDOWPLACEMENT lpwndpl);
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        private struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }

        void WindowAction(string className)
        {
            System.IntPtr app_hwnd;
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            app_hwnd = FindWindow(className, null);
            GetWindowPlacement(app_hwnd, ref wp);
            wp.showCmd = 2; // 1- Normal; 2 - Minimize; 3 - Maximize;
            SetWindowPlacement(app_hwnd, ref wp);
        }

        private Overlay CreateOverlay(string bitmapFilePath)
        {
            bool succes = false;
            var ov = new Overlay();
            var fileDirectory = Path.GetPathRoot(bitmapFilePath);
            var fileName = Path.GetFileName(bitmapFilePath);
            var filenameWithoutExt = Path.GetFileNameWithoutExtension(bitmapFilePath);
            var img8bitPath = Path.Combine(Main.FolderOverlays, "img8bit.bmp");
            string bo1FilePath = String.Empty;

            try
            {

                var temp = new Bitmap(bitmapFilePath);
                var bm320 = new Bitmap(temp, new Size(320, 200));
                temp.Dispose();


                Bitmap img8bit = ConvertorTo8Bit.ConvertTo8bppFormat(bm320);


                if (File.Exists(img8bitPath))
                {
                    File.Delete(img8bitPath);
                }

                img8bit.Save(img8bitPath, System.Drawing.Imaging.ImageFormat.Bmp);


                string noConsole = "-noconsole ";
                string mountHD = "-c \"mount c " + Main.FolderRoot + "\"";
                string switchToC = "-c \"c:\"";
                string switchDir = "-c \"cd Odyemu\"";
                string runBMR = "-c \"BMPTORLE " + "C:\\Overlays\\" + "img8bit.bmp" + " " + "C:\\Overlays\\" + "output.BO1\"";
                string exit = "-c \"exit\"";

                ProcessStartInfo dosBoxInfo = new ProcessStartInfo(Main.PathDosBox, noConsole + mountHD + switchToC + switchDir + runBMR + exit);
                // dosBoxInfo.WindowStyle = ProcessWindowStyle.Minimized;
                Process dosBoxProcess = new Process();
                dosBoxProcess.StartInfo = dosBoxInfo;
                dosBoxProcess.Start();

                System.Threading.Thread.Sleep(200);

                System.IntPtr app_hwnd;
                WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
                app_hwnd = dosBoxProcess.MainWindowHandle;
                GetWindowPlacement(app_hwnd, ref wp);
                wp.showCmd = 2;
                SetWindowPlacement(app_hwnd, ref wp);


                dosBoxProcess.WaitForExit();


                File.Delete(img8bitPath);


                bo1FilePath = Path.Combine(Main.FolderOverlays, "output.BO1");


                if (File.Exists(bo1FilePath))
                {
                    var lastwrite = File.GetLastWriteTime(bo1FilePath);
                    TimeSpan g = DateTime.Now - lastwrite;

                    if (g.Seconds < 5)
                        succes = true;

                }
                else
                {
                    succes = false;
                }

                if (succes)
                {
                    if (!File.Exists(Path.Combine(Main.FolderOverlays, fileName)))
                        File.Copy(bitmapFilePath, Path.Combine(Main.FolderOverlays, fileName));
                    ov.FileName = fileName;
                    ov.Name = filenameWithoutExt;
                    ov.Image = new Bitmap(img8bit);
                    ov.Bo1 = File.ReadAllBytes(bo1FilePath);
                    ov.Cartridge = 1;
                    ov.Asociate = false;
                    succes = ov.Save();

                }


                img8bit.Dispose();
                bm320.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot create Overlay \n" + ex.Message);
                return null;
            }

            finally
            {
                if (File.Exists(bo1FilePath))
                {
                    File.Delete(bo1FilePath);
                }
            }

            return ov;
        }
        private void LoadOverlays()
        {
            listView1.Clear();
            imageList1.Images.Clear();

            var files = Directory.GetFiles(Main.FolderRoot, "*.Overlay", SearchOption.AllDirectories);
            for (int j = 0; j < files.Length; j++)
            {
                var file = files[j];
                try
                {
                    var overlay = new Overlay(file);
                    if (!overlay.IsValid()) continue;

                    this.imageList1.Images.Add(overlay.Image);
                    ListViewItem item = new ListViewItem();
                    item.Text = overlay.Name;
                    item.Tag = overlay;

                    item.ImageIndex = j;

                    this.listView1.Items.Add(item);
                }

                catch
                {

                }
            }


            this.imageList1.Images.Add(Properties.Resources.none);
            ListViewItem itemnone = new ListViewItem();
            itemnone.Text = "No Overlay";
            itemnone.ImageIndex = files.Length;
            this.listView1.Items.Add(itemnone);
        }
        private void SetValuesToUI()
        {

            if (SelectedOverlay == null || !SelectedOverlay.IsValid())
            {
                SetVoidValuesToUI();
                return;
            }
            else
            {
                _isModifyngInterface = true;
                groupBoxOpacity.Enabled = true;
                groupBoxCartridge.Enabled = true;

                checkBoxOpacityEnabled.Checked = SelectedOverlay.Opacity;
                buttonPickOpaqueColor.Enabled = SelectedOverlay.Opacity;

                if (SelectedOverlay.Opacity)
                {
                    pictureBoxOpaqueColor.BackColor = SelectedOverlay.Image.GetPixel(0, 0);
                }
                else
                {
                    pictureBoxOpaqueColor.BackColor = SelectorOverlay.DefaultBackColor;

                }
                checkBoxAsociate.Checked = SelectedOverlay.Asociate;

                numericUpDownCartridgeNum.Value = Convert.ToDecimal(SelectedOverlay.Cartridge);
                pictureBoxOverlayPreview.Image = SelectedOverlay.Image;
                labelOverlayName.Text = SelectedOverlay.Name;

                _isModifyngInterface = false;
            }

        }
        private void SetVoidValuesToUI()
        {
            _isModifyngInterface = true;
            checkBoxAsociate.Checked = false;
            numericUpDownCartridgeNum.Value = 1;
            pictureBoxOverlayPreview.Image = null;
            labelOverlayName.Text = String.Empty;

            checkBoxOpacityEnabled.Checked = false;
            pictureBoxOpaqueColor.BackColor = SelectorOverlay.DefaultBackColor;
            pictureBoxOpaqueColor.Enabled = false;
            groupBoxOpacity.Enabled = false;
            groupBoxCartridge.Enabled = false;
            _isModifyngInterface = false;

        }
        private void SetLanguageToUI()
        {

            if (_currentTooltips != null && _currentTooltips.Count > 0)
            {
                foreach (var tp in _currentTooltips)
                    if (tp != null)
                        tp.Dispose();
            }
            _currentTooltips.Clear();
            string value;

            //TITLE
            value = Language.StringSelectAnOverlay;
            if (!String.IsNullOrEmpty(value))
            {
                labelSelectAnOverlay.Text = value;
            }

            //EDIT
            value = Language.StringEdit;
            if (!String.IsNullOrEmpty(value))
            {
                labelEdit.Text = "[+]" + value;
            }

            //OVERLAY SETTINGS
            value = Language.StringOverlaySettings;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxOverlaySettings.Text = value;
            }

            //OPACITY
            value = Language.StringOpacity;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxOpacity.Text = value;
            }

            //OPACITY ENABLED
            value = Language.StringEnabled;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxOpacityEnabled.Text = value;
            }
            value = Language.ToolTipOpacityEnabled;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(checkBoxOpacityEnabled, value);
            }

            //OPAQUE COLOR
            value = Language.StringOpaqueColor;
            if (!String.IsNullOrEmpty(value))
            {
                labelOpaqueColor.Text = value;
            }
            value = Language.ToolTipOpaqueColor;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(buttonPickOpaqueColor, value);
                tp.SetToolTip(pictureBoxOpaqueColor, value);
            }

            //CARTRIDGE
            value = Language.StringCartridge;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxCartridge.Text = value;
            }

            //ASOCIATE
            value = Language.StringAsociate;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxAsociate.Text = value;
            }
            value = Language.ToolTipAsociate;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(checkBoxAsociate, value);
            }

            //NUM
            value = Language.StringNum;
            if (!String.IsNullOrEmpty(value))
            {
                labelNum.Text = value;
            }
            value = Language.ToolTipNum;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(numericUpDownCartridgeNum, value);
                tp.SetToolTip(labelNum, value);
            }

            //DragAndDrop
            value = Language.StringDragAndDropInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelDragAndDropInfo.Text = value;
            }
            value = Language.ToolTipDragAndDrop;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(labelDragAndDropInfo, value);
            }

            //NOTE
            value = Language.StringNote;
            if (!String.IsNullOrEmpty(value))
            {
                labelNote.Text = value;
            }
            //NOTE
            value = Language.StringColorInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelNoteInfo.Text = value;
            }

        }
        #endregion

    }
}
