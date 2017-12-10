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
using System.Threading;


namespace Login
{
    public partial class Administracion : Form
    {
        int limp = 0;
        string[] DatosAdm = new string[99];
        string IDB = "";
        static int ID_adm =0;
        public Administracion()
        {
            InitializeComponent();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Cargando()
        {
           
            progressBar1.Show();

            progressBar1.Visible = true;
          
            progressBar1.Minimum = 1;
         
            progressBar1.Maximum = 1000000; ;
           
            progressBar1.Value = 1;
           
            progressBar1.Step = 1;

        
            for (int x = 1; x <= 1500000; x++)
            {
                
                if (progressBar1.Value < 100000 || x > 600000)
                {
                    progressBar1.PerformStep();
                }
               
               

            }
            if(progressBar1.Value == 1000000)
            {
                MessageBox.Show("Carga completa");
                progressBar1.Hide();
               

            }
        }
       

        private void agregarNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 1;
            Limpiar();
            //MessageBox.Show("se agregara uno nuevo");
            groupBox1.Show();
            Obtenerid();


        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 2;
            Limpiar();
           // MessageBox.Show("se actualizara uno ");
            groupBox2.Show();
        }

        private void porIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 3;
            Limpiar();
          //  MessageBox.Show("se eliminara por id");
            groupBox3.Show();

        }


        private void Administracion_Load(object sender, EventArgs e)
        {
            
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            groupBox6.Hide();
            groupBox7.Hide();
            button2.Hide();
            button5.Hide();
            label19.Text = IniciarSesion.usu;
            progressBar1.Hide();
            

            
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_Adm"]) , Convert.ToString(song["Usuario"]), Convert.ToString(song["Nivel"]))
            ); 


        }
       
        void Limpiar()
        {
            if (limp == 1) { groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox7.Hide(); groupBox8.Hide(); }
            if (limp == 2) { groupBox1.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox7.Hide(); groupBox8.Hide(); }
            if (limp == 3) { groupBox1.Hide(); groupBox2.Hide(); groupBox4.Hide(); groupBox7.Hide(); groupBox8.Hide(); }
            if (limp == 4) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox7.Hide(); groupBox8.Hide(); }
            if (limp == 5) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox8.Hide(); }
            if (limp == 5) { groupBox1.Hide(); groupBox2.Hide(); groupBox3.Hide(); groupBox4.Hide(); groupBox7.Hide(); }
        }

        private void Agregar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void Agregar_Admin()
        {
            bool verificacion = false;


            
           // MessageBox.Show("creando Administrador");
            BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",textBox1.Text},
                    {"Usuario",textBox2.Text },
                    {"Contraseña",textBox3.Text },
                    {"Nivel",comboBox1.Text }


                  };
            BsonDocument DatosAdmin = Admin;
            int longitud = textBox7.Text.Length;
            if (textBox9.Text == textBox3.Text)
            {
                longitud = textBox3.Text.Length;
                if (longitud >= 6)
                {

    

                    foreach (DataGridViewRow Row in dataGridView1.Rows)
                    {

                        String strFila = Row.Index.ToString();
                        string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                        if (Valor == this.textBox2.Text)
                        {
                            verificacion = true;
                        }
                        
                    }
                    if (verificacion == true)
                    {
                        MessageBox.Show("Usuario ya existe");
                    }
                    else
                    {
                        MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                        var db = client.GetDatabase("sistemaescolar");
                        var usuarios = db.GetCollection<BsonDocument>("Adm");

                        usuarios.InsertOne(DatosAdmin);
                        Cargando();
                        //MessageBox.Show("Administrador creado");
                        limpiarDatos();
                        Actualizar();
                    }
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

        void Obtenerid()
        {
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
          ID_adm = Convert.ToInt32(song["Id_Adm"])
           );

            ID_adm = ID_adm+1;
            textBox1.Text = Convert.ToString(ID_adm);

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

 

                        BsonDocument Admin = new BsonDocument
                  {//informacion del alumno
                    {"Id_Adm",IDB},
                    {"Usuario",textBox5.Text },
                    {"Contraseña",textBox8.Text },
                    {"Nivel",textBox6.Text }


                  };

                        BsonDocument DatosAdmin = Admin;



                        usuarios.InsertOne(DatosAdmin);

                        Cargando();
                        MessageBox.Show("Administrador actualizado");
                        limpiarDatos();
                        Actualizar();
                        groupBox4.Hide();
                        
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

            if (entity == null)
            {
                MessageBox.Show("Id no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox4.Show();

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);

                // dataGridView1.Rows.Add(DatosAdm[7], DatosAdm[11], DatosAdm[19]);

                textBox5.Text = DatosAdm[11];
                textBox6.Text = DatosAdm[19];

                button2.Show();
            }

          


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
            button5.Hide();
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
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Show();

            IDB = textBox10.Text;


            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");


            var filter_id = Builders<BsonDocument>.Filter.Eq("Id_Adm",IDB);
            var entity = usuarios.Find(filter_id).FirstOrDefault();
            
            if (entity == null)
            {
                MessageBox.Show("ID no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                groupBox4.Show();

                String DtAdmjson = entity.ToString();
                char[] separador = { '"', '"' };
                DatosAdm = DtAdmjson.Split(separador);


                textBox11.Text = DatosAdm[7];
                textBox12.Text = DatosAdm[11];
                textBox13.Text = DatosAdm[19];

                button2.Show();
            }

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Seguro que desea Eliminar?", "Eliminar",
       MessageBoxButtons.YesNo, MessageBoxIcon.Question)
       == DialogResult.Yes)
            {
                IDB = textBox10.Text;
                MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
                var db = client.GetDatabase("sistemaescolar");
                var usuarios = db.GetCollection<BsonDocument>("Adm");

                usuarios.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("Id_Adm", IDB));
                Cargando();
                Actualizar();
                limpiarDatos();
            }

        }

        void Actualizar()
        {

            dataGridView1.Rows.Clear();

            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("Adm");

            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_Adm"]), Convert.ToString(song["Usuario"]), Convert.ToString(song["Nivel"]))
            );
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void porIDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            limp = 4;
            Limpiar();
            //MessageBox.Show("Buscar por ID");
            groupBox6.Show();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["Id_Adm"].Value);

                if (Valor == this.textBox14.Text)
                {
                    dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                }
                else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void porNombreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            limp = 5;
            Limpiar();
            //MessageBox.Show("Buscar por ID");
            groupBox7.Show();
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

                String strFila = Row.Index.ToString();
                string Valor = Convert.ToString(Row.Cells["Usuario"].Value);

                if (Valor == this.textBox15.Text)
                {
                    dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;
                }
                else { dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White; }
            }
        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Enter))
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

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limp = 6;
            Limpiar();
            //MessageBox.Show("se agregara uno nuevo");
            groupBox8.Show();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PDF_Alumnos padfa = new PDF_Alumnos();
            padfa.Show();
        }
    }
}
