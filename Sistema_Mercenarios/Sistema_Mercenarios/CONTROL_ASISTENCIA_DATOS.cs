using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Mercenarios
{
    public partial class CONTROL_ASISTENCIA_DATOS : Form
    {
        public CONTROL_ASISTENCIA_DATOS()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           detalle_x_personal.detalle_PersonalxRutaxTurno_Mostrar d = new detalle_x_personal.detalle_PersonalxRutaxTurno_Mostrar();
            AddOwnedForm(d);
            d.btn_seleccionar.Visible = true;
            d.Show();
        }

        private void CONTROL_ASISTENCIA_DATOS_Load(object sender, EventArgs e)
        {
            if (TXTCODIGORUTA.Text != string.Empty)
            {
                MOSTRAR_PERSONAL(TXTCODIGORUTA.Text);
            }

        }
        public void MOSTRAR_PERSONAL(string TXTRUTA)
        {
            dgv_Control_Asistencia.DataSource = Capa_Negocio.N_Detalle_Asignacion_Rutas.Consulta_persona_mostrar(Convert.ToInt32(TXTCODIGORUTA.Text));
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            
            try
            {
                string rpt = "";

                if (TXTCODIGO_TURNO_X_RUTA.Text == string.Empty)
                {
                    MessageBox.Show("porfavor rellene los campos obligaorios");
                }
                else
                {
                    if (Program.isnuevoControlAsistencia)
                    {
                        MessageBox.Show("hola");
                        rpt = Capa_Negocio.N_CONTROL_ASISTENCIA.Registrar(datetime_f_registro.Value, Convert.ToInt32(TXTCODIGO_TURNO_X_RUTA.Text), txt_Descripcion.Text, "V");
                    }
                    else if (Program.ismodificarControlASistencia)
                    {
                        //rpt = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Editar(Convert.ToInt32(txt_codigo_detalle.Text), Convert.ToInt32(txt_codigo_ruta.Text),
                        //    Convert.ToInt32(txt_codigo_turno.Text), dtinicio.Value, dtfin.Value, txt_observaciones.Text);
                    }
                    if (rpt.Equals("ok"))
                    {
                        if (Program.isnuevoControlAsistencia)
                        {
                            MessageBox.Show("Se Registro de Forma correcta");
                           // Program.isnuevoPersonalTurnoRuta = false;
                            //Instancias = null;
                            this.Close();
                        }
                        else
                        {
                            //para el mensaje de editar
                            MessageBox.Show("Se edito de Forma correcta");
                            Program.ismodificarPersonalTurnoRuta = false;
                            //Instancias = null;
                            this.Close();
                        }
                    }
                    else
                    {
                        //MessageBox.Show(rpt);
                    }
                  //  detalle_x_personal.detalle_PersonalxRutaxTurno_Mostrar.frm.MOSTRAR();
                    //  this.Isnuevo = false;
                    //this.IsModificar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gb_Datos_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_Control_Asistencia.DataSource = Capa_Negocio.N_Detalle_Asignacion_Rutas.Consulta_persona_mostrar(Convert.ToInt32(TXTCODIGORUTA.Text));
        }
    }
}
