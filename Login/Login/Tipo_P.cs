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
    public partial class Tipo_P : Form
    {
        public static string t_profesor = "";
        public Tipo_P()
        {
            InitializeComponent();
        }

        private void Tipo_P_Load(object sender, EventArgs e)
        {

        }
        int longitud = 0;
       
        static int ID_P = 0;
        void BuscarID()
        {

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var Matricula = db.GetCollection<BsonDocument>("Profesores");

            //con este buscas todos 
            Matricula.AsQueryable<BsonDocument>().ToList().ForEach(matricu =>
             ID_P = Convert.ToInt32(matricu["Id_P"])

             );

        }

        

        //Metodo para insertar 
        void insertar()
        {

            //MessageBox.Show("Creando Profesor");
            BsonDocument crearProf = new BsonDocument
                  {
                     {"Id_P",ID_P},
                     {"t_profesor",t_profesor},
                     {"Nombre",textBox1.Text},
                     {"Apaterno",textBox2.Text},
                     {"Amaterno",textBox3.Text},
                     {"fecha_nac",dateTimePicker3.Text},
                     {"Telefono",textBox5.Text},
                     {"email",textBox4.Text},
                     {"contraseña",textBox14.Text}


                  };

            BsonDocument DatosProf = crearProf;

            //conexion

            //MessageBox.Show("Conectando ... ");
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Profesores");

            //Sintaxis para insertar un profesor
            usuarios.InsertOne(DatosProf);
            direccion();
            insertarcurso();

        }

        void insertarcurso()
        {

            BsonDocument crearCurso = new BsonDocument
                  {
                     {"Id_P",ID_P},
                     {"Curso",textBox11.Text},
                     {"Departamento",textBox12.Text},
                     {"F_inicio",dateTimePicker1.Text},
                     {"F_final",dateTimePicker2.Text },
                     {"Grupo",textBox13.Text },
                     {"Horario",comboBox1.Text },
                      {"Dia",comboBox2.Text }
                  };

            BsonDocument DatosCurso = crearCurso;

            //conexion


            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Cursos");

            //Sintaxis para insertar un profesor
            usuarios.InsertOne(DatosCurso);
            direccion();


        }

        //finaliza metodo para insertar

        //Metodo para insertar direccion
        void direccion()
        {

            BsonDocument crearDireccion = new BsonDocument
            {
                {"Calle", textBox6.Text},
                {"Colonia",textBox7.Text},
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






        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text)
                || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text)
                || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) || string.IsNullOrEmpty(textBox9.Text)
                || string.IsNullOrEmpty(textBox10.Text) || string.IsNullOrEmpty(textBox11.Text) || string.IsNullOrEmpty(textBox12.Text)
                || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(comboBox2.Text)
                || string.IsNullOrEmpty(textBox14.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }

            else
            {
                if (MessageBox.Show("Seguro que deseas agregar este profesor?", "Agregando",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                {
                    if (checkBox1.Checked)
                    {
                        t_profesor = "interno";
                        BuscarID();
                        ID_P = ID_P + 1;
                        insertar();
                        limpiar();
                        MessageBox.Show("Profesor Creado");
                    }
                    else
                    {
                        if (checkBox2.Checked)
                        {
                            t_profesor = "Externo";
                            BuscarID();
                            ID_P = ID_P + 1;
                            insertar();
                            limpiar();
                            MessageBox.Show("Profesor Creado");
                        }

                       
                        else
                        {
                            MessageBox.Show("Selecciona si el profesor es interno o externo");
                        }
                    }

                    
                }

            }





        }
        void limpiar()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
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
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

        }




        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            longitud = textBox14.Text.Length;
            if (longitud < 6)
            {
                //MessageBox.Show("Contraseña demasiado debil");
                label22.Text = "Contraseña demasiado debil";
            }
            else
            {
                label22.Text = "Contraseña fuerte";
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

