using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Capa_Negocio;
using Capa_Datos;

namespace Sistema_Mercenarios
{
    public partial class Detalle_PersonalxRuta_Datos : Form
    {

        public string rep = "";
        public  DataTable DTDETALLE_VENTA;
        public static Detalle_PersonalxRuta_Datos formdgv;

        public Detalle_PersonalxRuta_Datos()
        {
            InitializeComponent();


            Detalle_PersonalxRuta_Datos.formdgv = this;
            this.CenterToScreen();
            CREARTABLA();
            CONFIGURAR_DATAGRID();           
        }
        /////CREAR TABLA DE PERSONAL
        public void CREARTABLA()
        {
            this.DTDETALLE_VENTA = new DataTable();
            this.DTDETALLE_VENTA.Columns.Add("CODIGO", System.Type.GetType("System.Int32"));
            this.DTDETALLE_VENTA.Columns.Add("NOMBRE", System.Type.GetType("System.String"));
            this.DTDETALLE_VENTA.Columns.Add("AP.PATERNO", System.Type.GetType("System.String"));
            this.DTDETALLE_VENTA.Columns.Add("AP.MATERNO", System.Type.GetType("System.String"));
            this.DTDETALLE_VENTA.Columns.Add("NRO.DOCUMENTO", System.Type.GetType("System.String"));

            dgv_Detalle_PersonalxRutas_detalle.DataSource = DTDETALLE_VENTA;


           
        }
        public void CONFIGURAR_DATAGRID() {
            var dato = dgv_Detalle_PersonalxRutas_detalle;
            dato.Columns[0].Width = 90;
            dato.Columns[1].Width = 150;
            dato.Columns[2].Width = 140;
            dato.Columns[3].Width = 140;
            dato.Columns[4].Width = 160;
        }
        /// <summary>
        /// metodo para traer datos al datagridview de la tabla personal
        public void CARGARDATOSPERSONAL(string[] VALOR)
        {
            string[] fila = { VALOR[0], VALOR[1], VALOR[2], VALOR[3], VALOR[4] };
            
            this.dgv_Detalle_PersonalxRutas_detalle.Rows.Add(fila);
            dgv_Detalle_PersonalxRutas_detalle.Refresh();
          
        }
        public bool validarRegistroNuevo(string id)
        {
            bool valor = true;
            foreach (DataGridViewRow fila in dgv_Detalle_PersonalxRutas_detalle.Rows)
            {
                if (fila.Cells["CODIGO"].Value.ToString() == id)
                {
                    valor = false;
                    break;
                }
            }
            return valor;
        }
        /// </summary>

        private static Detalle_PersonalxRuta_Datos _instancias;

        public static Detalle_PersonalxRuta_Datos Instancias
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

