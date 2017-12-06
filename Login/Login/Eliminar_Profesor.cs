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


            MessageBox.Show("borrado");
            


        }




        private void Eliminar_Profesor_Load(object sender, EventArgs e)
        {

        }
    }
}
