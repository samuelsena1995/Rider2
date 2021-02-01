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
    public partial class Personal_Reporte : Form
    {
        public string _estado_ = "";
        public string _tipo_ = "";
        public string _texto_ = "";

        public Personal_Reporte()
        {
            InitializeComponent();
            this.CenterToScreen();

        }

        private static Personal_Reporte _instancias;

        public static Personal_Reporte Instancias
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
        public static Personal_Reporte Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Personal_Reporte();
            }
            return Instancias;
        }


        private void Personal_Reporte_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Personal_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Personal_BuscarTableAdapter.Fill(this.DataSet.sp_Personal_Buscar,_texto_,_estado_,_tipo_);

            this.reportViewer1.RefreshReport();
           // this.reportViewer2.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
