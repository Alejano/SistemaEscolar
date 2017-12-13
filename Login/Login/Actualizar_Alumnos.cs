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
    public partial class Actualizar_Alumnos : Form
    {
        string[] DatosAlum = new string[99];
        public static string t_alumno = "";
        public static int ID_A = 0;
        public static int id;
        //public IDP;
        public static string Id_Pr;
        public static string tipoProf;



        

        
        
        public Actualizar_Alumnos()
        {
            InitializeComponent();
        }
        void direccion()
        {

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Alumno");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
            var entity = usuarios.Find(filter_id).FirstOrDefault();

           

            String DtAdmjson = entity.ToString();
            char[] separador = { '"', '"' };
            DatosAlum = DtAdmjson.Split(separador);


            textBox12.Text = DatosAlum[9];
            textBox8.Text = DatosAlum[21];
            textBox11.Text = DatosAlum[13];
            textBox9.Text = DatosAlum[17];
            textBox10.Text = DatosAlum[25];

        }
        void ActualizarAlumno()
        {
            id = Convert.ToInt32(textBox1.Text);
            BsonDocument crearAlum = new BsonDocument
                    {

                     {"Id_A",id},

                     {"Nombre",textBox2.Text},
                     {"Apellido_Paterno",textBox3.Text},
                     {"Apellido_Materno",textBox6.Text},
                     {"Fecha_Nacimiento",dateTimePicker3.Text},
                     {"Telefono_Casa",textBox5.Text},
                     {"Telefono_Celular",textBox7.Text},

                     {"Correo_Electronico",textBox4.Text},
                     {"Contraseña",textBox14.Text},
                     {"T_Alumno",t_alumno},
                    };
            BsonDocument DatosAlum = crearAlum;


            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("alumno");
            usuarios.InsertOne(DatosAlum);
            
        }
        void ActualizarDireccion()
        {
            id = Convert.ToInt32(textBox1.Text);
            BsonDocument crearDireccion = new BsonDocument
            {
                
                { "Id_A",id },
                {"Calle", textBox12.Text},
                {"Colonia",textBox11.Text},
                {"Estado",textBox8.Text},
                {"Numero",textBox9.Text },
                {"Codigo Postal",textBox10.Text }
            };

            BsonDocument DireccionA = crearDireccion;


            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Alumno");

            usuarios.InsertOne(DireccionA);


        }

        void Baja_Alumno()
        {
            id = Convert.ToInt32(textBox1.Text);

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("alumno");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
        }

        void Baja_Direccion()
        {
            id = Convert.ToInt32(textBox1.Text);

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("Direccion_Alumno");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
        }


        private void Actualizar_Alumnos_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            button2.Hide();


            dataGridView1.AutoGenerateColumns = true;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("alumno");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(equis =>
            dataGridView1.Rows.Add(Convert.ToString(equis["Id_A"]), Convert.ToString(equis["Nombre"]))
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese un numero de cuenta para actualizarlo");
            }

            else
            {

                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("alumno");


                var filter_id = Builders<BsonDocument>.Filter.Eq("Id_A", Convert.ToUInt32(textBox1.Text));
                var entity = usuarios.Find(filter_id).FirstOrDefault();
                


                if (entity == null)
                {
                    MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    groupBox1.Show();
                    button2.Show();
                    dataGridView1.Hide();



                    

                    String DtAdmjson = entity.ToString();
                    char[] separador = { '"', '"' };
                    DatosAlum = DtAdmjson.Split(separador);
                    textBox1.Enabled = false;
                    textBox2.Text = DatosAlum[9];
                    textBox3.Text = DatosAlum[13];
                    textBox4.Text = DatosAlum[33];
                    textBox5.Text = DatosAlum[25];
                    textBox6.Text = DatosAlum[17];
                    textBox7.Text = DatosAlum[29];
                    dateTimePicker3.Text =DatosAlum[21];
                    //checkBox1.Text= DatosAlum[41];
                    //checkBox2.Text = DatosAlum[41];
                    textBox14.Text = DatosAlum[37];
                    direccion();

                    // dateTimePicker3.Text = DatosAlum[25];



                }
            }
            }

        private void button2_Click(object sender, EventArgs e)
        {
           if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
              || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text)
              || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)
              || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox12.Text)
               || string.IsNullOrEmpty(textBox14.Text)
             || string.IsNullOrEmpty(checkBox1.Text) || string.IsNullOrEmpty(checkBox2.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }

            if(checkBox1.Checked)
            {
                if (MessageBox.Show("Seguro que deseas actualizar los datos de este alumno?", "Actualizando",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                {
                    t_alumno = "interno";
                    Baja_Alumno();
                    Baja_Direccion();
                    ActualizarAlumno();
                    ActualizarDireccion();
                    MessageBox.Show("El alumno " + t_alumno + " se guardo en la base correctamente");
                    limpiar();
                    groupBox1.Hide();
                    button2.Hide();
                    dataGridView1.Show();
                    textBox1.Enabled = true;


                }
            }
            else
            {


                if (checkBox2.Checked)
                {

                    if (MessageBox.Show("Seguro desesas guardar?", "Guardando",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    {
                        t_alumno = "externo";
                        Baja_Alumno();
                        Baja_Direccion();
                        ActualizarAlumno();
                        ActualizarDireccion();
                        MessageBox.Show("El alumno " + t_alumno + " Se guardo en la base correctamente");
                        limpiar();
                        groupBox1.Hide();
                        button2.Hide();
                        dataGridView1.Show();
                        textBox1.Enabled = true;
                    }





                
                }
                else
                {

                    if (checkBox1.Checked == false || checkBox2.Checked == false)
                    {

                        MessageBox.Show("Se necesita elegir tipo otra vez el alumno interno/externo para continuar");
                    }


                }
            }
            
        }
                   
    

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            // if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        void limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox14.Clear();

           // checkBox1.Checked = false;
            //checkBox2.Checked = false;
        }
            private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }
    }
}


