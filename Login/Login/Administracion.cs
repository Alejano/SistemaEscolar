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
    public partial class Administracion : Form
    {
        int limp = 0;
        string[] DatosAdm = new string[99];
        string IDB = "";
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
            groupBox4.Hide();
          //  groupBox5.Hide();
            button2.Hide();

            

            /*
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");


            var filter_id = Builders<BsonDocument>.Filter.Eq("id", ObjectId.Parse("50ed4e7d5baffd13a44d0153"));
            var entity = usuarios.Find(filter_id).FirstOrDefault();
           MessageBox.Show( entity.ToString());
            */
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



            MessageBox.Show("creando Administrador");
            BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",textBox1.Text},
                    {"Usuario",textBox2.Text },
                    {"Contraseña",textBox3.Text },
                    {"Nivel",comboBox1.Text }


                  };
            int longitud = textBox7.Text.Length;
            if (textBox9.Text == textBox3.Text)
            {
                longitud = textBox3.Text.Length;
                if (longitud >= 6)
                {

                    BsonDocument DatosAdmin = Admin;

                    MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                    var db = client.GetDatabase("sistemaescolar");
                    var usuarios = db.GetCollection<BsonDocument>("Adm");

                    usuarios.InsertOne(DatosAdmin);

                    MessageBox.Show("Administrador creado");
                }
                else { MessageBox.Show("La contraseña debe tener minimo 6 caracteres"); }
            }
            else { MessageBox.Show("Contraseña no coincide"); }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Admin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int longitud = 0;
            if (MessageBox.Show("Confirme para actualizar", "actualizando",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {




                if (textBox7.Text == textBox8.Text)
                {
                    longitud = textBox7.Text.Length;
                    if (longitud >= 6)
                    {
                        MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                        var db = client.GetDatabase("sistemaescolar");
                        var usuarios = db.GetCollection<BsonDocument>("Adm");

                        usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB));

                        /* update de un soloregistro
                        var updateFilter = Builders<BsonDocument>.Filter.Eq("Nombre", DatosAdm[11]);
                        var update = Builders<BsonDocument>.Update.Set("Nombre", textBox5.Text);

                        usuarios.UpdateOne(updateFilter, update);
                        */



                        BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",IDB},
                    {"Usuario",textBox5.Text },
                    {"Contraseña",textBox8.Text },
                    {"Nivel",textBox6.Text }


                  };

                        BsonDocument DatosAdmin = Admin;



                        usuarios.InsertOne(DatosAdmin);


                        MessageBox.Show("adm actualizado");
                        limpiarDatos();
                    }
                    else
                    {
                        MessageBox.Show("Debe tener mas de 6 caracteres");
                    }
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinsiden");
                }

            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           IDB=textBox4.Text;
            

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Adm", textBox4.Text);
            var entity = usuarios.Find(filter_id).FirstOrDefault();
            MessageBox.Show(entity.ToString());

            groupBox4.Show();

            String DtAdmjson = entity.ToString();
            char[] separador = { '"','"' };
            DatosAdm = DtAdmjson.Split(separador);

           // dataGridView1.Rows.Add(DatosAdm[7], DatosAdm[11], DatosAdm[19]);

            textBox5.Text=DatosAdm[11];
            textBox6.Text = DatosAdm[19];

            button2.Show();


        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        void limpiarDatos()
        {
            button2.Hide();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

    }
}
