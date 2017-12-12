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
    public partial class BuscarProfesor : Form
    {
        public BuscarProfesor()
        {
            InitializeComponent();
        }

        private void BuscarProfesor_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("profesor");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_P"]), Convert.ToString(equis["t_profesor"]), Convert.ToString(equis["Nombre"]),
             Convert.ToString(equis["Apaterno"]), Convert.ToString(equis["Amaterno"]), Convert.ToString(equis["fecha_nac"]),
              Convert.ToString(equis["Telefono"]), Convert.ToString(equis["email"]), Convert.ToString(equis["contraseña"]))
            );
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un numero de cuenta para buscar");
            }

            else
            {

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("profesor");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_P", Convert.ToUInt32(textBox1.Text));
                var entity = usuarios.Find(filter_id).FirstOrDefault();
                //  MessageBox.Show(entity.ToString());


                if (entity == null)
                {
                    MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {

                        String strFila = Row.Index.ToString();
                        string Valor = Convert.ToString(Row.Cells["Id_P"].Value);

                        if (Valor == this.textBox1.Text)
                        {
                            dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                        }
                        else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
  if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }
    }
}
