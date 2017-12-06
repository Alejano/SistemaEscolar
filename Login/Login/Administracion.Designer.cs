namespace Login
{
    partial class Administracion
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
            this.Agregar = new System.Windows.Forms.MenuStrip();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buscarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.porIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porNombreToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.porEdadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Id_Adm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nivel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Agregar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Agregar
            // 
            this.Agregar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Agregar.Dock = System.Windows.Forms.DockStyle.Left;
            this.Agregar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.buscarToolStripMenuItem});
            this.Agregar.Location = new System.Drawing.Point(0, 0);
            this.Agregar.Name = "Agregar";
            this.Agregar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Agregar.Size = new System.Drawing.Size(68, 323);
            this.Agregar.TabIndex = 0;
            this.Agregar.Text = "menuStrip1";
            this.Agregar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Agregar_ItemClicked);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarNuevoToolStripMenuItem,
            this.actualizarToolStripMenuItem});
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // agregarNuevoToolStripMenuItem
            // 
            this.agregarNuevoToolStripMenuItem.Name = "agregarNuevoToolStripMenuItem";
            this.agregarNuevoToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.agregarNuevoToolStripMenuItem.Text = "Agregar Nuevo";
            this.agregarNuevoToolStripMenuItem.Click += new System.EventHandler(this.agregarNuevoToolStripMenuItem_Click);
            // 
            // actualizarToolStripMenuItem
            // 
            this.actualizarToolStripMenuItem.Name = "actualizarToolStripMenuItem";
            this.actualizarToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.actualizarToolStripMenuItem.Text = "Actualizar";
            this.actualizarToolStripMenuItem.Click += new System.EventHandler(this.actualizarToolStripMenuItem_Click);
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porIDToolStripMenuItem,
            this.porNombreToolStripMenuItem});
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.eliminarToolStripMenuItem.Text = "Eliminar";
            // 
            // porIDToolStripMenuItem
            // 
            this.porIDToolStripMenuItem.Name = "porIDToolStripMenuItem";
            this.porIDToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.porIDToolStripMenuItem.Text = "Por ID";
            this.porIDToolStripMenuItem.Click += new System.EventHandler(this.porIDToolStripMenuItem_Click);
            // 
            // porNombreToolStripMenuItem
            // 
            this.porNombreToolStripMenuItem.Name = "porNombreToolStripMenuItem";
            this.porNombreToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.porNombreToolStripMenuItem.Text = "Por Nombre";
            this.porNombreToolStripMenuItem.Click += new System.EventHandler(this.porNombreToolStripMenuItem_Click);
            // 
            // buscarToolStripMenuItem
            // 
            this.buscarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porIDToolStripMenuItem1,
            this.porNombreToolStripMenuItem1,
            this.porEdadToolStripMenuItem});
            this.buscarToolStripMenuItem.Name = "buscarToolStripMenuItem";
            this.buscarToolStripMenuItem.Size = new System.Drawing.Size(55, 19);
            this.buscarToolStripMenuItem.Text = "Buscar";
            // 
            // porIDToolStripMenuItem1
            // 
            this.porIDToolStripMenuItem1.Name = "porIDToolStripMenuItem1";
            this.porIDToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.porIDToolStripMenuItem1.Text = "Por ID";
            // 
            // porNombreToolStripMenuItem1
            // 
            this.porNombreToolStripMenuItem1.Name = "porNombreToolStripMenuItem1";
            this.porNombreToolStripMenuItem1.Size = new System.Drawing.Size(139, 22);
            this.porNombreToolStripMenuItem1.Text = "Por Nombre";
            // 
            // porEdadToolStripMenuItem
            // 
            this.porEdadToolStripMenuItem.Name = "porEdadToolStripMenuItem";
            this.porEdadToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.porEdadToolStripMenuItem.Text = "Por Edad";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(87, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 253);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Administrador";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Agregar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(361, 154);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(41, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "nivel de administracion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contraseña";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Numero de Cuenta ";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(244, 99);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 20);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(62, 99);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Datos";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(87, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 276);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actualizar";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(180, 38);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(150, 20);
            this.textBox4.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Ingrese el ID del Administrador";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 232);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Actualizar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(544, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 288);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Eliminar por ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "eliminar id";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id_Adm,
            this.Usuario,
            this.Nivel});
            this.dataGridView1.Location = new System.Drawing.Point(519, 24);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(313, 150);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(345, 36);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Buscar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox6);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(21, 86);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(262, 117);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Administrador";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Nivel";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(67, 26);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(150, 20);
            this.textBox5.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(67, 65);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(26, 20);
            this.textBox6.TabIndex = 6;
            // 
            // Id_Adm
            // 
            this.Id_Adm.HeaderText = "ID";
            this.Id_Adm.Name = "Id_Adm";
            // 
            // Usuario
            // 
            this.Usuario.HeaderText = "Admin";
            this.Usuario.Name = "Usuario";
            // 
            // Nivel
            // 
            this.Nivel.HeaderText = "Prioridad";
            this.Nivel.Name = "Nivel";
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 323);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Agregar);
            this.MainMenuStrip = this.Agregar;
            this.Name = "Administracion";
            this.Text = "Administracion";
            this.Load += new System.EventHandler(this.Administracion_Load);
            this.Agregar.ResumeLayout(false);
            this.Agregar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Agregar;
        private System.Windows.Forms.ToolStripMenuItem agregarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarNuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porNombreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem buscarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem porIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porNombreToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porEdadToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_Adm;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nivel;
    }
}