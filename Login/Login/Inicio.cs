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

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar_Alumno A = new Actualizar_Alumno();
            A.Show();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Eliminar_Profesor elp = new Eliminar_Profesor();
            elp.Show();
        }
        
        //Para la hora actual

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tiempoHoy = DateTime.Now;
            textBox1.Text = tiempoHoy.ToString();
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Actualizar_Profesor acp = new Actualizar_Profesor();
            acp.Show();
        }
    }
        
}
