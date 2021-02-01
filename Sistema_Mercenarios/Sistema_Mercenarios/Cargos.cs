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
    public partial class Cargos : Form
    {
        public static Cargos formdgv;

        public string _estado_ = "T";


        public Cargos()
        {
            InitializeComponent();

          Cargos.formdgv = this;
          MOSTRARMENU_PERMISO();
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

        private void Cargos_Load(object sender, EventArgs e)
        {
            dgv_Cargos.DataSource = N_Cargos.Buscar(txt_Busqueda.Text, cb_Estado.Text);

            Mostrar_Cargos();

            Program.isnuevoCargo = false;
            Program.ismodificarCargo = false;
            MOSTRARMENU_PERMISO();
          //  TamañoDGV();
        }

        public void TamañoDGV()
        {
            dgv_Cargos.ColumnHeadersHeight = 40;

            dgv_Cargos.Columns["CODIGO"].Width = 20;
            dgv_Cargos.Columns["F_REGISTRO"].Width = 20;
            dgv_Cargos.Columns["NOMBRE_CARGO"].Width = 40;
            dgv_Cargos.Columns["SUELDO"].Width = 30;
            dgv_Cargos.Columns["ESTADO"].Width = 100;

            
        }
        public void Mostrar_Cargos()
        {
            dgv_Cargos.DataSource = N_Cargos.Consultar_Todo();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Cargos.Rows.Count) + " registros encontrados";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Program.isnuevoCargo = false;
            Program.ismodificarCargo = false;
            this.Close();
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Program.isnuevoCargo = true;

            Cargos_Datos obj = Cargos_Datos.Get_instancia();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Cargos.Rows.Count > 0)
            {
                Program.ismodificarCargo = true;
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
                if (dgv_Cargos.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Cargos.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Cargos.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Cargos();
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
            Mostrar_Cargos();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_Cargos_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Cargos.Rows.Count > 0)
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
            dgv_Cargos.DataSource = N_Cargos.Buscar(txt_Busqueda.Text, _estado_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Cargos();
            }
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Cargos.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Cargos.CurrentRow.Cells["ESTADO"].Value.ToString() == "V")
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
                        Rpta = N_Cargos.CambiarEstado(Convert.ToInt32(dgv_Cargos.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");
                            Rpta = N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Cargos();
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
            Cargos_Filtro_Reportes reporte = new Cargos_Filtro_Reportes();

            reporte.ShowDialog();
        }
        public void Datos()
        {
            DataTable Datos = N_Cargos.Consulta_Id(Convert.ToInt32(this.dgv_Cargos.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Cargos_Datos frm = Cargos_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][1].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }
                frm.datetime_f_registro.Value = Convert.ToDateTime(Datos.Rows[0][2].ToString());
                frm.txt_nombre_cargo.Text = Datos.Rows[0][3].ToString();
                frm.txt_sueldo.Text = Datos.Rows[0][4].ToString();
                frm.txt_Descripcion.Text = Datos.Rows[0][5].ToString().Trim();

            

                if (Program.isnuevoCargo == true || Program.ismodificarCargo == true)
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

        private void btn_seleccion_Click(object sender, EventArgs e)
        {
           
        }

        private void Cargos_FormClosing(object sender, FormClosingEventArgs e)
        {
            btn_seleccionar.Visible = false;
            Program.ismodificarCargo = false;
            Program.isnuevoCargo = false;
            //Instancias = null;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            DataTable Datos = N_Cargos.Consulta_Id(Convert.ToInt32(this.dgv_Cargos.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Personal_Datos frm = Personal_Datos.Get_instancia();

                frm.txt_cargo.Text = Datos.Rows[0][3].ToString();
                frm.txt_cod_cargo.Text = Datos.Rows[0][0].ToString();
            }
                this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void MOSTRARMENU_PERMISO()
        {
            foreach (DataGridViewRow item in Menu_Principal.frm.dataGridView2.Rows)
            {
                if (item.Cells[0].Value.ToString() == "Carg01")
                {
                    ms_Nuevo.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Carg02")
                {
                    ms_Editar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Carg03")
                {
                    ms_Eliminar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Carg04")
                {
                    ms_CambiarEstado.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Carg05")
                {
                    informesToolStripMenuItem.Visible = true;
                }
            }

        }
    }
}
