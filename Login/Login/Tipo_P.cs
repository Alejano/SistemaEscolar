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
    public partial class Tipo_P : Form
    {
        public static string t_profesor="";
        public Tipo_P()
        {
            InitializeComponent();
        }

        private void Tipo_P_Load(object sender, EventArgs e)
        {
           
        }

        static string varid = "";
        static int ID_P = 0;
        void BuscarID()
        {


            MessageBox.Show("Cargando");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var Matricula = db.GetCollection<BsonDocument>("Adm_MatriculaP");
            
            //con este buscas todos 
            Matricula.AsQueryable<BsonDocument>().ToList().ForEach(matricu =>
             varid = ( Convert.ToString(matricu["Id_P"]) )

             );
            
            MessageBox.Show("Succeful  " + varid);
        }

        void CrearIdI()
        {
            // en esta parte vas a crear los registros {"Nombre",texbox2.text}
            MessageBox.Show("creando interno");
            ID_P = Convert.ToInt32(varid) + 1;

            /*BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_P",300000}
                     // {"Nombre",textBox1.Text}

                  };

            BsonDocument Datosid = crear_id;
           */

            MessageBox.Show("creando registro con nuevo id  " + ID_P);
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_MatriculaP");
            
            var updateFilter = Builders<BsonDocument>.Filter.Eq("Id_P", Convert.ToInt32(varid));
            var update = Builders<BsonDocument>.Update.Set("Id_P", ID_P);

            usuarios.UpdateOne(updateFilter, update);
            
            //con este haces un insert
            //usuarios.InsertOne(Datosid);
            MessageBox.Show("creado");

        }

        //Metodo para insertar 
        void insertar()
        {
           
            MessageBox.Show("Creando documento");
            BsonDocument crearProf = new BsonDocument
                  {
                     {"Id_P",ID_P},
                     {"t_profesor",t_profesor},
                     {"Nombre",textBox2.Text},
                     {"Apaterno",textBox3.Text},
                     {"Amaterno",textBox9.Text},
                     {"fecha_nac",textBox4.Text},
                     {"Telefono",textBox8.Text},
                     {"Curso",textBox5.Text},
                     {"Departamento",textBox6.Text}

                  };

            BsonDocument DatosProf = crearProf;

            //conexion

            MessageBox.Show("Conectando ... ");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Profesores");

            //Sintaxis para insertar un profesor
            usuarios.InsertOne(DatosProf);
            direccion();
            MessageBox.Show("Profesor Creado ...");
        }

            //finaliza metodo para insertar

        //Metodo para insertar direccion
         void direccion()
        {

            BsonDocument crearDireccion = new BsonDocument
            {
                {"Calle", textBox7.Text},
                {"Colonia",textBox10.Text},
                {"Estado",textBox11.Text},
                {"NumeroCa",textBox12.Text }
            };

            BsonDocument DireccionP = crearDireccion;

            MessageBox.Show("Conectando ... ");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Profesor");

            usuarios.InsertOne(DireccionP);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                t_profesor = "interno";
                BuscarID();
                CrearIdI();
                insertar();

            }
            if (checkBox2.Checked)
            {
                t_profesor = "Externo";
                BuscarID();
                CrearIdI();
                insertar();

            }
            else
            {
                MessageBox.Show("Selecciona si el profesor es interno o externo");
            }
            



        }
    }
}
