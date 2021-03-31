using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace FitnessCostumerManagement
{
    public partial class Form1 : Form
    {

        public Form1()
        {
           
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
           
        }



        private void btn_login_Click(object sender, EventArgs e)
        {

            SqlConnection sqlcon = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
            string query = "Select * from users Where user_name = '" + txt_username.Text.Trim() + "' and user_password = '" + txt_password.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {

                frmMain objFrmMain = new frmMain();
                this.Hide();
                objFrmMain.Show();
                MessageBox.Show("SUCCES");

            }
            else
            {
                MessageBox.Show("Verifica usernameul sau parola!");
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
