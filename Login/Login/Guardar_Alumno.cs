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
        static int Id_A;
        public Guardar_Alumno()
        {
            InitializeComponent();
        }

        private void Guardar_Alumno_Load(object sender, EventArgs e)
        {
            //BuscarID();
            

            if (Formulario_Alumnos.Diferenciador_A == "Internos")
            {
                CrearIdI();
            }
            else
            {
                CrearIdE();
            }

        }
        /*
        static string varid = "";
        void BuscarID()
        {
            
            
            MessageBox.Show("Cargando");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var Matricula = db.GetCollection<BsonDocument>("Adm_Matricula");

            var filter = Builders<BsonDocument>.Filter.Gte("Edad", 22);
            var sort = Builders<BsonDocument>.Sort.Ascending("Alejandro");
            Matricula.Find(filter).Sort(sort).ForEachAsync(song =>
            varid = (varid + Convert.ToString(song["_id"]) + " " + Convert.ToString(song["Nombre"]) + " " + Convert.ToString(song["Edad"]) + "\r\n")

            MessageBox.Show("Los datos son " + song["Nombre"] + "  " + song["Edad"])
            

            );
            
            

            MessageBox.Show("Succeful");
        }
        */
        void CrearIdI()
        {
            MessageBox.Show("creando");
            BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_A",17112500},
                     {"Tipo_Alumno","Interno" }
                  };

            BsonDocument Datosid = crear_id;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");
            usuarios.InsertOne(Datosid);

        }
        void CrearIdE()
        {
            MessageBox.Show("creando");
            BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_A",17112500},
                     {"Tipo_Alumno","Externo" }
                  };

            BsonDocument Datosid = crear_id;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");
            usuarios.InsertOne(Datosid);

        }
    }
}
