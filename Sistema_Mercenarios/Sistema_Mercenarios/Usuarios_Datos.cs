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
using System.Data;
using System.Data.SqlClient;

namespace Sistema_Mercenarios
{
    public partial class Usuarios_Datos : Form
    {
        public string rep = "";

        public Usuarios_Datos()
        {
            InitializeComponent();
        }

        private void Usuarios_Datos_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            txt_clave.UseSystemPasswordChar = true;
            txt_repetirclave.UseSystemPasswordChar = true;

            if (Program.ismodificarUsuario == true)
            {
                gb_Datos.Enabled = true;
            }
            else if (Program.isnuevoUsuario == true)
            {                
                gb_Datos.Enabled = true;
                LimpiarTxt();
                mostrarID_tabla();
            }
        }
        public void mostrarID_tabla()
        {
            string s = "select max(Codigo)as Codigo from Usuarios";
            SqlConnection sqlc;
            using (sqlc = new SqlConnection(Capa_Datos.D_Conexion.Conexion)) {
                sqlc.Open();
                SqlCommand cmd = new SqlCommand(s, sqlc);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                int i = Convert.ToInt16(dr["Codigo"].ToString());
                txt_Codigo.Text = (i + 1).ToString();
            }               
        }
        private static Usuarios_Datos _instancias;

        public static Usuarios_Datos Instancias
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
        public static Usuarios_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Usuarios_Datos();
            }
            return Instancias;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoUsuario = false;
            Program.ismodificarUsuario = false;

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

        private void Usuarios_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Usuarios.formdgv.Mostrar_Usuarios();
        }
        public void LimpiarTxt()
        {
           // txt_Codigo.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_nombre.Text = string.Empty;
            txt_usuario.Text = string.Empty;
            txt_clave.Text = string.Empty;
            txt_repetirclave.Text = string.Empty;
            txt_observaciones.Text = string.Empty;

        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_nombre.Text == string.Empty || txt_usuario.Text == string.Empty || txt_clave.Text == string.Empty || txt_repetirclave.Text == string.Empty)
                {
                    MessageBox.Show("Porfavor llene los campos obligatorios");
                }
                else
                {
                    if (txt_clave.Text != txt_repetirclave.Text)
                    {
                        MessageBox.Show("Las contraseñas no coinciden");
                    }
                    else
                    {
                        if (Program.isnuevoUsuario == true)
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

                            //   rep = N_Usuarios.Registrar(estado, txt_nombre.Text, txt_usuario.Text,N_Usuarios.Encriptar(txt_clave.Text), txt_observaciones.Text);
                            if (txtcopia_usuario.Text != string.Empty)
                            {
                                rep = N_Usuarios.Registrar(estado, txt_nombre.Text, txt_usuario.Text, Capa_Datos.D_Seguridad.encriptar(txt_clave.Text), txt_observaciones.Text);
                                rep = N_Usuarios.COPIAR_ASIGNACIONPERMISO_NUEVO_USUARIO(txt_Codigo.Text, txtcopia_usuario.Text);
                            }
                            else {
                                rep = N_Usuarios.Registrar(estado, txt_nombre.Text, txt_usuario.Text, Capa_Datos.D_Seguridad.encriptar(txt_clave.Text), txt_observaciones.Text);
                            }
                            

                        }
                       else if (Program.ismodificarUsuario == true)
                        {
                            //rep = N_Usuarios.Editar(txt_Codigo.Text, txt_nombre.Text, txt_usuario.Text,N_Usuarios.Encriptar(txt_clave.Text), txt_observaciones.Text);
                            if (txtcopia_usuario.Text != string.Empty) {
                                rep = N_Usuarios.Editar(txt_Codigo.Text, txt_nombre.Text, txt_usuario.Text, Capa_Datos.D_Seguridad.encriptar(txt_clave.Text), txt_observaciones.Text);
                                rep = N_Usuarios.COPIAR_ASIGNACIONPERMISO_NUEVO_USUARIO(txt_Codigo.Text, txtcopia_usuario.Text);
                            }else
                            {
                                rep = N_Usuarios.Editar(txt_Codigo.Text, txt_nombre.Text, txt_usuario.Text, Capa_Datos.D_Seguridad.encriptar(txt_clave.Text), txt_observaciones.Text);
                            }
                            
                        }

                        if (rep.Equals("ok"))
                        {
                            rep = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);

                            if (Program.ismodificarUsuario == true)
                            {
                                MessageBox.Show("Editado correctamente");
                            }
                            if (Program.isnuevoUsuario == true)
                            {
                                MessageBox.Show("Registrado correctamente");
                            }
                        }
                        else
                        {
                            MessageBox.Show(rep);
                        }

                        Program.isnuevoUsuario = false;
                        Program.ismodificarUsuario = false;
                        Instancias = null;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Program.ismodificarUsuario = false;
            Program.isnuevoUsuario = false;
            Instancias = null;

            this.Close();
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txt_clave.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                txt_clave.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mostrarID_tabla();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) {
                txtcopia_usuario.Enabled = true;
            }else
            {
                txtcopia_usuario.Enabled = false;
            }
        }
    }
}
