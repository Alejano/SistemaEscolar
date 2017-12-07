namespace Login
{
    partial class Cursos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCursos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Fechas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Miércoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sabádo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCursos
            // 
            this.cbCursos.FormattingEnabled = true;
            this.cbCursos.Location = new System.Drawing.Point(130, 44);
            this.cbCursos.Name = "cbCursos";
            this.cbCursos.Size = new System.Drawing.Size(111, 21);
            this.cbCursos.TabIndex = 0;
            this.cbCursos.SelectedIndexChanged += new System.EventHandler(this.cbCursos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el Curso:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fechas,
            this.Nombre,
            this.Lunes,
            this.Martes,
            this.Miércoles,
            this.Jueves,
            this.Viernes,
            this.Sabádo});
            this.dataGridView1.Location = new System.Drawing.Point(23, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(843, 202);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Fechas
            // 
            this.Fechas.HeaderText = "Fechas";
            this.Fechas.Name = "Fechas";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Lunes
            // 
            this.Lunes.HeaderText = "Lunes";
            this.Lunes.Name = "Lunes";
            // 
            // Martes
            // 
            this.Martes.HeaderText = "Martes";
            this.Martes.Name = "Martes";
            // 
            // Miércoles
            // 
            this.Miércoles.HeaderText = "Miércoles";
            this.Miércoles.Name = "Miércoles";
            // 
            // Jueves
            // 
            this.Jueves.HeaderText = "Jueves";
            this.Jueves.Name = "Jueves";
            // 
            // Viernes
            // 
            this.Viernes.HeaderText = "Viernes";
            this.Viernes.Name = "Viernes";
            // 
            // Sabádo
            // 
            this.Sabádo.HeaderText = "Sabádo";
            this.Sabádo.Name = "Sabádo";
            // 
            // Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 339);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCursos);
            this.Name = "Cursos";
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.Cursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fechas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lunes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Martes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Miércoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Jueves;
        private System.Windows.Forms.DataGridViewTextBoxColumn Viernes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sabádo;
    }
}