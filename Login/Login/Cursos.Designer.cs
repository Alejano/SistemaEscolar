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
            this.tbFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbHorario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOpCRUD = new System.Windows.Forms.GroupBox();
            this.gpActualizar = new System.Windows.Forms.GroupBox();
            this.rbActualizar = new System.Windows.Forms.RadioButton();
            this.rbEliminar = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.gbOpCRUD.SuspendLayout();
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
            this.tbFecha,
            this.tbHorario});
            this.dataGridView1.Location = new System.Drawing.Point(469, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(244, 183);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tbFecha
            // 
            this.tbFecha.HeaderText = "Fechas";
            this.tbFecha.Name = "tbFecha";
            this.tbFecha.ReadOnly = true;
            // 
            // tbHorario
            // 
            this.tbHorario.HeaderText = "Horario";
            this.tbHorario.Name = "tbHorario";
            this.tbHorario.ReadOnly = true;
            // 
            // gbOpCRUD
            // 
            this.gbOpCRUD.Controls.Add(this.rbEliminar);
            this.gbOpCRUD.Controls.Add(this.rbActualizar);
            this.gbOpCRUD.Controls.Add(this.gpActualizar);
            this.gbOpCRUD.Location = new System.Drawing.Point(23, 71);
            this.gbOpCRUD.Name = "gbOpCRUD";
            this.gbOpCRUD.Size = new System.Drawing.Size(366, 246);
            this.gbOpCRUD.TabIndex = 3;
            this.gbOpCRUD.TabStop = false;
            // 
            // gpActualizar
            // 
            this.gpActualizar.Location = new System.Drawing.Point(6, 53);
            this.gpActualizar.Name = "gpActualizar";
            this.gpActualizar.Size = new System.Drawing.Size(354, 187);
            this.gpActualizar.TabIndex = 0;
            this.gpActualizar.TabStop = false;
            // 
            // rbActualizar
            // 
            this.rbActualizar.AutoSize = true;
            this.rbActualizar.Location = new System.Drawing.Point(42, 20);
            this.rbActualizar.Name = "rbActualizar";
            this.rbActualizar.Size = new System.Drawing.Size(71, 17);
            this.rbActualizar.TabIndex = 1;
            this.rbActualizar.TabStop = true;
            this.rbActualizar.Text = "Actualizar";
            this.rbActualizar.UseVisualStyleBackColor = true;
            // 
            // rbEliminar
            // 
            this.rbEliminar.AutoSize = true;
            this.rbEliminar.Location = new System.Drawing.Point(200, 20);
            this.rbEliminar.Name = "rbEliminar";
            this.rbEliminar.Size = new System.Drawing.Size(61, 17);
            this.rbEliminar.TabIndex = 2;
            this.rbEliminar.TabStop = true;
            this.rbEliminar.Text = "Eliminar";
            this.rbEliminar.UseVisualStyleBackColor = true;
            // 
            // Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 339);
            this.Controls.Add(this.gbOpCRUD);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCursos);
            this.Name = "Cursos";
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.Cursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.gbOpCRUD.ResumeLayout(false);
            this.gbOpCRUD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn tbHorario;
        private System.Windows.Forms.GroupBox gbOpCRUD;
        private System.Windows.Forms.RadioButton rbEliminar;
        private System.Windows.Forms.RadioButton rbActualizar;
        private System.Windows.Forms.GroupBox gpActualizar;
    }
}