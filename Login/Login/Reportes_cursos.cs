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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Login
{
    public partial class Reportes_cursos : Form
    {
        static int index = 0;
        static string C = "";
        static string p = "";
        static string datos = "";
        static string Cursomen = "";
        static string mendem = "";
        static string Cursomay = "";
        static string maydem = "";

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
            dataGridView1.Rows.Add(Convert.ToString(song["Id_A"]), " ", Convert.ToString(song["Grupo"]), Convert.ToString(song["Promedio"]))
            );

            var usuarios2 = db.GetCollection<BsonDocument>("curso");

            usuarios2.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            dataGridView2.Rows.Add(Convert.ToString(song["Grupo"]),"", Convert.ToString(song["Horario"]))
            );


            Demandacurso();
            /*
            var usuarios3 = db.GetCollection<BsonDocument>("alumno");


            usuarios3.AsQueryable<BsonDocument>().ToList().ForEach(song =>
            
            dataGridView1.Rows[Convert.ToInt32(song)].Cells[1].Value=Convert.ToString(song["Nombre"])
            );
            */
            calculo();
            textBox1.Text = Cursomay + maydem;
            textBox2.Text = Cursomen + mendem;
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
            //var sort = Builders<BsonDocument>.Sort.Ascending("Alejandro");
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

        void calculo()
        {
            int valorMaximo = 0;
            int valorMinimo = int.MaxValue;
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                String strFila = row.Index.ToString();
                string Valor = Convert.ToString(row.Cells["Demanda"].Value);

                if (!row.IsNewRow)
                {
                    if (Convert.ToInt32(Valor) > valorMaximo)
                    {
                      // MessageBox.Show(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value));
                        valorMaximo = Convert.ToInt32(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value);
                    }

                    if (Convert.ToInt32(Valor) < valorMinimo)
                    {
                        valorMinimo = Convert.ToInt32(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value);
                    }
                }
                
            }

