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
    public partial class Turnos_Datos : Form
    {
        public string rep = "";

        public Turnos_Datos()
        {
            InitializeComponent();
        }

        private void Turnos_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (Program.ismodificarTurno == true)
            {
                gb_Datos.Enabled = true;
            }
            else if (Program.isnuevoTurno == true)
            {
                gb_Datos.Enabled = true;
                LimpiarTxt();
            }
        }

        private static Turnos_Datos _instancias;

        public static Turnos_Datos Instancias
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
        public static Turnos_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Turnos_Datos();
            }
            return Instancias;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoTurno = false;
            Program.ismodificarTurno = false;

            this.Close();
            Instancias = null;
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

        private void Turnos_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Turnos.formdgv.Mostrar_Turnos();
        }

        public void LimpiarTxt()
        {
            txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_nombre.Text = string.Empty;
            txt_Descripcion.Text = string.Empty;

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
                    if (Program.isnuevoTurno == true)
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

                        rep = N_Turnos.Registrar(estado, txt_nombre.Text, txt_Descripcion.Text);

                    }
                    if (Program.ismodificarTurno == true)
                    {
                        rep = N_Turnos.Editar(Convert.ToInt32(txt_Codigo.Text), txt_nombre.Text, txt_Descripcion.Text);
                    }

                    if (rep.Equals("ok"))
                    {
                        rep = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        if (Program.ismodificarTurno == true)
                        {
                            MessageBox.Show("Editado correctamente");
                        }
                        if (Program.isnuevoTurno == true)
                        {
                            MessageBox.Show("Registrado correctamente");
                        }

                    }
                    else
                    {
                        MessageBox.Show(rep);
                    }

                    Program.isnuevoTurno = false;
                    Program.ismodificarTurno = false;
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

            Program.ismodificarTurno = false;
            Program.isnuevoTurno = false;
            Instancias = null;

            this.Close();
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

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
