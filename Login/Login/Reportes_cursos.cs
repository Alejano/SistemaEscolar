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
    public partial class Reportes_cursos : Form
    {
        public Reportes_cursos()
        {
            InitializeComponent();
        }

        private void Reportes_cursos_Load(object sender, EventArgs e)
        {

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("CursoAlumno");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_A"]), Convert.ToString(song["Grupo"]), Convert.ToString(song["Promedio"]))
            );

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = from row in dataGridView1.Rows.Cast<DataGridViewRow>()
                          group row by Convert.ToString(row.Cells["Grupo"].Value) into Group
                         // where Group.Count 
                          select new
                          {
                              Clave = Group.Key,
                              Rows = Group,
                          };

            MessageBox.Show(result.Count().ToString());
        }
    }
}
