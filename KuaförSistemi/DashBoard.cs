using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaförSistemi
{
    public partial class DashBoard : Form
    {
        bool sidebarExpand;
        //bool processExpand;

        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;

        public DashBoard()
        {
            InitializeComponent();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter processDa = new SqlDataAdapter("SELECT COUNT(*) FROM ProcessTbl", con);
            DataTable processTable = new DataTable();
            processDa.Fill(processTable);
            processLbl.Text = processTable.Rows[0][0].ToString();
            con.Close();

            con.Open();
            SqlDataAdapter appointmentDa = new SqlDataAdapter("SELECT COUNT(*) FROM AppointmentTbl", con);
            DataTable appointmentTable = new DataTable();
            appointmentDa.Fill(appointmentTable);
            appLbl.Text = appointmentTable.Rows[0][0].ToString();
            con.Close();

            con.Open();
            SqlDataAdapter clientDa = new SqlDataAdapter("SELECT COUNT(*) FROM ClientTbl", con);
            DataTable clientTable = new DataTable();
            clientDa.Fill(clientTable);
            clientLbl.Text = clientTable.Rows[0][0].ToString();
            con.Close();

            con.Open();
            SqlDataAdapter userDa = new SqlDataAdapter("SELECT COUNT(*) FROM UserTbl", con);
            DataTable userTable = new DataTable();
            userDa.Fill(userTable);
            userLbl.Text = userTable.Rows[0][0].ToString();
            con.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış yapılsın mı?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (secenek == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (secenek == DialogResult.No)
            {
                //Hayır derse yapılacak işlemler
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                panel3.Width -= 10;
                if (panel3.Width == panel3.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                panel3.Width += 10;
                if (panel3.Width == panel3.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

    }
}
