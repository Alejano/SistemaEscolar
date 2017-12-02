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
        
        public Formulario_Alumnos()
        {
            InitializeComponent();
        }

        private void Formulario_Alumnos_Load(object sender, EventArgs e)
        {

        }

       
       
        private void button6_Click(object sender, EventArgs e)
        {
            Guardar_Alumno ga = new Guardar_Alumno();
            ga.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Borrar_Alumno ba = new Borrar_Alumno();
            ba.Show();

        }
    }
}
