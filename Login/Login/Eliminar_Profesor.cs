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
    public partial class Eliminar_Profesor : Form
    {
        public static int id = 0;
        public  static string p;
        string[] DatosProf = new string[99];

        public Eliminar_Profesor()
        {
            InitializeComponent();
        }

        void Baja_Profesor()
        {


            id = Convert.ToInt32(textBox1.Text);



            MessageBox.Show("Eliminando Profesor ...");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("Profesores");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_P", id));


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


        private void Eliminar_Profesor_Load(object sender, EventArgs e)
        {
            

            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Profesores");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_P"]) , Convert.ToString(equis["Nombre"]))
            );

            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un numero de cuenta para eliminar");
            }

            else
            {

                
                
                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Profesores");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_P", Convert.ToUInt32(textBox1.Text));
                var entity = usuarios.Find(filter_id).FirstOrDefault();
             //   MessageBox.Show(entity.ToString());

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosProf = DtAdmjson.Split(separador);

                textBox2.Text = DatosProf[13];
                textBox3.Text = DatosProf[17];
                textBox4.Text = DatosProf[29];
                textBox7.Text = DatosProf[33];
                textBox6.Text = DatosProf[25];



                button1.Show();
            }
        }

       private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que deseas eliminar este profesor?", "Profesor Eliminado",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                Baja_Profesor();
                limpiar();

                dataGridView1.AutoGenerateColumns = true;

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Profesores");

                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
                dataGridView1.Rows.Add(Convert.ToString(equis["Id_P"]), Convert.ToString(equis["Nombre"]))
                );




            }
            else
            {

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
    if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
