using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace KuaförSistemi
{
    public partial class Transition : Form
    {
        public Transition()
        {
            InitializeComponent();
        }

        private void Transition_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 20;
            progressBar1.Value = startpoint;
            if (progressBar1.Value == 100)
            {
                progressBar1.Value = 0;
                // İşlem tamamlandığında timer'ı durdur
                timer1.Stop();

                // Form geçişini gerçekleştir
                Login lgn = new Login();
                lgn.Show();
                this.Hide();
            }
        }
    }
}
