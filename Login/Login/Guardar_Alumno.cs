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
    public partial class Guardar_Alumno : Form
    {
        public static String Diferenciador_A = "";
        public Guardar_Alumno()
        {
            InitializeComponent();
        }

        private void Guardar_Alumno_Load(object sender, EventArgs e)
        {
           


        }

        static string varid = "";
        static int ID_A = 0;
        void BuscarID()
        {
            
            
            MessageBox.Show("Cargando");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var Matricula = db.GetCollection<BsonDocument>("Adm_Matricula");

            Matricula.AsQueryable<BsonDocument>().ToList().ForEach(song =>
             varid = ( Convert.ToString(song["Id_A"]))

             );



            MessageBox.Show("Succeful"+varid);
        }
        
        void CrearIdI()
        {
           
            MessageBox.Show("creando id");
            BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_A",ID_A},
                      {"Nombre",textBox1.Text} 
                     
                  };

            BsonDocument Datosid = crear_id;
            
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");

            var updateFilter = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToInt32(varid));
            var update = Builders<BsonDocument>.Update.Set("Id_A", ID_A);

            usuarios.UpdateOne(updateFilter, update);

            MessageBox.Show("id creado");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            if (checkBox1.Checked) {
                Diferenciador_A = "interno";
                BuscarID();
                ID_A = Convert.ToInt32(varid) + 1;
                CrearIdI();
                Agregar_Alumno();

                limpiar();
            }


            if (checkBox2.Checked) {
                Diferenciador_A = "externo";
                BuscarID();
                ID_A = Convert.ToInt32(varid) + 1;
                CrearIdI();

            }
            if (checkBox1.Checked == false || checkBox2.Checked == false) {

                MessageBox.Show("Se necesita elegir tippo de alumno para continuar");
            }



        }
        void Agregar_Alumno() {



            MessageBox.Show("creando Alumno");
            BsonDocument Alumno = new BsonDocument
                  {//informacion del alumno
                    {"Id_A",ID_A},
                    {"Nombre",textBox1.Text},
                    {"Apellidos",textBox2.Text},
                    {"Edad",textBox3.Text }

                  };

            BsonDocument DatosAlumno = Alumno;
            
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Alumnos");

            usuarios.InsertOne(DatosAlumno);

            MessageBox.Show("alumno creado");

        }
        //aqui creas el metodo Agregar_Direccion que va a conectar a la tabla Direccion_Alumno 
        //importante copia el de id alumno


        void limpiar() {
            textBox1.Clear();
            textBox2.Text = "";

            checkBox1.Checked = false;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
