using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Mercenarios
{
    public partial class INICIO_SESION : Form
    {
        public INICIO_SESION()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
          
            try
            {
                DataTable Datos = new DataTable();
                 Datos = Capa_Negocio.N_Usuarios.INICIO_SESION_NUEVO(txtUsuario.Text.ToUpper(), Capa_Datos.D_Seguridad.encriptar(txtPassword.Text));
                if (txtUsuario.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("COMPLETE LOS CAMPOS ", "SISTEMA RGJ GETSEMANI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Datos.Rows.Count == 0)
                {
                    MessageBox.Show("USUARIO Y/O CONTRASEÑA INCORRECTOS O NO TIENE FUNCIONES ASIGNADO", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    txtUsuario.Text = "";
                }
                else
                {
                    if (Datos.Rows[0][5].ToString() == "V")
                    {
                        Menu_Principal frm = Menu_Principal.Get_instancias();
                        Program.ID_USUARIO_GLOBAL = Convert.ToInt32(Datos.Rows[0][0].ToString());
                        Program.USUARIO_GLOBAL = Datos.Rows[0][2].ToString();
                        Program.PASSWORD_GLOBAL = Datos.Rows[0][3].ToString();
                        Program.NOMBRECOMPLETO_USUARIO_GLOBAL = Datos.Rows[0][1].ToString();
                        frm.lblcodigousaurio.Text = Convert.ToString(Program.ID_USUARIO_GLOBAL);
                        frm.lblusuario.Text = Program.USUARIO_GLOBAL;
                        // frm.lblcontraseña.Text = Capa_Negocio.N_Usuarios.Desencriptar(Program.PASSWORD_GLOBAL);
                        frm.lblcontraseña.Text = Capa_Datos.D_Seguridad.descomprimir(Program.PASSWORD_GLOBAL);
                        // frm.MOSTRAR_Id_Permiso_Pantalla_principal();
                        frm.lbl_Usuario.Text = "USUARIO: "+ Program.NOMBRECOMPLETO_USUARIO_GLOBAL;
                        // frm.PRIVILEGIOS_MIO();        
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(" EL USUARIO  " + Datos.Rows[0][1].ToString() + " SE DIO DE BAJA EN EL SISTEMA ?", ".: SISTEMA :.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
            
        }

        private void lblMINIMIZAR_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblSALIR_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void INICIO_SESION_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
