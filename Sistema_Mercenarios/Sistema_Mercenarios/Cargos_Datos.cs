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
    public partial class Cargos_Datos : Form
    {

        public string rep = "";

        public Cargos_Datos()
        {
            InitializeComponent();
        }

        private static Cargos_Datos _instancias;

        public static Cargos_Datos Instancias
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
        public static Cargos_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Cargos_Datos();
            }
            return Instancias;
        }

        private void Cargos_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (Program.ismodificarCargo == true)
            {
                gb_Datos.Enabled = true;
            }
            else if (Program.isnuevoCargo == true)
            {
                gb_Datos.Enabled = true;
                LimpiarTxt();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoCargo = false;
            Program.ismodificarCargo = false;

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

        private void Cargos_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
         Cargos.formdgv.Mostrar_Cargos();
        Cargos.formdgv.lbl_NroRegistros.Text = Convert.ToString(Cargos.formdgv.dgv_Cargos.Rows.Count) + " registros encontrados";
        }

        public void LimpiarTxt()
        {
            txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_nombre_cargo.Text = string.Empty;
            txt_sueldo.Text = "0";
            txt_Descripcion.Text = string.Empty;

            datetime_f_registro.Value = DateTime.Now;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombre_cargo.Text == string.Empty  || txt_sueldo.Text == string.Empty)
                {
                    MessageBox.Show("Porfavor llene los campos obligatorios");
                }
                else
                {
                    if (Program.isnuevoCargo == true)
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

                        rep = N_Cargos.Registrar(estado,datetime_f_registro.Value,txt_nombre_cargo.Text,Convert.ToDecimal(txt_sueldo.Text),txt_Descripcion.Text);

                    }
                    if (Program.ismodificarCargo == true)
                    {
                        rep = N_Cargos.Editar(Convert.ToInt32(txt_Codigo.Text), txt_nombre_cargo.Text, Convert.ToDecimal(txt_sueldo.Text), txt_Descripcion.Text);
                    }

                    if (rep.Equals("ok"))
                    {
                        rep = Capa_Negocio.N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        if (Program.ismodificarCargo == true)
                        {
                            MessageBox.Show("Editado correctamente");
                        }
                        if (Program.isnuevoCargo == true)
                        {
                            MessageBox.Show("Registrado correctamente");
                        }

                    }
                    else
                    {
                        MessageBox.Show(rep);
                    }

                    Program.isnuevoCargo = false;
                    Program.ismodificarCargo = false;
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

            if (Program.ismodificarCargo == true)
            {
                Program.ismodificarCargo = false;
            }
            else if (Program.isnuevoCargo == true)
            {
                Program.isnuevoCargo = false;

            }

            Instancias = null;

            this.Close();
        }

        private void txt_nombre_cargo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_sueldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            //if (char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
