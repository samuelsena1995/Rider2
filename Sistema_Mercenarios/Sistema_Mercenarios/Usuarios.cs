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
using System.Threading;

namespace Sistema_Mercenarios
{
    public partial class Usuarios : Form
    {
        public static Usuarios formdgv;

        public string _estado_ = "T";

        public Usuarios()
        {
            InitializeComponent();
            Usuarios.formdgv = this;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            // dgv_Usuarios.DataSource = N_Usuarios.Buscar(txt_Busqueda.Text, cb_Estado.Text);
       //  TamañoDGV();
            Mostrar_Usuarios();
            
            Program.isnuevoUsuario = false;
            Program.ismodificarUsuario = false;
          

        }
        public void TamañoDGV()
        {
            dgv_Usuarios.ColumnHeadersHeight = 40;

            //dgv_Usuarios.Columns["CODIGO"].Width = 20;
            //dgv_Usuarios.Columns["NOMBRE"].Width = 40;
            //dgv_Usuarios.Columns["USUARIO"].Width = 30;
            //dgv_Usuarios.Columns["CLAVE"].Width = 30;
            //dgv_Usuarios.Columns["ESTADO"].Width = 100;
            dgv_Usuarios.Columns[0].Width = 30;
            dgv_Usuarios.Columns[1].Width = 50;
            dgv_Usuarios.Columns[2].Width = 80;
            dgv_Usuarios.Columns[3].Width = 90;
            dgv_Usuarios.Columns[4].Width = 100;
            //dgv_Usuarios.Columns[5].Width = 100;
        }

        public void Mostrar_Usuarios()
        {
            dgv_Usuarios.DataSource = N_Usuarios.Consultar_Todo();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Usuarios.Rows.Count) + " registros encontrados";
        }

        //METODO PARA ARRASTRAR EL FORMULARIO------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoUsuario = false;
            Program.ismodificarUsuario = false;
            this.Close();
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Program.isnuevoUsuario = true;            
            Usuarios_Datos obj = Usuarios_Datos.Get_instancia();
            obj.mostrarID_tabla();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Usuarios.Rows.Count > 0)
            {
                Program.ismodificarUsuario = true;
                this.Datos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void ms_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Usuarios.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Usuarios.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Usuarios.Eliminar(Codigo);
                            }
                        }
                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");
                            Rpta = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Usuarios();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            Mostrar_Usuarios();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_Usuarios_DoubleClick(object sender, EventArgs e)
        {
            //if (dgv_Usuarios.Rows.Count > 0)
            //{
            //    this.Datos();
            //}
            //else
            //{
            //    MessageBox.Show("Seleccione un registro");
            //}
          //  Frm_Asignacion_Funciones f = (Frm_Asignacion_Funciones)Owner;
          //  f.txt_Codigo.Text = dgv_Usuarios.CurrentRow.Cells[0].Value.ToString();
          //  f.txt_nombre.Text = dgv_Usuarios.CurrentRow.Cells[1].Value.ToString();
          ////  f.txtNOMBRE.Focus();
          //  Program.isnuevo = true;
          //  Frm_Asignacion_Funciones.frm.SP_MOSTRAR_FUNCIONES();
          //  this.Close();
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            dgv_Usuarios.DataSource = N_Usuarios.Buscar(txt_Busqueda.Text, _estado_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Usuarios();
            }
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Usuarios.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Usuarios.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
                    {
                        Opcion = MessageBox.Show("¿Desea cambiar el estado a <Anulado>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "A";
                    }
                    else
                    {
                        Opcion = MessageBox.Show("¿Desea cambiar el estado a <Valido>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "V";
                    }

                    if (Opcion == DialogResult.OK)
                    {
                        string Rpta = "";
                        Rpta = N_Usuarios.CambiarEstado(dgv_Usuarios.CurrentRow.Cells["CODIGO"].Value.ToString(), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");
                            Rpta = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Usuarios();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un registro");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios_Filtro_Reportes reporte = new Usuarios_Filtro_Reportes();

            reporte.ShowDialog();
        }

        public void Datos()
        {
            DataTable Datos = N_Usuarios.Consulta_Id(this.dgv_Usuarios.CurrentRow.Cells["CODIGO"].Value.ToString());

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Usuarios_Datos frm = Usuarios_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][1].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }
                frm.txt_nombre.Text = Datos.Rows[0][2].ToString();
                frm.txt_usuario.Text = Datos.Rows[0][3].ToString();
                frm.txt_clave.Text = Capa_Datos.D_Seguridad.descomprimir(Datos.Rows[0][4].ToString());
                frm.txt_observaciones.Text = Datos.Rows[0][5].ToString().Trim();



                if (Program.isnuevoUsuario == true || Program.ismodificarUsuario == true)
                {
                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;
                }
                else
                {
                    frm.btn_Guardar.Enabled = false;
                    frm.btn_Cancelar.Enabled = false;
                }
                frm.ShowDialog();
            }
        }

        private void asignarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Funciones frm = new Funciones();
            //frm.ShowDialog();

            //DataTable Datos = N_Usuarios.Consulta_Id(this.dgv_Usuarios.CurrentRow.Cells["CODIGO"].Value.ToString());

            //if (Datos.Rows.Count < 1)
            //{
            //    MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //else
            //{
            //    Usuarios_Datos frm = Usuarios_Datos.Get_instancia();

            //    frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
            //}
        }
        

        private void asignacionPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_Usuarios.Rows.Count >= 0)
            {
                Program.Cambio_Estado = true;
                this.DatosAsignarPermiso();
            }
            else
            {
                MessageBox.Show("Selecciones");
            }
        }
        public void DatosAsignarPermiso()
        {

            try
            {

                DataTable codigo = N_Usuarios.Consulta_Id(this.dgv_Usuarios.CurrentRow.Cells[0].Value.ToString());
                if (codigo.Rows.Count == 0)
                {
                    MessageBox.Show("ERROR", "SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Frm_Asignacion_Funciones frm = Frm_Asignacion_Funciones.Get_instancias();


                    string co = codigo.Rows[0][0].ToString();//codigo
                    string nom = codigo.Rows[0][2].ToString();//nombre          
                    frm.txt_Codigo.Text = co.Trim();
                    frm.txt_nombre.Text = nom.Trim();
                    frm.ShowDialog();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("No hay ningun dato");
            }
        }
    }
}
