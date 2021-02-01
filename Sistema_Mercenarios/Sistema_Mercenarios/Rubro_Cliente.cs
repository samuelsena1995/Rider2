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
using Capa_Datos;
using Capa_Negocio;
using System.Threading;

namespace Sistema_Mercenarios
{
    public partial class Rubro_Cliente : Form
    {
        public static Rubro_Cliente formdgv;

        public string _estado_ = "T";

        public Rubro_Cliente()
        {
            InitializeComponent();

            Rubro_Cliente.formdgv = this;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rubro_Cliente_Load(object sender, EventArgs e)
        {

            dgv_Rubros.DataSource = N_Rubro_Cliente.Buscar(txt_Busqueda.Text,cb_Estado.Text);

            Mostrar_Rubro();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Rubros.Rows.Count) + " registros encontrados";

            Program.isnuevo = false;
            Program.ismodificar = false;
            Program.Cambio_Estado = false;

            TamañoDGV();

        }
        public void TamañoDGV()
        {
            dgv_Rubros.ColumnHeadersHeight = 40;

            dgv_Rubros.Columns["CODIGO"].Width = 20;
            dgv_Rubros.Columns["DESCRIPCION"].Width = 130;
            dgv_Rubros.Columns["ESTADO"].Width = 130;


        }
        public void Mostrar_Rubro()
        {
            dgv_Rubros.DataSource = N_Rubro_Cliente.Consultar_Todo();
        }

        public void Datos()
        {
            DataTable Datos = N_Rubro_Cliente.Consulta_Id(Convert.ToInt32(this.dgv_Rubros.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Rubro_Cliente_Datos frm = Rubro_Cliente_Datos.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
                frm.txt_Descrip.Text = Datos.Rows[0][1].ToString().Trim();
                if (Datos.Rows[0][2].ToString() == "V")
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

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Form rubro = this.MdiChildren.FirstOrDefault(y => y is Rubro_Cliente_Datos);
            if (rubro != null)
            {
                rubro.BringToFront();
                return;
            }
            Program.isnuevo = true;

            Rubro_Cliente_Datos obj = new Rubro_Cliente_Datos();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Rubros.Rows.Count > 0)
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
                if (dgv_Rubros.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Rubros.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Rubro_Cliente.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Rubro();
                        lbl_NroRegistros.Text = Convert.ToString(dgv_Rubros.Rows.Count) + " registros encontrados";

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
            Mostrar_Rubro();

            txt_Busqueda.Text = string.Empty;
            lbl_NroRegistros.Text = Convert.ToString(dgv_Rubros.Rows.Count) + " registros encontrados";
        }

        private void dgv_Rubros_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Rubros.Rows.Count > 0)
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
            dgv_Rubros.DataSource = N_Rubro_Cliente.Buscar(txt_Busqueda.Text,_estado_);

            if (txt_Busqueda.Text == string.Empty)
            {
                dgv_Rubros.DataSource = N_Rubro_Cliente.Consultar_Todo();
            }

            lbl_NroRegistros.Text = Convert.ToString(dgv_Rubros.Rows.Count) + " registros encontrados";

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
                if (dgv_Rubros.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Rubros.CurrentRow.Cells["ESTADO"].Value.ToString() == "V")
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
                        Rpta = N_Rubro_Cliente.CambiarEstado(Convert.ToInt32(dgv_Rubros.CurrentRow.Cells["CODIGO"].Value.ToString()),_estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Rubro();
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

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_Reportes_Click(object sender, EventArgs e)
        {
            //Rubro_Cliente_Reporte reporte = new Rubro_Cliente_Reporte();

            //reporte.ShowDialog();

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
            //Rubro_Cliente_Reporte reporte = new Rubro_Cliente_Reporte();

            //reporte.ShowDialog();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
