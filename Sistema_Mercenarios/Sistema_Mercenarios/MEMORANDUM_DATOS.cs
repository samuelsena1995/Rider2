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
    public partial class MEMORANDUM_DATOS : Form
    {
        public MEMORANDUM_DATOS()
        {
            InitializeComponent();
        }

        private void gb_Datos_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personal d = new Personal();
            AddOwnedForm(d);
            
            d.BTN_MEMORANDUM.Visible = true;
            d.Show();
        }
        #region INSTACIAS
        private static MEMORANDUM_DATOS _instancias;

        public static MEMORANDUM_DATOS Instancias
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
        public static MEMORANDUM_DATOS Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new MEMORANDUM_DATOS();
            }
            return Instancias;
        }
        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            CONTROL_ASISTENCIA d = new CONTROL_ASISTENCIA();
            AddOwnedForm(d);
            d.btn_seleccionar.Visible = true;
            d.Show();
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
                    if (Program.isnuevo_Memorandum)
                    {
                        rpt = Capa_Negocio.N_MEMORANDUM.Registrar(Convert.ToInt32(txt_Codigo.Text), datetime_f_registro.Value, txt_Descripcion.Text,Convert.ToInt32(lblCodigo_Persona.Text));
                    }
                    else if (Program.ismodificarControlASistencia)
                    {
                        //rpt = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Editar(Convert.ToInt32(txt_codigo_detalle.Text), Convert.ToInt32(txt_codigo_ruta.Text),
                        //    Convert.ToInt32(txt_codigo_turno.Text), dtinicio.Value, dtfin.Value, txt_observaciones.Text);
                    }
                    if (rpt.Equals("ok"))
                    {
                        if (Program.isnuevo_Memorandum)
                        {
                            MessageBox.Show("Se Registro de Forma correcta");
                            // Program.isnuevoPersonalTurnoRuta = false;
                            Instancias = null;
                            MEMORANDUM.frm.mostrar();
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
                    MEMORANDUM.frm.mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
