using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Sistema_Mercenarios
{
    public partial class Menu_Principal : Form
    {
        public static Menu_Principal frm;
        public Menu_Principal()
        {
            InitializeComponent();
            frm = this;
            this.CenterToScreen();
            this.Refresh();
           PRIVILEGIOS_MIO();
            //Privilegios();
        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        #region Funcionalidades del formulario
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panel_Contenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            //lbl_Usuario.Text = "Usuario: " + Program.Nombre_Usuario;
            //lbl_Nombre.Text = "Nombre: " + Program.Nombre_Trabajador;
            //lbl_Cargo.Text = "Cargo: " + Program.Nombre_Cargo;

            //  Privilegios();
            MOSTRAR_Id_Permiso_Pantalla_principal();
            PRIVILEGIOS_MIO();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("Desea salir del sistema?", "SISTEMA MERCENARIOS", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (Opcion == DialogResult.OK)
            {
                this.Close();
                new INICIO_SESION().Show();

            }
        }
        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        #endregion

        private void ts_Rubros_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<Rubro_Cliente>();
            //ts_Rubros.BackColor = Color.FromArgb(224,224, 224);

            //Program.Menu_Principal = 0;
        }

        private void ts_Rutas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Gestion_Rutas>();
            ts_Rutas.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //lbl_HORA.Text = DateTime.Now.Hour.ToString() + ':' + DateTime.Now.Minute.ToString();
            lbl_Hora.Text = DateTime.Now.Hour.ToString("D2") + ":" + DateTime.Now.Minute.ToString("D2");
            lbl_Fecha.Text = DateTime.Now.Date.ToShortDateString();

        }

        private void panel_Forms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cargosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Cargos>();
            cargosToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void uniformesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<Tipo_Herramientas_Uniformes>();
            //uniformesToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            //Program.Menu_Principal = 0;
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AbrirFormulario<Clientes>();
            //clientesToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            //Program.Menu_Principal = 0;
        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal obj = Personal.Get_instancia();

            AbrirFormulario<Personal>();
            personalToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel_fondo_izq_Paint(object sender, PaintEventArgs e)
        {

        }

        private void turnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Turnos>();
            turnosToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuarios>();
            usuariosToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void asignacionDePersonaARutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Detalle_PersonalxRuta>();
            asignacionDePersonaARutasToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Asignacion_Funciones o = new Frm_Asignacion_Funciones();
            o.ShowDialog();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panel_Forms.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {

                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                // formulario.Dock = DockStyle.Fill;
                panel_Forms.Controls.Add(formulario);
                panel_Forms.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);

            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            //if (Application.OpenForms["Rubro_Cliente"] == null)
            //    ts_Rubros.BackColor = Color.FromArgb(255,255,255);
            if (Application.OpenForms["Gestion_Rutas"] == null)
                ts_Rutas.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["Cargos"] == null)
                cargosToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["Personal"] == null)
                personalToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["Turnos"] == null)
                turnosToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["Usuarios"] == null)
                usuariosToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["Detalle_PersonalxRuta"] == null)
                asignacionDePersonaARutasToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            if (Application.OpenForms["detalle_PersonalxRutaxTurno_Mostrar"] == null)
                pERSONALPORTURNORUTAToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            //if (Application.OpenForms["Tipo_Herramientas_Uniformes"] == null)
            //    uniformesToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);
            //if (Application.OpenForms["Clientes"] == null)
            //    clientesToolStripMenuItem.BackColor = Color.FromArgb(255, 255, 255);


        }
        public void MOSTRAR_Id_Permiso_Pantalla_principal()
        {
            DataTable d = Capa_Negocio.N_Usuarios.MOSTRAR_Id_Permiso_Pantalla_principal(lblcodigousaurio.Text);
            dataGridView2.DataSource = d;

        }
        /// <summary>
        /// este metodo PRIVILEGIOS_MIO  va mostrar en el menu si tiene alguno de estos funciones registrado al usuario
        /// cuando ingrese mediate el login
        /// cambiar ese "Pxlnc-100" por lo que tenes eso puse de muestra 
        /// hacerlo por cada uno de tus formulario que tenes funcionando, hacer lo mismo que el codigo que esta comentado de la linea 326 
        /// ir al formulario de personal
        /// </summary>
        public void PRIVILEGIOS_MIO()
        {

            foreach (DataGridViewRow item in dataGridView2.Rows)
            {

                //MessageBox.Show(item.Cells[0].Value.ToString());
                if (item.Cells[0].Value.ToString() == "pers01" || item.Cells[0].Value.ToString() == "pers2" || item.Cells[0].Value.ToString() == "pers03"
                    || item.Cells[0].Value.ToString() == "pers04" || item.Cells[0].Value.ToString() == "pers05")
                {
/*                    ms_Personal.Visible = true;*///el menu del formulario principal
                    personalToolStripMenuItem.Visible = true;//ficha paciente
                }

                else if (item.Cells[0].Value.ToString() == "Carg01" || item.Cells[0].Value.ToString() == "Carg02" || item.Cells[0].Value.ToString() == "Carg03"
                    || item.Cells[0].Value.ToString() == "Carg04" || item.Cells[0].Value.ToString() == "Carg05")
                {
                   /* ms_Parametros.Visible = true;*///parametro
                    cargosToolStripMenuItem.Visible = true;                    //funcionario
                }
                else if (item.Cells[0].Value.ToString() == "Ru01" || item.Cells[0].Value.ToString() == "Ru02" || item.Cells[0].Value.ToString() == "Ru03"
                     || item.Cells[0].Value.ToString() == "Ru04" || item.Cells[0].Value.ToString() == "Ru05")
                {
                    //parametrosYConfiguracionToolStripMenuItem.Visible = true;//parametro
                    ts_Rutas.Visible = true;//medico
                }
                else if (item.Cells[0].Value.ToString() == "Tur01" || item.Cells[0].Value.ToString() == "Tur02" || item.Cells[0].Value.ToString() == "Tur03"
                    || item.Cells[0].Value.ToString() == "Tur04" || item.Cells[0].Value.ToString() == "Tur05")
                {
                    //parametrosYConfiguracionToolStripMenuItem.Visible = true;//parametro
                    turnosToolStripMenuItem.Visible = true;//tipo sala
                }
                else if (item.Cells[0].Value.ToString() == "Perx01" || item.Cells[0].Value.ToString() == "Perx02" || item.Cells[0].Value.ToString() == "Perx03"
                   || item.Cells[0].Value.ToString() == "Perx04" || item.Cells[0].Value.ToString() == "Perx05" )
                {
                  
                    asignacionDePersonaARutasToolStripMenuItem.Visible = true;//tipo sala
                }
                //else if (item.Cells[0].Value.ToString() == "Perx01" || item.Cells[0].Value.ToString() == "Perx02" || item.Cells[0].Value.ToString() == "Perx03"
                //    || item.Cells[0].Value.ToString() == "Perx04" || item.Cells[0].Value.ToString() == "Perx05" )
                //{
                    //    administracionToolStripMenuItem.Visible = true;//administrador
                    //    uSUARIOSToolStripMenuItem.Visible = true;//usuario
                    //}
                //}
            }

        }

        private static Menu_Principal instancias;

        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancias = null;
        }

        private void ms_Personal_Click(object sender, EventArgs e)
        {

        }

        private void pERSONALPORTURNORUTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<detalle_x_personal.detalle_PersonalxRutaxTurno_Mostrar>();
            pERSONALPORTURNORUTAToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
          
            Program.Menu_Principal = 0;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void memorandumsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<MEMORANDUM>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void asistenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<CONTROL_ASISTENCIA>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void lbl_Usuario_Click(object sender, EventArgs e)
        {
            
        }

        private void copiasDeSeguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Frm_Copia_Seguridad>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<PERMISO_DATOS>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void faltasRetrasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FALTA_DATOS>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        private void restrasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<RETRASO_DATOS>();
            memorandumsToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);

            Program.Menu_Principal = 0;
        }

        public static Menu_Principal Instancias
        {
            get
            {
                return instancias;
            }

            set
            {
                instancias = value;
            }
        }
        public static Menu_Principal Get_instancias()
        {
            if (Instancias == null)
            {
                Instancias = new Menu_Principal();
            }
            return Instancias;
        }
    }       
}
