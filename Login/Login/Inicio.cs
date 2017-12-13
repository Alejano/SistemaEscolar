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
            Close();

        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Borrar_Alumno ba = new Borrar_Alumno();
            ba.Show();
            Close();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tipo_P tp = new Tipo_P();
            tp.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Cursos curso = new Cursos();
            curso.Show();
            Close();
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Actualizar_Alumnos A = new Actualizar_Alumnos();
            A.Show();
            Close();
        }

        private void profesoresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Eliminar_Profesor elp = new Eliminar_Profesor();
            elp.Show();
            Close();
        }
        
        //Para la hora actual

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime tiempoHoy = DateTime.Now;
            label1.Text = tiempoHoy.ToString();
           
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Actualizar_Profesor acp = new Actualizar_Profesor();
            acp.Show();
            Close();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuscarProfesor buscarprof = new BuscarProfesor();
            buscarprof.Show();
            Close();
        }

        private void leerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            BuscarAlumno buscaralum = new BuscarAlumno();
            buscaralum.Show();
            Close();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            label3.Text = IniciarSesion.usu;
            button1.Hide();
            if (Administracion.adm == 1) { button1.Show(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos cr = new Cursos();
            cr.Show();
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Administracion.adm = 0;
            Administracion admin = new Administracion();
            admin.Show();
            Close();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IniciarSesion ini = new IniciarSesion();
            ini.Show();
            Close();
        }
    }
        
}
