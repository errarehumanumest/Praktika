using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Praktika;

namespace Praktika
{

    
    public partial class Form1 : Form
    {
        DB duom = new DB();
        public Form1()
        {
            InitializeComponent();
        }
        
  
        //string ConnString = @"server=localhost;user id=root;password=aaa12345;persistsecurityinfo=True;database=mydb_nuoma";

        private void label3_Click(object sender, EventArgs e)
        {
               
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Iveskite Vartotojo varda ir slaptazodi");
                return;
            }
            try
            {
                //Create conn

              //  MySqlConnection con = new MySqlConnection(ConnString);
            MySqlCommand cmd = new MySqlCommand("Select * from vartotojas_login where username=@username and password=@password", duom.con);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            duom.con.Open();

            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapt.Fill(ds);
            duom.con.Close();
            int count = ds.Tables[0].Rows.Count;
            //If count is equal to 1, than show frmMain form
            if (count == 1)
            {
                MessageBox.Show("Prisijungete");
               Form2 m = new Form2();

                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Blogai ivestas vartotojo vardas ar slaptazodis");
            }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