        public static Detalle_PersonalxRuta_Datos Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Detalle_PersonalxRuta_Datos();
            }
            return Instancias;
        }
       
        private void Detalle_PersonalxRuta_Datos_Load(object sender, EventArgs e)
        {
            
            this.CenterToScreen();

            if (Program.ismodificarDetalleRuta == true)
            {
                groupBox1.Enabled = true;
                if (txt_codigo_ruta.Text != string.Empty)
                {
                    MOSTRARPERSONAL();
                }
                lbl_Titulo.Text = "EDITAR DATOS";
                //mostrar();                
            }
            else if (Program.isnuevoDetalleRuta == true)
            {
                groupBox1.Enabled = true;
                LimpiarTxt();
                lbl_Titulo.Text = "REGISTRAR DATOS";
            }
            else {
                if (txt_codigo_ruta.Text != string.Empty)
                {
                    MOSTRARPERSONAL();
                }
                btn_Guardar.Visible = false;
                lbl_Titulo.Text = "CONSULTAR DATOS";
            }
            //   CREARTABLA();
            CONFIGURAR_DATAGRID();
            
        }
       
       
        

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (Program.ismodificarDetalleRuta == true)
            {
                Program.ismodificarDetalleRuta = false;
            }
            else if (Program.isnuevoDetalleRuta == true)
            {
                Program.isnuevoDetalleRuta = false;

            }
            Instancias = null;
            this.Close();
           
        }

        private void Detalle_PersonalxRuta_Datos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Detalle_PersonalxRuta.formdgv.Mostrar_Asignacion();
            this.Refresh();
        }

        public void LimpiarTxt()
        {
            txt_codigo_DETALLE.Text = string.Empty;
            cb_Estado.Text = "Valido";
            txt_codigo_ruta.Text = string.Empty;
            txt_nombre_ruta.Text = string.Empty;
            txt_observaciones.Text = string.Empty;
        }
        string resp = "";
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txt_codigo_ruta.Text == string.Empty || dgv_Detalle_PersonalxRutas_detalle.Rows.Count < 1)
            //    {
            //        MessageBox.Show("Porfavor llene los campos obligatorios");
            //    }
            //    else
            //    {
            //        if (Program.isnuevoDetalleRuta == true)
            //        {

            //            //resp = Capa_Negocio.N_USUARIOS.ELIMINAR_ASIGNACION_PERMISO_IDUSUARIO(txtvodigo.Text);
            //            foreach (DataGridViewRow item in dgv_Detalle_PersonalxRutas_detalle.Rows)
            //            {
            //              //  resp = Capa_Negocio.N_Asignacion_Rutas.REGISTRAR_USUARIO_DETALLE_RUTAS(Convert.ToInt32(txt_codigo_ruta.Text), Convert.ToInt32(item.Cells["CODIGO"].Value), txt_observaciones.Text, "V");
            //                //resp = Capa_Negocio.N_AuxiliarDetalle_Ruta.RegistrarAxiliar(Convert.ToInt32(txt_codigo_ruta.Text));
            //            }
            //          //  resp = Capa_Negocio.N_AuxiliarDetalle_Ruta.RegistrarAxiliar(Convert.ToInt32(txt_codigo_ruta.Text));
            //        }
            //        else if (Program.ismodificarDetalleRuta == true)
            //        {
            //            //   resp = Capa_Negocio.N_AuxiliarDetalle_Ruta.EditarAuxilia(Convert.ToInt32(txt_codigo.Text));
            //            foreach (DataGridViewRow item in dgv_Detalle_PersonalxRutas_detalle.Rows)
            //            {
            //                //resp = Capa_Negocio.N_Asignacion_Rutas.REGISTRAR_USUARIO_DETALLE_RUTAS(Convert.ToInt32(txt_codigo_ruta.Text), Convert.ToInt32(item.Cells["CODIGO"].Value), txt_observaciones.Text, "V");
            //                //resp = Capa_Negocio.N_AuxiliarDetalle_Ruta.RegistrarAxiliar(Convert.ToInt32(txt_codigo_ruta.Text));
            //            }
            //            // resp = Capa_Negocio.N_AuxiliarDetalle_Ruta.RegistrarAxiliar(Convert.ToInt32(txt_codigo_ruta.Text));
            //        }

            //        if (resp.Equals("OK"))
            //        {
            //            MessageBox.Show("SE REGISTRO DE FORMA CORRECTA LOS PERMISOS");
            //        }
            //        //  Frm_Pantalla_principal o = Frm_Pantalla_principal.Get_instancias();
            //        // o.PRIVILEGIOS_MIO();
            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{
            //    if (txt_codigo_ruta.Text == string.Empty || dgv_Detalle_PersonalxRutas.Rows.Count < 1)
            //    {
            //        MessageBox.Show("Porfavor llene los campos obligatorios");
            //    }
            //    else
            //    {
            //        if (Program.isnuevoDetalleRuta == true)
            //        {
            //            string estado = "";
            //            if (cb_Estado.Text == "Valido")
            //            {
            //                estado = "V";
            //            }
            //            else
            //            {
            //                estado = "A";
            //            }

            //           // rep = N_Asignacion_Rutas.Registrar(estado, txt_observaciones.Text, Convert.ToInt32(txt_codigo_ruta.Text), Detalle());

            //        }
            //        if (Program.ismodificarDetalleRuta == true)
            //        {
            //         //   rep = N_Asignacion_Rutas.Editar(Convert.ToInt32(txt_codigo.Text), txt_observaciones.Text, Convert.ToInt32(txt_codigo_ruta.Text), Detalle());
            //        }

            //        if (rep.Equals("ok"))
            //        {

            //            if (Program.ismodificarDetalleRuta == true)
            //            {
            //                MessageBox.Show("Editado correctamente");
            //            }
            //            if (Program.isnuevoDetalleRuta == true)
            //            {
            //                MessageBox.Show("Registrado correctamente");
            //            }

            //        }
            //        else
            //        {
            //            MessageBox.Show(rep);
            //        }

            //        //this.dgv_Detalle_PersonalxRutas.Rows.Clear();
            //        Program.isnuevoDetalleRuta = false;
            //        Program.ismodificarDetalleRuta = false;
            //        Instancias = null;

            //        this.Close();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private int[] Detalle()
        {
            int[] reg = new int[20];
            int f = 0;
            foreach (DataGridViewRow row in dgv_Detalle_PersonalxRutas_detalle.Rows)
            {
                reg[f] = Convert.ToInt32(row.Cells["CODIGO"].Value.ToString());
                f++;
            }
            return reg;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Program.ismodificarDetalleRuta = false;
            Program.isnuevoDetalleRuta = false;
            Instancias = null;
            this.Close();
            
        }

        private void cb_Estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btn_buscar_rubro_Click(object sender, EventArgs e)
        {
            Gestion_Rutas frm = new Gestion_Rutas();

            frm.menustpNUEVO.Visible = false;
            frm.ms_Eliminar.Visible = false;
            frm.ms_Editar.Visible = false;
            frm.ms_CambiarEstado.Visible = false;
            frm.informesToolStripMenuItem.Visible = false;

            frm.btn_seleccionar.Visible = true;
            frm.ShowDialog();
        }

        private void txt_nombre_ruta_TextChanged(object sender, EventArgs e)
        {
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {

            Personal frm = new Personal();

            frm.ms_Nuevo.Visible = false;
            frm.ms_Eliminar.Visible = false;
            frm.ms_Editar.Visible = false;
            frm.ms_CambiarEstado.Visible = false;
            frm.informesToolStripMenuItem.Visible = false;

            frm.btn_detalle_ruta.Visible = true;

            frm.ShowDialog();
        }

      
      

        private void btn_quitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dgv_Detalle_PersonalxRutas_detalle.CurrentCell.RowIndex;

                this.dgv_Detalle_PersonalxRutas_detalle.Rows.RemoveAt(indiceFila);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Seleccione un registro");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void MOSTRARPERSONAL()
        {
           dgv_Detalle_PersonalxRutas_detalle.DataSource = Capa_Negocio.N_Detalle_Asignacion_Rutas.Consulta_persona_mostrar(Convert.ToInt32(txt_codigo_DETALLE.Text));

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rpt = "";

                if (txt_codigo_ruta.Text == string.Empty)
                {
                    MessageBox.Show("porfavor rellene los campos obligaorios");
                }
                else
                {
                    if (Program.isnuevoDetalleRuta)
                    {
                        if (dgv_Detalle_PersonalxRutas_detalle.Rows.Count <= 0)
                        {
                            MessageBox.Show("POR FAVOR SELECCIONE EL PERSONAL");
                            btn_agregar.Focus();
                        }
                        else {
                            rpt = N_Detalle_Asignacion_Rutas.Registra_Reserva("V", txt_observaciones.Text, "V", Convert.ToInt32(txt_codigo_ruta.Text), DTDETALLE_VENTA);
                        }
                    }
                    else if(Program.ismodificarDetalleRuta)
                    {
                        //aqui va el de editar
                        //rpt = Capa_Negocio.N_Detalle_Asignacion_Rutas.eliminar(Convert.ToInt32(txt_codigo_DETALLE.Text));
                        //rpt = N_Detalle_Asignacion_Rutas.Registra_Reserva("V", txt_observaciones.Text, "V", Convert.ToInt32(txt_codigo_ruta.Text), DTDETALLE_VENTA);
                    }
                    if (rpt.Equals("ok"))
                    {
                        if (Program.isnuevoDetalleRuta)
                        {
                            MessageBox.Show("Se Registro de Forma correcta");
                            Instancias = null;
                            Program.isnuevoDetalleRuta = false;
                            this.Close();
                        }
                        else
                        {
                            //para el mensaje de editar
                            MessageBox.Show("se edito de forma correcta");
                                Instancias = null;
                            Program.ismodificarDetalleRuta = false;
                            this.Close();
                        }
                    }
                    else
                    {
                     //   MessageBox.Show(rpt);
                    }

                    //Program.ismodificarDetalleRuta = false;

                    //this.Close();
                    //  this.Isnuevo = false;
                    //this.IsModificar = false;
                    Detalle_PersonalxRuta.formdgv.Mostrar_Asignacion();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MOSTRARPERSONAL();
        }        
    }
}
