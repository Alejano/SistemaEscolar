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
    public partial class Administracion : Form
    {
        int limp = 0;
        public Administracion()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 1;
            limpiar();
            MessageBox.Show("se agregara uno nuevo");
            groupBox1.Show();


        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 2;
            limpiar();
            MessageBox.Show("se actualizara uno ");
            groupBox2.Show();
        }

        private void porIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 3;
            limpiar();
            MessageBox.Show("se eliminara por id");
            groupBox3.Show();

        }

        private void porNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("se eliminara por nombre");
        }

        private void Administracion_Load(object sender, EventArgs e)
        {
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
        }
        void limpiar()
        {
            if (limp == 1) { groupBox2.Hide(); groupBox3.Hide(); }
            if (limp == 2) { groupBox1.Hide(); groupBox3.Hide(); }
            if (limp == 3) { groupBox1.Hide(); groupBox2.Hide(); }

        }

        private void Agregar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void Agregar_Admin()
        {



            MessageBox.Show("creando Alumno");
            BsonDocument Alumno = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",textBox1.Text},
                    {"Usuario",textBox2.Text },
                    {"Contraseña",textBox3.Text }
                   


                  };

            BsonDocument DatosAlumno = Alumno;

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Alumnos");

            usuarios.InsertOne(DatosAlumno);

            MessageBox.Show("alumno creado");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
