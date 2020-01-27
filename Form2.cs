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


namespace Praktika
{


    
    public partial class Form2 : Form
    {
        Duomenys duom = new Duomenys();
        public Form2()
        {
            InitializeComponent();
   
        }
    
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            dataGridView1.DataSource = null;
            DaiktasGrid();
           
        }


        private void DaiktasGrid()
        {
            //dataGridView1.DataSource  = null ;

            duom.Daiktai.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            duom.ReadDaiktas();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Pavadinimas";
            dataGridView1.Columns[2].Name = "kaina";
            dataGridView1.Columns[3].Name = "Savininkas";
            dataGridView1.Columns[3].Width = 120;

           // dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = "yyyy-MM-dd";

            duom.Daiktai.ForEach((itm) =>
            {
                dataGridView1.Rows.Add(itm.idDaiktas, itm.Pavadinimas, itm.kaina, itm.idVartotojas);
            });
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // dataGridView1.DataSource = null;
           // dataGridView1.Columns.Clear();
           // dataGridView1.Rows.Clear();
            VartotojaiGrid();
        }
        private void VartotojaiGrid()
        {
            duom.Vartotojai.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();


            duom.ReadVartotojai();
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "ID";
            dataGridView1.Columns[1].Name = "Vardas";
            dataGridView1.Columns[2].Name = "Pavarde";
            dataGridView1.Columns[3].Name = "Adresas";
            dataGridView1.Columns[4].Name = "Tel_Nr";
          

           

            duom.Vartotojai.ForEach((itm) =>
            {
                dataGridView1.Rows.Add(itm.idVartotojas, itm.Vardas, itm.Pavarde, itm.adresas, itm.Tel_Nr);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Duomenys.Daiktas DaiktassSelect = duom.Daiktai.Find((dkt) =>
            {
                return dkt.idDaiktas == Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value);
            });

            duom.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "delete from daiktas where idDaiktas=@idDaiktas";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = duom.con;

                cmd.Parameters.Add("@idDaiktas", MySqlDbType.Int32).Value = DaiktassSelect.idDaiktas;
                cmd.ExecuteNonQuery();
                duom.con.Close();
            }

            duom.DeleteDaiktas(DaiktassSelect);

            dataGridView1.Rows.RemoveAt(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Index);
            MessageBox.Show("Daiktas ištrintas!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 m = new Form3();

            m.Show();
            
        }
    }
}
