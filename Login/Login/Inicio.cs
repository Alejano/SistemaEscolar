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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Profesores pr = new Profesores();
            pr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formulario_Alumnos fa = new Formulario_Alumnos();
            fa.Show();
        }
    }
}
