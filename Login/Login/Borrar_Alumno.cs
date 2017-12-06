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
       

        public static int id= 0;
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
            var baja= obten.GetCollection<BsonDocument>("Alumnos");

           
            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
            

            MessageBox.Show("borrado");
            Baja_Direccion();

            
        }
        
         void Baja_Direccion() {

                
               id = Convert.ToInt32(textBox1.Text);



                MessageBox.Show("BAJA  DIRECCION............");

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var borrar_direccion= db.GetCollection<BsonDocument>("Direccion_Alumno");

                borrar_direccion.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
           

                MessageBox.Show("borrado direccion del alumno");


               

            }
        


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Seguro que deseas eliminar?", "Eliminando",
        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        == DialogResult.Yes)
            {
                Baja_Alumno();
                MessageBox.Show("Eliminado");
            }
            
           
        }

        

        }
    }

