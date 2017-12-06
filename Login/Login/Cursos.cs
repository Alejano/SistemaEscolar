using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace Login
{
    public partial class Cursos : Form
    {
        public static string nombreCurso = "";
        public static string mostrarCurso = "";
        public Cursos()
        {
            InitializeComponent();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var curso = db.GetCollection<BsonDocument>("Cursos");
            curso.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            cbCursos.Items.Add(nombreCurso + Convert.ToString(song["Curso"]))
            );
        }

        private void cbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarCurso = cbCursos.Text;

        }
    }
}
