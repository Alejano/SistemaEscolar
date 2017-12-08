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
               







                if (textBox1.Text == "adm" && textBox2.Text == "qwerty")
                {
                    Administracion adm = new Administracion();
                    adm.Show();
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
        {/*
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
             clientesx = (clientesx + Convert.ToString(song["Usuario"]) + " " + Convert.ToString(song["Contraseña"])  + "\r\n")

            );
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
