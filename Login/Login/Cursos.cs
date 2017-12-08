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
        public string cursoActualizar()
        {
            string algo = "";

            return algo;
        }
        public string cursoEliminar()
        {
            string algo = "";

            return algo;
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            gbOpCRUD.Visible = false;
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
            gbOpCRUD.Visible = true;
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Cursos");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Curso", mostrarCurso);
            var entity = usuarios.Find(filter_id).FirstOrDefault();
            MessageBox.Show(entity.ToString());

            //string[] DtAdm = new string[10];
            String DtAdmjson = entity.ToString();
            char[] separador = { '"', '"' };
            //dataGridView1.Rows.Add(DtAdmjson.Split(separador));
            //string[] DatosAdm = DtAdmjson.Split(separador);

            //dataGridView1.Rows.Add(DatosAdm[7], DatosAdm[11], DatosAdm[19]);
            
            /*
            var DtAdm = entity.ToArray();
            dataGridView1.Rows.Add(DtAdm[1]);
            dataGridView1.Rows.Add(DtAdm[2]);
            dataGridView1.Rows.Add(DtAdm[3]);
            */

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
