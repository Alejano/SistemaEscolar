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
    public partial class Guardar_Alumno : Form
    {
        public static string Diferenciador_A = "";
        public static int ID_A = 0;
        public Guardar_Alumno()
         
        {
            InitializeComponent();
        }

        private void Guardar_Alumno_Load(object sender, EventArgs e)
        {
           


        }


        //static int ID_A = 0; 

        void BuscarID()
        {
            
            
            
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var Matriculas= db.GetCollection<BsonDocument>("alumno");

            Matriculas.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            ID_A=Convert.ToInt32(song["Id_A"])

             );



           
        }
        
      

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text != textBox14.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
            }
            else
            {



                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
                   || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text)
                   || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)
                   || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox12.Text)
                   || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(checkBox1.Text) || string.IsNullOrEmpty(checkBox2.Text)
                   || string.IsNullOrEmpty(textBox14.Text))
                {
                    MessageBox.Show("No puede dejar campos vacios");
                }




                if (checkBox1.Checked)
                {

                    if (MessageBox.Show("Seguro desesas guardar?", "Guardando",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            == DialogResult.Yes)
                    {
                        Diferenciador_A = "interno";
                        BuscarID();
                        ID_A = ID_A + 1;
                        Agregar_Alumno();
                        Agregar_Direccion();
                        MessageBox.Show("El alumno " + Diferenciador_A + " se guardo en la base correctamente");

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
                            Diferenciador_A = "externo";
                            BuscarID();
                            ID_A = ID_A + 1;
                            Agregar_Alumno();
                            Agregar_Direccion();
                            MessageBox.Show("El alumno " + Diferenciador_A + " Se guardo en la base correctamente");

                        }






                    }
                    else
                    {

                        if (checkBox1.Checked == false || checkBox2.Checked == false)
                        {

                            MessageBox.Show("Se necesita elegir tipo de alumno (interno/externo) para continuar");
                        }


                    }
                }
                limpiar();
            }
                




        }
        void Agregar_Alumno()
        {

           

           
            BsonDocument Alumno = new BsonDocument
                  {
                    
                    {"Id_A",ID_A},
                    {"Nombre",textBox1.Text},
                    {"Apellido_Paterno",textBox2.Text},
                    {"Apellido_Materno",textBox3.Text},
                    {"Fecha_Nacimiento",dateTimePicker3.Text},
                    {"Telefono_Casa",textBox4.Text },
                    {"Telefono_Celular",textBox5.Text },
                    {"Correo_Electronico",textBox9.Text },
                    {"Contraseña",textBox13.Text },
                    {"T_Alumno",Diferenciador_A },



                  };

            BsonDocument DatosAlumno = Alumno;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("alumno");

            usuarios.InsertOne(DatosAlumno);

           
            
            

        }
        void Agregar_Direccion() {

            
            BsonDocument Direccion = new BsonDocument
                  {
                    {"Id_A",ID_A},
                    {"Calle",textBox6.Text},
                    {"Colonia",textBox7.Text},
                    {"Numero",textBox8.Text },
                    {"Estado",textBox10.Text },
                    {"Codigo Postal",textBox12.Text }


                  };

            BsonDocument DireccionAlumno = Direccion;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Direccion_Alumno");

            usuarios.InsertOne(DireccionAlumno);

           



        }
        
        void limpiar() {
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
            textBox13.Clear();
            textBox14.Clear();
           
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)

        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
               // if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
          
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
           // if (textBox7.Text == textBox8.Text) {
              //  MessageBox.Show("ok");
            
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inicio ini = new Inicio();
            ini.Show();
            Hide();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
