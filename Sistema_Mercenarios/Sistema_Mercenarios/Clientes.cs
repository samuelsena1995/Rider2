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
    public partial class Clientes : Form
    {
        public static Clientes formdgv;

        public string _estado_ = "T";
        public string _tipo_ = "Nombre(s)";

        public Clientes()
        {
            InitializeComponent();
            Clientes.formdgv = this;

        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            dgv_Clientes.DataSource = N_Clientes.Buscar(txt_Busqueda.Text, _estado_, _tipo_);

            Mostrar_Clientes();

            Program.isnuevo = false;
            Program.ismodificar = false;
            Program.Cambio_Estado = false;

            TamañoDGV();
        }
        public void TamañoDGV()
        {
            dgv_Clientes.ColumnHeadersHeight = 40;

            dgv_Clientes.Columns["CODIGO"].Width = 12;
            dgv_Clientes.Columns["F_REGISTRO"].Width = 20;
            dgv_Clientes.Columns["NOMBRE"].Width = 15;
            dgv_Clientes.Columns["AP_PATERNO"].Width = 15;
            dgv_Clientes.Columns["AP_MATERNO"].Width = 15;
            dgv_Clientes.Columns["NRO_DOCUMENTO"].Width = 15;
            dgv_Clientes.Columns["T_DOCUMENTO"].Width = 10;
            dgv_Clientes.Columns["ESTADO"].Width = 80;


        }
        public void Mostrar_Clientes()
        {
            dgv_Clientes.DataSource = N_Clientes.Consultar_Todo();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Clientes.Rows.Count) + " registros encontrados";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Form form = this.MdiChildren.FirstOrDefault(y => y is Clientes_Datos);
            if (form != null)
            {
                form.BringToFront();
                return;
            }
            Program.isnuevo = true;

            Clientes_Datos obj = new Clientes_Datos();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Clientes.Rows.Count > 0)
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
                if (dgv_Clientes.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Clientes.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Clientes.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Clientes();
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
            Mostrar_Clientes();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_Clientes_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Clientes.Rows.Count > 0)
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
            dgv_Clientes.DataSource = N_Clientes.Buscar(txt_Busqueda.Text, _estado_, _tipo_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Clientes();
            }

        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Clientes.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Clientes.CurrentRow.Cells["ESTADO"].Value.ToString() == "V")
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
                        Rpta = N_Clientes.CambiarEstado(Convert.ToInt32(dgv_Clientes.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Clientes();
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

        private void cb_tipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Nombre(s)")
            {
                _tipo_ = "Nombre(s)";
            }
            if (cb_tipo.Text == "Ap_paterno")
            {
                _tipo_ = "Ap_paterno";
            }
            if (cb_tipo.Text == "Ap_materno")
            {
                _tipo_ = "Ap_materno";
            }
            if (cb_tipo.Text == "Nro_documento")
            {
                _tipo_ = "Nro_documento";
            }
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

        public void Datos()
        {
            DataTable Datos = N_Clientes.Consulta_Id(Convert.ToInt32(this.dgv_Clientes.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Clientes_Datos frm = Clientes_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][1].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }
                frm.dateTime_F_Registro.Value = Convert.ToDateTime(Datos.Rows[0][2].ToString());
                frm.txt_nombres.Text = Datos.Rows[0][3].ToString();
                frm.txt_ap_paterno.Text = Datos.Rows[0][4].ToString();
                frm.txt_ap_materno.Text = Datos.Rows[0][5].ToString();

                frm.txt_nro_documento.Text = Datos.Rows[0][6].ToString();
                frm.cb_tipo_documento.Text = Datos.Rows[0][7].ToString();
                frm.txt_correo.Text = Datos.Rows[0][8].ToString();
                frm.txt_telefono.Text = Datos.Rows[0][9].ToString();

                frm.txt_Descripcion.Text = Datos.Rows[0][10].ToString().Trim();
                frm.txt_cod_rubro.Text = Datos.Rows[0][11].ToString();

                frm.txt_rubro.Text = Datos.Rows[0][12].ToString();

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

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Clientes_Reporte rep = new Clientes_Reporte();

            //rep.ShowDialog();
        }
    }
}
