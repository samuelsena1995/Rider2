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
    public partial class Turnos : Form
    {
        public static Turnos formdgv;

        public string _estado_ = "T";

        public Turnos()
        {
            InitializeComponent();
            Turnos.formdgv = this;
            MOSTRARMENU_PERMISO();
        }

        private void Turnos_Load(object sender, EventArgs e)
        {
            dgv_Turnos.DataSource = N_Turnos.Buscar(txt_Busqueda.Text, cb_Estado.Text);

            Mostrar_Turnos();

            Program.isnuevoTurno = false;
            Program.ismodificarTurno = false;
            MOSTRARMENU_PERMISO();
            TamañoDGV();
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

        public void TamañoDGV()
        {
            dgv_Turnos.ColumnHeadersHeight = 40;

            dgv_Turnos.Columns["CODIGO"].Width = 20;
            dgv_Turnos.Columns["NOMBRE"].Width = 40;
            dgv_Turnos.Columns["DESCRIPCION"].Width = 30;
            dgv_Turnos.Columns["ESTADO"].Width = 100;
        }

        public void Mostrar_Turnos()
        {
            dgv_Turnos.DataSource = N_Turnos.Consultar_Todo();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Turnos.Rows.Count) + " registros encontrados";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoTurno = false;
            Program.ismodificarTurno = false;
            this.Close();
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Program.isnuevoTurno = true;

            Turnos_Datos obj = Turnos_Datos.Get_instancia();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Turnos.Rows.Count > 0)
            {
                Program.ismodificarTurno = true;
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
                if (dgv_Turnos.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Turnos.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Turnos.Eliminar(Convert.ToInt32(Codigo));
                            }
                        }
                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Turnos();
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
            Mostrar_Turnos();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_Turnos_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Turnos.Rows.Count > 0)
            {
                this.Datos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            dgv_Turnos.DataSource = N_Turnos.Buscar(txt_Busqueda.Text, _estado_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Turnos();
            }
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Turnos.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Turnos.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
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
                        Rpta = N_Turnos.CambiarEstado(Convert.ToInt32(dgv_Turnos.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Turnos();
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
            Turnos_Filtro_Reportes reporte = new Turnos_Filtro_Reportes();

            reporte.ShowDialog();
        }
        public void Datos()
        {
            DataTable Datos = N_Turnos.Consulta_Id(Convert.ToInt32(this.dgv_Turnos.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Turnos_Datos frm = Turnos_Datos.Get_instancia();

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
                frm.txt_Descripcion.Text = Datos.Rows[0][3].ToString().Trim();



                if (Program.isnuevoTurno == true || Program.ismodificarTurno == true)
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

        private void Turnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_seleccionar.Visible = false;
            Program.ismodificarTurno = false;
            Program.isnuevoTurno = false;
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            ////mio
            Detalle_PersonalxRutaxTurno fr = (Detalle_PersonalxRutaxTurno)Owner;
            fr.txt_codigo_turno.Text = dgv_Turnos.CurrentRow.Cells[0].Value.ToString();
            fr.txt_nombre_turno.Text = dgv_Turnos.CurrentRow.Cells[1].Value.ToString();
            this.Close();

            //DataTable Datos = N_Turnos.Consulta_Id(Convert.ToInt32(this.dgv_Turnos.CurrentRow.Cells["CODIGO"].Value.ToString()));

            //if (Datos.Rows.Count < 1)
            //{
            //    MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //}
            //else
            //{
            //    Turnos_Datos frm = Turnos_Datos.Get_instancia();

            //    frm.txt_cargo.Text = Datos.Rows[0][3].ToString();
            //    frm.txt_cod_cargo.Text = Datos.Rows[0][0].ToString();
            //}
            //this.Close();
        }

        public void MOSTRARMENU_PERMISO()
        {
            foreach (DataGridViewRow item in Menu_Principal.frm.dataGridView2.Rows)
            {
                if (item.Cells[0].Value.ToString() == "Tur01")             
                {
                    ms_Nuevo.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Tur02")
                {
                    ms_Editar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Tur03")
                {
                    ms_Eliminar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Tur04")
                {
                    ms_CambiarEstado.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Tur05")
                {
                    informesToolStripMenuItem.Visible = true;
                }
            }

        }

        private void dgv_Turnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
    }
