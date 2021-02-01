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
    public partial class Tipo_Herramientas_Uniformes : Form
    {

        public static Tipo_Herramientas_Uniformes formdgv;

        public string _estado_ = "T";
        public string _tipo_ = "T";

        public Tipo_Herramientas_Uniformes()
        {
            InitializeComponent();
            Tipo_Herramientas_Uniformes.formdgv = this;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Tipo_Herramientas_Uniformes_Load(object sender, EventArgs e)
        {
            dgv_herramientas_uniformes.DataSource = N_Tipo_Herramientas_Uniformes.Buscar(txt_Busqueda.Text, _estado_, _tipo_);

            Mostrar_Tipo_Herrramienta_Uniforme();


            Program.isnuevo = false;
            Program.ismodificar = false;
            Program.Cambio_Estado = false;

            TamañoDGV();
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

        public void TamañoDGV()
        {
            dgv_herramientas_uniformes.ColumnHeadersHeight = 40;

            dgv_herramientas_uniformes.Columns["CODIGO"].Width = 12;
            dgv_herramientas_uniformes.Columns["F_REGISTRO"].Width = 20;
            dgv_herramientas_uniformes.Columns["TIPO"].Width = 15;
            dgv_herramientas_uniformes.Columns["NOMBRE"].Width = 15;
            dgv_herramientas_uniformes.Columns["TALLA"].Width = 10;
            dgv_herramientas_uniformes.Columns["STOCK"].Width = 10;
            dgv_herramientas_uniformes.Columns["ESTADO"].Width = 80;


        }
        public void Mostrar_Tipo_Herrramienta_Uniforme()
        {
            dgv_herramientas_uniformes.DataSource = N_Tipo_Herramientas_Uniformes.Consultar_Todo();

            lbl_NroRegistros.Text = Convert.ToString(dgv_herramientas_uniformes.Rows.Count) + " registros encontrados";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Form form = this.MdiChildren.FirstOrDefault(y => y is Tipo_Herramientas_Uniformes_Datos);
            if (form != null)
            {
                form.BringToFront();
                return;
            }
            Program.isnuevo = true;

            Tipo_Herramientas_Uniformes_Datos obj = new Tipo_Herramientas_Uniformes_Datos();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_herramientas_uniformes.Rows.Count > 0)
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
                if (dgv_herramientas_uniformes.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_herramientas_uniformes.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Tipo_Herramientas_Uniformes.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Tipo_Herrramienta_Uniforme();
                        lbl_NroRegistros.Text = Convert.ToString(dgv_herramientas_uniformes.Rows.Count) + " registros encontrados";

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
            Mostrar_Tipo_Herrramienta_Uniforme();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_herramientas_uniformes_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_herramientas_uniformes.Rows.Count > 0)
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
            dgv_herramientas_uniformes.DataSource = N_Tipo_Herramientas_Uniformes.Buscar(txt_Busqueda.Text, _estado_,_tipo_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Tipo_Herrramienta_Uniforme();
            }

            lbl_NroRegistros.Text = Convert.ToString(dgv_herramientas_uniformes.Rows.Count) + " registros encontrados";
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_herramientas_uniformes.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_herramientas_uniformes.CurrentRow.Cells["ESTADO"].Value.ToString() == "V")
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
                        Rpta = N_Tipo_Herramientas_Uniformes.CambiarEstado(Convert.ToInt32(dgv_herramientas_uniformes.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Tipo_Herrramienta_Uniforme();
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

        public void Datos()
        {
            DataTable Datos = N_Tipo_Herramientas_Uniformes.Consulta_Id(Convert.ToInt32(this.dgv_herramientas_uniformes.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Tipo_Herramientas_Uniformes_Datos frm = Tipo_Herramientas_Uniformes_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][1].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }
                frm.dateTime_f_registro.Value = Convert.ToDateTime(Datos.Rows[0][2].ToString());
                frm.txt_nombre.Text = Datos.Rows[0][3].ToString();
                frm.cb_tipo.Text = Datos.Rows[0][4].ToString();
                frm.cb_talla.Text = Datos.Rows[0][5].ToString();
                frm.numericUpDown_stock.Text = Datos.Rows[0][6].ToString();
                frm.txt_Descripcion.Text = Datos.Rows[0][7].ToString().Trim();



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

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Todos")
            {
                _tipo_ = "T";
            }
            if (cb_tipo.Text == "Herramienta")
            {
                _tipo_ = "Herramienta";
            }
            if (cb_tipo.Text == "Uniforme")
            {
                _tipo_ = "Uniforme";
            }
        }

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tipo_Herramientas_Uniformes_Reporte rep = new Tipo_Herramientas_Uniformes_Reporte();

            //rep.ShowDialog();
        }
    }
}
