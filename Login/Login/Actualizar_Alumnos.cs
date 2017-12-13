﻿using System;
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
        //static int ID_A = 0;
        public static int id;

        public static string Id_Al;
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

            //MessageBox.Show(entity.ToString());

            String DtAdmjson = entity.ToString();
            char[] separador = { '"', '"' };
            DatosAlum = DtAdmjson.Split(separador);


            textBox12.Text = DatosAlum[9];
            textBox8.Text = DatosAlum[21];
            textBox11.Text = DatosAlum[13];
            textBox9.Text = DatosAlum[17];
            textBox10.Text = DatosAlum[25];

        }
        void Actualizardireccion()
        {
            Id_Al = textBox1.Text;
            BsonDocument crearDireccion = new BsonDocument
            {
                
                { "Id_A",Id_Al },
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



            // MessageBox.Show("Eliminando Profesor ...");

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var obten = client.GetDatabase("sistemaescolar");
            var baja = obten.GetCollection<BsonDocument>("alumno");


            baja.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_A", id));
        }

        void bajaDireccion()
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
                    textBox13.Text =DatosAlum[21];
                    checkBox1.Text= DatosAlum[41];
                    checkBox2.Text = DatosAlum[41];
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
              || string.IsNullOrEmpty(textBox13.Text) || string.IsNullOrEmpty(textBox14.Text)
              || string.IsNullOrEmpty(checkBox1.Text) || string.IsNullOrEmpty(checkBox2.Text))
            {
                MessageBox.Show("No puede dejar campos vacios");
            }

            else
            {
                if (MessageBox.Show("Seguro que deseas actualizar los datos de este alumno?", "Actualizando",
           MessageBoxButtons.YesNo, MessageBoxIcon.Question)
           == DialogResult.Yes)
                {
                    Baja_Alumno();
                    bajaDireccion();
                    Id_Al = textBox1.Text;
                    //int idActualizado = Convert.ToInt32(Id_Al);
                    BsonDocument crearAlum = new BsonDocument
                    {
                     {"Id_A",Id_Al},
                     {"T_Alumno",t_alumno},
                     {"Nombre",textBox2.Text},
                     {"Apellido_paterno",textBox3.Text},
                     {"Apellido_materno",textBox6.Text},
                     {"Edad",textBox13.Text},
                     {"Telefono_Casa",textBox5.Text},
                     {"Telefono_Celular",textBox7.Text},

                     {"Correo_Electronico",textBox4.Text},
                     {"contraseña",textBox14.Text}
                    };
                    BsonDocument DatosAlum = crearAlum;


                    MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                    var db = client.GetDatabase("sistemaescolar");
                    var usuarios = db.GetCollection<BsonDocument>("alumno");

                    //Sintaxis para insertar un profesor
                    // direccionP();
                    usuarios.InsertOne(DatosAlum);
                    Actualizardireccion();

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
        }
    }
}
