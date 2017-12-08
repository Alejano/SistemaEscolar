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
        string usu = "";
        string contraeña = "";

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

                
                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Adm");

                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>

                 dataGridView1.Rows.Add(Convert.ToString(song["Usuario"]), Convert.ToString(song["Contraseña"]))
                );

                foreach (DataGridViewRow Row in dataGridView1.Rows)
                {

                    String strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                    if (Valor == this.textBox1.Text)
                    {

                        foreach (DataGridViewRow Row2 in dataGridView1.Rows)
                        {

                            String strFila2 = Row2.Index.ToString();
                            string Valor2 = Convert.ToString(Row2.Cells["Contraseña"].Value);

                            if (Valor == this.textBox2.Text)
                            {
                                MessageBox.Show("Administrador iniciado");
                            }
                            else
                            {
                                MessageBox.Show("Usuario o Contraseña No se encuentran regirtados");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña No se encuentran regirtados");
                    }
                }


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
