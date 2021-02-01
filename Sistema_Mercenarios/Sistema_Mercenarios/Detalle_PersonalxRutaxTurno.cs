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
    public partial class Detalle_PersonalxRutaxTurno : Form
    {
        public Detalle_PersonalxRutaxTurno()
        {
            InitializeComponent();
        }

        private void Detalle_PersonalxRutaxTurno_Load(object sender, EventArgs e)
        {
            if (txt_codigo_ruta.Text != string.Empty)
            {
                MOSTRAR_PERSONAL(txt_codigo_ruta.Text);
            }
            if (Program.ismodificarPersonalTurnoRuta == true)
            {
                        
                lbl_Titulo.Text = "EDITAR DATOS";
                //mostrar();                
            }
            else if (Program.isnuevoPersonalTurnoRuta == true)
            {
                groupBox1.Enabled = true;              
                lbl_Titulo.Text = "REGISTRAR DATOS";
            }
            else
            {
                groupBox1.Enabled = false;                                
                lbl_Titulo.Text = "CONSULTAR DATOS";
            }
        }
        public void MOSTRAR_PERSONAL(string TXTRUTA) {
            dgv_Detalle_PersonalxRutas.DataSource = Capa_Negocio.N_Detalle_Asignacion_Rutas.Consulta_persona_mostrar(Convert.ToInt32(txt_codigo_ruta.Text));
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Instancias = null;
        }
        #region INSTANCIAS
        private static Detalle_PersonalxRutaxTurno _instancias;

        public static Detalle_PersonalxRutaxTurno Instancias
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
        public static Detalle_PersonalxRutaxTurno Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Detalle_PersonalxRutaxTurno();
            }
            return Instancias;
        }
        #endregion

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpt = "";

                if (txt_codigo_turno.Text == string.Empty)
                {
                    MessageBox.Show("porfavor rellene los campos obligaorios");
                }
                else
                {
                    if (Program.isnuevoPersonalTurnoRuta)
                    {       
                        rpt = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Registra_PERSONAL_TURNO_DERUTA("V",txt_observaciones.Text,"V",Convert.ToInt32(txt_codigo_ruta.Text),Convert.ToInt32(txt_codigo_turno.Text),dtinicio.Value,dtfin.Value);
                    }
                    else if(Program.ismodificarPersonalTurnoRuta)
                    {
                        rpt = Capa_Negocio.N_DETALLE_PERSONAL_TURNO_RUTA.Editar(Convert.ToInt32(txt_codigo_detalle.Text), Convert.ToInt32(txt_codigo_ruta.Text),
                            Convert.ToInt32(txt_codigo_turno.Text), dtinicio.Value, dtfin.Value, txt_observaciones.Text);
                    }
                    if (rpt.Equals("ok"))
                    {
                        rpt = Capa_Negocio.N_Usuarios.EditaR_Audi(Convert.ToString(Program.ID_USUARIO_GLOBAL), Program.IP(), Program.NOMBRECOMPLETO_USUARIO_GLOBAL);
                        if (Program.isnuevoPersonalTurnoRuta)
                        {                            
                            MessageBox.Show("Se Registro de Forma correcta");
                            Program.isnuevoPersonalTurnoRuta = false;
                            Instancias = null;
                            this.Close();
                        }
                        else
                        {
                            //para el mensaje de editar
                            MessageBox.Show("Se edito de Forma correcta");
                            Program.ismodificarPersonalTurnoRuta = false;
                            Instancias = null;
                            this.Close();
                        }
                    }
                    else
                    {
                        //MessageBox.Show(rpt);
                    }
                    detalle_x_personal.detalle_PersonalxRutaxTurno_Mostrar.frm.MOSTRAR();
                    //  this.Isnuevo = false;
                    //this.IsModificar = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_buscar_rubro_Click(object sender, EventArgs e)
        {
            Turnos d = new Turnos();
            AddOwnedForm(d);
            d.btn_seleccionar.Visible = true;
            d.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Instancias = null;
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Gestion_Rutas d = new Gestion_Rutas();
            Detalle_PersonalxRuta d = new Detalle_PersonalxRuta();
            AddOwnedForm(d);
            d.btn_seleccionar.Visible = true;
            d.Show();
        }
    }
}
