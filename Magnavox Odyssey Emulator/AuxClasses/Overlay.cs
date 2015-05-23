using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace Magnavox_Odyssey_Emulator.AuxClasses
{

    [Serializable]
    public class Overlay
    {
        
        public string FileName;
        public string Name;
        public Bitmap Image;
        public byte[] Bo1;
        public bool Opacity;
        public bool Asociate;
        public byte Cartridge;

        public Overlay()
        { }
        public Overlay(string filepath)
        {
            if (!File.Exists(filepath)) return;

            try
            {
                var bin = new BinaryFormatter();
                var stream = new MemoryStream(File.ReadAllBytes(filepath));
                var obj = bin.Deserialize(stream);
                stream.Close();
                if (obj != null && obj is Overlay)
                {
                    var overlay = obj as Overlay;
                    FileName = overlay.FileName;
                    Name = overlay.Name;
                    Image = overlay.Image;
                    Bo1 = overlay.Bo1;
                    Opacity = overlay.Opacity;
                    Asociate = overlay.Asociate;
                    Cartridge = overlay.Cartridge;
                }
            }
            catch { return; };

        }

        public bool IsValid()
        {
            if (String.IsNullOrEmpty(Name)) return false;
            if (String.IsNullOrWhiteSpace(Name)) return false;
            if (Image == null) return false;
            if (Bo1 == null || Bo1.Length < 1) return false;
            return true;
        }
        public bool Save()
        {
            if (!IsValid()) return false;

            try
            {
                var bin = new BinaryFormatter();
                var stream = File.Create(Path.Combine(Main.FolderOverlays, Name + ".Overlay"));
                bin.Serialize(stream, this);
                stream.Close();
                return true;

            }
            catch { return false; };
        }

        #region Windows API Imports
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

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

        private void WindowAction(string className)
        {
            System.IntPtr app_hwnd;
            WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
            app_hwnd = FindWindow(className, null);
            GetWindowPlacement(app_hwnd, ref wp);
            wp.showCmd = 2; // 1- Normal; 2 - Minimize; 3 - Maximize;
            SetWindowPlacement(app_hwnd, ref wp);
        }
        #endregion

        public bool SetOpaqueColor(Color opaqueColor)
        {


            var OroginalbitmapFilePath = Path.Combine(Main.FolderOverlays, FileName);
            bool succes = false;

            var img8bitPath = Path.Combine(Main.FolderOverlays, "parse.bmp");
            string bo1FilePath = String.Empty;

            try
            {
                var temp = new Bitmap(OroginalbitmapFilePath);
                var bm = new Bitmap(temp, new Size(320, 200));
                temp.Dispose();

                if (opaqueColor != null)
                    bm.SetPixel(0, 0, opaqueColor);


                Bitmap img8bit = ConvertorTo8Bit.ConvertTo8bppFormat(bm);



                //img8bit.Save(Path.Combine(Main.FolderOverlays, "8bit.bmp"));
                if (File.Exists(img8bitPath))
                {
                    File.Delete(img8bitPath);
                }

                img8bit.Save(img8bitPath, System.Drawing.Imaging.ImageFormat.Bmp);


                string noConsole = "-noconsole ";
                string mountHD = "-c \"mount c " + Main.FolderRoot + "\"";
                string switchToC = "-c \"c:\"";
                string switchDir = "-c \"cd Odyemu\"";
                string runBMR = "-c \"BMPTORLE " + "C:\\Overlays\\" + "parse.bmp" + " " + "C:\\Overlays\\" + "output.BO1\"";
                string exit = "-c \"exit\"";

                ProcessStartInfo dosBoxInfo = new ProcessStartInfo(Main.PathDosBox, noConsole + mountHD + switchToC + switchDir + runBMR + exit);
                dosBoxInfo.CreateNoWindow = true;
                dosBoxInfo.WindowStyle = ProcessWindowStyle.Minimized;
                dosBoxInfo.UseShellExecute = false;
                dosBoxInfo.ErrorDialog = false;

                dosBoxInfo.WindowStyle = ProcessWindowStyle.Minimized;
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
                var lastwrite = File.GetLastWriteTime(bo1FilePath);

                if (File.Exists(bo1FilePath))
                {
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

                    Bo1 = File.ReadAllBytes(bo1FilePath);
                    Image = new Bitmap(img8bit);
                    //File.Copy(bitmapFilePath, Path.Combine(Main.FolderOverlays, fileName));
                    //ov.Name = filenameWithoutExt;
                    //ov.Image = new Bitmap(img8bit);
                    //ov.Bo1 = File.ReadAllBytes(bo1FilePath);
                    //ov.Cartridge = 1;
                    //ov.Asociate = false;
                    //succes = ov.Save();

                }


                img8bit.Dispose();
                bm.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (File.Exists(bo1FilePath))
                {
                    File.Delete(bo1FilePath);
                }
            }

            Save();
            return succes;
        }

        public string[] GetParameters()
        {
            List<string> ret = new List<string>();

            ret.Add('@' + "game.bo1");

            if (Opacity)
                ret.Add("OPAQUE");

            return ret.ToArray();
        }
        public static Overlay GetDefaultOverlay()
        {
            var files = Directory.GetFiles(Main.FolderRoot, "*.Overlay", SearchOption.AllDirectories);
            var ov = new Overlay(files[0]);
            return ov;
        }
    }
}