//            MessageBox.Show("El valor mínimo es, el valor máximo es "+ Convert.ToString( valorMinimo) +Convert.ToString( valorMaximo));
            docDemanda(valorMaximo);
        }
        int men = 0;
        void docDemanda(  int vmax)
        {
           
            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {


                String strFila = Row.Index.ToString();
                int Valor = Convert.ToInt32(Row.Cells["Demanda"].Value);

                if (!Row.IsNewRow)
                {
                    if (Valor <= (vmax / 3))
                    {
                        mendem = mendem + Convert.ToInt32(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value.ToString())+ "\r\n";
                        men = 1;
                        docCurso(strFila, men);
                    }
                    else
                    {

                        if (Valor >= vmax || Valor <= vmax / 2)
                        {

                            maydem = maydem + Convert.ToInt32(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value.ToString())+ "\r\n";
                            men = 2;
                            docCurso(strFila, men);
                        }

                    }
                }

            }

        }

        void docCurso(string strFila, int men)
        {

            if (men == 1)
            {
             Cursomen = Cursomen + Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString())+ "\r\n";
             dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[5].Value = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString());
            }
            if(men == 2 )
            {
                Cursomay = Cursomay + Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString()) + "\r\n";
               dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[4].Value = Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString());
            }
            
        }




        private void button1_Click(object sender, EventArgs e)
        {


            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf (*.pdf)|*.pdf| txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 3;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    
                    myStream.Close();
                    crearPDF(saveFileDialog1.FileName);
                    
                }
            }


            MessageBox.Show("Guardado exitosamente", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        void crearPDF(string nombre)
        {
            
            Document doc = new Document(PageSize.LETTER);
            MessageBox.Show(nombre);
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@nombre, FileMode.Create));


            doc.AddTitle("Cursos");
            doc.AddCreator("Sistema Escolar");

            doc.Open();


            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);


            doc.Add(new Paragraph("Sistema Escolar"));
            doc.Add(Chunk.NEWLINE);


            doc.Add(new Paragraph("Tabla de los cursos con el total de alumnos inscritos y horarios de preferencia "));
            doc.Add(Chunk.NEWLINE);


            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;


            PdfPCell clCurso = new PdfPCell(new Phrase("Curso", _standardFont));
            clCurso.BorderWidth = 0;
            clCurso.BorderWidthBottom = 0.75f;

            PdfPCell clAlumnos = new PdfPCell(new Phrase("Alumnos inscritos", _standardFont));
            clAlumnos.BorderWidth = 0;
            clAlumnos.BorderWidthBottom = 0.75f;

            PdfPCell clHorario = new PdfPCell(new Phrase("Horario", _standardFont));
            clHorario.BorderWidth = 0;
            clHorario.BorderWidthBottom = 0.75f;


            tblPrueba.AddCell(clCurso);
            tblPrueba.AddCell(clAlumnos);
            tblPrueba.AddCell(clHorario);

            foreach (DataGridViewRow Row in dataGridView2.Rows)
            {


                String strFila = Row.Index.ToString();
                

                if (!Row.IsNewRow)
                {

                    clCurso = new PdfPCell(new Phrase(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString()), _standardFont));
                    clCurso.BorderWidth = 0;

                    clAlumnos = new PdfPCell(new Phrase(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[1].Value.ToString()), _standardFont));
                    clAlumnos.BorderWidth = 0;

                    clHorario = new PdfPCell(new Phrase(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[2].Value.ToString()), _standardFont));
                    clHorario.BorderWidth = 0;

                    tblPrueba.AddCell(clCurso);
                    tblPrueba.AddCell(clAlumnos);
                    tblPrueba.AddCell(clHorario);
                }
            }

            doc.Add(tblPrueba);


            doc.Add(new Paragraph("---------------------------------------------------------------------------------"));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("                      Promedio General de cada curso                  "));
            doc.Add(Chunk.NEWLINE);


            PdfPTable tblPrueba2 = new PdfPTable(2);
            tblPrueba.WidthPercentage = 100;


            PdfPCell clcurso = new PdfPCell(new Phrase("Curso", _standardFont));
            clcurso.BorderWidth = 0;
            clcurso.BorderWidthBottom = 0.75f;

            PdfPCell clPromedio = new PdfPCell(new Phrase("Promedio", _standardFont));
            clPromedio.BorderWidth = 0;
            clPromedio.BorderWidthBottom = 0.75f;


            tblPrueba2.AddCell(clcurso);
            tblPrueba2.AddCell(clPromedio);

            foreach (DataGridViewRow Row2 in dataGridView2.Rows)
            {


                String strFila = Row2.Index.ToString();


                if (!Row2.IsNewRow)
                {

                    clcurso = new PdfPCell(new Phrase(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[0].Value.ToString()), _standardFont));
                    clcurso.BorderWidth = 0;

                    clPromedio = new PdfPCell(new Phrase(Convert.ToString(dataGridView2.Rows[Convert.ToInt32(strFila)].Cells[3].Value.ToString()), _standardFont));
                    clPromedio.BorderWidth = 0;


                    tblPrueba2.AddCell(clcurso);
                    tblPrueba2.AddCell(clPromedio);
                }
            }

            doc.Add(tblPrueba2);

            doc.Add(new Paragraph("---------------------------------------------------------------------------------------------------------"));
            doc.Add(Chunk.NEWLINE);


            doc.Add(new Paragraph("Cursos Demandados "));
            doc.Add(Chunk.NEWLINE);

            PdfPTable tblPrueba3 = new PdfPTable(2);
            tblPrueba.WidthPercentage = 100;


            PdfPCell clcursomy = new PdfPCell(new Phrase("Curso con mayor demanda", _standardFont));
            clcursomy.BorderWidth = 0;
            clcursomy.BorderWidthBottom = 0.75f;

            PdfPCell clcursomn = new PdfPCell(new Phrase("Curso con menor demanda", _standardFont));
            clcursomn.BorderWidth = 0;
            clcursomn.BorderWidthBottom = 0.75f;


            tblPrueba3.AddCell(clcursomy);
            tblPrueba3.AddCell(clcursomn);

        
                


              
            clcursomy = new PdfPCell(new Phrase(Cursomay + maydem , _standardFont));
            clcursomy.BorderWidth = 0;
                        
            clcursomn = new PdfPCell(new Phrase(Cursomen + mendem, _standardFont));
            clcursomn.BorderWidth = 0;
                    

            tblPrueba3.AddCell(clcursomy);
            tblPrueba3.AddCell(clcursomn);
                
            

            doc.Add(tblPrueba3);

            doc.Add(new Paragraph("-----------------------------------------------------------------------------------------------------------"));
            doc.Add(Chunk.NEWLINE);

            doc.Add(new Paragraph("Att: Area Administrativa"));
            doc.Add(Chunk.NEWLINE);




            doc.Close();
            writer.Close();
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
