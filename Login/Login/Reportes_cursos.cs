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
using System.Collections;

namespace Login
{
    public partial class Reportes_cursos : Form
    {
        static int indexx = 0;
        static int index = 0;
        static string C = "";
        static string p = "";
        static string datos = "";

        public Reportes_cursos()
        {
            InitializeComponent();
        }

        private void Reportes_cursos_Load(object sender, EventArgs e)
        {
           //int Id_P = 0;
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("cursoAlumno");

           
            usuarios.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView1.Rows.Add(Convert.ToString(song["Id_A"]), Convert.ToString(song["Id_P"]), Convert.ToString(song["Grupo"]), Convert.ToString(song["Promedio"]))
            );

            var usuarios2 = db.GetCollection<BsonDocument>("curso");

            usuarios2.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView2.Rows.Add(Convert.ToString(song["Grupo"]),"", Convert.ToString(song["Horario"]))
            );


            Demandacurso();
           

        }

        void Demandacurso()
        {

            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {

                if (dataGridView2.Rows[i].Cells[0].Value.ToString() == " ")
                {
                    MessageBox.Show("lista recorrida");
                }
                else
                {

                   // MessageBox.Show(Convert.ToString(i));
                    if (index != dataGridView2.RowCount - 1)
                    {
                        C = dataGridView2.Rows[i].Cells[0].Value.ToString();
                        p = dataGridView2.Rows[i].Cells[0].Value.ToString();
                    }


                    cursoalumno(C);
                    promediocurso(p);
                    index = index + 1;

                }
            }
            // MessageBox.Show(datos);
            index = 0;
        }




        void cursoalumno(string c)
        {
            MongoClient client = new MongoClient("mongodb://Directivo:q234ty@ds111496.mlab.com:11496/sistemaescolar");
            var db = client.GetDatabase("sistemaescolar");
            var usuarios = db.GetCollection<BsonDocument>("cursoAlumno");
           

            var filter_id = Builders<BsonDocument>.Filter.Eq("Grupo",c);
           // var sort = Builders<BsonDocument>.Sort.Ascending("Alejandro");
            var cuenta = usuarios.Count(filter_id);

            //MessageBox.Show(Convert.ToString(cuenta));
            //dataGridView1.Rows["Numero entero de la fila"].Cells["Numero entero de la celda"].Value.ToString();
            datos = datos+"'"+ cuenta +'"';
            dataGridView2.Rows[index].Cells[1].Value = cuenta;

            


        }
        int acumulador = 0;
        void promediocurso(string p)
        {
            acumulador = 0;
            foreach (DataGridViewRow Row in dataGridView1.Rows)
            {

               
                    String strFila = Row.Index.ToString();
                    string Valor = Convert.ToString(Row.Cells["Grupo"].Value);
                   

                    if (Valor == p)
                    {
                    acumulador= acumulador + Convert.ToInt32(dataGridView1.Rows[Convert.ToInt32(strFila)].Cells[3].Value.ToString());
                        // dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Red;

                    }
                    else
                    {
                        //   dataGridView1.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.White;
                    }
                
            }
            // MessageBox.Show(Convert.ToString(acumulador));
            if(acumulador >= 4)
            {
                
                acumulador = acumulador / Convert.ToInt32(dataGridView2.Rows[Convert.ToInt32(index)].Cells[1].Value);
            }
           


            dataGridView2.Rows[Convert.ToInt32(index)].Cells[3].Value = Convert.ToString(acumulador);

        }

      
        

        private void button1_Click(object sender, EventArgs e)
        {
           

       
          

        }

        



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
