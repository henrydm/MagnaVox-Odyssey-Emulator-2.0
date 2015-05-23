using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magnavox_Odyssey_Emulator
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();

        }

        private void Loading_Load(object sender, EventArgs e)
        {
            

        }


        public void raise1()
        {
            for (int i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(1);
                progressBar1.Value = i;
            }
        }
        public void raise2()
        {

            for (int i = 5000; i < 10000; i++)
            {
                System.Threading.Thread.Sleep(1);
                progressBar1.Value = i;
            }
        }
        public void CloseMe()
        {
            this.Close();
        }
    }
}
