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
using System.Globalization;
using System.Runtime.InteropServices;
using Magnavox_Odyssey_Emulator.AuxClasses;
namespace Magnavox_Odyssey_Emulator
{
    public partial class Settings : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys key);

        #region --> Definitions
        private List<ToolTip> _currentTooltips;

        string _dosBoxConfigPath;
        string _dosBoxPath;
        string _dosBoxFolderPath;

        public event EventHandler OnLanguageChanged;
        #endregion

        //Constructor
        public Settings()
        {
            _currentTooltips = new List<ToolTip>();
            InitializeComponent();
        }

        #region --> Form Events
        private void Settings_Load(object sender, EventArgs e)
        {
            _dosBoxFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DosBox");
            _dosBoxConfigPath = Path.Combine(_dosBoxFolderPath, "dosbox-0.74.conf");
            _dosBoxPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Odyssey", "DosBox.exe");

            //Comprobem que existeixi la carpeta de configuracio del DosBox si no la creem
            if (Directory.Exists(_dosBoxFolderPath) == false || File.Exists(_dosBoxConfigPath) == false)
            {
                ProcessStartInfo dosBoxInfo = new ProcessStartInfo(_dosBoxPath);
                Process dosBoxProcess = Process.Start(dosBoxInfo);

                while (Directory.Exists(_dosBoxFolderPath) == false)
                    System.Threading.Thread.Sleep(100);

                dosBoxProcess.Kill();
            }



            SetAllSettingToUI();
            LoadLanguagesCombo();
            SetLanguageToUI();
        }

        //Reset
        private void buttonResetKeyboard_Click(object sender, EventArgs e)
        {


            ResetKeyBoardFile();

            SetKeyboardConfigToUI();
        }
        private void buttonResetConfig_Click(object sender, EventArgs e)
        {
            checkBoxHideCursor.Checked = true;
            checkBoxFullScreen.Checked = false;
            SaveEmulatorConfig();

            var emuconfigPath = Path.Combine(Main.FolderOdyemu, "ODYEMU.INI");
            if (File.Exists(emuconfigPath))
                File.Delete(emuconfigPath);

            FileStream file = File.Create(emuconfigPath);
            file.Write(Properties.Resources.ODYEMUINI, 0, Properties.Resources.ODYEMUINI.Length);
            file.Close();
            file.Dispose();

            SetEmulatorConfigToUI();
        }

        //KeyBoard
        private void textBoxKeyBoardKeyUp(object sender, KeyEventArgs e)
        {
            var textBox = (TextBox)sender;

            //SHIFT
            if (e.KeyCode == Keys.ShiftKey)
            {
                var lShift = GetAsyncKeyState(Keys.LShiftKey);
                var rShift = GetAsyncKeyState(Keys.RShiftKey);

                if (lShift == 1)
                    textBox.Text = System.Enum.GetName(typeof(Keys), Keys.LShiftKey);

                if (rShift == 1)
                    textBox.Text = System.Enum.GetName(typeof(Keys), Keys.RShiftKey);
            }

            //ALT
            else if (e.KeyCode == Keys.Menu)
            {
                var lAlt = GetAsyncKeyState(Keys.LMenu);
                var rAlt = GetAsyncKeyState(Keys.RMenu);

                if (lAlt == 1)
                    textBox.Text = System.Enum.GetName(typeof(Keys), Keys.LMenu);

                if (rAlt == 1)
                    textBox.Text = System.Enum.GetName(typeof(Keys), Keys.RMenu);
            }


            else
                textBox.Text = System.Enum.GetName(typeof(Keys), e.KeyCode);


            this.SelectNextControl(this.ActiveControl, true, true, true, true);


            //Keys g = (Keys)System.Enum.Parse(typeof(Keys), ((TextBox)sender).Text);
            // String f = System.Enum.GetName(typeof(Keys), e.KeyCode);
        }
        private void textBoxKeyBoardKeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        //Capacitors
        private void knobControlBatSizeH_ValueChanged(object Sender)
        {
            lbDigitalMeterBatSizeH.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatSizeV_ValueChanged(object Sender)
        {
            lbDigitalMeterBatSizeV.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBallSize_ValueChanged(object Sender)
        {
            lbDigitalMeterBallSize.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlWallSize_ValueChanged(object Sender)
        {
            lbDigitalMeterWallSize.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlWallWide_ValueChanged(object Sender)
        {
            lbDigitalMeterWallWide.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlWallPercentage_ValueChanged(object Sender)
        {
            lbDigitalMeterWallPercentage.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlWallPosition_ValueChanged(object Sender)
        {
            lbDigitalMeterWallPosition.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatSpotH_ValueChanged(object Sender)
        {
            lbDigitalMeterBatSpotH.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatSpotV_ValueChanged(object Sender)
        {
            lbDigitalMeterBatSpotV.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatDampH_ValueChanged(object Sender)
        {
            lbDigitalMeterBatDampH.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatDampV_ValueChanged(object Sender)
        {
            lbDigitalMeterBatDampV.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBallSpotH_ValueChanged(object Sender)
        {
            lbDigitalMeterBallSpotH.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBallSpotV_ValueChanged(object Sender)
        {
            lbDigitalMeterBallSpotV.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatAcceleration_ValueChanged(object Sender)
        {
            lbDigitalMeterBatAcceleration.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlBatDeceleration_ValueChanged(object Sender)
        {
            lbDigitalMeterBatDeceleration.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlEngAcceleration_ValueChanged(object Sender)
        {
            lbDigitalMeterEngAcceleration.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlEngDeceleration_ValueChanged(object Sender)
        {
            lbDigitalMeterEngDeceleration.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlWallCapacitor_ValueChanged(object Sender)
        {
            lbDigitalMeterWallCapacitor.Value = ((KnobControl.KnobControl)Sender).Value;
        }
        private void knobControlRiffleCapacitor_ValueChanged(object Sender)
        {
            lbDigitalMeterRiffleCapacitor.Value = ((KnobControl.KnobControl)Sender).Value;
        }

        private void buttonOpenUserFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = Main.FolderRoot;
            prc.Start();
        }

        private void textBoxResolution_TextChanged(object sender, EventArgs e)
        {
            var text = ((TextBox)sender).Text;

            foreach (var c in text)
                if (!Char.IsNumber(c))
                    ((TextBox)sender).Text = String.Empty;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Language.SetLanguage(comboBoxLanguage.SelectedItem.ToString());
            SetLanguageToUI();
            if (OnLanguageChanged != null) OnLanguageChanged(this, null);
        }
        private void comboBoxOutPut_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxOutPut.Text == "surface")
            {
                textBoxResolutionX.Text = String.Empty;
                textBoxResolutionY.Text = String.Empty;

                textBoxResolutionY.Enabled = false;
                textBoxResolutionX.Enabled = false;
            }
            else
            {
                textBoxResolutionY.Enabled = true;
                textBoxResolutionX.Enabled = true;

                var lines = File.ReadAllLines(_dosBoxConfigPath);

                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];

                    if (String.IsNullOrEmpty(line)) continue;

                    if (line.StartsWith("windowresolution="))
                    {

                        textBoxResolutionX.Text = String.Empty;
                        textBoxResolutionY.Text = String.Empty;
                        if (line != "windowresolution=original")
                        {
                            var resolution = line.Trim("windowresolution=".ToCharArray());

                            bool y = false;
                            foreach (char c in resolution)
                            {
                                if (y)
                                    textBoxResolutionY.Text += c;
                                else
                                    if (char.IsNumber(c))
                                        textBoxResolutionX.Text += c;
                                    else y = true;

                            }
                        }
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveAllSettingsFromUI();
            this.Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region --> Private Functions
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

            //BUTTONS
            value = Language.StringSave;
            if (!String.IsNullOrEmpty(value))
            {
                buttonSave.Text = value;
            }

            value = Language.StringCancel;
            if (!String.IsNullOrEmpty(value))
            {
                buttonCancel.Text = value;
            }

            value = Language.StringCancel;
            if (!String.IsNullOrEmpty(value))
            {
                buttonCancel.Text = value;
            }


            //TAB TITLES
            value = Language.StringCapacitorsAndPerformance;
            if (!String.IsNullOrEmpty(value))
            {
                tabPageCapacitors.Text = value;
            }

            value = Language.StringObjectSizes;
            if (!String.IsNullOrEmpty(value))
            {
                tabPageObjectSizes.Text = value;
            }

            value = Language.StringKeboardSettings;
            if (!String.IsNullOrEmpty(value))
            {
                tabPageKeyBoardSettings.Text = value;
            }

            value = Language.StringOtherSettings;
            if (!String.IsNullOrEmpty(value))
            {
                tabPageOtherSettings.Text = value;
            }

            //FALTA ABOUT

            /*FINAL TABS*/






            /*CAPACITORS & PERFORMANCE*/

            //BatSpotH
            value = Language.StringBatSpotH;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSpotH.Text = value;
            }
            value = Language.ToolTipBatSpotH;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatSpotH, value);
                _currentTooltips.Add(tp);
            }

            //BatSpotV
            value = Language.StringBatSpotV;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSpotV.Text = value;
            }
            value = Language.ToolTipBatSpotV;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatSpotV, value);
            }

            //BatDampH
            value = Language.StringBatDampH;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatDampH.Text = value;
            }
            value = Language.ToolTipBatDampH;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatDampH, value);
            }

            //BatDampV
            value = Language.StringBatDampV;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatDampV.Text = value;
            }
            value = Language.ToolTipBatDampV;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatDampV, value);
            }

            //BallSpotH
            value = Language.StringBallSpotH;
            if (!String.IsNullOrEmpty(value))
            {
                labelBallSpotH.Text = value;
            }
            value = Language.ToolTipBallSpotH;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBallSpotH, value);
            }

            //BallSpotV
            value = Language.StringBallSpotV;
            if (!String.IsNullOrEmpty(value))
            {
                labelBallSpotV.Text = value;
            }
            value = Language.ToolTipBallSpotV;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBallSpotV, value);
            }

            //BatAcceleration
            value = Language.StringBatAceleration;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatAcelaration.Text = value;
            }
            value = Language.ToolTipBatAceleration;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatAcceleration, value);
                _currentTooltips.Add(tp);
            }

            //BatDeceleration
            value = Language.StringBatDeceleration;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatDeceleration.Text = value;
            }
            value = Language.ToolTipBatDeceleration;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatDeceleration, value);
                _currentTooltips.Add(tp);
            }

            //EngAceleration
            value = Language.StringEngAceleration;
            if (!String.IsNullOrEmpty(value))
            {
                labelEngAceleration.Text = value;
            }
            value = Language.ToolTipEngAceleration;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxEngAcceleration, value);
                _currentTooltips.Add(tp);
            }

            //EngDeceleration
            value = Language.StringEngDeceleration;
            if (!String.IsNullOrEmpty(value))
            {
                labelEngDeceleration.Text = value;
            }
            value = Language.ToolTipEngDeceleration;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxEngDeceleration, value);
                _currentTooltips.Add(tp);
            }

            //INFO
            value = Language.StringCapacitorsTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelCapacitors.Text = value;
            }
            value = Language.StringCapacitorsInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelCapacitorsInfo.Text = value;
            }

            value = Language.StringBatSpots;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSpots.Text = value;
            }
            value = Language.StringBatSpotsInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSpotsInfo.Text = value;
            }


            /*OBJECT SIZES*/

            //BatSizeH
            value = Language.StringBatSizeH;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSizeH.Text = value;
            }
            value = Language.ToolTipBatSizeH;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatSizeH, value);
                _currentTooltips.Add(tp);
            }

            //BatSizeV
            value = Language.StringBatSizeV;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSizeV.Text = value;
            }
            value = Language.ToolTipBatSizeV;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBatSizeV, value);
                _currentTooltips.Add(tp);
            }

            //BallSize
            value = Language.StringBallSize;
            if (!String.IsNullOrEmpty(value))
            {
                labelBallSize.Text = value;
            }
            value = Language.ToolTipBallSize;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxBallSize, value);
                _currentTooltips.Add(tp);
            }


            //WIDTH WALL SIDE
            value = Language.StringWidthWallSize;
            if (!String.IsNullOrEmpty(value))
            {
                labelWidthWallSize.Text = value;
            }
            value = Language.ToolTipWidthWallSize;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxWidthWallSize, value);
                _currentTooltips.Add(tp);
            }

            //WIDTH WALL WIDE
            value = Language.StringWidthWallWide;
            if (!String.IsNullOrEmpty(value))
            {
                labelWidthWallWide.Text = value;
            }
            value = Language.ToolTipWidthWallWide;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxWidthWallWide, value);
                _currentTooltips.Add(tp);
            }

            //WALL PERCENTAGE
            value = Language.StringWallPercentage;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPercentage.Text = value;
            }

            value = Language.ToolTipWallPercentage;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxWallPercentage, value);
                _currentTooltips.Add(tp);
            }


            //WallPosition
            value = Language.StringWallPosition;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPosition.Text = value;
            }
            value = Language.ToolTipWallPosition;
            if (!String.IsNullOrEmpty(value))
            {
                var tp = new ToolTip();
                tp.SetToolTip(groupBoxWallPosition, value);
                _currentTooltips.Add(tp);
            }



            //INFO
            //SIZES
            value = Language.StringSizeInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelSizeInfo.Text = value;
            }

            //BAT SIZE
            value = Language.StringBatSizeTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSizeTitle.Text = value;
            }
            value = Language.StringBatSizeInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelBatSizeInfo.Text = value;
            }

            //BALL SIZE
            value = Language.StringBallSizeTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelBallSizeTitle.Text = value;
            }
            value = Language.StringBallSizeInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelBallSizeInfo.Text = value;
            }

            //WALL WIDTH
            value = Language.StringWallWidthTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallWidthTitle.Text = value;
            }
            value = Language.StringWallWidthInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallWidthInfo.Text = value;
            }

            //WALL PERCENTAGE
            value = Language.StringWallPercentageTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPercentageTitle.Text = value;
            }
            value = Language.StringWallPercentageInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPercentageInfo.Text = value;
            }


            //WALL PERCENTAGE
            value = Language.StringWallPositionTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPositionTitle.Text = value;
            }
            value = Language.StringWallPositionInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallPositionInfo.Text = value;
            }

            /*FINAL OBJECT SIZES*/


            /*KEYBOARD*/

            //PLAYER 1
            value = Language.StringPlayer1;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxPlayer1.Text = value;
            }

            //PLAYER 2
            value = Language.StringPlayer2;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxPlayer2.Text = value;
            }

            //MOVE UP
            value = Language.StringMoveUp;
            if (!String.IsNullOrEmpty(value))
            {
                labelMoveUp1.Text = value;
                labelMoveUp2.Text = value;
            }
            //MOVE DOWN
            value = Language.StringMoveDown;
            if (!String.IsNullOrEmpty(value))
            {
                labelMoveDown1.Text = value;
                labelMoveDown2.Text = value;
            }
            //MOVE RIGHT
            value = Language.StringMoveRight;
            if (!String.IsNullOrEmpty(value))
            {
                labelMoveRight1.Text = value;
                labelMoveRight2.Text = value;
            }
            //MOVE LEFT
            value = Language.StringMoveLeft;
            if (!String.IsNullOrEmpty(value))
            {
                labelMoveLeft1.Text = value;
                labelMoveLeft2.Text = value;
            }
            //ENGLISH UP
            value = Language.StringEnglishUp;
            if (!String.IsNullOrEmpty(value))
            {
                labelEnglishUp1.Text = value;
                labelEnglishUp2.Text = value;
            }
            //ENGLISH DOWN
            value = Language.StringEnglishDown;
            if (!String.IsNullOrEmpty(value))
            {
                labelEnglishDown1.Text = value;
                labelEnglishDown2.Text = value;
            }

            //SERVE BALL
            value = Language.StringServeBall;
            if (!String.IsNullOrEmpty(value))
            {
                labelServe1.Text = value;
                labelServe2.Text = value;
            }

            //RESRT KEYBOARD
            value = Language.StringReset;
            if (!String.IsNullOrEmpty(value))
            {
                buttonResetKeyboard.Text = value;
            }


            /*FINAL KEYBOARD*/


            /*OTHER SETTINGS*/

            //GLOBAL SETTINGS
            value = Language.StringGlobalSettings;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxGlobalSettings.Text = value;
            }

            //AUTOMATIC PLAYER 
            value = Language.StringAutomaticPlayer;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxAutoMaticPlayer.Text = value;
            }

            //AUTOMATIC PLAYER 1
            value = Language.StringPlayer1;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxAutoP1.Text = value;
            }

            //AUTOMATIC PLAYER 2
            value = Language.StringPlayer2;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxAutoP2.Text = value;
            }


            //COLORS 
            value = Language.StringColors;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxColors.Text = value;
            }

            //Color
            value = Language.StringColor;
            if (!String.IsNullOrEmpty(value))
            {
                labelColor.Text = value;
            }

            //TColor
            value = Language.StringTColor;
            if (!String.IsNullOrEmpty(value))
            {
                labelTColor.Text = value;
            }


            //DOS ENVIORNMENT
            value = Language.StringDOSNEnviornment;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxDosEnviornment.Text = value;
            }

            //FULL SCREEN
            value = Language.StringFullScreen;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxFullScreen.Text = value;
            }

            //HIDE CURSOR
            value = Language.StringHideCursor;
            if (!String.IsNullOrEmpty(value))
            {
                checkBoxHideCursor.Text = value;
            }


            //LANGUAGE
            value = Language.StringLanguage;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxLanguage.Text = value;
            }


            //OTHER CAPACITORS
            value = Language.StringOtherCapacitors;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxOtherCapacitors.Text = value;
            }

            //WALL CAPACITORS
            value = Language.StringWallCapacitors;
            if (!String.IsNullOrEmpty(value))
            {
                labelWallCapacitor.Text = value;
            }

            //RIFFLE CAPACITOR
            value = Language.StringRiffleCapacitor;
            if (!String.IsNullOrEmpty(value))
            {
                labelRiffleCapacitor.Text = value;
            }


            //RIFFLE CAPACITOR TITLE
            value = Language.StringRiffleCapacitorTitle;
            if (!String.IsNullOrEmpty(value))
            {
                labelRiffleCapacitorTitle.Text = value;
            }

            //RIFFLE CAPACITOR INFO
            value = Language.StringRiffleCapacitorInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelRiffleCapacitorInfo.Text = value;
            }



            //USER FOLDER 
            value = Language.StringUserFolder;
            if (!String.IsNullOrEmpty(value))
            {
                groupBoxUserFolder.Text = value;
            }

            //USER FOLDER INFO
            value = Language.StringUserFolderInfo;
            if (!String.IsNullOrEmpty(value))
            {
                labelUserFolderInfo.Text = value;
            }

            //OPEN USER FOLDER
            value = Language.StringOpen;
            if (!String.IsNullOrEmpty(value))
            {
                buttonOpenUserFolder.Text = value;
            }

            //OUTPUT
            value = Language.StringOutput;
            if (!String.IsNullOrEmpty(value))
            {
                labelOutput.Text = value;
            }

            //RESOLUTION
            value = Language.StringResolution;
            if (!String.IsNullOrEmpty(value))
            {
                labelResolution.Text = value;
            }

        }
        private void LoadLanguagesCombo()
        {
            for (int i = 0; i < Language.AvaliableLanguages.Count; i++)
            {
                var lang = Language.AvaliableLanguages[i];
                comboBoxLanguage.Items.Add(lang);
                if (lang == Language.CurrentLanguage)
                {
                    comboBoxLanguage.SelectedIndex = i;
                }
            }

        }

        private void SaveAllSettingsFromUI()
        {
            SaveDosSettings();
            SaveEmulatorConfig();
            SaveKeyboardConfigFromUI();
        }
        private void SetAllSettingToUI()
        {
            SetDosSettingsToUI();
            SetKeyboardConfigToUI();
            SetEmulatorConfigToUI();
        }

        private void SaveDosSettings()
        {
            var newLines = new List<string>();

            var lines = File.ReadAllLines(_dosBoxConfigPath);

            for (int i = 0; i < lines.Length; i++)
            {

                if (lines[i].StartsWith("output="))
                {
                    lines[i] = "output=" + comboBoxOutPut.Text;
                }

                if (lines[i].StartsWith("fullscreen="))
                {
                    lines[i] = "fullscreen=" + (checkBoxFullScreen.Checked ? "true" : "false");
                }
                else if (lines[i].StartsWith("autolock="))
                {
                    lines[i] = "autolock=" + (checkBoxHideCursor.Checked ? "true" : "false");
                }
                else if (lines[i].StartsWith("windowresolution="))
                {

                    if (String.IsNullOrEmpty(textBoxResolutionX.Text) || String.IsNullOrEmpty(textBoxResolutionY.Text) || String.IsNullOrWhiteSpace(textBoxResolutionX.Text) || String.IsNullOrWhiteSpace(textBoxResolutionY.Text))
                        lines[i] = "windowresolution=original";
                    else
                        lines[i] = "windowresolution=" + textBoxResolutionX.Text + "x" + textBoxResolutionY.Text;
                }
                else if (lines[i].StartsWith("fullesolution="))
                {

                    if (String.IsNullOrEmpty(textBoxResolutionX.Text) || String.IsNullOrEmpty(textBoxResolutionY.Text) || String.IsNullOrWhiteSpace(textBoxResolutionX.Text) || String.IsNullOrWhiteSpace(textBoxResolutionY.Text))
                        lines[i] = "fullesolution=original";
                    else
                        lines[i] = "fullesolution=" + textBoxResolutionX.Text + "x" + textBoxResolutionY.Text;
                }
            }

            File.WriteAllLines(_dosBoxConfigPath, lines);
        }
        private void SetDosSettingsToUI()
        {

            var lines = File.ReadAllLines(_dosBoxConfigPath);

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (String.IsNullOrEmpty(line)) continue;

                if (line.StartsWith("output="))
                {


                    var currentOutput = line.Substring(7, line.Length - 7);

                    for (int j = 0; j < comboBoxOutPut.Items.Count; j++)
                    {
                        var item = comboBoxOutPut.Items[j];
                        if (item.ToString() == currentOutput)
                        {
                            comboBoxOutPut.SelectedIndex = j;
                        }
                    }
                }

                if (line.StartsWith("fullscreen="))
                {
                    checkBoxFullScreen.Checked = line == "fullscreen=true";
                }
                else if (line.StartsWith("autolock="))
                {
                    checkBoxHideCursor.Checked = line == "autolock=true";
                }
                else if (line.StartsWith("windowresolution="))
                {

                    if (line != "windowresolution=original")
                    {
                        var resolution = line.Trim("windowresolution=".ToCharArray());

                        bool y = false;
                        foreach (char c in resolution)
                        {
                            if (y)
                                textBoxResolutionY.Text += c;
                            else
                                if (char.IsNumber(c))
                                    textBoxResolutionX.Text += c;
                                else y = true;

                        }
                    }
                }
            }
        }

        private void SaveKeyboardConfigFromUI()
        {
            var data = new byte[28];

            data[0] = ParseToIBMATEncoding(textBoxPlayer1Left.Text);
            data[2] = ParseToIBMATEncoding(textBoxPlayer1Right.Text);
            data[4] = ParseToIBMATEncoding(textBoxPlayer1Up.Text);
            data[6] = ParseToIBMATEncoding(textBoxPlayer1Down.Text);
            data[8] = ParseToIBMATEncoding(textBoxPlayer1EnglishUp.Text);
            data[10] = ParseToIBMATEncoding(textBoxPlayer1EnglishDown.Text);
            data[12] = ParseToIBMATEncoding(textBoxPlayer1Serve.Text);

            data[14] = ParseToIBMATEncoding(textBoxPlayer2Left.Text);
            data[16] = ParseToIBMATEncoding(textBoxPlayer2Right.Text);
            data[18] = ParseToIBMATEncoding(textBoxPlayer2Up.Text);
            data[20] = ParseToIBMATEncoding(textBoxPlayer2Down.Text);
            data[22] = ParseToIBMATEncoding(textBoxPlayer2EnglishUp.Text);
            data[24] = ParseToIBMATEncoding(textBoxPlayer2EnglishDown.Text);
            data[26] = ParseToIBMATEncoding(textBoxPlayer2Serve.Text);

            var filePath = Path.Combine(Main.FolderOdyemu, "KEYBOARD.DAT");

            if (Directory.Exists(Main.FolderOdyemu) == false) return;

            File.WriteAllBytes(filePath, data);

        }
        private void SetKeyboardConfigToUI()
        {
            if (Directory.Exists(Main.FolderOdyemu) == false) return;
            var filePath = Path.Combine(Main.FolderOdyemu, "KEYBOARD.DAT");
            if (File.Exists(filePath) == false) return;

            var data = File.ReadAllBytes(filePath);

            if (data.Length != 28) return;

            textBoxPlayer1Left.Text = ParseFromIBMATEncoding(data[0]).ToString();
            textBoxPlayer1Right.Text = ParseFromIBMATEncoding(data[2]).ToString();
            textBoxPlayer1Up.Text = ParseFromIBMATEncoding(data[4]).ToString();
            textBoxPlayer1Down.Text = ParseFromIBMATEncoding(data[6]).ToString();
            textBoxPlayer1EnglishUp.Text = ParseFromIBMATEncoding(data[8]).ToString();
            textBoxPlayer1EnglishDown.Text = ParseFromIBMATEncoding(data[10]).ToString();
            textBoxPlayer1Serve.Text = ParseFromIBMATEncoding(data[12]).ToString();

            textBoxPlayer2Left.Text = ParseFromIBMATEncoding(data[18]).ToString();
            textBoxPlayer2Right.Text = ParseFromIBMATEncoding(data[20]).ToString();
            textBoxPlayer2Up.Text = ParseFromIBMATEncoding(data[14]).ToString();
            textBoxPlayer2Down.Text = ParseFromIBMATEncoding(data[16]).ToString();
            textBoxPlayer2EnglishUp.Text = ParseFromIBMATEncoding(data[22]).ToString();
            textBoxPlayer2EnglishDown.Text = ParseFromIBMATEncoding(data[24]).ToString();
            textBoxPlayer2Serve.Text = ParseFromIBMATEncoding(data[26]).ToString();





            File.WriteAllBytes(filePath, data);

        }

        private void SaveEmulatorConfig()
        {
            var filePath = Path.Combine(Main.FolderOdyemu, "ODYEMU.INI");
            if (Directory.Exists(Main.FolderOdyemu) == false)
                Directory.CreateDirectory(Main.FolderOdyemu);


            List<string> lines = new List<string>();

            lines.Add(String.Format("{0} = {1}", "HBatCap", Convert.ToString(knobControlBatSpotH.Value)));
            lines.Add(String.Format("{0} = {1}", "VBatCap", Convert.ToString(knobControlBatSpotV.Value)));
            lines.Add(String.Format("{0} = {1}", "HDampCap", Convert.ToString(knobControlBatDampH.Value)));
            lines.Add(String.Format("{0} = {1}", "VDampCap", Convert.ToString(knobControlBatDampV.Value)));
            lines.Add(String.Format("{0} = {1}", "HBallCap", Convert.ToString(knobControlBallSpotH.Value)));
            lines.Add(String.Format("{0} = {1}", "VBallCap", Convert.ToString(knobControlBallSpotV.Value)));
            lines.Add(String.Format("{0} = {1}", "RifleCap", Convert.ToString(knobControlRiffleCapacitor.Value)));
            lines.Add(String.Format("{0} = {1}", "WallCap", Convert.ToString(knobControlWallCapacitor.Value)));
            lines.Add(String.Format("{0} = {1}", "HBatSize", Convert.ToString(knobControlBatSizeH.Value)));
            lines.Add(String.Format("{0} = {1}", "VBatSize", Convert.ToString(knobControlBatSizeV.Value)));
            lines.Add(String.Format("{0} = {1}", "BallSize", Convert.ToString(knobControlBallSize.Value)));
            lines.Add(String.Format("{0} = {1}", "HWallSize", Convert.ToString(knobControlWallSize.Value)));
            lines.Add(String.Format("{0} = {1}", "HWallWide", Convert.ToString(knobControlWallWide.Value)));
            lines.Add(String.Format("{0} = {1}", "SmallWallPercent", Convert.ToString(knobControlWallPercentage.Value)));
            lines.Add(String.Format("{0} = {1}", "HWallEarly", Convert.ToString(knobControlWallPosition.Value)));
            lines.Add(String.Format("{0} = {1}", "BatAcc", Convert.ToString(knobControlBatAcceleration.Value)));
            lines.Add(String.Format("{0} = {1}", "BatDec", Convert.ToString(knobControlBatDeceleration.Value)));
            lines.Add(String.Format("{0} = {1}", "EngAcc", Convert.ToString(knobControlEngAcceleration.Value)));
            lines.Add(String.Format("{0} = {1}", "EngDec", Convert.ToString(knobControlEngDeceleration.Value)));
            lines.Add(String.Format("{0} = {1}", "Colour", Convert.ToString(numericUpDownColor.Value)));
            lines.Add(String.Format("{0} = {1}", "TColour", Convert.ToString(numericUpDownTColor.Value)));

            lines.Add(String.Format("{0} = {1}", "Auto1", checkBoxAutoP1.Checked ? "1" : "0"));
            lines.Add(String.Format("{0} = {1}", "Auto2", checkBoxAutoP2.Checked ? "1" : "0"));


            File.Delete(filePath);
            File.WriteAllLines(filePath, lines);



        }
        private void SetEmulatorConfigToUI()
        {
            var filePath = Path.Combine(Main.FolderOdyemu, "ODYEMU.INI");
            if (Directory.Exists(Main.FolderOdyemu) == false) return;
            if (File.Exists(filePath) == false) return;

            List<string> lines = File.ReadLines(filePath).ToList();

            foreach (var l in lines)
            {
                if (l.Contains(";") || String.IsNullOrEmpty(l)) continue;

                string value = String.Empty;
                if (l.Contains("HBatCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatSpotH.Value = Convert.ToInt32(value);
                }
                if (l.Contains("VBatCap "))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatSpotV.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("HDampCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatDampH.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("VDampCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatDampV.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("HBallCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBallSpotH.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("VBallCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBallSpotV.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("RifleCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlRiffleCapacitor.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("WallCap"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlWallCapacitor.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("HBatSize"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatSizeH.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("VBatSize"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatSizeV.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("BallSize"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBallSize.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("HWallSize"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlWallSize.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("HWallWide"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlWallWide.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("SmallWallPercent"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlWallPercentage.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("HWallEarly"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlWallPosition.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("BatAcc"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatAcceleration.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("BatDec "))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlBatDeceleration.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("EngAcc"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlEngAcceleration.Value = Convert.ToInt32(value);
                }
                else if (l.Contains("EngDec"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        knobControlEngDeceleration.Value = Convert.ToInt32(value);
                }

                //Colors
                else if (l.Contains("TColour"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        numericUpDownTColor.Value = Convert.ToInt32(value);
                }

                else if (l.Contains("Colour"))
                {
                    foreach (var c in l)
                        if (Char.IsNumber(c))
                            value += c;
                    if (!String.IsNullOrEmpty(value))
                        numericUpDownColor.Value = Convert.ToInt32(value);
                }


                //Auto Player
                else if (l.Contains("Auto1"))
                {
                    checkBoxAutoP1.Checked = l[8] == '1';
                }
                else if (l.Contains("Auto2"))
                {
                    checkBoxAutoP2.Checked = l[8] == '1';
                }
            }
        }

        //Keyboard Parsing
        private static Byte ParseToIBMATEncoding(String KeyName)
        {
            Keys key = (Keys)System.Enum.Parse(typeof(Keys), KeyName);


            switch (key)
            {
                case Keys.Escape:
                    return 1;

                case Keys.D1:
                    return 2;

                case Keys.D2:
                    return 3;

                case Keys.D3:
                    return 4;

                case Keys.D4:
                    return 5;

                case Keys.D5:
                    return 6;

                case Keys.D6:
                    return 7;

                case Keys.D7:
                    return 8;

                case Keys.D8:
                    return 9;

                case Keys.D9:
                    return 10;

                case Keys.D0:
                    return 11;

                case Keys.Oem4: // apostrof
                    return 12;

                case Keys.Back:
                    return 14;

                case Keys.Delete:
                    return 14;

                case Keys.Tab:
                    return 15;

                case Keys.Q:
                    return 16;

                case Keys.W:
                    return 17;

                case Keys.E:
                    return 18;

                case Keys.R:
                    return 19;

                case Keys.T:
                    return 20;

                case Keys.Y:
                    return 21;

                case Keys.U:
                    return 22;

                case Keys.I:
                    return 23;

                case Keys.O:
                    return 24;

                case Keys.P:
                    return 25;

                case Keys.OemSemicolon:
                    return 26;

                case Keys.Oemplus:
                    return 27;

                case Keys.Enter:
                    return 28;

                //case Keys.ControlKey:
                //return 29;
                case Keys.RMenu:
                    return 29;

                case Keys.A:
                    return 30;

                case Keys.S:
                    return 31;

                case Keys.D:
                    return 32;

                case Keys.F:
                    return 33;

                case Keys.G:
                    return 34;

                case Keys.H:
                    return 35;

                case Keys.J:
                    return 36;

                case Keys.K:
                    return 37;

                case Keys.L:
                    return 38;

                case Keys.LShiftKey:
                    return 42;

                case Keys.Z:
                    return 44;

                case Keys.X:
                    return 45;

                case Keys.C:
                    return 46;

                case Keys.V:
                    return 47;

                case Keys.B:
                    return 48;

                case Keys.N:
                    return 49;

                case Keys.M:
                    return 50;

                case Keys.Oemcomma:
                    return 51;

                case Keys.OemPeriod:
                    return 52;

                case Keys.OemMinus:
                    return 53;
                case Keys.Divide:
                    return 53;

                case Keys.RShiftKey:
                    return 54;

                case Keys.Multiply:
                    return 55;

                case Keys.LMenu:
                    return 56;

                case Keys.Space:
                    return 57;

                case Keys.CapsLock:
                    return 58;

                case Keys.F1:
                    return 59;

                case Keys.F2:
                    return 60;

                case Keys.F3:
                    return 61;

                case Keys.F4:
                    return 62;

                case Keys.F5:
                    return 63;

                case Keys.F6:
                    return 64;

                case Keys.F7:
                    return 65;

                case Keys.F8:
                    return 66;

                case Keys.F9:
                    return 67;

                case Keys.F10:
                    return 68;

                case Keys.NumLock:
                    return 69;

                case Keys.Scroll:
                    return 70;

                case Keys.NumPad7:
                    return 71;
                case Keys.Home:
                    return 71;

                case Keys.NumPad8:
                    return 72;
                case Keys.Up:
                    return 72;

                case Keys.NumPad9:
                    return 73;
                case Keys.Prior:
                    return 73;

                case Keys.Subtract:
                    return 74;

                case Keys.NumPad4:
                    return 75;
                case Keys.Left:
                    return 75;

                case Keys.NumPad5:
                    return 76;

                case Keys.NumPad6:
                    return 77;
                case Keys.Right:
                    return 77;

                case Keys.Add:
                    return 78;

                case Keys.NumPad1:
                    return 79;
                case Keys.End:
                    return 79;

                case Keys.NumPad2:
                    return 80;
                case Keys.Down:
                    return 80;

                case Keys.NumPad3:
                    return 81;
                case Keys.PageDown:
                    return 81;

                case Keys.NumPad0:
                    return 82;
                case Keys.Insert:
                    return 82;

                case Keys.Decimal:
                    return 83;

                case Keys.PrintScreen:
                    return 84;

                case Keys.F11:
                    return 87;

                case Keys.F12:
                    return 88;

                case Keys.Pause:
                    return 90;

            }

            return 0;

        }
        private static Keys ParseFromIBMATEncoding(Byte byteCode)
        {



            switch (byteCode)
            {
                case 1:
                    return Keys.Escape;

                case 2:
                    return Keys.D1;

                case 3:
                    return Keys.D2;

                case 4:
                    return Keys.D3;

                case 5:
                    return Keys.D3;

                case 6:
                    return Keys.D5;

                case 7:
                    return Keys.D6;

                case 8:
                    return Keys.D7;

                case 9:
                    return Keys.D8;

                case 10:
                    return Keys.D9;

                case 11:
                    return Keys.D0;

                case 12: // apostrof
                    return Keys.Oem4;

                case 14:
                    return Keys.Delete;

                //case Keys.Delete:
                //return 14;

                case 15:
                    return Keys.Tab;

                case 16:
                    return Keys.Q;

                case 17:
                    return Keys.W;

                case 18:
                    return Keys.E;

                case 19:
                    return Keys.R;

                case 20:
                    return Keys.T;

                case 21:
                    return Keys.Y;

                case 22:
                    return Keys.U;

                case 23:
                    return Keys.I;

                case 24:
                    return Keys.O;

                case 25:
                    return Keys.P;

                case 26:
                    return Keys.OemSemicolon;

                case 27:
                    return Keys.Oemplus;

                case 28:
                    return Keys.Enter;

                //case Keys.ControlKey:
                //return 29;
                case 29:
                    return Keys.RMenu;

                case 30:
                    return Keys.A;
                case 31:
                    return Keys.S;
                case 32:
                    return Keys.D;
                case 33:
                    return Keys.F;
                case 34:
                    return Keys.G;
                case 35:
                    return Keys.H;
                case 36:
                    return Keys.J;
                case 37:
                    return Keys.K;
                case 38:
                    return Keys.L;

                case 42:
                    return Keys.LShiftKey;

                case 44:
                    return Keys.Z;

                case 45:
                    return Keys.X;

                case 46:
                    return Keys.C;

                case 47:
                    return Keys.V;

                case 48:
                    return Keys.B;

                case 49:
                    return Keys.N;

                case 50:
                    return Keys.M;

                case 51:
                    return Keys.Oemcomma;

                case 52:
                    return Keys.OemPeriod;

                //case 53:
                // return Keys.OemMinus;
                case 53:
                    return Keys.Divide;

                case 54:
                    return Keys.RShiftKey;

                case 55:
                    return Keys.Multiply;

                case 56:
                    return Keys.LMenu;

                case 57:
                    return Keys.Space;

                case 58:
                    return Keys.CapsLock;

                case 59:
                    return Keys.F1;

                case 60:
                    return Keys.F2;

                case 61:
                    return Keys.F3;

                case 62:
                    return Keys.F4;

                case 63:
                    return Keys.F5;

                case 64:
                    return Keys.F6;

                case 65:
                    return Keys.F7;

                case 66:
                    return Keys.F8;

                case 67:
                    return Keys.F9;

                case 68:
                    return Keys.F10;

                case 69:
                    return Keys.NumLock;

                case 70:
                    return Keys.Scroll;

                case 71:
                    return Keys.NumPad7;
                //case Keys.Home:
                // return 71;

                //case 72:
                //return Keys.NumPad8;
                case 72:
                    return Keys.Up;

                case 73:
                    return Keys.NumPad9;
                //case Keys.Prior:
                //return 73;

                case 74:
                    return Keys.Subtract;

                //case Keys.NumPad4:
                //return 75;
                case 75:
                    return Keys.Left;

                case 76:
                    return Keys.NumPad5;

                //case 77:
                // return Keys.NumPad6;
                case 77:
                    return Keys.Right;

                case 78:
                    return Keys.Add;

                case 79:
                    return Keys.NumPad1;
                //case Keys.End:
                //return 79;

                //case Keys.NumPad2:
                //return 80;
                case 80:
                    return Keys.Down;

                case 81:
                    return Keys.NumPad3;
                //case Keys.PageDown:
                //return 81;

                case 82:
                    //return Keys.NumPad0;
                    //case Keys.Insert:
                    return Keys.Insert;

                case 83:
                    return Keys.Decimal;

                case 84:
                    return Keys.PrintScreen;

                case 87:
                    return Keys.F11;

                case 88:
                    return Keys.F12;

                case 90:
                    return Keys.Pause;

            }

            return Keys.None;

        }
        #endregion

        public static void ResetKeyBoardFile()
        {
            var data = new byte[28];

            data[0] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Left));
            data[2] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Right));
            data[4] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Up));
            data[6] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Down));
            data[8] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Insert));
            data[10] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.Delete));
            data[12] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.RShiftKey));

            data[14] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.A));
            data[16] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.D));
            data[18] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.W));
            data[20] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.S));
            data[22] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.R));
            data[24] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.F));
            data[26] = ParseToIBMATEncoding(Enum.GetName(typeof(Keys), Keys.LShiftKey));

            var filePath = Path.Combine(Main.FolderOdyemu, "KEYBOARD.DAT");

            if (Directory.Exists(Main.FolderOdyemu) == false) return;

            File.WriteAllBytes(filePath, data);
        }
    }
}
