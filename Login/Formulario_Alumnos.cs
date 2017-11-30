using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Login
{
    public partial class Formulario_Alumnos : Form
    {
        public static String Diferenciador_A = ""; 
        public Formulario_Alumnos()
        {
            InitializeComponent();
        }

        private void Formulario_Alumnos_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Diferenciador_A = "Interno";
            Formulario_Int_Ext fr2 = new Formulario_Int_Ext();
            fr2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diferenciador_A = "Externo";
            Formulario_Int_Ext fr2 = new Formulario_Int_Ext();
            fr2.Show();
        }
    }
}
