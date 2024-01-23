using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuaförSistemi
{
    public partial class User : Form
    {
        bool sidebarExpand;

        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;

        public User()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
            this.Hide();
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

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from UserTbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dgvUser.DataSource = table;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update UserTbl Set UserName=@UserName,UserPassword=@UserPassword,Phone=@Phone Where UserId=@UserId", con);
            cmd.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@UserName", txtName.Text);
            cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtId.Text = txtName.Text = txtPassword.Text = txtPhone.Text = string.Empty;
            txtName.Focus();
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvUser.CurrentRow.Cells[0].Value.ToString();

            txtName.Text = dgvUser.CurrentRow.Cells[1].Value.ToString();

            txtPassword.Text = dgvUser.CurrentRow.Cells[2].Value.ToString();

            txtPhone.Text = dgvUser.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from UserTbl where UserId=@UserId", con);
            cmd.Parameters.AddWithValue("UserId", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtId.Text = txtName.Text = txtPassword.Text = txtPhone.Text = string.Empty;
            txtName.Focus();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                panel1.Width -= 10;
                if (panel1.Width == panel1.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            }
            else
            {
                panel1.Width += 10;
                if (panel1.Width == panel1.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
    }
}
