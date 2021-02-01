namespace Sistema_Mercenarios
{
    partial class CONTROL_ASISTENCIA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CONTROL_ASISTENCIA));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Estado = new System.Windows.Forms.ComboBox();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.lbl_NroRegistros = new System.Windows.Forms.Label();
            this.dgv_Control_asistencia = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ms_Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Editar = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_CambiarEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeRubrosDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pERMISOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retrasosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Control_asistencia)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(102, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 24);
            this.label1.TabIndex = 78;
            this.label1.Text = "CONTROL DE ASISTENCIA";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Busqueda);
            this.groupBox1.Controls.Add(this.btn_Actualizar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_Estado);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(402, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 74);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de búsqueda";
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.BackColor = System.Drawing.Color.White;
            this.txt_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.Location = new System.Drawing.Point(216, 33);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(187, 29);
            this.txt_Busqueda.TabIndex = 49;
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Actualizar.BackgroundImage = global::Sistema_Mercenarios.Properties.Resources.icActualizar;
            this.btn_Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Actualizar.ForeColor = System.Drawing.Color.White;
            this.btn_Actualizar.Location = new System.Drawing.Point(409, 30);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(37, 34);
            this.btn_Actualizar.TabIndex = 50;
            this.btn_Actualizar.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 51;
            this.label4.Text = "Estado";
            // 
            // cb_Estado
            // 
            this.cb_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Estado.FormattingEnabled = true;
            this.cb_Estado.Items.AddRange(new object[] {
            "Todos",
            "Valido",
            "Anulado"});
            this.cb_Estado.Location = new System.Drawing.Point(79, 33);
            this.cb_Estado.Name = "cb_Estado";
            this.cb_Estado.Size = new System.Drawing.Size(127, 28);
            this.cb_Estado.TabIndex = 52;
            this.cb_Estado.Text = "Todos";
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Titulo.Location = new System.Drawing.Point(100, 46);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(201, 36);
            this.lbl_Titulo.TabIndex = 76;
            this.lbl_Titulo.Text = "LISTADO DE";
            // 
            // lbl_NroRegistros
            // 
            this.lbl_NroRegistros.AutoSize = true;
            this.lbl_NroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NroRegistros.ForeColor = System.Drawing.Color.Black;
            this.lbl_NroRegistros.Location = new System.Drawing.Point(604, 519);
            this.lbl_NroRegistros.Name = "lbl_NroRegistros";
            this.lbl_NroRegistros.Size = new System.Drawing.Size(185, 20);
            this.lbl_NroRegistros.TabIndex = 74;
            this.lbl_NroRegistros.Text = "00 registros encontrados";
            this.lbl_NroRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Control_asistencia
            // 
            this.dgv_Control_asistencia.AllowUserToAddRows = false;
            this.dgv_Control_asistencia.AllowUserToDeleteRows = false;
            this.dgv_Control_asistencia.AllowUserToOrderColumns = true;
            this.dgv_Control_asistencia.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Control_asistencia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Control_asistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Control_asistencia.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Control_asistencia.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Control_asistencia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Control_asistencia.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Control_asistencia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Control_asistencia.ColumnHeadersHeight = 40;
            this.dgv_Control_asistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Control_asistencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Control_asistencia.GridColor = System.Drawing.Color.Gray;
            this.dgv_Control_asistencia.Location = new System.Drawing.Point(20, 124);
            this.dgv_Control_asistencia.MultiSelect = false;
            this.dgv_Control_asistencia.Name = "dgv_Control_asistencia";
            this.dgv_Control_asistencia.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Control_asistencia.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Control_asistencia.RowHeadersVisible = false;
            this.dgv_Control_asistencia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Control_asistencia.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Control_asistencia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Control_asistencia.Size = new System.Drawing.Size(840, 375);
            this.dgv_Control_asistencia.TabIndex = 73;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_Nuevo,
            this.ms_Editar,
            this.ms_Eliminar,
            this.ms_CambiarEstado,
            this.informesToolStripMenuItem,
            this.pERMISOSToolStripMenuItem,
            this.faltaToolStripMenuItem,
            this.retrasosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(871, 28);
            this.menuStrip1.TabIndex = 71;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ms_Nuevo
            // 
            this.ms_Nuevo.ForeColor = System.Drawing.Color.Black;
            this.ms_Nuevo.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_add_70px_510874;
            this.ms_Nuevo.Name = "ms_Nuevo";
            this.ms_Nuevo.Size = new System.Drawing.Size(88, 24);
            this.ms_Nuevo.Text = "Nuevo";
            this.ms_Nuevo.Click += new System.EventHandler(this.ms_Nuevo_Click);
            // 
            // ms_Editar
            // 
            this.ms_Editar.ForeColor = System.Drawing.Color.Black;
            this.ms_Editar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_081_Pen_183209;
            this.ms_Editar.Name = "ms_Editar";
            this.ms_Editar.Size = new System.Drawing.Size(85, 24);
            this.ms_Editar.Text = "Editar";
            // 
            // ms_Eliminar
            // 
            this.ms_Eliminar.ForeColor = System.Drawing.Color.Black;
            this.ms_Eliminar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_icons_delete_1564502;
            this.ms_Eliminar.Name = "ms_Eliminar";
            this.ms_Eliminar.Size = new System.Drawing.Size(102, 24);
            this.ms_Eliminar.Text = "Eliminar";
            // 
            // ms_CambiarEstado
            // 
            this.ms_CambiarEstado.ForeColor = System.Drawing.Color.Black;
            this.ms_CambiarEstado.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_UI_Basic_GLYPH_48_4733376;
            this.ms_CambiarEstado.Name = "ms_CambiarEstado";
            this.ms_CambiarEstado.Size = new System.Drawing.Size(159, 24);
            this.ms_CambiarEstado.Text = "Cambiar estado";
            this.ms_CambiarEstado.Click += new System.EventHandler(this.ms_CambiarEstado_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeRubrosDeClienteToolStripMenuItem});
            this.informesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.informesToolStripMenuItem.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_print_1608799;
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.informesToolStripMenuItem.Text = "Informes";
            // 
            // listadoDeRubrosDeClienteToolStripMenuItem
            // 
            this.listadoDeRubrosDeClienteToolStripMenuItem.Name = "listadoDeRubrosDeClienteToolStripMenuItem";
            this.listadoDeRubrosDeClienteToolStripMenuItem.Size = new System.Drawing.Size(212, 24);
            this.listadoDeRubrosDeClienteToolStripMenuItem.Text = "Listado de cargos";
            // 
            // pERMISOSToolStripMenuItem
            // 
            this.pERMISOSToolStripMenuItem.Name = "pERMISOSToolStripMenuItem";
            this.pERMISOSToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.pERMISOSToolStripMenuItem.Text = "Permisos";
            this.pERMISOSToolStripMenuItem.Click += new System.EventHandler(this.pERMISOSToolStripMenuItem_Click);
            // 
            // faltaToolStripMenuItem
            // 
            this.faltaToolStripMenuItem.Name = "faltaToolStripMenuItem";
            this.faltaToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.faltaToolStripMenuItem.Text = "Falta";
            this.faltaToolStripMenuItem.Click += new System.EventHandler(this.faltaToolStripMenuItem_Click);
            // 
            // retrasosToolStripMenuItem
            // 
            this.retrasosToolStripMenuItem.Name = "retrasosToolStripMenuItem";
            this.retrasosToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.retrasosToolStripMenuItem.Text = "Retrasos";
            this.retrasosToolStripMenuItem.Click += new System.EventHandler(this.retrasosToolStripMenuItem_Click);
            // 
            // btn_seleccionar
            // 
            this.btn_seleccionar.BackColor = System.Drawing.Color.White;
            this.btn_seleccionar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_seleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seleccionar.ForeColor = System.Drawing.Color.Black;
            this.btn_seleccionar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_Ok_984756__1_;
            this.btn_seleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_seleccionar.Location = new System.Drawing.Point(20, 519);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(118, 34);
            this.btn_seleccionar.TabIndex = 79;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_seleccionar.UseVisualStyleBackColor = false;
            this.btn_seleccionar.Visible = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Gray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(831, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 72;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_First_place_first_position_medal_position_medal_prize_47632271;
            this.pictureBox1.Location = new System.Drawing.Point(20, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // CONTROL_ASISTENCIA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 576);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_Titulo);
            this.Controls.Add(this.lbl_NroRegistros);
            this.Controls.Add(this.dgv_Control_asistencia);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CONTROL_ASISTENCIA";
            this.Text = "CONTROL_ASISTENCIA";
            this.Load += new System.EventHandler(this.CONTROL_ASISTENCIA_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CONTROL_ASISTENCIA_MouseMove);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Control_asistencia)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_seleccionar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.ToolStripMenuItem listadoDeRubrosDeClienteToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ms_CambiarEstado;
        public System.Windows.Forms.ToolStripMenuItem ms_Eliminar;
        public System.Windows.Forms.ToolStripMenuItem ms_Editar;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ToolStripMenuItem ms_Nuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.Label lbl_Titulo;
        public System.Windows.Forms.Label lbl_NroRegistros;
        public System.Windows.Forms.DataGridView dgv_Control_asistencia;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pERMISOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faltaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retrasosToolStripMenuItem;
    }
}