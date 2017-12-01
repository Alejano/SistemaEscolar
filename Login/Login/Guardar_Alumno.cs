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
                Agregar_Direccion();
                MessageBox.Show("El alumno " + Diferenciador_A + " Se guardo en la base correctamente");
              
                
            }


            if (checkBox2.Checked)
            {
                Diferenciador_A = "externo";
                BuscarID();
                ID_A = Convert.ToInt32(varid) + 1;
                CrearIdI();
                Agregar_Alumno();
                Agregar_Direccion();
                MessageBox.Show("El alumno " + Diferenciador_A + " Se guardo en la base correctamente");
                


            } else {

                if (checkBox1.Checked == false || checkBox2.Checked == false)
                {

                    MessageBox.Show("Se necesita elegir tipo de alumno para continuar");
                }

                limpiar();
            }




        }
        void Agregar_Alumno()
        {



            MessageBox.Show("creando Alumno");
            BsonDocument Alumno = new BsonDocument
                  {//informacion del alumno
                    {"Id_A",ID_A},
                    {"Nombre",textBox1.Text},
                    {"Apellidos",textBox2.Text},
                    {"Edad",textBox3.Text },
                    {"Telefono Casa",textBox4.Text },
                    {"Telefono Celular",textBox5.Text },
                    {"T_Alumno",Diferenciador_A }


                  };

            BsonDocument DatosAlumno = Alumno;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Alumnos");

            usuarios.InsertOne(DatosAlumno);

            MessageBox.Show("alumno creado");

        }
        void Agregar_Direccion() {

            MessageBox.Show("creando direccion del  Alumno");
            BsonDocument Direccion = new BsonDocument
                  {
                    {"Id_A",ID_A},
                    {"Calle",textBox6.Text},
                    {"Entre",textBox7.Text},
                    {"Y",textBox8.Text },
                    {"Numero",textBox10.Text },
                    {"Colonia",textBox11.Text },
                    {"Codigo Postal",textBox12.Text }


                  };

            BsonDocument DireccionAlumno = Direccion;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Alumno");

            usuarios.InsertOne(DireccionAlumno);

            MessageBox.Show("direccion de alumno creada");



        }
        
        void limpiar() {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
