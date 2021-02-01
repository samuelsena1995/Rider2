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
    public partial class Rubro_Cliente_Datos : Form
    {
        public string rep = "";

        public Rubro_Cliente_Datos()
        {
            InitializeComponent();

            this.Location = new Point(1150, 250);
            this.StartPosition = FormStartPosition.Manual;
        }

        private void Rubro_Cliente_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            if (Program.ismodificar == true)
            {
                gb_Datos.Enabled = true;
            }
            else if (Program.isnuevo == true)
            {
                gb_Datos.Enabled = true;
            }
        }
        private static Rubro_Cliente_Datos _instancias;

        public static Rubro_Cliente_Datos Instancias
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
        public static Rubro_Cliente_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Rubro_Cliente_Datos();
            }
            return Instancias;
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

        private void Rubro_Cliente_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Rubro_Cliente.formdgv.Mostrar_Rubro();
            Rubro_Cliente.formdgv.lbl_NroRegistros.Text = Convert.ToString(Rubro_Cliente.formdgv.dgv_Rubros.Rows.Count) + " registros encontrados";

        }

        public void LimpiarTxt()
        {
            txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_Descrip.Text = string.Empty;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_Descrip.Text == string.Empty)
                {
                    MessageBox.Show("Porfavor inserte los datos requerido");
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

                        rep = N_Rubro_Cliente.Registrar(this.txt_Descrip.Text.Trim(),estado);

                    }
                    if (Program.ismodificar == true)
                    {
                        rep = N_Rubro_Cliente.Editar(Convert.ToInt32(txt_Codigo.Text), this.txt_Descrip.Text.Trim());
                    }

                    if (rep.Equals("ok"))
                    {
                        rep = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        if (Program.ismodificar == true)
                        {
                            MessageBox.Show("Se Modifco de froma correcta ");
                        }
                        if (Program.isnuevo == true)
                        {
                            MessageBox.Show("Se registro de forma correcta");
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

        private void txt_Descrip_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
