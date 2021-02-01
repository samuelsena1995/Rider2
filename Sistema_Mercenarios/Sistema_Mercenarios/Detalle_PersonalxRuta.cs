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

namespace Sistema_Mercenarios
{
    public partial class Detalle_PersonalxRuta : Form
    {
        public static Detalle_PersonalxRuta formdgv;

        public string _estado_ = "T";

        public Detalle_PersonalxRuta()
        {
            InitializeComponent();
            Detalle_PersonalxRuta.formdgv = this;
            //  Mostrar_Asignacion();
            Mostrar_Personal();
            MOSTRARMENU_PERMISO();
        }

        private void Detalle_PersonalxRuta_Load(object sender, EventArgs e)
        {
            // dgv_Detalle_PersonalxRutas.DataSource = N_Asignacion_Rutas.Buscar(txt_Busqueda.Text, _estado_);
            Mostrar_Personal();
        //    Mostrar_Asignacion();
            MOSTRARMENU_PERMISO();
            Program.isnuevoDetalleRuta = false;
            Program.ismodificarDetalleRuta = false;

         //   TamañoDGV();           
        }
        public void TamañoDGV()
        {
            dgv_Detalle_PersonalxRutas.ColumnHeadersHeight = 40;

            dgv_Detalle_PersonalxRutas.Columns["DETALLE"].Width = 20;
            dgv_Detalle_PersonalxRutas.Columns["CODIGO RUTA"].Width = 10;
            dgv_Detalle_PersonalxRutas.Columns["ZONA"].Width = 10;
            dgv_Detalle_PersonalxRutas.Columns["OBSERVACION"].Width = 30;
            dgv_Detalle_PersonalxRutas.Columns["ESTADO"].Width = 80;
        }
        public void Mostrar_Asignacion()
        {
            dgv_Detalle_PersonalxRutas.DataSource = N_Detalle_Asignacion_Rutas.Consultar_Todo_detalle_asignacionrutas();

            lbl_NroRegistros.Text = Convert.ToString(dgv_Detalle_PersonalxRutas.Rows.Count) + " registros encontrados";

        }
        ////mostrar el boton seleccionar para pasar datos al detalle de turno x ruta
        public void Mostrar_Personal()
        {
            if (btn_seleccionar.Visible == false)
            {
                dgv_Detalle_PersonalxRutas.DataSource = N_Detalle_Asignacion_Rutas.Consultar_Todo_detalle_asignacionrutas();

                lbl_NroRegistros.Text = Convert.ToString(dgv_Detalle_PersonalxRutas.Rows.Count) + " registros encontrados";
            }
            else
            {
                // if (btn_seleccionar.Visible == true)
                if (btn_seleccionar.Visible == true)
                {
                    dgv_Detalle_PersonalxRutas.DataSource = N_Detalle_Asignacion_Rutas.Consultar_Todo_detalle_no_asignados();

                    lbl_NroRegistros.Text = Convert.ToString(dgv_Detalle_PersonalxRutas.Rows.Count) + " registros encontrados";
                }
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Program.isnuevoDetalleRuta = true;
           
            Detalle_PersonalxRuta_Datos obj = Detalle_PersonalxRuta_Datos.Get_instancia();
            obj.CREARTABLA();
            obj.Show();
            // obj.CREARTABLA();
            //if (obj.dgv_Detalle_PersonalxRutas.Columns.Count > 0)
            //{
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Remove("CODIGO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Remove("NOMBRE");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Remove("AP_PATERNO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Remove("AP_MATERNO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Remove("NRO_DOCUMENTO");
            //}
            //else
            //{
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Add("CODIGO", "CODIGO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Add("NOMBRE", "NOMBRE");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Add("AP_PATERNO", "AP_PATERNO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Add("AP_MATERNO", "AP_MATERNO");
            //    obj.dgv_Detalle_PersonalxRutas.Columns.Add("NRO_DOCUMENTO", "NRO_DOCUMENTO");
            //}

            //dgv_Detalle_PersonalxRutas.DataSource = dgv_Detalle_PersonalxRutas;

            //obj.ShowDialog();

        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Detalle_PersonalxRutas.Rows.Count > 0)
            {
                Program.ismodificarDetalleRuta = true;

                Detalle_PersonalxRuta_Datos obj = Detalle_PersonalxRuta_Datos.Get_instancia();
                obj.CREARTABLA();                
                this.Datos2();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void ms_Eliminar_Click(object sender, EventArgs e)
        {
            DataTable CODIGO_DETALLE_TURNO = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.MOSTRAR_DETALLE_TURNO_RUTA();
            try
            {
                if (dgv_Detalle_PersonalxRutas.Rows.Count > 0)
                {
                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                     //   string Codigo;
                        string Rpta = "";
                       // string Rpta2 = "";
                        foreach (DataGridViewRow row in dgv_Detalle_PersonalxRutas.Rows)
                        {
                            if (row.Selected)
                            {
                                if (this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells["ESTADO"].Value.ToString() == "Anulado")
                                {                                   
                                        Rpta = Capa_Negocio.N_Detalle_Asignacion_Rutas.eliminar(Convert.ToInt32(dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString()));                                                                                                                                                                                                                
                                }
                                else {                                    
                                    MessageBox.Show("NO SE PUEDE ELIMINAR EL REGISTRO POR QUE EL ESTADO ESTA <VALIDO> PORFAVOR CAMBI EL ESTADO");
                                }
                            }
                        }
                        if (Rpta.Equals("ok"))
                        {
                            MessageBox.Show("Se eliminó de forma correcta el Registro");
                        }
                        else
                        {
                         //   MessageBox.Show(Rpta);
                        }
                        Mostrar_Asignacion();
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
            Mostrar_Asignacion();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_Detalle_PersonalxRutas_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Detalle_PersonalxRutas.Rows.Count > 0)
            {
                Detalle_PersonalxRuta_Datos obj = Detalle_PersonalxRuta_Datos.Get_instancia();

                //if (obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Count > 0)
                //{
                //    obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Remove("CODIGO");
                //    obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Remove("NOMBRE");
                //    obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Remove("AP.PATERNO");
                //    obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Remove("AP.MATERNO");
                //    obj.dgv_Detalle_PersonalxRutas_detalle.Columns.Remove("NRO.DOCUMENTO");
                //}

                this.Datos2();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            dgv_Detalle_PersonalxRutas.DataSource = N_Detalle_Asignacion_Rutas.Buscar(txt_Busqueda.Text, _estado_,cb_tipo.Text);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Asignacion();
            }
            lbl_NroRegistros.Text = Convert.ToString(dgv_Detalle_PersonalxRutas.Rows.Count) + " registros encontrados";
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                /////////////
                if (dgv_Detalle_PersonalxRutas.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
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
                        //   Rpta = N_Asignacion_Rutas.CambiarEstado(Convert.ToInt32(dgv_Detalle_PersonalxRutas.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);
                        Rpta = N_Detalle_Asignacion_Rutas.CAMBIO_ESTADO(Convert.ToInt32(dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString()), _estado);
                        if (Rpta.Equals("ok"))
                        {
                            MessageBox.Show("Se cambio es estado");
                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        Mostrar_Asignacion();
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

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            Detalle_PersonalxRutaxTurno fr = (Detalle_PersonalxRutaxTurno)Owner;
            fr.txt_codigo_ruta.Text = dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString();
            fr.txt_nombre_ruta.Text = dgv_Detalle_PersonalxRutas.CurrentRow.Cells[2].Value.ToString();
            fr.MOSTRAR_PERSONAL(dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString());
            this.Close();
        }
        public void Datos2()
        {
            //DataTable Datos = N_Asignacion_Rutas.Consulta_Id(Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells["DETALLE"].Value.ToString()));
            DataTable Datos = N_Detalle_Asignacion_Rutas.Consulta_Id_DETALLE_RUTA(Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Detalle_PersonalxRuta_Datos frm = Detalle_PersonalxRuta_Datos.Get_instancia();

                frm.txt_codigo_DETALLE.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][1].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }

                frm.txt_observaciones.Text = Datos.Rows[0][2].ToString();
                frm.txt_codigo_ruta.Text = Datos.Rows[0][3].ToString();

                if (Datos.Rows[0][4].ToString() == "N")
                {
                    frm.txt_nombre_ruta.Text = "Norte";
                }
                if (Datos.Rows[0][4].ToString() == "S")
                {
                    frm.txt_nombre_ruta.Text = "Sur";
                }
                if (Datos.Rows[0][4].ToString() == "E")
                {
                    frm.txt_nombre_ruta.Text = "Este";
                }
                if (Datos.Rows[0][4].ToString() == "O")
                {
                    frm.txt_nombre_ruta.Text = "Oeste";
                }
                if (Datos.Rows[0][4].ToString() == "C")
                {
                    frm.txt_nombre_ruta.Text = "Centro";
                }

                //frm.dgv_Detalle_PersonalxRutas.Columns.Remove("CODIGO");
                //frm.dgv_Detalle_PersonalxRutas.Columns.Remove("NOMBRE");
                //frm.dgv_Detalle_PersonalxRutas.Columns.Remove("AP_PATERNO");
                //frm.dgv_Detalle_PersonalxRutas.Columns.Remove("AP_MATERNO");
                //frm.dgv_Detalle_PersonalxRutas.Columns.Remove("NRO_DOCUMENTO");


                //   frm.dgv_Detalle_PersonalxRutas.DataSource = N_Detalle_Asignacion_Rutas.Consulta_Id(Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells["CODIGO"].Value.ToString()));
                // frm.dgv_Detalle_PersonalxRutas.DataSource = Capa_Negocio.N_AuxiliarDetalle_Ruta.Consulta_detalle_ruta(Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells[1].Value.ToString()));

                // frm.dgv_Detalle_PersonalxRutas.DataSource = Capa_Negocio.N_Detalle_Asignacion_Rutas.Consulta_persona_mostrar(Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString()), Convert.ToInt32(this.dgv_Detalle_PersonalxRutas.CurrentRow.Cells[1].Value.ToString()));


                //if (Program.isnuevoDetalleRuta == true || Program.ismodificarDetalleRuta == true)
              
                if (Program.isnuevoDetalleRuta == true)
                {

                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;

                }
                else if (Program.ismodificarDetalleRuta == true) {
                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;
                }
                else
                {
                    frm.btn_Guardar.Visible = false;
                    frm.btn_Cancelar.Enabled = true;
                }
                frm.ShowDialog();
            }
        }
       
        private void lbl_NroRegistros_Click(object sender, EventArgs e)
        {

        }

        private void Detalle_PersonalxRuta_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Refresh();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void MOSTRARMENU_PERMISO()
        {
            foreach (DataGridViewRow item in Menu_Principal.frm.dataGridView2.Rows)
            {
                if (item.Cells[0].Value.ToString() == "Perx01")
                {
                    ms_Nuevo.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Perx02")
                {
                    ms_Editar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Perx03")
                {
                    ms_Eliminar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Perx04")
                {
                    ms_CambiarEstado.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "Perx05")
                {
                    informesToolStripMenuItem.Visible = true;
                }
            }


        }

        private void lbl_Titulo_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Detalle_PersonalxRutas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgv_Detalle_PersonalxRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //    Detalle_PersonalxRutaxTurno fr = (Detalle_PersonalxRutaxTurno)Owner;
        //    fr.txt_codigo_ruta.Text = dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString();
        //    fr.txt_nombre_ruta.Text = dgv_Detalle_PersonalxRutas.CurrentRow.Cells[2].Value.ToString();
        //    fr.MOSTRAR_PERSONAL(dgv_Detalle_PersonalxRutas.CurrentRow.Cells[0].Value.ToString());
        //    this.Close();
        }

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_PersonalxRuta_Filtro_Reportes rep = new Detalle_PersonalxRuta_Filtro_Reportes();

            rep.ShowDialog();
        }
    }

}
