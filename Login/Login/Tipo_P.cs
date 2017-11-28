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
            var Matricula = db.GetCollection<BsonDocument>("Adm_Matricula");

            //con este buscas todos 
            Matricula.AsQueryable<BsonDocument>().ToList().ForEach(song =>
             varid = (Convert.ToString(song["Id_P"]))

             );



            MessageBox.Show("Succeful" + varid);
        }

        void CrearIdI()
        {
            // en esta parte vas a crear los registros {"Nombre",texbox2.text}
           /* MessageBox.Show("creando interno");
            BsonDocument crear_id = new BsonDocument
                  {
                     {"Id_P",ID_P}
                     // {"Nombre",textBox1.Text}

                  };

            BsonDocument Datosid = crear_id;
            */

            MessageBox.Show("creando registro con nuevo id" + ID_P);
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm_Matricula");
            
            var updateFilter = Builders<BsonDocument>.Filter.Eq("Id_P", Convert.ToInt32(varid));
            var update = Builders<BsonDocument>.Update.Set("Id_P", ID_P);

            usuarios.UpdateOne(updateFilter, update);
            
            //con este haces un insert
            //usuarios.InsertOne(Datosid);
            MessageBox.Show("creado");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { }
            BuscarID();
            ID_P = Convert.ToInt32(varid) + 1;
            CrearIdI();

        }
    }
}
