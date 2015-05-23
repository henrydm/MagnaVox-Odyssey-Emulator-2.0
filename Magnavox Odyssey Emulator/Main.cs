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
using Magnavox_Odyssey_Emulator.AuxClasses;

namespace Magnavox_Odyssey_Emulator
{
    public partial class Main : Form
    {
        #region Definitions
        public static String FolderRoot;
        public static String PathDosBox;
        public static String FolderOdyemu;
        public static String FolderLanguages;
        public static String FolderOverlays;
        public static String FolderCartridges;

        bool _mouseOutOfSettings;
        Overlay CurrentOverlay;
        Cartridge CurrentCartridge;
        List<ToolTip> _currentTooltips;

        #endregion

        //Constructor
        public Main()
        {
            _currentTooltips = new List<ToolTip>();
            CurrentCartridge = Cartridge.Create(1);
            InitializeComponent();
        }

        #region -->Private Functions
        private void CopyFiles()
        {
            //Diccionaris de contingut dels fichers
            var binaryFiles = new Dictionary<String, byte[]>(); //-> <Path,Data>

            //Root Folder
            FolderRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "odyssey");
            if (Directory.Exists(FolderRoot) == false)
                Directory.CreateDirectory(FolderRoot);

            //DosBox
            PathDosBox = Path.Combine(FolderRoot, "DosBox.exe");

            //Odyssey Emulator Folder
            FolderOdyemu = Path.Combine(FolderRoot, "Odyemu");
            if (Directory.Exists(FolderOdyemu) == false)
                Directory.CreateDirectory(FolderOdyemu);


            //Languages Folder
            FolderLanguages = Path.Combine(FolderRoot, "Languages");
            if (Directory.Exists(FolderLanguages) == false)
                Directory.CreateDirectory(FolderLanguages);


            //OverLays Folder
            FolderOverlays = Path.Combine(FolderRoot, "Overlays");
            if (Directory.Exists(FolderOverlays) == false)
                Directory.CreateDirectory(FolderOverlays);

            //Cartridges Folder
            FolderCartridges = Path.Combine(FolderRoot, "Cartridges");
            if (Directory.Exists(FolderOverlays) == false)
                Directory.CreateDirectory(FolderOverlays);


            //KEBOARD
            if (!File.Exists(Path.Combine(FolderOdyemu, "KEBOARD.DAT")))
                Settings.ResetKeyBoardFile();

            //Afegim fitxers de recursos
            binaryFiles.Add(PathDosBox, Properties.Resources.DOSBox);
            binaryFiles.Add(Path.Combine(FolderRoot, "SDL.dll"), Properties.Resources.SDL);
            binaryFiles.Add(Path.Combine(FolderRoot, "SDL_net.dll"), Properties.Resources.SDL_net);

            binaryFiles.Add(Path.Combine(FolderOdyemu, "ODYEMU.EXE"), Properties.Resources.ODYEMU);
            binaryFiles.Add(Path.Combine(FolderOdyemu, "BMPTORLE.EXE"), Properties.Resources.BMPTORLE);
            binaryFiles.Add(Path.Combine(FolderOdyemu, "ODYEMU.INI"), Properties.Resources.ODYEMUINI);
            binaryFiles.Add(Path.Combine(FolderOdyemu, "ODYEMU.TXT"), Properties.Resources.ODYEMUTXT);

            //Afegim fitxers d'imioma
            binaryFiles.Add(Path.Combine(FolderLanguages, "English.lang"), Properties.Resources.English);
            binaryFiles.Add(Path.Combine(FolderLanguages, "Español.lang"), Properties.Resources.Español);


