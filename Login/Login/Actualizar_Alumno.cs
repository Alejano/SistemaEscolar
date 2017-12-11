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
    public partial class Actualizar_Alumno : Form
    {
       // public static string id = "";
        public static string id ="0";

        
        public Actualizar_Alumno()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Buscar_Nombre();
            //Cambiar_Datos_Alumno();
           

        }
       // static int id=0;

        void Cambiar_Datos_Alumno() {
            

            MessageBox.Show("cambiando datos");
            /*

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Alumnos");
            */
            //var updateFilter = Builders<BsonDocument>.Filter.Eq("Nombre", Convert.ToInt32(variable));
           // var update = Builders<BsonDocument>.Update.Set("Nombre",id);
           
            //nombre = textBox1.Text;
            
           /* "Calle",textBox6.Text
             "Entre",textBox7.Text
             "Y",textBox8.Text 
             "Numero",textBox10.Text 
             "Colonia",textBox11.Text 
             "Codigo Postal",textBox12.Text */

           // usuarios.UpdateOne(updateFilter, update);

            MessageBox.Show("datos cambiados");


        }
        //static string variable = "";

        void Buscar_Nombre() {
            string variable = "";
          //  variable = textBox14.Text;
            MessageBox.Show("buscando");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var buscar = db.GetCollection<BsonDocument>("alumno");

            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", variable);


            buscar.Find(filter).ForEachAsync(song => variable = (Convert.ToString(song["Nombre"])));



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //SOLO LETRAS
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

    
        //SOLO NUMEROS
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)&&(e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
             

            {

                // tu codigo

            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {


        }

        private void Actualizar_Alumno_Load(object sender, EventArgs e)
        {

        }
    }
}

       
    

