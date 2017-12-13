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
        //public static string p;
        string[] DatosAlum = new string[99];
        
        public Borrar_Alumno()
        {
            InitializeComponent();
        }

        void Baja_Alumno()
        {


           id = Convert.ToInt32(textBox1.Text);



            MessageBox.Show("BAJA ALUMNO  ............");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja= obten.GetCollection<BsonDocument>("alumno");

           
            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
            

            MessageBox.Show("borrado");
            

            
        }

        void bajaDireccion()
        {
            id = Convert.ToInt32(textBox1.Text);
            MessageBox.Show("BAJA DIRECCION ALUMNO  ............");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("Direccion_Alumno");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
        }

        void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            textBox7.Clear();
            dataGridView1.Rows.Clear();
        }



        private void Form2_Load(object sender, EventArgs e)
        {


            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("alumno");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_A"]), Convert.ToString(equis["Nombre"]))
            );

            button1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("¿Seguro que deseas eliminar este profesor?", "Profesor Eliminado",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                //buscarDireccion();
                
                Baja_Alumno();
                bajaDireccion();
                limpiar();

                dataGridView1.AutoGenerateColumns = true;

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("alumno");

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese  numero  cuenta para eliminar alumno");
            }

            else
            {

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("alumno");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
                var entity = usuarios.Find(filter_id).FirstOrDefault();
                // MessageBox.Show(entity.ToString());

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAlum = DtAdmjson.Split(separador);

                textBox2.Text = DatosAlum[9];
                textBox3.Text = DatosAlum[13];
                textBox4.Text = DatosAlum[17];
                textBox7.Text = DatosAlum[41];
               



                button1.Show();
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
        }
        /* void buscarDireccion()
{
MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
var db = client.GetDatabase("sistemaescolar");
var usuarios = db.GetCollection<BsonDocument>("Direccion_Alumno");


var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
var entity = usuarios.Find(filter_id).FirstOrDefault();

//MessageBox.Show(entity.ToString());

String DtAdmjson = entity.ToString();
char[] separador = { '"', '"' };
DatosAlum = DtAdmjson.Split(separador);
}*/
    }
    }

