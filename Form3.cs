using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Praktika;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Praktika
{
    public partial class Form3 : Form
    {
        Duomenys duom = new Duomenys();
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            duom.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "insert into daiktas " +
                    "( pavadinimas, kaina, idVartotojas, idSritis, idBusena) values " +
                    "( @Pavadinimas, @kaina, @idVartotojas, @idSritis, @idBusena) ";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = duom.con;

               // cmd.Parameters.Add("@idDaiktas", MySqlDbType.Int32).Value = ++idDaiktas;
                cmd.Parameters.Add("@Pavadinimas", MySqlDbType.VarChar).Value = textBox1.Text;
                cmd.Parameters.Add("@kaina", MySqlDbType.VarChar).Value = textBox2.Text;
                cmd.Parameters.Add("@idVartotojas", MySqlDbType.VarChar).Value = textBox3.Text;
                cmd.Parameters.Add("@idSritis", MySqlDbType.VarChar).Value = 6;
                cmd.Parameters.Add("@idBusena", MySqlDbType.VarChar).Value = 1;
                cmd.ExecuteNonQuery();
                duom.con.Close();
            }

            this.Hide();
            duom.Daiktai.Clear();
            //Form2.dataGridView1.Rows.Clear();
            //Form2.dataGridView1.Columns.Clear();
            MessageBox.Show("Sėkmingai pridėta į duomenų bazę!");
          
        }
    }
    }


