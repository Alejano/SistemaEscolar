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
        string[] DatosAdm = new string[99];
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
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var cursoCB = db.GetCollection<BsonDocument>("Cursos");
            cursoCB.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            cbCursos.Items.Add(nombreCurso + Convert.ToString(song["Curso"]))
            );
            Button addNewRowButton = new Button();
            MongoClient client1 = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db1 = client.GetDatabase("sistemaescolar");
            var cursoTodos = db.GetCollection<BsonDocument>("Cursos");
            cursoTodos.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dgvCursos.Rows.Add(Convert.ToString(song["Grupo"]), Convert.ToString(song["Curso"]), 
            Convert.ToString(song["Departamento"]), Convert.ToString(song["F_inicio"]), Convert.ToString(song["F_final"]), 
            Convert.ToString(song["Horario"]), Convert.ToString(song["Dia"])
            ));
        }

        private void cbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarCurso = cbCursos.Text;
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var cursoFilter = db.GetCollection<BsonDocument>("Cursos");
            var filter_id = Builders<BsonDocument>.Filter.Eq("Curso", mostrarCurso);

            var entity = cursoFilter.Find(filter_id).FirstOrDefault();

            if (entity == null)
            {
                MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);
                
                dgvCursos.Rows.Add(DatosAdm[32]);
                dgvCursos.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            Close();
        }
    }
}
