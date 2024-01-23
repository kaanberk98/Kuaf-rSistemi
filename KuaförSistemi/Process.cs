using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
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
    public partial class Process : Form
    {
        bool sidebarExpand;

        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;

        public Process()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new("Insert into ProcessTbl values (@PrName,@PrCost,@PrDesc)", con);
            cmd.Parameters.AddWithValue("@PrName", txtName.Text);
            cmd.Parameters.AddWithValue("@PrCost", txtCost.Text);
            cmd.Parameters.AddWithValue("@PrDesc", txtDesc.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtName.Text = txtCost.Text = txtDesc.Text = string.Empty;
            txtName.Focus();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ProcessTbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dgvProcess.DataSource = table;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ProcessTbl Set Name=@Name,Cost=@Cost,Description=@Description Where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Cost", txtCost.Text);
            cmd.Parameters.AddWithValue("@Description", txtDesc.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);


            txtId.Text = txtName.Text = txtCost.Text = txtDesc.Text = string.Empty;
            txtName.Focus();
        }

        private void dgvProcess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvProcess.CurrentRow.Cells[0].Value.ToString();

            txtName.Text = dgvProcess.CurrentRow.Cells[1].Value.ToString();

            txtCost.Text = dgvProcess.CurrentRow.Cells[2].Value.ToString();

            txtDesc.Text = dgvProcess.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from ProcessTbl where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);


            txtId.Text = txtName.Text = txtCost.Text = txtDesc.Text = string.Empty;
            txtName.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Client cli = new Client();
            cli.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DashBoard dash = new DashBoard();
            dash.Show();
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

            }
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
    }
}
