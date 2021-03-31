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
    public partial class frmMain : Form
    {
        DataTable dt = new DataTable();
        public void ClearAll()
        {
            dt = new DataTable();
            listBox1.Items.Clear();
            textBox1.Text = "";
        }
        public void LoadData()
        {
            SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
            SqlCommand cmd = new SqlCommand("SELECT costumers.* FROM costumers", conn);
            SqlDataAdapter sa = new SqlDataAdapter(cmd);
            conn.Open();
            sa.Fill(dt);
            conn.Close();
            sa.Dispose();
            cmd.Dispose();
            conn.Dispose();
        }

        public class my_costumer
        {
            public int id;
            public string username;
            public override string ToString()
            {
                return username;
            }
        }

        public void show_costumers()
        {
            int i;
            for (i = 0; i < dt.Rows.Count; i++)
            {
                my_costumer costumer = new my_costumer();
                costumer.id = Convert.ToInt32(dt.Rows[i]["id_costumer"]);
                costumer.username = Convert.ToString(dt.Rows[i]["username"]);
                listBox1.Items.Add(costumer);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();
            show_costumers();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string info = "";
            int i;
            if (dt.Rows.Count > 0 && index >= 0)
            {
                for (i = 0; i < dt.Columns.Count; i++)
                {
                    info += dt.Columns[i].ColumnName + ": " + dt.Rows[index][dt.Columns[i].ColumnName] + "\r\n";
                }
            }
            textBox1.Text = info;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 dialog = new Form2();
            dialog.ShowDialog();
            ClearAll();
            LoadData();
            show_costumers();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                string costumer_id = dt.Rows[index][dt.Columns[0].ColumnName].ToString();
                SqlConnection conn = new SqlConnection(@"Data Source =(localdb)\MSSQLLocalDB;" + "Initial Catalog=fitnessapp_db;Integrated Security = True;");
                SqlCommand cmd = new SqlCommand("DELETE FROM costumers WHERE id_costumer=" + costumer_id + ";", conn);
                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                cmd.Dispose();
                ClearAll();
                LoadData();
                show_costumers();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 dialog = new Form3();
            dialog.ShowDialog();
        }
    }
}
