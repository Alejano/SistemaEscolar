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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Guardar_Alumno ga = new Guardar_Alumno();
            ga.Show();

        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrar_Alumno ba = new Borrar_Alumno();
            ba.Show();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_P tp = new Tipo_P();
            tp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursos curso = new Cursos();
            curso.Show();
        }
    }
}
