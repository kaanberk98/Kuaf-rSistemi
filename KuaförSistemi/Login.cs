using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaförSistemi
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand cmd;

        public Login()
        {
            InitializeComponent();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtKAdi.Text;
            string password = txtPassword.Text;
            con = new SqlConnection("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Select * From UserTbl where Name= '" + txtKAdi.Text + "'And Password='" + txtPassword.Text + "'";
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Appointment app = new Appointment();
                app.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Yaptınız");
            }
            con.Close();

            txtKAdi.Text = txtPassword.Text = string.Empty;
            txtKAdi.Focus();

        }
    }
}
