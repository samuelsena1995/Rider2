namespace Sistema_Mercenarios
{
    partial class PERMISO_DATOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PERMISO_DATOS));
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nombre_cargo = new System.Windows.Forms.TextBox();
            this.datetime_f_registro = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_Titulo = new System.Windows.Forms.Label();
            this.txt_Descripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.gb_Datos = new System.Windows.Forms.GroupBox();
            this.lblCodigo_Autorizado = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pb_Img = new System.Windows.Forms.PictureBox();
            this.panelBarraTitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.pb_img2 = new System.Windows.Forms.PictureBox();
            this.gb_Datos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).BeginInit();
            this.panelBarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img2)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(15, 367);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 20);
            this.label13.TabIndex = 114;
            this.label13.Text = "* Campos obligatorios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(14, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "AUTORIZADO POR *";
            // 
            // txt_nombre_cargo
            // 
            this.txt_nombre_cargo.BackColor = System.Drawing.Color.White;
            this.txt_nombre_cargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nombre_cargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombre_cargo.Location = new System.Drawing.Point(14, 124);
            this.txt_nombre_cargo.Name = "txt_nombre_cargo";
            this.txt_nombre_cargo.Size = new System.Drawing.Size(321, 26);
            this.txt_nombre_cargo.TabIndex = 3;
            // 
            // datetime_f_registro
            // 
            this.datetime_f_registro.Enabled = false;
            this.datetime_f_registro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetime_f_registro.Location = new System.Drawing.Point(259, 61);
            this.datetime_f_registro.Name = "datetime_f_registro";
            this.datetime_f_registro.Size = new System.Drawing.Size(139, 27);
            this.datetime_f_registro.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "F. Registro*";
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Gray;
            this.btn_Cancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_Cancelar.Location = new System.Drawing.Point(354, 370);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(95, 36);
            this.btn_Cancelar.TabIndex = 110;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Titulo
            // 
            this.lbl_Titulo.AutoSize = true;
            this.lbl_Titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Titulo.ForeColor = System.Drawing.Color.DimGray;
            this.lbl_Titulo.Location = new System.Drawing.Point(72, 44);
            this.lbl_Titulo.Name = "lbl_Titulo";
            this.lbl_Titulo.Size = new System.Drawing.Size(381, 39);
            this.lbl_Titulo.TabIndex = 112;
            this.lbl_Titulo.Text = "PERMISO REGISTRO";
            // 
            // txt_Descripcion
            // 
            this.txt_Descripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Descripcion.Location = new System.Drawing.Point(14, 187);
            this.txt_Descripcion.Multiline = true;
            this.txt_Descripcion.Name = "txt_Descripcion";
            this.txt_Descripcion.Size = new System.Drawing.Size(515, 61);
            this.txt_Descripcion.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(14, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Descripción";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(14, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Código de Control Asistencia*";
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.BackColor = System.Drawing.Color.White;
            this.txt_Codigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Codigo.Enabled = false;
            this.txt_Codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Codigo.Location = new System.Drawing.Point(14, 61);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(91, 26);
            this.txt_Codigo.TabIndex = 0;
            // 
            // gb_Datos
            // 
            this.gb_Datos.BackColor = System.Drawing.SystemColors.Control;
            this.gb_Datos.Controls.Add(this.lblCodigo_Autorizado);
            this.gb_Datos.Controls.Add(this.button1);
            this.gb_Datos.Controls.Add(this.label3);
            this.gb_Datos.Controls.Add(this.txt_nombre_cargo);
            this.gb_Datos.Controls.Add(this.datetime_f_registro);
            this.gb_Datos.Controls.Add(this.label2);
            this.gb_Datos.Controls.Add(this.txt_Descripcion);
            this.gb_Datos.Controls.Add(this.pb_Img);
            this.gb_Datos.Controls.Add(this.label5);
            this.gb_Datos.Controls.Add(this.label4);
            this.gb_Datos.Controls.Add(this.txt_Codigo);
            this.gb_Datos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_Datos.ForeColor = System.Drawing.Color.DarkRed;
            this.gb_Datos.Location = new System.Drawing.Point(13, 95);
            this.gb_Datos.Name = "gb_Datos";
            this.gb_Datos.Size = new System.Drawing.Size(545, 267);
            this.gb_Datos.TabIndex = 108;
            this.gb_Datos.TabStop = false;
            this.gb_Datos.Text = "Datos del cargo";
            // 
            // lblCodigo_Autorizado
            // 
            this.lblCodigo_Autorizado.AutoSize = true;
            this.lblCodigo_Autorizado.Location = new System.Drawing.Point(176, 157);
            this.lblCodigo_Autorizado.Name = "lblCodigo_Autorizado";
            this.lblCodigo_Autorizado.Size = new System.Drawing.Size(53, 20);
            this.lblCodigo_Autorizado.TabIndex = 37;
            this.lblCodigo_Autorizado.Text = "label1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_gnome_searchtool_39022;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(355, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 26);
            this.button1.TabIndex = 36;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb_Img
            // 
            this.pb_Img.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_icon_45_note_list_314884__1_;
            this.pb_Img.Location = new System.Drawing.Point(464, 26);
            this.pb_Img.Name = "pb_Img";
            this.pb_Img.Size = new System.Drawing.Size(75, 62);
            this.pb_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Img.TabIndex = 29;
            this.pb_Img.TabStop = false;
            // 
            // panelBarraTitulo
            // 
            this.panelBarraTitulo.BackColor = System.Drawing.Color.DarkRed;
            this.panelBarraTitulo.Controls.Add(this.btnCerrar);
            this.panelBarraTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarraTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelBarraTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.panelBarraTitulo.Name = "panelBarraTitulo";
            this.panelBarraTitulo.Size = new System.Drawing.Size(574, 32);
            this.panelBarraTitulo.TabIndex = 111;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(546, 7);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(20, 20);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Image = global::Sistema_Mercenarios.Properties.Resources.iconfinder_save_16088231;
            this.btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Guardar.Location = new System.Drawing.Point(455, 370);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(103, 36);
            this.btn_Guardar.TabIndex = 109;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // pb_img2
            // 
            this.pb_img2.Image = global::Sistema_Mercenarios.Properties.Resources.ic_datos;
            this.pb_img2.Location = new System.Drawing.Point(12, 37);
            this.pb_img2.Name = "pb_img2";
            this.pb_img2.Size = new System.Drawing.Size(55, 50);
            this.pb_img2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_img2.TabIndex = 113;
            this.pb_img2.TabStop = false;
            // 
            // PERMISO_DATOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 428);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.pb_img2);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.lbl_Titulo);
            this.Controls.Add(this.gb_Datos);
            this.Controls.Add(this.panelBarraTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PERMISO_DATOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PERMISO_DATOS";
            this.Load += new System.EventHandler(this.PERMISO_DATOS_Load);
            this.gb_Datos.ResumeLayout(false);
            this.gb_Datos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Img)).EndInit();
            this.panelBarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_img2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.PictureBox pb_img2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txt_nombre_cargo;
        public System.Windows.Forms.DateTimePicker datetime_f_registro;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Titulo;
        public System.Windows.Forms.TextBox txt_Descripcion;
        private System.Windows.Forms.PictureBox pb_Img;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.PictureBox btnCerrar;
        public System.Windows.Forms.GroupBox gb_Datos;
        private System.Windows.Forms.Panel panelBarraTitulo;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label lblCodigo_Autorizado;
    }
}