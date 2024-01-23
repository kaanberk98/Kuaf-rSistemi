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
using System.Xml.Linq;

namespace KuaförSistemi
{
    public partial class Appointment : Form
    {

        bool sidebarExpand;

        SqlConnection con = new("Data Source=KAANBERK-BILGIN\\SQLEXPRESS;Database=KuaforDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlDataAdapter da;
        SqlCommand cmd;

        public Appointment()
        {
            InitializeComponent();
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

        List<Clients> clientsList = new List<Clients>();
        List<Processs> processList = new List<Processs>();

        private void Appointment_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new("SELECT Name FROM ClientTbl", con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                clientsList.Add(
                    new Clients(
                        reader["Name"].ToString()
                    ));
            }

            reader.Close();

            con.Close();

            cmbClient.DataSource = clientsList;
            cmbClient.DisplayMember = "Name";

            SqlCommand komut = new("SELECT Name FROM ProcessTbl", con);

            con.Open();

            SqlDataReader rdr = komut.ExecuteReader();

            while (rdr.Read())
            {
                processList.Add(
                    new Processs(
                        rdr["Name"].ToString()
                    ));
            }

            rdr.Close();

            con.Close();

            cmbProcess.DataSource = processList;
            cmbProcess.DisplayMember = "Name";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbClient.Text == "" || cmbProcess.Text == "" || dtpDate.Text == "" || dtpTime.Text == "")
            {
                MessageBox.Show("Lütfen Boş Değer Bırakmayınız.", "Hatalı İşlem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                con.Open();

                SqlCommand cmd = new("Insert into AppointmentTbl values (@Client,@Process,@ApDate,@Time)", con);
                cmd.Parameters.AddWithValue("@Client", cmbClient.Text);
                cmd.Parameters.AddWithValue("@Process", cmbProcess.Text);
                cmd.Parameters.AddWithValue("@ApDate", dtpDate.Value);
                cmd.Parameters.AddWithValue("@Time", dtpTime.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Kayıt Başarıyla Eklendi.", "Kaydet", MessageBoxButtons.OK, MessageBoxIcon.Information);


                txtId.Text = cmbClient.Text = cmbProcess.Text = dtpDate.Text = dtpTime.Text = string.Empty;
                cmbClient.Focus();
            }


            
        }


        private void btnDisplay_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from AppointmentTbl", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            da.Fill(table);
            dgvApp.DataSource = table;
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Update AppointmentTbl Set Client=@Client,Process=@Process,Date=@Date,Time=@Time Where ID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtId.Text));
            cmd.Parameters.AddWithValue("@Client", cmbClient.Text);
            cmd.Parameters.AddWithValue("@Process", cmbProcess.Text);
            cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
            cmd.Parameters.AddWithValue("@Time", dtpTime.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Güncellendi", "Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cmbProcess.DataSource = processList;
            cmbProcess.DisplayMember = "Name";

            txtId.Text = cmbClient.Text = cmbProcess.Text = dtpDate.Text = dtpTime.Text = string.Empty;
            cmbClient.Focus();
        }

        private void dgvApp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvApp.CurrentRow.Cells[0].Value.ToString();

            cmbClient.Text = dgvApp.CurrentRow.Cells[1].Value.ToString();

            cmbProcess.Text = dgvApp.CurrentRow.Cells[2].Value.ToString();

            dtpDate.Text = dgvApp.CurrentRow.Cells[3].Value.ToString();

            dtpTime.Text = dgvApp.CurrentRow.Cells[4].Value.ToString();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Delete from AppointmentTbl where ID=@ID", con);
            cmd.Parameters.AddWithValue("ID", Convert.ToInt32(txtId.Text));

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Başarıyla Silindi!", "Silme", MessageBoxButtons.OK, MessageBoxIcon.Information);


            txtId.Text = cmbClient.Text = cmbProcess.Text = dtpDate.Text = dtpTime.Text = string.Empty;
            cmbClient.Focus();
        }
    }
}
