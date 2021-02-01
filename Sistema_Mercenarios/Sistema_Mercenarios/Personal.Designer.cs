namespace Sistema_Mercenarios
{
    partial class Personal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ms_Nuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Editar = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_Eliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_CambiarEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.informesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeRubrosDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_NroRegistros = new System.Windows.Forms.Label();
            this.dgv_personal = new System.Windows.Forms.DataGridView();
            this.cb_Estado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.txt_Busqueda = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_tipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_seleccionar = new System.Windows.Forms.Button();
            this.btn_detalle_ruta = new System.Windows.Forms.Button();
            this.BTN_SELECCIONAR_PERMISOS = new System.Windows.Forms.Button();
            this.BTN_MEMORANDUM = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gray;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ms_Nuevo,
            this.ms_Editar,
            this.ms_Eliminar,
            this.ms_CambiarEstado,
            this.informesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseMove);
            // 
            // ms_Nuevo
            // 
            this.ms_Nuevo.ForeColor = System.Drawing.Color.Black;
            this.ms_Nuevo.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_add_70px_510874;
            this.ms_Nuevo.Name = "ms_Nuevo";
            this.ms_Nuevo.Size = new System.Drawing.Size(84, 24);
            this.ms_Nuevo.Text = "Nuevo";
            this.ms_Nuevo.Visible = false;
            this.ms_Nuevo.Click += new System.EventHandler(this.ms_Nuevo_Click);
            // 
            // ms_Editar
            // 
            this.ms_Editar.ForeColor = System.Drawing.Color.Black;
            this.ms_Editar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_081_Pen_183209;
            this.ms_Editar.Name = "ms_Editar";
            this.ms_Editar.Size = new System.Drawing.Size(81, 24);
            this.ms_Editar.Text = "Editar";
            this.ms_Editar.Visible = false;
            this.ms_Editar.Click += new System.EventHandler(this.ms_Editar_Click);
            // 
            // ms_Eliminar
            // 
            this.ms_Eliminar.ForeColor = System.Drawing.Color.Black;
            this.ms_Eliminar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_icons_delete_1564502;
            this.ms_Eliminar.Name = "ms_Eliminar";
            this.ms_Eliminar.Size = new System.Drawing.Size(98, 24);
            this.ms_Eliminar.Text = "Eliminar";
            this.ms_Eliminar.Visible = false;
            this.ms_Eliminar.Click += new System.EventHandler(this.ms_Eliminar_Click);
            // 
            // ms_CambiarEstado
            // 
            this.ms_CambiarEstado.ForeColor = System.Drawing.Color.Black;
            this.ms_CambiarEstado.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_UI_Basic_GLYPH_48_4733376;
            this.ms_CambiarEstado.Name = "ms_CambiarEstado";
            this.ms_CambiarEstado.Size = new System.Drawing.Size(155, 24);
            this.ms_CambiarEstado.Text = "Cambiar estado";
            this.ms_CambiarEstado.Visible = false;
            this.ms_CambiarEstado.Click += new System.EventHandler(this.ms_CambiarEstado_Click);
            // 
            // informesToolStripMenuItem
            // 
            this.informesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeRubrosDeClienteToolStripMenuItem});
            this.informesToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.informesToolStripMenuItem.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_print_1608799;
            this.informesToolStripMenuItem.Name = "informesToolStripMenuItem";
            this.informesToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.informesToolStripMenuItem.Text = "Informes";
            this.informesToolStripMenuItem.Visible = false;
            // 
            // listadoDeRubrosDeClienteToolStripMenuItem
            // 
            this.listadoDeRubrosDeClienteToolStripMenuItem.Name = "listadoDeRubrosDeClienteToolStripMenuItem";
            this.listadoDeRubrosDeClienteToolStripMenuItem.Size = new System.Drawing.Size(225, 24);
            this.listadoDeRubrosDeClienteToolStripMenuItem.Text = "Listado de personal";
            this.listadoDeRubrosDeClienteToolStripMenuItem.Click += new System.EventHandler(this.listadoDeRubrosDeClienteToolStripMenuItem_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Gray;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(780, 4);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_icon_person_stalker_211873;
            this.pictureBox2.Location = new System.Drawing.Point(21, 63);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(76, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 83;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(101, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 36);
            this.label5.TabIndex = 82;
            this.label5.Text = "LISTADO DE";
            // 
            // lbl_NroRegistros
            // 
            this.lbl_NroRegistros.AutoSize = true;
            this.lbl_NroRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NroRegistros.ForeColor = System.Drawing.Color.Black;
            this.lbl_NroRegistros.Location = new System.Drawing.Point(579, 495);
            this.lbl_NroRegistros.Name = "lbl_NroRegistros";
            this.lbl_NroRegistros.Size = new System.Drawing.Size(216, 24);
            this.lbl_NroRegistros.TabIndex = 80;
            this.lbl_NroRegistros.Text = "00 registros encontrados";
            this.lbl_NroRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_personal
            // 
            this.dgv_personal.AllowUserToAddRows = false;
            this.dgv_personal.AllowUserToDeleteRows = false;
            this.dgv_personal.AllowUserToOrderColumns = true;
            this.dgv_personal.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_personal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_personal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_personal.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_personal.BackgroundColor = System.Drawing.Color.White;
            this.dgv_personal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_personal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(41)))), ((int)(((byte)(68)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_personal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_personal.ColumnHeadersHeight = 40;
            this.dgv_personal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_personal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_personal.GridColor = System.Drawing.Color.Gray;
            this.dgv_personal.Location = new System.Drawing.Point(20, 142);
            this.dgv_personal.MultiSelect = false;
            this.dgv_personal.Name = "dgv_personal";
            this.dgv_personal.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_personal.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_personal.RowHeadersVisible = false;
            this.dgv_personal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(93)))), ((int)(((byte)(142)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_personal.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_personal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_personal.Size = new System.Drawing.Size(769, 348);
            this.dgv_personal.TabIndex = 79;
            this.dgv_personal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_personal_CellContentClick);
            this.dgv_personal.DoubleClick += new System.EventHandler(this.dgv_personal_DoubleClick);
            // 
            // cb_Estado
            // 
            this.cb_Estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Estado.FormattingEnabled = true;
            this.cb_Estado.Items.AddRange(new object[] {
            "Todos",
            "Valido",
            "Anulado"});
            this.cb_Estado.Location = new System.Drawing.Point(77, 55);
            this.cb_Estado.Name = "cb_Estado";
            this.cb_Estado.Size = new System.Drawing.Size(114, 28);
            this.cb_Estado.TabIndex = 78;
            this.cb_Estado.Text = "Todos";
            this.cb_Estado.SelectedIndexChanged += new System.EventHandler(this.cb_Estado_SelectedIndexChanged);
            this.cb_Estado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_Estado_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(10, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 77;
            this.label4.Text = "Estado";
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Actualizar.BackgroundImage = global::Sistema_Mercenarios.Properties.Resources.icActualizar;
            this.btn_Actualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Actualizar.ForeColor = System.Drawing.Color.White;
            this.btn_Actualizar.Location = new System.Drawing.Point(396, 52);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(37, 34);
            this.btn_Actualizar.TabIndex = 76;
            this.btn_Actualizar.UseVisualStyleBackColor = false;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // txt_Busqueda
            // 
            this.txt_Busqueda.BackColor = System.Drawing.Color.White;
            this.txt_Busqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Busqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Busqueda.Location = new System.Drawing.Point(200, 55);
            this.txt_Busqueda.Name = "txt_Busqueda";
            this.txt_Busqueda.Size = new System.Drawing.Size(191, 29);
            this.txt_Busqueda.TabIndex = 75;
            this.txt_Busqueda.TextChanged += new System.EventHandler(this.txt_Busqueda_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_tipo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_Busqueda);
            this.groupBox1.Controls.Add(this.btn_Actualizar);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb_Estado);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(350, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(439, 95);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de búsqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cb_tipo
            // 
            this.cb_tipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tipo.FormattingEnabled = true;
            this.cb_tipo.Items.AddRange(new object[] {
            "Nombre(s)",
            "Ap_paterno",
            "Ap_materno",
            "Nro_documento"});
            this.cb_tipo.Location = new System.Drawing.Point(244, 21);
            this.cb_tipo.Name = "cb_tipo";
            this.cb_tipo.Size = new System.Drawing.Size(147, 28);
            this.cb_tipo.TabIndex = 64;
            this.cb_tipo.Text = "Nombre(s)";
            this.cb_tipo.SelectedIndexChanged += new System.EventHandler(this.cb_tipo_SelectedIndexChanged);
            this.cb_tipo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cb_tipo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(147, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Buscar por";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(100, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 36);
            this.label3.TabIndex = 85;
            this.label3.Text = "PERSONAL";
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
            this.btn_seleccionar.Location = new System.Drawing.Point(21, 470);
            this.btn_seleccionar.Name = "btn_seleccionar";
            this.btn_seleccionar.Size = new System.Drawing.Size(118, 34);
            this.btn_seleccionar.TabIndex = 86;
            this.btn_seleccionar.Text = "Seleccionar";
            this.btn_seleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_seleccionar.UseVisualStyleBackColor = false;
            this.btn_seleccionar.Visible = false;
            this.btn_seleccionar.Click += new System.EventHandler(this.btn_seleccionar_Click);
            // 
            // btn_detalle_ruta
            // 
            this.btn_detalle_ruta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_detalle_ruta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_detalle_ruta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_detalle_ruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_detalle_ruta.ForeColor = System.Drawing.Color.Black;
            this.btn_detalle_ruta.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_Ok_984756__1_;
            this.btn_detalle_ruta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_detalle_ruta.Location = new System.Drawing.Point(145, 496);
            this.btn_detalle_ruta.Name = "btn_detalle_ruta";
            this.btn_detalle_ruta.Size = new System.Drawing.Size(118, 34);
            this.btn_detalle_ruta.TabIndex = 88;
            this.btn_detalle_ruta.Text = "Seleccionar";
            this.btn_detalle_ruta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_detalle_ruta.UseVisualStyleBackColor = false;
            this.btn_detalle_ruta.Visible = false;
            this.btn_detalle_ruta.Click += new System.EventHandler(this.button2_Click);
            // 
            // BTN_SELECCIONAR_PERMISOS
            // 
            this.BTN_SELECCIONAR_PERMISOS.BackColor = System.Drawing.Color.White;
            this.BTN_SELECCIONAR_PERMISOS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_SELECCIONAR_PERMISOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SELECCIONAR_PERMISOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SELECCIONAR_PERMISOS.ForeColor = System.Drawing.Color.Black;
            this.BTN_SELECCIONAR_PERMISOS.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_Ok_984756__1_;
            this.BTN_SELECCIONAR_PERMISOS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_SELECCIONAR_PERMISOS.Location = new System.Drawing.Point(20, 496);
            this.BTN_SELECCIONAR_PERMISOS.Name = "BTN_SELECCIONAR_PERMISOS";
            this.BTN_SELECCIONAR_PERMISOS.Size = new System.Drawing.Size(118, 34);
            this.BTN_SELECCIONAR_PERMISOS.TabIndex = 89;
            this.BTN_SELECCIONAR_PERMISOS.Text = "Seleccionar";
            this.BTN_SELECCIONAR_PERMISOS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_SELECCIONAR_PERMISOS.UseVisualStyleBackColor = false;
            this.BTN_SELECCIONAR_PERMISOS.Visible = false;
            this.BTN_SELECCIONAR_PERMISOS.Click += new System.EventHandler(this.BTN_SELECCIONAR_PERMISOS_Click);
            // 
            // BTN_MEMORANDUM
            // 
            this.BTN_MEMORANDUM.BackColor = System.Drawing.Color.White;
            this.BTN_MEMORANDUM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BTN_MEMORANDUM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MEMORANDUM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_MEMORANDUM.ForeColor = System.Drawing.Color.Black;
            this.BTN_MEMORANDUM.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_Ok_984756__1_;
            this.BTN_MEMORANDUM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_MEMORANDUM.Location = new System.Drawing.Point(78, 496);
            this.BTN_MEMORANDUM.Name = "BTN_MEMORANDUM";
            this.BTN_MEMORANDUM.Size = new System.Drawing.Size(118, 34);
            this.BTN_MEMORANDUM.TabIndex = 90;
            this.BTN_MEMORANDUM.Text = "Seleccionar";
            this.BTN_MEMORANDUM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BTN_MEMORANDUM.UseVisualStyleBackColor = false;
            this.BTN_MEMORANDUM.Visible = false;
            this.BTN_MEMORANDUM.Click += new System.EventHandler(this.BTN_MEMORANDUM_Click);
            // 
            // Personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 533);
            this.Controls.Add(this.dgv_personal);
            this.Controls.Add(this.btn_detalle_ruta);
            this.Controls.Add(this.BTN_MEMORANDUM);
            this.Controls.Add(this.BTN_SELECCIONAR_PERMISOS);
            this.Controls.Add(this.btn_seleccionar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_NroRegistros);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Personal";
            this.Text = "Personal";
            this.Load += new System.EventHandler(this.Personal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_personal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem ms_Nuevo;
        public System.Windows.Forms.ToolStripMenuItem ms_Editar;
        public System.Windows.Forms.ToolStripMenuItem ms_Eliminar;
        public System.Windows.Forms.ToolStripMenuItem ms_CambiarEstado;
        public System.Windows.Forms.ToolStripMenuItem informesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem listadoDeRubrosDeClienteToolStripMenuItem;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_NroRegistros;
        public System.Windows.Forms.DataGridView dgv_personal;
        private System.Windows.Forms.ComboBox cb_Estado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.TextBox txt_Busqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_tipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btn_seleccionar;
        public System.Windows.Forms.Button btn_detalle_ruta;
        public System.Windows.Forms.Button BTN_SELECCIONAR_PERMISOS;
        public System.Windows.Forms.Button BTN_MEMORANDUM;
    }
}