            //Copiem fichers
            try
            {
                foreach (var pair in binaryFiles)
                {
                    string path = pair.Key;
                    byte[] data = pair.Value;

                    if (File.Exists(path) == false)
                    {
                        FileStream file = File.Create(path);
                        file.Write(data, 0, data.Length);
                        file.Close();
                        file.Dispose();
                    }
                }


                //Cartutxos
                for (int i = 1; i <= 12; i++)
                {
                    if (!File.Exists(Path.Combine(FolderCartridges, "Cartridge" + i + ".Cartridge")))
                    {
                        var cart = Cartridge.Create(i);
                        cart.Save();
                    }
                }



                //Overlays
                if (!File.Exists(Path.Combine(FolderOverlays, "Analogic.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Analogic.png"), BuiltInOverlays.OverlaysImages.Analogic_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "BasketBall.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "BasketBall.png"), BuiltInOverlays.OverlaysImages.BasketBall_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Brain Wave.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Brain Wave.png"), BuiltInOverlays.OverlaysImages.Brain_Wave_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Cat and Mouse.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Cat and Mouse.png"), BuiltInOverlays.OverlaysImages.Cat_and_Mouse_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Football.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Football.png"), BuiltInOverlays.OverlaysImages.Football_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Hockey.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Hockey.png"), BuiltInOverlays.OverlaysImages.Hockey_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Percepts.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Percepts.png"), BuiltInOverlays.OverlaysImages.Percepts_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Roulette.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Roulette.png"), BuiltInOverlays.OverlaysImages.Roulette_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Simon Says.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Simon Says.png"), BuiltInOverlays.OverlaysImages.Simon_Says_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Ski.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Ski.png"), BuiltInOverlays.OverlaysImages.Ski_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Soccer.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Soccer.png"), BuiltInOverlays.OverlaysImages.Soccer_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "States.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "States.png"), BuiltInOverlays.OverlaysImages.States_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Submarine.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Submarine.png"), BuiltInOverlays.OverlaysImages.Submarine_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Tennis.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Tennis.png"), BuiltInOverlays.OverlaysImages.Tennis_png);
                if (!File.Exists(Path.Combine(FolderOverlays, "Win.png")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Win.png"), BuiltInOverlays.OverlaysImages.Win_png);

                if (!File.Exists(Path.Combine(FolderOverlays, "Analogic.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Analogic.Overlay"), BuiltInOverlays.OverlaysBinary.Analogic);
                if (!File.Exists(Path.Combine(FolderOverlays, "BasketBall.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "BasketBall.Overlay"), BuiltInOverlays.OverlaysBinary.BasketBall);
                if (!File.Exists(Path.Combine(FolderOverlays, "Brain Wave.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Brain Wave.Overlay"), BuiltInOverlays.OverlaysBinary.Brain_Wave);
                if (!File.Exists(Path.Combine(FolderOverlays, "Cat and Mouse.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Cat and Mouse.Overlay"), BuiltInOverlays.OverlaysBinary.Cat_and_Mouse);
                if (!File.Exists(Path.Combine(FolderOverlays, "Football.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Football.Overlay"), BuiltInOverlays.OverlaysBinary.Football);
                if (!File.Exists(Path.Combine(FolderOverlays, "Hockey.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Hockey.Overlay"), BuiltInOverlays.OverlaysBinary.Hockey);
                if (!File.Exists(Path.Combine(FolderOverlays, "Percepts.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Percepts.Overlay"), BuiltInOverlays.OverlaysBinary.Percepts);
                if (!File.Exists(Path.Combine(FolderOverlays, "Roulette.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Roulette.Overlay"), BuiltInOverlays.OverlaysBinary.Roulette);
                if (!File.Exists(Path.Combine(FolderOverlays, "Simon Says.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Simon Says.Overlay"), BuiltInOverlays.OverlaysBinary.Simon_Says);
                if (!File.Exists(Path.Combine(FolderOverlays, "Ski.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Ski.Overlay"), BuiltInOverlays.OverlaysBinary.Ski);
                if (!File.Exists(Path.Combine(FolderOverlays, "Soccer.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Soccer.Overlay"), BuiltInOverlays.OverlaysBinary.Soccer);
                if (!File.Exists(Path.Combine(FolderOverlays, "States.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "States.Overlay"), BuiltInOverlays.OverlaysBinary.States);
                if (!File.Exists(Path.Combine(FolderOverlays, "Submarine.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Submarine.Overlay"), BuiltInOverlays.OverlaysBinary.Submarine);
                if (!File.Exists(Path.Combine(FolderOverlays, "Tennis.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Tennis.Overlay"), BuiltInOverlays.OverlaysBinary.Tennis);
                if (!File.Exists(Path.Combine(FolderOverlays, "Win.Overlay")))
                    File.WriteAllBytes(Path.Combine(FolderOverlays, "Win.Overlay"), BuiltInOverlays.OverlaysBinary.Win);


            }
            catch (Exception e)
            {
                MessageBox.Show("Error al copiar els fichers: \n" + e.Message);
                return;
            }

            return;

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

            value = Language.StringCartridge;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxCartridge.Text = value;
            }

            value = Language.StringOverlay;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxOverlay.Text = value;
            }

            value = Language.StringRun;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxRun.Text = value;
            }

            value = Language.ToolTipCartridge;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(buttonCart, value);
                _currentTooltips.Add(tp);
            }

            value = Language.ToolTipOverlay;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(buttonOverlay, value);
                _currentTooltips.Add(tp);
            }

            value = Language.ToolTipRun;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(pictureBoxRun, value);
                _currentTooltips.Add(tp);
            }

            value = Language.ToolTipSettings;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(pictureBoxSettings, value);
                _currentTooltips.Add(tp);
            }

        }
        private Image GetCartridgeImage(byte num)
        {
            switch (num)
            {
                case 1: return Properties.Resources.buttonCart1_Image;
                case 2: return Properties.Resources.buttonCart2_Image;
                case 3: return Properties.Resources.buttonCart3_Image;
                case 4: return Properties.Resources.buttonCart4_Image;
                case 5: return Properties.Resources.buttonCart5_Image;
                case 6: return Properties.Resources.buttonCart6_Image;
                case 7: return Properties.Resources.buttonCart7_Image;
                case 8: return Properties.Resources.buttonCart8_Image;
                case 9: return Properties.Resources.buttonCart9_Image;
                case 10: return Properties.Resources.buttonCart10_Image;
                case 11: return Properties.Resources.buttonCart11_Image;
                case 12: return Properties.Resources.buttonCart12_Image;
                default: return Properties.Resources.none;
            }
        }
        private void Run()
        {
            var targetPathMo1 = Path.Combine(FolderOdyemu, "game.mo1");
            var targetPathBo1 = Path.Combine(FolderOdyemu, "game.bo1");

            var content = CurrentCartridge.Pins;

            if (CurrentOverlay != null)
            {
                File.WriteAllBytes(targetPathBo1, CurrentOverlay.Bo1);
                content.AddRange(CurrentOverlay.GetParameters());
            }

            File.WriteAllLines(targetPathMo1, content);


            //Arrenquem el DosBox
            string noConsole = "-noconsole ";
            string mountHD = "-c \"mount c " + FolderOdyemu + "\"";
            string switchToC = "-c \"c:\"";
            string runGame = "-c \"odyemu " + "game.mo1\"";
            string exit = "-c \"exit\"";


            ProcessStartInfo dosBoxInfo = new ProcessStartInfo(PathDosBox, noConsole + mountHD + switchToC + runGame + exit);
            Process dosBoxProcess = Process.Start(dosBoxInfo);
            this.Visible = false;
            dosBoxProcess.WaitForExit();
            this.Visible = true;
        }
        #endregion

        #region --> Form Events
        private void Form1_Load(object sender, EventArgs e)
        {
            CopyFiles();

            //Initialize Language
            var files = Directory.GetFiles(Main.FolderRoot, "Language.conf", SearchOption.AllDirectories);

            bool langLoaded = false;
            if (files != null && files.Length > 0)
            {
                var langFilePath = files[0];
                var lines = File.ReadLines(langFilePath).ToArray();
                if (lines != null && lines.Length > 0)
                {
                    Language.SetLanguage(lines[0]);
                    SetLanguageToUI();
                    langLoaded = true;
                }
            }

            if (!langLoaded)
            {
                Language.SetLanguage("English");
                SetLanguageToUI();
                langLoaded = true;
            }


            //Load Overlay
            CurrentOverlay = null;
            buttonOverlay.BackgroundImage = Properties.Resources.none;

            //Load Cartridge

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath);
            string file1 = Path.Combine(appPath, "stdout.txt");
            string file2 = Path.Combine(appPath, "stderr.txt");

            if (File.Exists(file1))
                File.Delete(file1);

            if (File.Exists(file2))
                File.Delete(file2);
        }

        private void buttonCart_Click(object sender, EventArgs e)
        {
            var selector = new SelectorCart();
            selector.ShowDialog();
            CurrentCartridge = selector.SelectedCart;
            buttonCart.Image = GetCartridgeImage((byte)CurrentCartridge.Num);
            selector.Dispose();

        }
        private void buttonOverlay_Click(object sender, EventArgs e)
        {
            var selector = new SelectorOverlay(CurrentOverlay);
            selector.ShowDialog();
            CurrentOverlay = selector.SelectedOverlay;

            if (selector.None)
            {
                buttonOverlay.BackgroundImage = Properties.Resources.none;
                CurrentOverlay = null;
            }

            else
            {
                if (CurrentOverlay != null)
                {
                    buttonOverlay.BackgroundImage = CurrentOverlay.Image;

                    if (CurrentOverlay.Asociate)
                    {
                        CurrentCartridge = Cartridge.Create(CurrentOverlay.Cartridge);
                        buttonCart.Image = GetCartridgeImage(CurrentOverlay.Cartridge);
                    }
                }

            }



        }

        private void pictureBoxRunEmulator_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pictureBoxRunEmulator_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pictureBoxRunEmulator_Click(object sender, EventArgs e)
        {

            Run();

        }

        private void pictureBoxSettings_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            //Zona fora
            if (x < pictureBoxSettings.Width * 0.4 && y > pictureBoxSettings.Height * 0.5 || x > pictureBoxSettings.Width * 0.8 && y < pictureBoxSettings.Height * 0.3)
            {
                if (!_mouseOutOfSettings)
                {
                    Cursor = Cursors.Default;
                    _mouseOutOfSettings = true;
                    pictureBoxSettings.Image = ResourcesGraphics.odysseyMachine;

                }
            }

            else
            {
                Cursor = Cursors.Hand;
                if (_mouseOutOfSettings)
                {
                    _mouseOutOfSettings = false;
                    pictureBoxSettings.Image = ResourcesGraphics.odysseyMachineLight;
                }
            }
        }
        private void pictureBoxSettings_MouseLeave(object sender, EventArgs e)
        {

            Cursor = Cursors.Default;
            _mouseOutOfSettings = true;
            pictureBoxSettings.Image = ResourcesGraphics.odysseyMachine;
        }
        private void pictureBoxSettings_Click(object sender, EventArgs e)
        {
            if (!_mouseOutOfSettings)
            {
              
                var dlg = new Settings();
                dlg.OnLanguageChanged += dlg_OnLanguageChanged;
                dlg.ShowDialog();
                dlg.OnLanguageChanged -= dlg_OnLanguageChanged;
                dlg.Dispose();
            }
        }

        void dlg_OnLanguageChanged(object sender, EventArgs e)
        {
            SetLanguageToUI();
        }

        #endregion
    }
}
