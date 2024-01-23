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
using System.Xml.Linq;

namespace KuaförSistemi
{
    public partial class Register : Form
    {
        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;



        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(txtKAdi.Text==""||txtPassword.Text==""||txtPhone.Text=="")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();

                SqlCommand cmd = new("Insert into UserTbl values (@UserName,@UserPassword,@Phone)", con);
                cmd.Parameters.AddWithValue("@UserName", txtKAdi.Text);
                cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Yeni Kayıt Başarıyla Oluştu.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Login log = new Login();
                log.Show();
                this.Hide();
            }
            

        }
    }
}
