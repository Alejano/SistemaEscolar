using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace Login
{
    public partial class PDF_Alumnos : Form
    {
        string DireccionPDF = "";
        public PDF_Alumnos()
        {
            InitializeComponent();
        }

        private void PDF_Alumnos_Load(object sender, EventArgs e)
        {
            DireccionPDF= textBox1.Text;
            
            
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        void crearPDF(string nombre)
        {
         
            Document doc = new Document(PageSize.LETTER);
            MessageBox.Show(nombre);
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@nombre, FileMode.Create));

        
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("soy jano");

            doc.Open();

         
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

       
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

           
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

          
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

           
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

           
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "pdf (*.pdf)|*.pdf| txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                  
                    myStream.Close();
                }
            }

            crearPDF(saveFileDialog1.FileName);
        }
    }
}
