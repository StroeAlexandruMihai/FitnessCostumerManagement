using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FitnessCostumerManagement
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadFiles(dgvFiles);
        }

        public void LoadFiles(DataGridView table)
        {
            SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
            SqlCommand cmd = new SqlCommand("SELECT files_costumer.*, trainers.trainer_name " +
                "FROM files_costumer INNER JOIN trainers " +
                " ON files_costumer.antrenor_id=trainers.id_trainer", conn);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            conn.Open();
            sa.Fill(dt);
            conn.Close();
            sa.Dispose();
            cmd.Dispose();
            conn.Dispose();
            table.DataSource = dt;
            table.Columns["antrenament_id"].Visible = false;
            table.Columns["antrenor_id"].Visible = false;
        }
        public void Clear()
        {
            txtTrainName.Text = "";
            txtMinutes.Text = "";
            txtGroup.Text = "";
            txtTrainerID.Text = "";
            txtAntrenamentID.Text = "";
        }

        private void dgvFiles_SelectionChanged(object sender, EventArgs e)
        {
            Clear();
            if (dgvFiles.SelectedRows.Count > 0)
            {
                txtTrainName.Text = dgvFiles.SelectedRows[0].Cells["antrenament_name"].Value.ToString();
                txtMinutes.Text = dgvFiles.SelectedRows[0].Cells["antrenament_size"].Value.ToString();
                txtGroup.Text = dgvFiles.SelectedRows[0].Cells["antrenament_type"].Value.ToString();
                txtTrainerID.Text = dgvFiles.SelectedRows[0].Cells["antrenor_id"].Value.ToString();
                txtAntrenamentID.Text = dgvFiles.SelectedRows[0].Cells["antrenament_id"].Value.ToString();
            }
        }

     

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
            {
                SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
                SqlCommand cmd = new SqlCommand("DELETE FROM files_costumer WHERE antrenament_id=" +
                    dgvFiles.SelectedRows[0].Cells["antrenament_id"].Value.ToString() + ";", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                LoadFiles(dgvFiles);
            }

        }

        private void btn_modify_Click(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
            {
                if (txtTrainName.Text != "" && txtMinutes.Text != "" && txtGroup.Text != "" && txtTrainerID.Text != "")
                {
                    SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
                    string query = "UPDATE files_costumer SET " +
                        "antrenament_name='" + txtTrainName.Text + "'," +
                        "antrenament_size='" + txtMinutes.Text + "'," +
                        "antrenament_type='" + txtGroup.Text + "'," +
                        "antrenor_id='" + txtTrainerID.Text + "'" +
                        "WHERE antrenament_id='" +
                        dgvFiles.SelectedRows[0].Cells["antrenament_id"].Value.ToString() +
                        "';";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    cmd.ExecuteReader();
                    conn.Close();
                    cmd.Dispose();
                    conn.Dispose();
                    LoadFiles(dgvFiles);
                }
                else
                {
                    MessageBox.Show("Introduceti date in toate campurile!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txtTrainName.Text != "" && txtMinutes.Text != "" && txtGroup.Text != "" && txtTrainerID.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
                string query = "INSERT INTO files_costumer " +
                    "(antrenament_name, antrenament_size, antrenament_type, antrenor_id)" +
                    "values ('" + txtTrainName.Text +
                    "', '" + txtMinutes.Text +
                    "', '" + txtGroup.Text +
                    "', '" + txtTrainerID.Text + "');";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                LoadFiles(dgvFiles);
            }
            else
            {
                MessageBox.Show("Introduceti date in toate campurile",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void txtFileSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUserID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
