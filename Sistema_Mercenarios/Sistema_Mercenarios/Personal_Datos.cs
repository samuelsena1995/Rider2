using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Capa_Negocio;
using Capa_Datos;


namespace Sistema_Mercenarios
{
    public partial class Personal_Datos : Form
    {
        public string rep = "";

      public static Personal_Datos formdgv;

        public Personal_Datos()
        {
            InitializeComponent();
            Personal_Datos.formdgv = this;


            this.Location = new Point(1150, 250);
            this.StartPosition = FormStartPosition.Manual;
        }

        private static Personal_Datos _instancias;

        public static Personal_Datos Instancias
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
        public static Personal_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Personal_Datos();
            }
            return Instancias;
        }

        private void Personal_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (Program.ismodificarPersonal == true)
            {
                tabControl1.Enabled = true;
                btn_Guardar.Enabled = true;
                btn_Cancelar.Enabled = true;

                label11.Visible = false;
                dateTime_f_retiro.Visible = false;
            
            }
            else if (Program.isnuevoPersonal == true)
            {
                tabControl1.Enabled = true;
                LimpiarTxt();
                btn_Guardar.Enabled = true;
                btn_Cancelar.Enabled = true;

                label11.Visible = false;
                dateTime_f_retiro.Visible = false;
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoPersonal = false;
            Program.ismodificarPersonal = false;

            this.Close();
        }

        private void Personal_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.isnuevoPersonal = false;
            Program.ismodificarPersonal = false;
            tabControl1.Enabled = false;

            Personal.formdgv.Mostrar_Personal();
         
        }
        public void LimpiarTxt()
        {
            txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_nombres.Text = string.Empty;
            txt_ap_paterno.Text = string.Empty;
            txt_ap_materno.Text = string.Empty;
            txt_nro_documento.Text = string.Empty;
            cb_tipo_documento.Text = "Cédula de identidad";
            cb_estado_civil.Text = "Soltero";
            txt_telefono.Text = string.Empty;
            cb_sexo.Text = "Hombre";
            cb_zona.Text = "Norte";
            txt_Descripcion.Text = string.Empty;

            txt_cod_cargo.Text = string.Empty;
            txt_cargo.Text = string.Empty;

            dateTime_f_registro.Value = DateTime.Now;
            dateTime_f_retiro.Value = DateTime.Now;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombres.Text == string.Empty || txt_ap_paterno.Text == string.Empty || txt_ap_materno.Text == string.Empty || txt_nro_documento.Text == string.Empty || txt_telefono.Text == string.Empty || txt_cargo.Text == string.Empty)
                {
                    MessageBox.Show("Porfavor llene los campos obligatorios");
                }
                else
                {
                    if (Program.isnuevoPersonal == true)
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

                        rep = N_Personal.Registrar(estado, dateTime_f_registro.Value, txt_nombres.Text, txt_ap_paterno.Text, txt_ap_materno.Text, dateTimePicker_f_nacimiento.Value, Convert.ToInt32(txt_nro_documento.Text), cb_tipo_documento.Text, cb_estado_civil.Text, cb_sexo.Text, Convert.ToInt32(txt_telefono.Text), txt_Descripcion.Text,cb_zona.Text, Convert.ToInt32(txt_cod_cargo.Text));

                    }
                    if (Program.ismodificarPersonal == true)
                    {
                        rep = N_Personal.Editar(Convert.ToInt32(txt_Codigo.Text), txt_nombres.Text, txt_ap_paterno.Text, txt_ap_materno.Text, dateTimePicker_f_nacimiento.Value, Convert.ToInt32(txt_nro_documento.Text), cb_tipo_documento.Text, cb_estado_civil.Text, cb_sexo.Text, Convert.ToInt32(txt_telefono.Text), txt_Descripcion.Text, cb_zona.Text, Convert.ToInt32(txt_cod_cargo.Text));
                    }

                    if (rep.Equals("ok"))
                    {
                        rep = Capa_Negocio.N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        if (Program.ismodificarPersonal == true)
                        {
                            MessageBox.Show("Editado correctamente");
                        }
                        if (Program.isnuevoPersonal == true)
                        {
                            MessageBox.Show("Registrado correctamente");
                        }

                    }
                    else
                    {
                        MessageBox.Show(rep);
                    }

                    Program.isnuevoPersonal = false;
                    Program.ismodificarPersonal = false;
                    tabControl1.Enabled = false;

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
            Program.isnuevoPersonal = false;
            Program.ismodificarPersonal = false;
            tabControl1.Enabled = false;

            this.Close();
        }

        private void cb_talla_camisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_tipo_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_estado_civil_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_sexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_zona_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btn_buscar_cargo_Click(object sender, EventArgs e)
        {
            Cargos frm = new Cargos();

            frm.ms_Nuevo.Visible = false;
            frm.ms_Eliminar.Visible = false;
            frm.ms_Editar.Visible = false;
            frm.ms_CambiarEstado.Visible = false;
            frm.informesToolStripMenuItem.Visible = false;

            frm.btn_seleccionar.Visible = true;
            frm.ShowDialog();

        }

        private void txt_cargo_TextChanged(object sender, EventArgs e)
        {
        }

        private void cb_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ap_paterno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_ap_materno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_nro_documento_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cb_zona_DrawItem(object sender, DrawItemEventArgs e)
        {
           
        }
    }
}
