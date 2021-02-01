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
    public partial class RETRASO_DATOS : Form
    {
        public RETRASO_DATOS()
        {
            InitializeComponent();
        }

        private void RETRASO_DATOS_Load(object sender, EventArgs e)
        {

        }
        #region INSTACIAS
        private static RETRASO_DATOS _instancias;

        public static RETRASO_DATOS Instancias
        {
            get
            {
                return _instancias;
            }

            set
            {
                _instancias = value;
            }
        }
        public static RETRASO_DATOS Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new RETRASO_DATOS();
            }
            return Instancias;
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int MINUTO_CARGADO=Convert.ToInt32(LBLMINUTOS_RETRASO.Text);
            int MINUTOACTUAL=Convert.ToInt32(DateTime.Now.Minute.ToString());
            int RESULTADO=MINUTO_CARGADO-MINUTOACTUAL;
            //  MessageBox.Show(DateTime.Now.Minute.ToString());
            MessageBox.Show(RESULTADO.ToString());
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpt = "";

                if (txt_Codigo.Text == string.Empty)
                {
                    MessageBox.Show("porfavor rellene los campos obligaorios");
                }
                else
                {
                    if (Program.isnuevo_Retraso)
                    {
                        rpt = Capa_Negocio.N_RETRASO.Registrar(Convert.ToInt32(txt_Codigo.Text), datetime_f_registro.Value, txt_Descripcion.Text, LBLMINUTOS_RETRASO.Text);
                    }
                    else if (Program.ismodificarControlASistencia)
                    {
                        //rpt = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Editar(Convert.ToInt32(txt_codigo_detalle.Text), Convert.ToInt32(txt_codigo_ruta.Text),
                        //    Convert.ToInt32(txt_codigo_turno.Text), dtinicio.Value, dtfin.Value, txt_observaciones.Text);
                    }
                    if (rpt.Equals("ok"))
                    {
                        if (Program.isnuevo_Retraso)
                        {
                            MessageBox.Show("Se Registro de Forma correcta");
                            // Program.isnuevoPersonalTurnoRuta = false;
                            Instancias = null;
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

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (Program.isnuevo_Retraso == true) {
                Program.isnuevo_Retraso = false;
            }
            Instancias = null;
            Close();
        }
    }
}
