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
    public partial class Tipo_Herramientas_Uniformes_Datos : Form
    {

        public string rep = "";

        public Tipo_Herramientas_Uniformes_Datos()
        {
            InitializeComponent();

            this.Location = new Point(1150, 250);
            this.StartPosition = FormStartPosition.Manual;
        }

        private static Tipo_Herramientas_Uniformes_Datos _instancias;

        public static Tipo_Herramientas_Uniformes_Datos Instancias
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
        public static Tipo_Herramientas_Uniformes_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Tipo_Herramientas_Uniformes_Datos();
            }
            return Instancias;
        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Tipo_Herramientas_Uniformes_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (Program.ismodificar == true)
            {
                gb_Datos.Enabled = true;
            }
            else if (Program.isnuevo == true)
            {
                gb_Datos.Enabled = true;
                LimpiarTxt();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.ismodificar == true)
            {
                Program.ismodificar = false;
            }
            else if (Program.isnuevo == true)
            {
                Program.isnuevo = false;

            }

            this.Close();
            Instancias = null;
        }

        private void Tipo_Herramientas_Uniformes_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Tipo_Herramientas_Uniformes.formdgv.Mostrar_Tipo_Herrramienta_Uniforme();

        }
        public void LimpiarTxt()
        {
            txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_nombre.Text = string.Empty;
            cb_tipo.Text = "Herramienta";
            cb_talla.Text = "Unica";
            numericUpDown_stock.TextAlign = 0;
            txt_Descripcion.Text = string.Empty;

            dateTime_f_registro.Value = DateTime.Now;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombre.Text == string.Empty)
                {
                    MessageBox.Show("Porfavor llene los campos obligatorios");
                }
                else
                {
                    if (Program.isnuevo == true)
                    {
                        string estado = "";
                        if (cb_Estado.Text == "Valido")
                        {
                            estado = "V";
                        }
                        else
                        {
                            estado = "A";
                        }

                        rep = N_Tipo_Herramientas_Uniformes.Registrar(estado, dateTime_f_registro.Value, txt_nombre.Text, cb_tipo.Text,cb_talla.Text,Convert.ToInt32(numericUpDown_stock.Value), txt_Descripcion.Text);

                    }
                    if (Program.ismodificar == true)
                    {
                        rep = N_Tipo_Herramientas_Uniformes.Editar(Convert.ToInt32(txt_Codigo.Text), txt_nombre.Text, cb_tipo.Text, cb_talla.Text, Convert.ToInt32(numericUpDown_stock.Value), txt_Descripcion.Text);
                    }

                    if (rep.Equals("ok"))
                    {

                        if (Program.ismodificar == true)
                        {
                            MessageBox.Show("Editado correctamente");
                        }
                        if (Program.isnuevo == true)
                        {
                            MessageBox.Show("Registrado correctamente");
                        }

                    }
                    else
                    {
                        MessageBox.Show(rep);
                    }

                    Program.isnuevo = false;
                    Program.ismodificar = false;
                    Instancias = null;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (Program.ismodificar == true)
            {
                Program.ismodificar = false;
            }
            else if (Program.isnuevo == true)
            {
                Program.isnuevo = false;

            }

            this.Close();
            Instancias = null;
        }

        private void cb_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_talla_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
