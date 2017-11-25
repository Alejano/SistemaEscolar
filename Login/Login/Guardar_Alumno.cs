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
        static string Id_A;
        public Guardar_Alumno()
        {
            InitializeComponent();
        }

        private void Guardar_Alumno_Load(object sender, EventArgs e)
        {
            BuscarID();
            CrearId();
        }
        static string varid = "";
        void BuscarID()
        {
            
            
            MessageBox.Show("Cargando");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(usu =>
            varid = (varid + Convert.ToString("  id_usuario  " + usu["id"])
            + "  nombre  " + Convert.ToString(usu["Nombre"])
            + "  apellido  " + Convert.ToString(usu["Apellido"]) + "\r\n")

            );

            

            MessageBox.Show("Succeful");
        }
        void CrearId()
        {
            BsonDocument crear_usuario = new BsonDocument
                  {
                     {"Id_A","17112500"}
                  };

            BsonDocument DatosUsuario = crear_usuario;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");
            usuarios.InsertOne(DatosUsuario);

        }
    }
}
