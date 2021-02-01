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
    public partial class Clientes_Datos : Form
    {
        public string rep = "";

        SqlConnection cnn;
        SqlCommand cmd;
        SqlDataReader dr;


        public static Clientes_Datos formdgv;

        public Clientes_Datos()
        {
            InitializeComponent();
            Clientes_Datos.formdgv = this;

            this.Location = new Point(1150, 250);
            this.StartPosition = FormStartPosition.Manual;
        }

        private static Clientes_Datos _instancias;

        public static Clientes_Datos Instancias
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
        public static Clientes_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Clientes_Datos();
            }
            return Instancias;
        }

        private void Clientes_Datos_Load(object sender, EventArgs e)
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

            Autocompletar_Rubros();
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

        private void Clientes_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Clientes.formdgv.Mostrar_Clientes();
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
            txt_telefono.Text = string.Empty;
            txt_correo.Text = string.Empty;
            cb_zona.Text = "Norte";
            txt_Descripcion.Text = string.Empty;

            txt_rubro.Text = string.Empty;
            txt_cod_rubro.Text = string.Empty;

            dateTime_F_Registro.Value = DateTime.Now;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombres.Text == string.Empty || txt_ap_paterno.Text == string.Empty || txt_ap_materno.Text == string.Empty || txt_nro_documento.Text == string.Empty || txt_telefono.Text == string.Empty || txt_rubro.Text == string.Empty)
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

                        rep = N_Clientes.Registrar(estado, dateTime_F_Registro.Value, txt_nombres.Text, txt_ap_paterno.Text, txt_ap_materno.Text, Convert.ToInt32(txt_nro_documento.Text), cb_tipo_documento.Text, txt_correo.Text, Convert.ToInt32(txt_telefono.Text), txt_Descripcion.Text, Convert.ToInt32(txt_cod_rubro.Text));

                    }
                    if (Program.ismodificar == true)
                    {
                        rep = N_Clientes.Editar(Convert.ToInt32(txt_Codigo.Text), txt_nombres.Text, txt_ap_paterno.Text, txt_ap_materno.Text, Convert.ToInt32(txt_nro_documento.Text), cb_tipo_documento.Text, txt_correo.Text, Convert.ToInt32(txt_telefono.Text), txt_Descripcion.Text, Convert.ToInt32(txt_cod_rubro.Text));
                    }

                    if (rep.Equals("ok"))
                    {
                        rep = Capa_Negocio.N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
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

        private void cb_tipo_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_zona_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_buscar_rubro_Click(object sender, EventArgs e)
        {
            Rubro_Cliente rubro = new Rubro_Cliente();

            rubro.ShowDialog();


        }
        public void Autocompletar_Rubros()
        {
            try
            {
                cnn = new SqlConnection();
                cnn.ConnectionString = D_Conexion.Conexion;
                cnn.Open();

                cmd = new SqlCommand("Select Descripcion from Rubro_Clientes", cnn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txt_rubro.AutoCompleteCustomSource.Add(dr["Descripcion"].ToString());
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("No se pudo autocompletar el textbox: " + ex.ToString());
            }
        }
        public void CargarDatos_Rubro()
        {
            DataTable Datos = N_Rubro_Cliente.Consulta_Nombre(txt_rubro.Text);

            if (Datos.Rows.Count == 0)
            {
                txt_cod_rubro.Text = string.Empty;
            }
            else
            {
                txt_cod_rubro.Text = Convert.ToString(Datos.Rows[0][0].ToString());

            }
        }


        private void txt_rubro_TextChanged(object sender, EventArgs e)
        {
            CargarDatos_Rubro();
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

        private void cb_zona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombres_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            //SOLO DEJA METER LETRAS
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

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
           //SOLO DEJA METER NUMERO//
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
    }
    }







