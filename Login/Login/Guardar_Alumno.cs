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
            ID_A = Convert.ToInt32(varid) + 1;
            MessageBox.Show("creando interno");
            BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_A",ID_A}
                     
                  };

            BsonDocument Datosid = crear_id;
            MessageBox.Show("creando registro con nuevo id"+ ID_A);
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");

            var updateFilter = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToInt32(varid));
            var update = Builders<BsonDocument>.Update.Set("Id_A", ID_A);

            usuarios.UpdateOne(updateFilter, update);

            MessageBox.Show("creado");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarID();
            CrearIdI();
        }
    }
}
