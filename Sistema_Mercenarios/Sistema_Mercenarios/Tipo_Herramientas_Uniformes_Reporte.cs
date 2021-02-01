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
    public partial class Tipo_Herramientas_Uniformes_Reporte : Form
    {

        string _estado_ = "T";
        string _tipo_ = "T";

        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;
        public Tipo_Herramientas_Uniformes_Reporte()
        {
            InitializeComponent();
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_Tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Estado.Text == "Todos")
            {
                _estado_ = "T";
            }
            if (cb_Estado.Text == "Valido")
            {
                _estado_ = "V";
            }
            if (cb_Estado.Text == "Anulado")
            {
                _estado_ = "A";
            }
        }

        private void cb_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Tipo.Text == "Todos")
            {
                _tipo_ = "T";
            }
            if (cb_Tipo.Text == "Herramienta")
            {
                _tipo_ = "Herramienta";
            }
            if (cb_Tipo.Text == "Uniforme")
            {
                _tipo_ = "Uniforme";
            }
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

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            this.sp_Tipo_Herramientas_Uniformes_BuscarTableAdapter.Fill(this.DataSet.sp_Tipo_Herramientas_Uniformes_Buscar, txt_Texto.Text, _estado_, _tipo_);

            this.reportViewer1.RefreshReport();
        }

        private void btn_VerTodos_Click(object sender, EventArgs e)
        {
            cb_Estado.Text = "Todos";
            cb_Tipo.Text = "Todos";
            txt_Texto.Text = string.Empty;

            this.sp_Tipo_Herramientas_Uniformes_BuscarTableAdapter.Fill(this.DataSet.sp_Tipo_Herramientas_Uniformes_Buscar, txt_Texto.Text, _estado_, _tipo_);

            this.reportViewer1.RefreshReport();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
        }

        private void Tipo_Herramientas_Uniformes_Reporte_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Tipo_Herramientas_Uniformes_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Tipo_Herramientas_Uniformes_BuscarTableAdapter.Fill(this.DataSet.sp_Tipo_Herramientas_Uniformes_Buscar,txt_Texto.Text,_estado_,_tipo_);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
