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
    public partial class Rubro_Cliente_Reporte : Form
    {
        public Rubro_Cliente_Reporte()
        {
            InitializeComponent();
        }

        string _vEstado = "T";

        private void Gestion_Rutas_Reporte_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Rubro_Clientes_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Rubro_Clientes_BuscarTableAdapter.Fill(this.DataSet.sp_Rubro_Clientes_Buscar,txt_Texto.Text,_vEstado);
           
            this.reportViewer1.RefreshReport();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Capturar posicion y tamaño antes de maximizar para restaurar
        int lx, ly;
        int sw, sh;

        private void cb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Estado.Text == "Todos")
            {
                _vEstado = "T";
            }
            if (cb_Estado.Text == "Valido")
            {
                _vEstado = "V";
            }
            if (cb_Estado.Text == "Anulado")
            {
                _vEstado = "A";
            }

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Rubro_Clientes_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Rubro_Clientes_BuscarTableAdapter.Fill(this.DataSet.sp_Rubro_Clientes_Buscar, txt_Texto.Text, _vEstado);

            this.reportViewer1.RefreshReport();
        }

        private void btn_VerTodos_Click(object sender, EventArgs e)
        {
            cb_Estado.Text = "Todos";
            txt_Texto.Text = string.Empty;

            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Rubro_Clientes_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Rubro_Clientes_BuscarTableAdapter.Fill(this.DataSet.sp_Rubro_Clientes_Buscar, txt_Texto.Text, _vEstado);

            this.reportViewer1.RefreshReport();
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

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
    }
}
