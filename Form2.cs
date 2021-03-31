using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FitnessCostumerManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" &&
                textBox2.Text != "" &&
                textBox3.Text != "" &&
                textBox4.Text != "" &&
                textBox5.Text != "" &&
                textBox6.Text != "" &&
                textBox7.Text != "" &&
                textBox8.Text != "")
            {
                SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
                string query = "INSERT INTO costumers (username, password, costumer_level, costumer_date, costumer_discount, " +
                    "costumer_phone, costumer_email, costumer_age, costumer_add_admin_id) values (" +
                    "'" + textBox1.Text +
                    "', '" + textBox2.Text +
                    "', '" + textBox3.Text +
                    "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                    "', '" + textBox4.Text +
                    "', '" + textBox5.Text +
                    "', '" + textBox6.Text +
                    "', '" + textBox7.Text +
                    "', '" + textBox8.Text + "');";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
                this.Close();
            }
            else
            {
                MessageBox.Show("Introduceti date in toate campurile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
    }

