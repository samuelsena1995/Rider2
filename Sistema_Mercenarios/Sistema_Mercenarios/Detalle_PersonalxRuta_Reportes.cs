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
    public partial class Detalle_PersonalxRuta_Reportes : Form
    {
        public string _estado_ = "";
        public string _tipo_ = "";
        public string _texto_ = "";

        public Detalle_PersonalxRuta_Reportes()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private static Detalle_PersonalxRuta_Reportes _instancias;

        public static Detalle_PersonalxRuta_Reportes Instancias
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
        public static Detalle_PersonalxRuta_Reportes Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Detalle_PersonalxRuta_Reportes();
            }
            return Instancias;
        }
        private void Detalle_PersonalxRuta_Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet.SP_BUSCAR_DETALLE_RUTAS2' Puede moverla o quitarla según sea necesario.
            this.SP_BUSCAR_DETALLE_RUTAS2TableAdapter.Fill(this.DataSet.SP_BUSCAR_DETALLE_RUTAS2,_texto_,_estado_,_tipo_);

            this.reportViewer1.RefreshReport();
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
