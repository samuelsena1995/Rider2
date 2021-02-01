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
namespace Sistema_Mercenarios
{
    public partial class CONTROL_ASISTENCIA : Form
    {
        public CONTROL_ASISTENCIA()
        {
            InitializeComponent();
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Form ruta = this.MdiChildren.FirstOrDefault(y => y is CONTROL_ASISTENCIA_DATOS);
            if (ruta != null)
            {
                ruta.BringToFront();
                return;
            }
            Program.isnuevoControlAsistencia = true;
            CONTROL_ASISTENCIA_DATOS obj = new CONTROL_ASISTENCIA_DATOS();
            obj.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();            
        }

        private void CONTROL_ASISTENCIA_Load(object sender, EventArgs e)
        {
            MOSTRAR();
        }
        public void MOSTRAR() {
            dgv_Control_asistencia.DataSource = Capa_Negocio.N_CONTROL_ASISTENCIA.Consultar_Todo();
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_Control_asistencia.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_Control_asistencia.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
                    {
                        Opcion = MessageBox.Show("¿Desea cambiar el estado a <Anulado>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "A";
                    }
                    else {
                        Opcion = MessageBox.Show("¿Desea cambiar el estado a <Valido>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        _estado = "V";
                    }
                        if (Opcion == DialogResult.OK)
                        {
                            string Rpta = "";                       
                            Rpta = Capa_Negocio.N_CONTROL_ASISTENCIA.CambiarEstado(Convert.ToInt32(dgv_Control_asistencia.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado);

                            if (Rpta.Equals("ok"))
                            {
                                 MessageBox.Show("Se Cambio el Dato a: "+_estado);
                            }
                            else
                            {
                                MessageBox.Show(Rpta);
                            }

                            MOSTRAR();
                        }
                    
                    else
                    {
                        MessageBox.Show("Personal retirado, no puede cambiar el estado");
                        _estado = "Valido";
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

        private void pERMISOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_Control_asistencia.Rows.Count > 0)
            {
                Program.isnuevo_permiso = true;
                Datos();
            }
            else {
                MessageBox.Show("No hay Datos seleccionado");
            }
        }
        public void Datos()
        {
            DataTable Datos = Capa_Negocio.N_CONTROL_ASISTENCIA.Consulta_Id(Convert.ToInt32(this.dgv_Control_asistencia.CurrentRow.Cells[0].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                PERMISO_DATOS frm = PERMISO_DATOS.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
                frm.datetime_f_registro.Value = Convert.ToDateTime(Datos.Rows[0][1].ToString());                             

                if (Program.isnuevo_permiso == true)
                {
                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;
                }
                //else
                //{
                //    frm.btn_Guardar.Enabled = false;
                //    frm.btn_Cancelar.Enabled = false;
                //}
                frm.ShowDialog();
            }
        }

        public void Datos_falta()
        {
            DataTable Datos = Capa_Negocio.N_CONTROL_ASISTENCIA.Consulta_Id(Convert.ToInt32(this.dgv_Control_asistencia.CurrentRow.Cells[0].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                FALTA_DATOS frm = FALTA_DATOS.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
                frm.datetime_f_registro.Value = Convert.ToDateTime(Datos.Rows[0][1].ToString());

                if (Program.isnuevo_falta == true )
                {
                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;
                }
                //else
                //{
                //    frm.btn_Guardar.Enabled = false;
                //    frm.btn_Cancelar.Enabled = false;
                //}
                frm.ShowDialog();
            }
        }

        public void Datos_Retraso()
        {
            DataTable Datos = Capa_Negocio.N_CONTROL_ASISTENCIA.Consulta_Id(Convert.ToInt32(this.dgv_Control_asistencia.CurrentRow.Cells[0].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                //string FechaHora1 = cInicio.Text + ' ' + HoraInicio.Text;
                //DateTime FechaHoraInicio = DateTime.Parse(FechaHora1);
                //string FechaHora2 = cfin.Text + ' ' + HoraTermino.Text;
                //DateTime FechaHoraTermino = DateTime.Parse(FechaHora2);

                //TimeSpan diferencia = FechaHoraTermino - FechaHoraInicio;
                //var diferenciaenminutos = diferencia.TotalMinutes;

                DateTime minutos = Convert.ToDateTime(dgv_Control_asistencia.CurrentRow.Cells[1].Value.ToString());
               // DateTime minutos1 = minutos.Minute.ToString("mm");
                DateTime MINUTO_CARGADO =Convert.ToDateTime( minutos.ToString());
                DateTime MINUTOACTUAL = Convert.ToDateTime(DateTime.Now.ToString());
                TimeSpan RESULTADO =  MINUTOACTUAL-MINUTO_CARGADO;
                string diferencia = RESULTADO.ToString();
                          
                RETRASO_DATOS frm = RETRASO_DATOS.Get_instancia();

                frm.txt_Codigo.Text = Datos.Rows[0][0].ToString();
                frm.datetime_f_registro.Value = Convert.ToDateTime(Datos.Rows[0][1].ToString());              
                frm.LBLMINUTOS_RETRASO.Text = diferencia.ToString();
                if (Program.isnuevo_Retraso == true )
                {
                    frm.btn_Guardar.Enabled = true;
                    frm.btn_Cancelar.Enabled = true;
                }
                //else
                //{
                //    frm.btn_Guardar.Enabled = false;
                //    frm.btn_Cancelar.Enabled = false;
                //}
                frm.ShowDialog();
            }
        }

        private void faltaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_Control_asistencia.Rows.Count > 0)
            {
                Program.isnuevo_falta = true;
                Datos_falta();
            }
            else
            {
                MessageBox.Show("No hay Datos seleccionado");
            }
        }

        private void retrasosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_Control_asistencia.Rows.Count > 0)
            {
                Program.isnuevo_Retraso = true;
                Datos_Retraso();
            }
            else
            {
                MessageBox.Show("No hay Datos seleccionado");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CONTROL_ASISTENCIA_DATOS fr = (CONTROL_ASISTENCIA_DATOS)Owner;
            //fr.TXTCODIGO_TURNO_X_RUTA.Text = dgv_Control_asistencia.CurrentRow.Cells[0].Value.ToString();
            DateTime minutos = Convert.ToDateTime(dgv_Control_asistencia.CurrentRow.Cells[1].Value.ToString());
            MessageBox.Show("hola " + minutos.ToString("mm:ss"));
            //this.Close();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            MEMORANDUM_DATOS fr = (MEMORANDUM_DATOS)Owner;
            fr.txt_Codigo.Text = dgv_Control_asistencia.CurrentRow.Cells[0].Value.ToString();
            fr.datetime_f_registro.Text = dgv_Control_asistencia.CurrentRow.Cells[1].Value.ToString();           
            this.Close();
        }

        private void CONTROL_ASISTENCIA_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
