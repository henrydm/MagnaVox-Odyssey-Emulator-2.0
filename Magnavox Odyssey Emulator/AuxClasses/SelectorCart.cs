using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magnavox_Odyssey_Emulator.AuxClasses
{
    public partial class SelectorCart : Form
    {
        public Cartridge SelectedCart;

        
        public SelectorCart()
        {
            InitializeComponent();
            SelectedCart = Cartridge.Create(1);
        }

        private void buttonCart1_Click(object sender, EventArgs e)
        {
            SelectedCart = Cartridge.Create(Convert.ToInt32(((sender) as Button).Name.Trim("buttonCart".ToCharArray())));
            Close();
        }

    }
}
