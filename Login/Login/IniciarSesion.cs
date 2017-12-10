using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Login
{
    public partial class IniciarSesion : Form
    {
        public static string usu = "";
        bool u = false;
         bool c = false;
        string niv = "";


        public IniciarSesion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

                
               
                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {

                    String strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells["Usuario"].Value);
                    string Valor2 = Convert.ToString(Row.Cells["Contraseña"].Value);
                    string Valor3 = Convert.ToString(Row.Cells["Nivel"].Value);

                    if (Valor == this.textBox1.Text)
                    {
                        u = true;
                        usu = Valor;
                        if (Valor2 == this.textBox2.Text)
                        {
                            c = true;
                            

                            if (Valor3 == "1")
                            {
                                Administracion ad = new Administracion();
                                ad.Show();
                                usu = Valor;
                               
                                
                            }
                            else
                            {
                                if (Valor3 == "2")
                                {
                                    Inicio ini = new Inicio();
                                    ini.Show();
                                    usu = Valor;
                                    
                                };

                            }
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrectos");
                        }
                    } 
                }
                if (u == false) { MessageBox.Show("Usuario o Contraseña incorrectos"); }

            }
            else
            {
                if (textBox1.Text == "" && textBox2.Text == "") { MessageBox.Show("Necesita ingresar los datos"); }
                else
                { 
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Necesita ingresar su nombre de Usuario");
                    }
                    else
                    {
                        MessageBox.Show("Necesita ingresar su contraseña");
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>

             dataGridView1.Rows.Add(Convert.ToString(song["Usuario"]), Convert.ToString(song["Contraseña"]), Convert.ToString(song["Nivel"]))
            );


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tiempoHoy = DateTime.Now;
            label4.Text = tiempoHoy.ToString();
        }
    }
}
