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
    public partial class BuscarAlumno : Form
    {
        public BuscarAlumno()
        {
            InitializeComponent();
        }
       
        private void BuscarAlumno_Load(object sender, EventArgs e)
        {
            
            {
                dataGridView1.AutoGenerateColumns = true;
                
                
                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("alumno");
               
              ///var usuarios2 = db.GetCollection<BsonDocument>("Direccion_Alumno");

                usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
                dataGridView1.Rows.Add(Convert.ToString(equis["Id_A"]), Convert.ToString(equis["Nombre"]), Convert.ToString(equis["Apellido_Paterno"]),
                 Convert.ToString(equis["Apellido_Materno"]), Convert.ToString(equis["Edad"]), Convert.ToString(equis["Telefono_Casa"]),
                  Convert.ToString(equis["Telefono_Celular"]), Convert.ToString(equis["Correo_Electronico"]),
                  Convert.ToString(equis["Contraseña"]), Convert.ToString(equis["T_Alumno"]))
                 




                  );

               
                 


               
                 

            }
            
              
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
                var usuarios = db.GetCollection<BsonDocument>("alumno");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
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
                        string Valor = Convert.ToString(Row.Cells["Id_A"].Value);

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
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
        }
    }
}
