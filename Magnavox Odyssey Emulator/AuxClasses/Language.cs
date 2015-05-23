using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Magnavox_Odyssey_Emulator.AuxClasses
{

    public static class Language
    {
        #region Definitions
        public static String CurrentLanguage;
        public static List<String> AvaliableLanguages;
        public static String

       //GENERAL INFO
       StringCancel,
       StringOK,
       StringSave,



       //MAIN SCREEN
       StringCartridge,
       StringOverlay,
       StringRun,

       ToolTipCartridge,
       ToolTipOverlay,
       ToolTipRun,
       ToolTipSettings,

       //OVERLAY SELECTOR
       StringSelectAnOverlay,
       StringEdit,
       StringOverlaySettings,
       StringOpacity,
       StringEnabled,
       StringOpaqueColor,
       StringAsociate,
       StringNum,
       StringDragAndDropInfo,
       StringNote,
       StringColorInfo,
       ToolTipOpacityEnabled,
       ToolTipOpaqueColor,
       ToolTipAsociate,
       ToolTipNum,
       ToolTipDragAndDrop,




       //SETTINGS//

       //CAPACITORS & PERFORMANCE
       StringCapacitorsAndPerformance,
       StringBatSpotH,
       StringBatSpotV,
       StringBatDampH,
       StringBatDampV,
       StringBallSpotH,
       StringBallSpotV,
       StringBatAceleration,
       StringBatDeceleration,
       StringEngAceleration,
       StringEngDeceleration,
       StringCapacitorsTitle,
       StringCapacitorsInfo,
       StringBatSpots,
       StringBatSpotsInfo,
       ToolTipBatSpotH,
       ToolTipBatSpotV,
       ToolTipBatDampH,
       ToolTipBatDampV,
       ToolTipBallSpotH,
       ToolTipBallSpotV,
       ToolTipBatAceleration,
       ToolTipBatDeceleration,
       ToolTipEngAceleration,
       ToolTipEngDeceleration,



       //OBJECT SIZES
       StringObjectSizes,
       StringBatSizeH,
       ToolTipBatSizeH,
       StringBatSizeV,
       ToolTipBatSizeV,
       StringBallSize,
       ToolTipBallSize,
       StringWidthWallSize,
       ToolTipWidthWallSize,
       StringWidthWallWide,
       ToolTipWidthWallWide,
       StringWallPercentage,
       ToolTipWallPercentage,
       StringWallPosition,
       ToolTipWallPosition,
       StringSizeInfo,
       StringBatSizeTitle,
       StringBatSizeInfo,
       StringBallSizeTitle,
       StringBallSizeInfo,
       StringWallWidthTitle,
       StringWallWidthInfo,
       StringWallPercentageTitle,
       StringWallPercentageInfo,
       StringWallPositionTitle,
       StringWallPositionInfo,


       //KEYBOARD
       StringPlayer1,
       StringPlayer2,
       StringMoveUp,
       StringMoveDown,
       StringMoveRight,
       StringMoveLeft,
       StringEnglishUp,
       StringEnglishDown,
       StringServeBall,
       StringReset,

       //OTHER SETTING
       StringGlobalSettings,
       StringAutomaticPlayer,
       StringColors,
       StringColor,
       StringTColor,
       StringDOSNEnviornment,
       StringFullScreen,
       StringHideCursor,
       StringLanguage,
       StringLanguageDisplay,
       StringOtherCapacitors,
       StringWallCapacitors,
       StringRiffleCapacitor,
       StringRiffleCapacitorTitle,
       StringRiffleCapacitorInfo,
       StringUserFolder,
       StringUserFolderInfo,
       StringOpen,
       StringKeboardSettings,
       StringOtherSettings,
        StringOutput,
        StringResolution;

        #endregion


        public static void SetLanguage(string lang)
        {
            //Load Available Languages
            AvaliableLanguages = new List<string>();
            var languageFiles = new Dictionary<string, string>();
            foreach (string filePath in Directory.GetFiles(Main.FolderRoot, "*.lang", SearchOption.AllDirectories))
            {
                languageFiles.Add(Path.GetFileNameWithoutExtension(filePath), filePath);
                AvaliableLanguages.Add(Path.GetFileNameWithoutExtension(filePath));
            }
            if (!languageFiles.ContainsKey(lang)) return;

            //Set Strings

            var lines = File.ReadAllLines(languageFiles[lang], Encoding.UTF8);
            foreach (var line in lines)
            {
                if (line.StartsWith("/")) continue;
                if (line.StartsWith(" ")) continue;
                if (!line.Contains("=")) continue;
                var equalsPosition = line.IndexOf('=');
                if (equalsPosition == -1) continue;

                var word = line.Substring(0, equalsPosition);
                var traslated = line.Substring(equalsPosition + 1, line.Length - 1 - equalsPosition);



                //GENERAL INFO
                if (word == "StringCancel") { StringCancel = traslated; }
                else if (word == "StringOK") { StringOK = traslated; }
                else if (word == "StringSave") { StringSave = traslated; }


                //MAIN SCREEN
                else if (word == "StringCartridge") { StringCartridge = traslated; }
                else if (word == "StirngOverlay") { StringOverlay = traslated; }
                else if (word == "StringRun") { StringRun = traslated; }

                else if (word == "ToolTipCartridge") { ToolTipCartridge = traslated; }
                else if (word == "ToolTipOverlay") { ToolTipOverlay = traslated; }
                else if (word == "ToolTipRun") { ToolTipRun = traslated; }
                else if (word == "ToolTipSettings") { ToolTipSettings = traslated; }

                //OVERLAY SELECTOR
                else if (word == "StringSelectAnOverlay") { StringSelectAnOverlay = traslated; }
                else if (word == "StringOverlaySettings") { StringOverlaySettings = traslated; }
                else if (word == "StringEdit") { StringEdit = traslated; }
                else if (word == "StringOpacity") { StringOpacity = traslated; }
                else if (word == "StringEnabled") { StringEnabled = traslated; }
                else if (word == "StringOpaqueColor") { StringOpaqueColor = traslated; }
                else if (word == "StringAsociate") { StringAsociate = traslated; }
                else if (word == "StringNum") { StringNum = traslated; }
                else if (word == "StringDragAndDropInfo") { StringDragAndDropInfo = traslated; }
                else if (word == "StringNote") { StringNote = traslated; }
                else if (word == "StringColorInfo") { StringColorInfo = traslated; }
                //TOOLTIPS
                else if (word == "ToolTipOpacityEnabled") { ToolTipOpacityEnabled = traslated; }
                else if (word == "ToolTipOpaqueColor") { ToolTipOpaqueColor = traslated; }
                else if (word == "ToolTipAsociate") { StringNum = traslated; }
                else if (word == "ToolTipNum") { ToolTipNum = traslated; }
                else if (word == "ToolTipDragAndDrop") { ToolTipDragAndDrop = traslated; }


                //SETTINGS//

                //CAPACITORS & PERFORMANCE
                else if (word == "StringCapacitorsAndPerformance") { StringCapacitorsAndPerformance = traslated; }
                else if (word == "StringBatSpotH") { StringBatSpotH = traslated; }
                else if (word == "StringBatSpotV") { StringBatSpotV = traslated; }
                else if (word == "StringBatDampH") { StringBatDampH = traslated; }
                else if (word == "StringBatDampV") { StringBatDampV = traslated; }
                else if (word == "StringBallSpotH") { StringBallSpotH = traslated; }
                else if (word == "StringBallSpotV") { StringBallSpotV = traslated; }
                else if (word == "StringBatAceleration") { StringBatAceleration = traslated; }
                else if (word == "StringBatDeceleration") { StringBatDeceleration = traslated; }
                else if (word == "StringEngAceleration") { StringEngAceleration = traslated; }
                else if (word == "StringEngDeceleration") { StringEngDeceleration = traslated; }
                else if (word == "StringCapacitorsTitle") { StringCapacitorsTitle = traslated; }
                else if (word == "StringCapacitorsInfo") { StringCapacitorsInfo = traslated; }
                else if (word == "StringBatSpots") { StringBatSpots = traslated; }
                else if (word == "StringBatSpotsInfo") { StringBatSpotsInfo = traslated; }
                //TOOLTIPS
                else if (word == "ToolTipBatSpotH") { ToolTipBatSpotH = traslated; }
                else if (word == "ToolTipBatSpotV") { ToolTipBatSpotV = traslated; }
                else if (word == "ToolTipAsociate") { ToolTipAsociate = traslated; }
                else if (word == "ToolTipBatDampH") { ToolTipBatDampH = traslated; }
                else if (word == "ToolTipBatDampV") { ToolTipBatDampV = traslated; }
                else if (word == "ToolTipBallSpotH") { ToolTipBallSpotH = traslated; }
                else if (word == "ToolTipBallSpotV") { ToolTipBallSpotV = traslated; }
                else if (word == "ToolTipBatAceleration") { ToolTipBatAceleration = traslated; }
                else if (word == "ToolTipBatDeceleration") { ToolTipBatDeceleration = traslated; }
                else if (word == "ToolTipEngAceleration") { ToolTipEngAceleration = traslated; }
                else if (word == "ToolTipEngDeceleration") { ToolTipEngDeceleration = traslated; }

                //OBJECT SIZES
                else if (word == "StringObjectSizes") { StringObjectSizes = traslated; }
                else if (word == "StringBatSizeH") { StringBatSizeH = traslated; }
                else if (word == "ToolTipBatSizeH") { ToolTipBatSizeH = traslated; }
                else if (word == "StringBatSizeV") { StringBatSizeV = traslated; }
                else if (word == "ToolTipBatSizeV") { ToolTipBatSizeV = traslated; }
                else if (word == "StringBallSize") { StringBallSize = traslated; }
                else if (word == "ToolTipBallSize") { ToolTipBallSize = traslated; }
                else if (word == "StringWidthWallSize") { StringWidthWallSize = traslated; }
                else if (word == "ToolTipWidthWallSize") { ToolTipWidthWallSize = traslated; }
                else if (word == "StringWidthWallWide") { StringWidthWallWide = traslated; }
                else if (word == "ToolTipWidthWallWide") { ToolTipWidthWallWide = traslated; }
                else if (word == "StringWallPercentage") { StringWallPercentage = traslated; }
                else if (word == "ToolTipWallPercentage") { ToolTipWallPercentage = traslated; }
                else if (word == "StringWallPosition") { StringWallPosition = traslated; }
                else if (word == "ToolTipWallPosition") { ToolTipWallPosition = traslated; }
                else if (word == "StringSizeInfo") { StringSizeInfo = traslated; }
                else if (word == "StringBatSizeTitle") { StringBatSizeTitle = traslated; }
                else if (word == "StringBatSizeInfo") { StringBatSizeInfo = traslated; }
                else if (word == "StringBallSizeTitle") { StringBallSizeTitle = traslated; }
                else if (word == "StringBallSizeInfo") { StringBallSizeInfo = traslated; }
                else if (word == "StringWallWidthTitle") { StringWallWidthTitle = traslated; }
                else if (word == "StringWallWidthInfo") { StringWallWidthInfo = traslated; }
                else if (word == "StringWallPercentageTitle") { StringWallPercentageTitle = traslated; }
                else if (word == "StringWallPercentageInfo") { StringWallPercentageInfo = traslated; }
                else if (word == "StringWallPositionTitle") { StringWallPositionTitle = traslated; }
                else if (word == "StringWallPositionInfo") { StringWallPositionInfo = traslated; }


                //KEYBOARD
                else if (word == "StringKeboardSettings") { StringKeboardSettings = traslated; }
                else if (word == "StringPlayer1") { StringPlayer1 = traslated; }
                else if (word == "StringPlayer2") { StringPlayer2 = traslated; }
                else if (word == "StringMoveUp") { StringMoveUp = traslated; }
                else if (word == "StringMoveDown") { StringMoveDown = traslated; }
                else if (word == "StringMoveRight") { StringMoveRight = traslated; }
                else if (word == "StringMoveLeft") { StringMoveLeft = traslated; }
                else if (word == "StringEnglishUp") { StringEnglishUp = traslated; }
                else if (word == "StringEnglishDown") { StringEnglishDown = traslated; }
                else if (word == "StringServeBall") { StringServeBall = traslated; }
                else if (word == "StringReset") { StringReset = traslated; }

                //OTHER SETTING
                else if (word == "StringOtherSettings") { StringOtherSettings = traslated; }
                else if (word == "StringGlobalSettings") { StringGlobalSettings = traslated; }
                else if (word == "StringAutomaticPlayer") { StringAutomaticPlayer = traslated; }
                else if (word == "StringColors") { StringColors = traslated; }
                else if (word == "StringColor") { StringColor = traslated; }
                else if (word == "StringTColor") { StringTColor = traslated; }
                else if (word == "StringDOSNEnviornment") { StringDOSNEnviornment = traslated; }
                else if (word == "StringFullScreen") { StringFullScreen = traslated; }
                else if (word == "StringHideCursor") { StringHideCursor = traslated; }
                else if (word == "StringLanguage") { StringLanguage = traslated; }
                else if (word == "StringLanguageDisplay") { StringLanguageDisplay = traslated; }
                else if (word == "StringOtherCapacitors") { StringOtherCapacitors = traslated; }
                else if (word == "StringWallCapacitors") { StringWallCapacitors = traslated; }
                else if (word == "StringRiffleCapacitor") { StringRiffleCapacitor = traslated; }
                else if (word == "StringRiffleCapacitorTitle") { StringRiffleCapacitorTitle = traslated; }
                else if (word == "StringRiffleCapacitorInfo") { StringRiffleCapacitorInfo = traslated; }
                else if (word == "StringUserFolder") { StringUserFolder = traslated; }
                else if (word == "StringUserFolderInfo") { StringUserFolderInfo = traslated; }
                else if (word == "StringOutput") { StringOutput = traslated; }
                else if (word == "StringResolution") { StringResolution = traslated; }
            }

            //Save Settings
            var langFilePath = (Path.Combine(Main.FolderLanguages, "Language.conf"));
            File.WriteAllText(langFilePath, lang);


            CurrentLanguage = lang;
        }
    }
}
