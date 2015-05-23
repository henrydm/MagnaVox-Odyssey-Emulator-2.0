using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Magnavox_Odyssey_Emulator.AuxClasses
{
    [Serializable]
    public class Cartridge
    {
        public int Num;
        public List<string> Pins;

        public Cartridge()
        {
        }

        public Cartridge(string filepath)
        {
            if (!File.Exists(filepath)) return;

            try
            {
                var bin = new BinaryFormatter();
                var stream = new MemoryStream(File.ReadAllBytes(filepath));
                var obj = bin.Deserialize(stream);
                stream.Close();
                if (obj != null && obj is Cartridge)
                {
                    var cart = obj as Cartridge;

                    Num = cart.Num;
                    Pins = cart.Pins;
                }
            }
            catch { return; };
        }
        public bool Save()
        {
            if (!IsValid()) return false;

            try
            {
                var bin = new BinaryFormatter();
                var stream = File.Create(Path.Combine(Main.FolderCartridges, "Cartridge" + Num + ".Cartridge"));
                bin.Serialize(stream, this);
                stream.Close();
                return true;

            }
            catch { return false; };
        }
        public bool IsValid()
        {
            if (Num < 1 || Num > 12) return false;
            if (Pins == null) return false;
            if (!Pins.Any()) return false;
            foreach (var pinSet in Pins)
            {
                if (pinSet == null) return false;
                if (pinSet.Length == 0) return false;
            }
            return true;
        }


        public static Cartridge Create(int num)
        {



            var cart = new Cartridge();
            cart.Num = num;
            switch (num)
            {
                case 1:
                    cart.Pins = new List<string> { "2-4", "6-8-14-16-20-22", "30-34", "31-39", "35-37" };
                    break;
                case 2:
                    cart.Pins = new List<string> { "2-4", "6-8" };
                    break;
                case 3:
                    cart.Pins = new List<string> { "2-4", "6-8-10-20-22", "30-34", "31-39", "35-37", "42-44" };
                    break;
                case 4:
                    cart.Pins = new List<string> { "2-4", "6-8-18", "21-23", "33-37-39" };
                    break;
                case 5:
                    cart.Pins = new List<string> { "2-4", "6-8-10-20-22", "21-23-25", "30-34", "31-33-39", "35-37" };
                    break;
                case 6:
                    cart.Pins = new List<string> { "2-4", "3-5-9", "25-28-38" };
                    break;
                case 7:
                    cart.Pins = new List<string> { "2-4", "6-8-10-14-16-20-22", "13-27", "23-25", "30-34", "31-39", "35-37", "42-44" };
                    break;
                case 8:
                    cart.Pins = new List<string> { "2-4", "6-8-10-14-16-20-22", "34-36", "9-11-13", "15-17", "31-39", "35-37" };
                    break;
                case 9:
                    cart.Pins = new List<string> { "2-4", "6-24", "21-23" };
                    break;
                case 10:
                    cart.Pins = new List<string> { "2-4", "6-8-10-20-22-24", "23-25", "30-34", "35-37" };
                    break;
                case 11:
                    cart.Pins = new List<string> { "2-4", "6-8-12-14-20-22", "9-11-13", "15-17", "31-39", "35-37", "34-36", "38-40" };
                    break;
                case 12:
                    cart.Pins = new List<string> { "2-4", "3-5-7", "6-8-18", "21-23", "26-28", "33-37-39" };
                    break;
            }

            return cart;
        }

    }

}
