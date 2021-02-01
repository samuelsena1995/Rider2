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
using System.Text.RegularExpressions;
using Capa_Negocio;


namespace Sistema_Mercenarios
{
    public partial class Cargos_Reporte : Form
    {
        public string _estado_ = "";
        public string _texto_ = "";
        public Cargos_Reporte()
        {
            InitializeComponent();

            this.CenterToScreen();
        }

        private static Cargos_Reporte _instancias;

        public static Cargos_Reporte Instancias
        {
            get
            {
                return _instancias;
            }

            set
            {
                _instancias = value;
            }
        }
        public static Cargos_Reporte Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Cargos_Reporte();
            }
            return Instancias;
        }

        private void Cargos_Reporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Cargos_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Cargos_BuscarTableAdapter.Fill(this.DataSet.sp_Cargos_Buscar,_texto_,_estado_);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cargos_Reporte_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
