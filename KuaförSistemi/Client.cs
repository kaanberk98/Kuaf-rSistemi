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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KuaförSistemi
{
    public partial class Client : Form
    {
        bool sidebarExpand;

        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;

        public Client()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Show();
            this.Hide();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Appointment app = new Appointment();
            app.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.Show();
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
                //Hayır derse yapılacak işlemler
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new("Insert into ClientTbl values (@CliName,@CliPhone,@CliAddress,@CliDOB,@CliGender)", con);
            cmd.Parameters.AddWithValue("@CliName", CliNameTb.Text);
            cmd.Parameters.AddWithValue("@CliPhone", CliPhoneTb.Text);
            cmd.Parameters.AddWithValue("@CliAddress", AddressTb.Text);
            cmd.Parameters.AddWithValue("@CliDOB", DOBDate.Value);
            cmd.Parameters.AddWithValue("@CliGender", GenCb.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtId.Text = CliNameTb.Text = CliPhoneTb.Text = AddressTb.Text = string.Empty;
            CliNameTb.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update ClientTbl Set Name=@Name,Phone=@Phone,Address=@Address,Birthday=@Birthday,Gender=@Gender Where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@Name", CliNameTb.Text);
            cmd.Parameters.AddWithValue("@Phone", CliPhoneTb.Text);
            cmd.Parameters.AddWithValue("@Address", AddressTb.Text);
            cmd.Parameters.AddWithValue("@Birthday", DOBDate.Value);
            cmd.Parameters.AddWithValue("@Gender", GenCb.SelectedItem.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from ClientTbl where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClientDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = ClientDGV.CurrentRow.Cells[0].Value.ToString();

            CliNameTb.Text = ClientDGV.CurrentRow.Cells[1].Value.ToString();

            CliPhoneTb.Text = ClientDGV.CurrentRow.Cells[2].Value.ToString();

            AddressTb.Text = ClientDGV.CurrentRow.Cells[3].Value.ToString();

            DOBDate.Text = ClientDGV.CurrentRow.Cells[4].Value.ToString();

            GenCb.Text = ClientDGV.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnDisplay_Click_1(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from ClientTbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            ClientDGV.DataSource = table;
            con.Close();
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }
    }
}
