    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Praktika
{
    class DB
    {
        public MySqlConnection con;
        public DB()
        {
            string host = "localhost";
            string db = "mydb_nuoma";
            string port = "3306";
            string user = "root";
            string pass = "aaa12345";
            string constring = "datasource =" + host + "; database=" + db + "; port =" + port + "; username =" + user + "; password=" + pass + "; SslMode=none";
            con = new MySqlConnection(constring);
        }
    }

    class Duomenys : DB
    {
        public class Daiktas
        {

            public int idDaiktas;
            public string Pavadinimas;
            public int kaina;
            public string idVartotojas;


            public Daiktas(int idDaiktas, string Pavadinimas, int kaina, string idVartotojas)
            {
                this.idDaiktas = idDaiktas;
                this.Pavadinimas = Pavadinimas;
                this.kaina = kaina;
                this.idVartotojas = idVartotojas;

            }
        }
        public List<Daiktas> Daiktai = new List<Daiktas>();
        public DataSet item = new DataSet();
        public void UpdateDaiktas(Daiktas a)
        {
            int index = Daiktai.FindIndex((daik) =>
            {
                return daik.idDaiktas == a.idDaiktas;
            });

            Daiktai[index] = a;
        }
        public void InsertDaiktas(Daiktas a)
        {
            int index = Daiktai.FindLastIndex((daik) =>
            {
                return daik.idDaiktas == a.idDaiktas;
            });

            Daiktai[index] = a;
        }
        /// <summary>Albumo ištrynimo metodas.</summary>
        public void DeleteDaiktas(Daiktas a)
        {
            Daiktai.Remove(a);
        }
        /// <summary>Duomenų nuskaitymas iš duomenų bazės "Albumas", duomenų rinkinio užpildymas nuskaitytais duomenimis ir įkėlimas į dinaminį sąrašą.</summary>
        public void ReadDaiktas()
        {
            item.Clear();
            string kat = "select daiktas.idDaiktas, daiktas.Pavadinimas, daiktas.kaina, vartotojas.Vardas " +
                "from daiktas inner join vartotojas on daiktas.idVartotojas=vartotojas.idVartotojas ";
            MySqlDataAdapter AMDA = new MySqlDataAdapter(kat, con);
            AMDA.Fill(item, "daiktas");
            foreach (DataRow Adr in item.Tables["daiktas"].Rows)
            {
                Daiktai.Add(
                    new Daiktas(
                        Convert.ToInt32(Adr[0]),
                        (Adr[1].ToString()),
                        Convert.ToInt32(Adr[2]),
                        (Adr[3].ToString())

                    )
                );
            }
        }


        public class Vartotojas
        {
            public int idVartotojas;
            public string Vardas;
            public string Pavarde;
            public string adresas;
            public int Tel_Nr;


            // konstruktorius:
            public Vartotojas(int idVartotojas, string Vardas, string Pavarde, string adresas, int Tel_Nr)
            {
                this.idVartotojas = idVartotojas;
                this.Vardas = Vardas;
                this.Pavarde = Pavarde;
                this.adresas = adresas;
                this.Tel_Nr = Tel_Nr;

            }

        }
        public List<Vartotojas> Vartotojai = new List<Vartotojas>();
        public DataSet member = new DataSet();
        public void UpdateVartotojai(Vartotojas a)
        {
            int index = Vartotojai.FindIndex((vart) =>
            {
                return vart.idVartotojas == a.idVartotojas;
            });

            Vartotojai[index] = a;
        }
        public void InsertVartotojai(Vartotojas a)
        {
            int index = Vartotojai.FindLastIndex((vart) =>
            {
                return vart.idVartotojas == a.idVartotojas;
            });

            Vartotojai[index] = a;
        }
        public void DeleteVartotojai(Vartotojas a)
        {
            Vartotojai.Remove(a);
        }
        public void ReadVartotojai()
        {
            member.Clear();
            string vart = "select vartotojas.idVartotojas, vartotojas.Vardas, vartotojas.Pavarde, vartotojas.Adresas, vartotojas.Tel_Nr FROM vartotojas";
            
            MySqlDataAdapter VMDA = new MySqlDataAdapter(vart, con);
            VMDA.Fill(member, "vartotojas");
            foreach (DataRow Vdr in member.Tables["vartotojas"].Rows)
            {
                Vartotojai.Add(
                    new Vartotojas(
                        Convert.ToInt32(Vdr[0]),
                        (Vdr[1].ToString()),
                        (Vdr[2].ToString()),
                        (Vdr[3].ToString()),
                        Convert.ToInt32(Vdr[4])
                    )
                );
            }
        }
    }






}

