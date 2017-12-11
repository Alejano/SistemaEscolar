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
    public partial class Borrar_Alumno : Form
    {

        public static int id = 0;
        public static string p;
        string[] DatosAlum = new string[99];
        
        public Borrar_Alumno()
        {
            InitializeComponent();
        }
        void Baja_Alumno()
        {


            id = Convert.ToInt32(textBox1.Text);



            MessageBox.Show("Eliminando Alumno ...");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("Alumnos");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));


            //MessageBox.Show("borrado");
        }

        void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            textBox7.Clear();
            dataGridView1.Rows.Clear();
        }
        

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Alumnos");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_A"]), Convert.ToString(equis["Nombre"]))
            );

            button1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que deseas eliminar este alumno?", "Alumno Eliminado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                Baja_Alumno();
                limpiar();

                dataGridView1.AutoGenerateColumns = true;

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Alumnos");

                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
                dataGridView1.Rows.Add(Convert.ToString(equis["Id_A"]), Convert.ToString(equis["Nombre"]))
                );




            }
            else
            {

            }
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un numero de cuenta alumno para eliminar");
            }

            else
            {



                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Alumnos");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
                var entity = usuarios.Find(filter_id).FirstOrDefault();
                //   MessageBox.Show(entity.ToString());

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAlum = DtAdmjson.Split(separador);

                textBox2.Text = DatosAlum[13];
                textBox3.Text = DatosAlum[17];
                textBox4.Text = DatosAlum[29];
                textBox7.Text = DatosAlum[33];
                textBox6.Text = DatosAlum[25];



                button1.Show();
            }
        }
    }
    }

