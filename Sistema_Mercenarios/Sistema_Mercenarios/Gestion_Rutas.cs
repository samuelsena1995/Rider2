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
    public partial class Gestion_Rutas : Form
    {
        public static Gestion_Rutas formdgv;

        public string _zona_ = "T";
        public string _estado_ = "T";

        public Gestion_Rutas()
        {
            this.CenterToScreen();
            InitializeComponent();
            Gestion_Rutas.formdgv = this;
            MOSTRARMENU_PERMISO();
        }

        private void Gestion_Rutas_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            dgv_Rutas.DataSource = N_Rutas.Buscar(txt_Busqueda.Text, _estado_, _zona_);

            Mostrar_Rutas();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Rutas.Rows.Count) + " registros encontrados";

            Program.isnuevo = false;
            Program.ismodificar = false;
            Program.Cambio_Estado = false;
            MOSTRARMENU_PERMISO();

            TamañoDGV();
        }
        public void TamañoDGV()
        {
            dgv_Rutas.ColumnHeadersHeight = 40;

            dgv_Rutas.Columns["CODIGO"].Width = 40;
            dgv_Rutas.Columns["DESCRIPCION"].Width = 130;
            dgv_Rutas.Columns["ZONA"].Width = 50;
            dgv_Rutas.Columns["ESTADO"].Width = 100;
        }

        public void Datos()
        {
            DataTable Datos = N_Rutas.Consulta_Id(Convert.ToInt32(this.dgv_Rutas.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Gestion_Rutas_Datos frm = Gestion_Rutas_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
                frm.txt_Descrip.Text = Datos.Rows[0][1].ToString().Trim();
                frm.cb_Zona.Text = Datos.Rows[0][2].ToString();

                if (Datos.Rows[0][3].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }

                if (Program.isnuevo == true || Program.ismodificar == true)
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
        public void Mostrar_Rutas()
        {
            dgv_Rutas.DataSource = N_Rutas.Consultar_Todo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_Rutas_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Rutas.Rows.Count > 0)
            {
                this.Datos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void menustpNUEVO_Click(object sender, EventArgs e)
        {
            Form ruta = this.MdiChildren.FirstOrDefault(y => y is Gestion_Rutas_Datos);
            if (ruta != null)
            {
                ruta.BringToFront();
                return;
            }
            Program.isnuevo = true;

            Gestion_Rutas_Datos obj = new Gestion_Rutas_Datos();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Rutas.Rows.Count > 0)
            {
                Program.ismodificar = true;
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
                if (dgv_Rutas.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("Realmente desea eliminar el registro?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Rutas.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Rutas.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Rutas();
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
            Mostrar_Rutas();

            txt_Busqueda.Text = string.Empty;
            lbl_NroRegistros.Text = Convert.ToString(dgv_Rutas.Rows.Count) + " registros encontrados";
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            dgv_Rutas.DataSource = N_Rutas.Buscar(txt_Busqueda.Text, _estado_, _zona_);

            if (txt_Busqueda.Text == string.Empty)
            {
                dgv_Rutas.DataSource = N_Rutas.Consultar_Todo();
            }

            lbl_NroRegistros.Text = Convert.ToString(dgv_Rutas.Rows.Count) + " registros encontrados";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Program.resultado_funcion = NRoles.login_funcion(Convert.ToInt32(Program.Id_Rol));
            //foreach (int idServ in Program.resultado_funcion)
            //{
            //    switch (idServ)
            //    {
            //        case 5: menustpNUEVO.Visible = true; break;
            //        case 6: menustpEDITAR.Visible = true; break;
            //        case 7: menustpELIMINAR.Visible = true; break;
            //        //case 8: menustpCAMBIARESTADO.Visible = true; break;

            //        default:

            //            break;
            //    }
            //}

            //lbl_NroRegistros.Text = Convert.ToString(dgv_Rubros.Rows.Count) + " registros encontrados";
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Rutas.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Rutas.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
                    {
                        Opcion = MessageBox.Show("Realmente desea cambiar el estado a <Anulado>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "A";
                    }
                    else
                    {
                        Opcion = MessageBox.Show("Realmente desea cambiar el estado a <Valido>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "V";
                    }

                    if (Opcion == DialogResult.OK)
                    {
                        string Rpta = "";
                        Rpta = N_Rutas.CambiarEstado(Convert.ToInt32(dgv_Rutas.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");
                            Rpta = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Rutas();
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

        private void cb_Zona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Zona.Text == "Todos")
            {
                _zona_ = "T";
            }
            if (cb_Zona.Text == "Norte")
            {
                _zona_ = "N";
            }
            if (cb_Zona.Text == "Sur")
            {
                _zona_ = "S";
            }
            if(cb_Zona.Text == "Este")
            {
                _zona_ = "E";
            }
            if (cb_Zona.Text == "Oeste")
            {
                _zona_ = "O";
            }
            if (cb_Zona.Text == "Centro")
            {
                _zona_ = "C";
            }
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_Zona_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            //Gestion_Rutas_Reporte rep = new Gestion_Rutas_Reporte();

            //rep.ShowDialog();
        }

        private void listadoDeRutasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gestion_Rutas_Filtro_Reportes rep = new Gestion_Rutas_Filtro_Reportes();

            rep.ShowDialog();
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            DataTable Datos = N_Rutas.Consulta_Id(Convert.ToInt32(this.dgv_Rutas.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Detalle_PersonalxRuta_Datos frm = Detalle_PersonalxRuta_Datos.Get_instancia();

                frm.txt_codigo_ruta.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][2].ToString() == "N")
                {
                    frm.txt_nombre_ruta.Text = "Norte";
                }
                if (Datos.Rows[0][2].ToString() == "S")
                {
                    frm.txt_nombre_ruta.Text = "Sur";
                }
                if (Datos.Rows[0][2].ToString() == "E")
                {
                    frm.txt_nombre_ruta.Text = "Este";
                }
                if (Datos.Rows[0][2].ToString() == "O")
                {
                    frm.txt_nombre_ruta.Text = "Oeste";
                }
                if (Datos.Rows[0][2].ToString() == "C")
                {
                    frm.txt_nombre_ruta.Text = "Centro";
                }

            }
            this.Close();
        }

        private void Gestion_Rutas_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_seleccionar.Visible = false;
        }
        //permisos
        public void MOSTRARMENU_PERMISO()
        {
            foreach (DataGridViewRow item in Menu_Principal.frm.dataGridView2.Rows)
            {
                if (item.Cells[0].Value.ToString() == "Ru01")
                {
                    menustpNUEVO.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Ru02")
                {
                    ms_Editar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Ru03")
                {
                    ms_Eliminar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Ru04")
                {
                    ms_CambiarEstado.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Ru05")
                {
                    informesToolStripMenuItem.Visible = true;
                }
            }


        }

        private void dgv_Rutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Detalle_PersonalxRutaxTurno fr = (Detalle_PersonalxRutaxTurno)Owner;
            //fr.txt_codigo_ruta.Text = dgv_Rutas.CurrentRow.Cells[0].Value.ToString();
            //fr.txt_nombre_ruta.Text = dgv_Rutas.CurrentRow.Cells[1].Value.ToString();
            //this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
