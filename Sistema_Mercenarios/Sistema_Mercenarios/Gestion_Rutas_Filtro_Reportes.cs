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
   
    public partial class Gestion_Rutas_Filtro_Reportes : Form
    {
        public string _est_ = "T";
        public string _zon_ = "T";

        public Gestion_Rutas_Filtro_Reportes()
        {
            InitializeComponent();

            this.CenterToScreen();

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            Gestion_Rutas_Reporte frm = Gestion_Rutas_Reporte.Get_instancia();

            frm._estado_ = _est_;
            frm._zona_ = _zon_;
            frm._texto_ = txt_Busqueda.Text;

            frm.ShowDialog();
        }

        private void cb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Estado.Text == "Todos")
            {
                _est_ = "T";
            }
            if (cb_Estado.Text == "Valido")
            {
                _est_ = "V";
            }
            if (cb_Estado.Text == "Anulado")
            {
                _est_ = "A";
            }
        }

        private void cb_zona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_zona.Text == "Todos")
            {
                _zon_ = "T";
            }
            if (cb_zona.Text == "Norte")
            {
                _zon_ = "N";
            }
            if (cb_zona.Text == "Sur")
            {
                _zon_ = "S";
            }
            if (cb_zona.Text == "Este")
            {
                _zon_ = "E";
            }
            if (cb_zona.Text == "Oeste")
            {
                _zon_ = "O";
            }
            if (cb_zona.Text == "Centro")
            {
                _zon_ = "C";
            }
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Gestion_Rutas_Filtro_Reportes_Load(object sender, EventArgs e)
        {

        }
    }
}
