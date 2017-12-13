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
    public partial class Actualizar_Profesor : Form
    {

        string[] DatosProf = new string[99];
        public static string t_profesor = "";
        public static int ID_P = 0;
        public static int id ;
        string IDP;

        public static string Id_Pr;
        public static string tipoProf;

        public Actualizar_Profesor()
        {
            InitializeComponent();
        }


        void direccion()
        {

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Profesor");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_P",ID_P);
            var entity = usuarios.Find(filter_id).FirstOrDefault();

           MessageBox.Show(entity.ToString());

            String DtAdmjson = entity.ToString();
            char[] separador = { '"', '"' };
            DatosProf = DtAdmjson.Split(separador);

            textBox7.Text = DatosProf[9];
            textBox8.Text = DatosProf[17];
            textBox11.Text = DatosProf[13];
            textBox9.Text = DatosProf[21];
            textBox10.Text = DatosProf[25];

        }

        void bajaDireccion()
        {
        
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("Direccion_Profesor");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_P", ID_P));
        }

        void Baja_Profesor()
        {


           // MessageBox.Show("Eliminando Profesor ...");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("profesor");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_P", ID_P));
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Actualizar_Profesor_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            button2.Hide();


            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("profesor");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_P"]), Convert.ToString(equis["Nombre"]))
            );


        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ID_P = Convert.ToInt32(textBox1.Text);
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un numero de cuenta para actualizarlo");
            }

            else
            {

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("profesor");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_P", ID_P);
                var entity = usuarios.Find(filter_id).FirstOrDefault();
                //  MessageBox.Show(entity.ToString());


                if (entity == null)
                {
                    MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    
                    groupBox1.Show();
                    button2.Show();
                    dataGridView1.Hide();

                    direccion();
                    String DtAdmjson = entity.ToString();
                    char[] separador = { '"', '"' };
                    DatosProf = DtAdmjson.Split(separador);

                    
                    
                    MessageBox.Show(Convert.ToString("nombre " + DatosProf[9])+
                        Convert.ToString(" apat "+DatosProf[13])+
                        Convert.ToString(" ama " + DatosProf[17])+
                        Convert.ToString(" fecha " + DatosProf[21])+
                        Convert.ToString(" tel " + DatosProf[25])+
                        Convert.ToString(" corr " + DatosProf[29]));
                        
                    
                   textBox2.Text = DatosProf[9];
                   textBox3.Text = DatosProf[13];
                   textBox6.Text = DatosProf[17];
                   textBox5.Text = DatosProf[25];
                   textBox4.Text = DatosProf[29];
                   dateTimePicker1.Text=DatosProf[21];
                    


                }

            }
        }
        
           

        void Actualizardireccion()
        {

            BsonDocument crearDireccion = new BsonDocument
            {
                {"Id_P",ID_P },
                {"Calle", textBox7.Text},
                {"Colonia",textBox11.Text},
                {"Estado",textBox8.Text},
                {"NumCasa",textBox9.Text },
                {"CP",textBox10.Text }
            };

            BsonDocument DireccionP = crearDireccion;


            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Profesor");

            usuarios.InsertOne(DireccionP);


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        void Actualizar()
        {

            dataGridView1.Rows.Clear();

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("profesores");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_P"]), Convert.ToString(song["Nombre"]))
            );

            dataGridView1.Show();
            groupBox1.Hide();
            button2.Hide();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
              || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text)
              || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)
              || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox14.Text)
              || string.IsNullOrEmpty(checkBox1.Text) || string.IsNullOrEmpty(checkBox2.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }

            else
            {
                if (MessageBox.Show("Seguro que deseas actualizar los datos de este profesor?", "Actualizando",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                {
                    //Id_Pr = textBox1.Text;
                    //int idActualizado = Convert.ToInt32(Id_Pr);
                
                    Baja_Profesor();
                    bajaDireccion();
                    
                                     
                                       
                    MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                    var db = client.GetDatabase("sistemaescolar");
                    var usuarios = db.GetCollection<BsonDocument>("profesor");
                   


                    BsonDocument crearProf = new BsonDocument
                    {
                      {"Id_P",ID_P},
                     {"Nombre",textBox2.Text},
                     {"Apaterno",textBox3.Text},
                     {"Amaterno",textBox6.Text},
                     {"fecha_nac",dateTimePicker1.Text},
                     {"Telefono",textBox5.Text},
                     {"email",textBox4.Text},
                     {"contraseña",textBox14.Text}
                    };
                    BsonDocument DatosProf = crearProf;


                    //Sintaxis para insertar un profesor
                    // direccionP();
                    usuarios.InsertOne(DatosProf);
                     Actualizardireccion();

                    MessageBox.Show("Profesor Actualizado correctamente");
                    Actualizar();
                    limpiar();

                }
            }

            Inicio inic = new Inicio();
            
            inic.Show();
            Close();
        }
        void limpiar()
        {
            ID_P = 0;
            dateTimePicker1.ResetText();
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
                e.Handled = true;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan 
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inicio inic = new Inicio();
            inic.Show();
            Close();
        }
    }
}
