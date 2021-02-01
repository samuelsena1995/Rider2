using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Mercenarios.detalle_x_personal
{
    public partial class detalle_PersonalxRutaxTurno_Mostrar : Form
    {
       public static detalle_PersonalxRutaxTurno_Mostrar frm;
        public string _estado_ = "T";
        public string _tipo_ = "Codigo";
        public detalle_PersonalxRutaxTurno_Mostrar()
        {
            InitializeComponent();
            frm = this;
        }

        private void detalle_PersonalxRutaxTurno_Mostrar_Load(object sender, EventArgs e)
        {
            MOSTRAR();
        }
        public void MOSTRAR() {
            if (btn_seleccionar.Visible == false)
            {
                dgv_Detalle_PersonalxTuernoxRutas.DataSource = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.MOSTRAR_DETALLE_TURNO_RUTA();
            }
            else if (btn_seleccionar.Visible == true) {
                dgv_Detalle_PersonalxTuernoxRutas.DataSource = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.PERSONAL_TURNO_RUTA_NO_ASIGNADO();
            }
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            
            Form ruta = this.MdiChildren.FirstOrDefault(y => y is detalle_PersonalxRutaxTurno_Mostrar);
            if (ruta != null)
            {
                ruta.BringToFront();
                return;
            }
            Program.isnuevoPersonalTurnoRuta = true;        
            Detalle_PersonalxRutaxTurno obj = new Detalle_PersonalxRutaxTurno();
            obj.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
            if (dgv_Detalle_PersonalxTuernoxRutas.Rows.Count > 0)
            {
                Program.ismodificarPersonalTurnoRuta = true;
                this.Datos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }
        public void Datos()
        {
            DataTable Datos = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.SP_CONSULTAR_ID_PERSONAL_DETALLE_TURNO_RUTA(Convert.ToInt32(this.dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[0].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                Detalle_PersonalxRutaxTurno frm = Detalle_PersonalxRutaxTurno.Get_instancia();

                frm.txt_codigo_detalle.Text = Datos.Rows[0][0].ToString();

                if (Datos.Rows[0][6].ToString() == "V")
                {
                    frm.cb_Estado.Text = "Valido";
                }
                else
                {
                    frm.cb_Estado.Text = "Anulado";
                }
                frm.txt_codigo_ruta.Text = Datos.Rows[0][1].ToString();
                frm.txt_nombre_ruta.Text = Datos.Rows[0][2].ToString();
                frm.txt_codigo_turno.Text = Datos.Rows[0][3].ToString();
                frm.txt_nombre_turno.Text = Datos.Rows[0][4].ToString().Trim();
                frm.txt_observaciones.Text = Datos.Rows[0][5].ToString().Trim();
                frm.dtinicio.Value = Convert.ToDateTime(Datos.Rows[0][7].ToString());
                frm.dtfin.Value = Convert.ToDateTime(Datos.Rows[0][8].ToString());

                if (Program.isnuevoPersonalTurnoRuta == true || Program.ismodificarPersonalTurnoRuta == true)
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

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Detalle_PersonalxTuernoxRutas.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
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
                        Rpta = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.CambiarEstado(Convert.ToInt32(dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[0].Value.ToString()), _estado);

                        if (Rpta.Equals("ok"))
                        {
                            // MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        MOSTRAR();
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

        private void ms_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Detalle_PersonalxTuernoxRutas.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_Detalle_PersonalxTuernoxRutas.Rows)
                        {
                            if (row.Selected)
                            {
                                if (this.dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells["ESTADO"].Value.ToString() == "Anulado")
                                {
                                    Codigo = Convert.ToString(row.Cells[0].Value);
                                    Rpta = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Eliminar(Convert.ToInt32(Codigo));
                                }
                                else {
                                    MessageBox.Show("DESHABILITE PRIMERO EL DATO ");
                                }
                                
                            }
                        }
                        if (Rpta.Equals("ok"))
                        {
                             MessageBox.Show("Se eliminó de forma correcta el Registro");

                        }
                        else
                        {
                            MessageBox.Show(Rpta);
                        }

                        MOSTRAR();
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

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Codigo")
            {
                _tipo_ = "Codigo";
            }
            if (cb_tipo.Text == "Zona")
            {
                _tipo_ = "Zona";
            }
            if (cb_tipo.Text == "Turno")
            {
                _tipo_ = "Turno";
            }
        }

        private void txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            dgv_Detalle_PersonalxTuernoxRutas.DataSource = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Buscar(txt_Busqueda.Text, _estado_, _tipo_);

            if (txt_Busqueda.Text == string.Empty)
            {
                MOSTRAR();
            }

            lbl_NroRegistros.Text = Convert.ToString(dgv_Detalle_PersonalxTuernoxRutas.Rows.Count) + " registros encontrados";
        }

        private void dgv_Detalle_PersonalxTuernoxRutas_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_Detalle_PersonalxTuernoxRutas.Rows.Count > 0)
            {
                Detalle_PersonalxRuta_Datos obj = Detalle_PersonalxRuta_Datos.Get_instancia();
                obj.groupBox1.Enabled = false;         
                this.Datos();
            }
            else
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalle_PersonalxRutaxTurno_Filtro_Reportes rep = new Detalle_PersonalxRutaxTurno_Filtro_Reportes();

            rep.ShowDialog();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                CONTROL_ASISTENCIA_DATOS fr = (CONTROL_ASISTENCIA_DATOS)Owner;
                fr.TXTCODIGO_TURNO_X_RUTA.Text = dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[0].Value.ToString();
                fr.TXTZONA.Text = dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[2].Value.ToString();
                fr.TXT_TURNO.Text = dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[4].Value.ToString();
                fr.TXTCODIGORUTA.Text = dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[1].Value.ToString();
                fr.MOSTRAR_PERSONAL(dgv_Detalle_PersonalxTuernoxRutas.CurrentRow.Cells[1].Value.ToString());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("NO HAY DATOS PARA ASIGNAR");
            }
            
        }
    }
}
