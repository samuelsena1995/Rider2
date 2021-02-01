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
    public partial class Personal : Form
    {

       public static Personal formdgv;

        public string _estado_ = "T";
        public string _tipo_ = "Nombre(s)";

        public Personal()
        {
            InitializeComponent();
         Personal.formdgv = this;
            MOSTRARMENU_PERMISO();
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            // dgv_personal.DataSource = N_Personal.Buscar(txt_Busqueda.Text, _estado_, _tipo_);
            if (btn_detalle_ruta.Visible == true)
            {
                MOSTRAR_PERSONAL_BUTTON2();
            }
            else if (BTN_MEMORANDUM.Visible == true)
            {
                mostrar_Personal_Memorandum();
            }
            else if (BTN_SELECCIONAR_PERMISOS.Visible == true) {
                mostrar_Personal_PERMISOS();
            }
            else
            {
                Mostrar_Personal();
            }
       

            Program.isnuevoPersonal = false;
            Program.ismodificarPersonal = false;

            TamañoDGV();
        }
        /// <summary>
        /// para ocultar los botones del menu si el usuario tiene esos permisos
        /// este if hace que los botones del menu se VEA o se OCULTE ya que por defecto viene VISIBLE=FALSE
        /// poner lo mismo que tenes en tu scrpit en sql 
        /// solo para este formulario  es codigo
        /// para los demas formalrio copiar este medoto MOSTRARMENU_PERMISO
        /// e iniciar en el load para que funcione

        public void MOSTRARMENU_PERMISO()
        {
            foreach (DataGridViewRow item in Menu_Principal.frm.dataGridView2.Rows)
            {
                if (item.Cells[0].Value.ToString() == "pers01")
                {
                    ms_Nuevo.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "pers02")
                {
                    ms_Editar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "pers03")
                {
                    ms_Eliminar.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "pers04")
                {
                    ms_CambiarEstado.Visible = true;
                }
                else if (item.Cells[0].Value.ToString() == "pers05")
                {
                    informesToolStripMenuItem.Visible = true;
                }               
            }


        }
        /// </summary>

        private static Personal _instancias;

        public static Personal Instancias
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

        public static Personal Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Personal();
            }
            return Instancias;
        }

        public void TamañoDGV()
        {
            dgv_personal.ColumnHeadersHeight = 40;

            dgv_personal.Columns["CODIGO"].Width = 12;
            dgv_personal.Columns["F_REGISTRO"].Width = 20;
            dgv_personal.Columns["NOMBRE"].Width = 15;
            dgv_personal.Columns["AP_PATERNO"].Width = 15;
            dgv_personal.Columns["AP_MATERNO"].Width = 15;
            dgv_personal.Columns["NRO_DOCUMENTO"].Width = 15;
            dgv_personal.Columns["T_DOCUMENTO"].Width = 10;
            dgv_personal.Columns["ESTADO"].Width = 80;


        }
        public void Mostrar_Personal()
        {
            //if (button2.Visible == false)
            //{
                dgv_personal.DataSource = N_Personal.Consultar_Todo();

                lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            //}          
            //else
            //{
            //    // if (btn_seleccionar.Visible == true)
            //    if (button2.Visible == true)
            //    {
                    //dgv_personal.DataSource = N_Personal.Consultar_No_Asignados();

                    //lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            //    }
            //}
        
        }
        public void MOSTRAR_PERSONAL_BUTTON2()
        {
            if (btn_detalle_ruta.Visible == true)
            {
                dgv_personal.DataSource = N_Personal.Consultar_No_Asignados();

                lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            }
        }
        public void mostrar_Personal_Memorandum()
        {
            if (BTN_MEMORANDUM.Visible == true)
            {
                dgv_personal.DataSource = N_Personal.sp_Personal_No_Asignado_MEMORANDUM();

                lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            }
            //else
            //{
            //    dgv_personal.DataSource = N_Personal.sp_Personal_No_Asignado_MEMORANDUM();

            //    lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            //}
        }
        public void mostrar_Personal_PERMISOS()
        {
            if (BTN_SELECCIONAR_PERMISOS.Visible == true)
            {
                dgv_personal.DataSource = N_Personal.sp_Personal_No_Asignado_MEMORANDUM();

                lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            }
            //else
            //{
            //    dgv_personal.DataSource = N_Personal.sp_Personal_No_Asignado_MEMORANDUM();

            //    lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
            //}
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Program.isnuevoPersonal = true;

            Personal_Datos obj = Personal_Datos.Get_instancia();
            obj.ShowDialog();
        }

        private void ms_Editar_Click(object sender, EventArgs e)
        {
          
            if (dgv_personal.Rows.Count > 0)
            {
                if (dgv_personal.CurrentRow.Cells["ESTADO"].Value.ToString() == "Anulado")
                {
                    MessageBox.Show("No se puede Editar el registro porque está ANULADO");
                }
                else
                {
                    Program.ismodificarPersonal = true;
                    this.Datos();
                }
              
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
                if (dgv_personal.Rows.Count > 0)
                {


                    DialogResult Opcion;
                    Opcion = MessageBox.Show("¿Desea eliminar el registro?", "Sistema_Mercenarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (Opcion == DialogResult.OK)
                    {
                        string Codigo;
                        string Rpta = "";
                        foreach (DataGridViewRow row in dgv_personal.Rows)
                        {
                            if (row.Selected)
                            {
                                Codigo = Convert.ToString(row.Cells["CODIGO"].Value);
                                Rpta = N_Personal.Eliminar(Convert.ToInt32(Codigo));
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

                        Mostrar_Personal();
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
            Mostrar_Personal();

            txt_Busqueda.Text = string.Empty;
        }

        private void dgv_personal_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_personal.Rows.Count > 0)
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
            dgv_personal.DataSource = N_Personal.Buscar(txt_Busqueda.Text, _estado_, _tipo_);

            if (txt_Busqueda.Text == string.Empty)
            {
                Mostrar_Personal();
            }

            lbl_NroRegistros.Text = Convert.ToString(dgv_personal.Rows.Count) + " registros encontrados";
        }

        private void ms_CambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgv_personal.Rows.Count > 0)
                {
                    string _estado = "";
                    DialogResult Opcion;

                    if (this.dgv_personal.CurrentRow.Cells["ESTADO"].Value.ToString() == "Valido")
                    {
                        Opcion = MessageBox.Show("¿Desea cambiar el estado a <Anulado>?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (Opcion == DialogResult.OK)
                        {
                            string Rpta = "";
                            _estado = "A";

                            DateTime _f_retiro = DateTime.Now;

                            Rpta = N_Personal.CambiarEstado(Convert.ToInt32(dgv_personal.CurrentRow.Cells["CODIGO"].Value.ToString()), _estado, _f_retiro);

                            if (Rpta.Equals("ok"))
                            {
                                // MessageBox.Show("Se eliminó de forma correcta el Registro");

                            }
                            else
                            {
                                MessageBox.Show(Rpta);
                            }

                            Mostrar_Personal();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personal retirado, no puede cambiar el estado");
                        _estado = "V";
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

        private void cb_tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo.Text == "Nombre(s)")
            {
                _tipo_ = "Nombre(s)";
            }
            if (cb_tipo.Text == "Ap_paterno")
            {
                _tipo_ = "Ap_paterno";
            }
            if (cb_tipo.Text == "Ap_materno")
            {
                _tipo_ = "Ap_materno";
            }
            if (cb_tipo.Text == "Nro_documento")
            {
                _tipo_ = "Nro_documento";
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
        public void Datos()
        {
            DataTable Datos = N_Personal.Consulta_Id(Convert.ToInt32(this.dgv_personal.CurrentRow.Cells["CODIGO"].Value.ToString()));

            if (Datos.Rows.Count < 1)
            {
                MessageBox.Show("ERROR", "SISTEMA MERCENARIOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Personal_Datos frm = Personal_Datos.Get_instancia();

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
                frm.txt_nombres.Text = Datos.Rows[0][3].ToString();
                frm.txt_ap_paterno.Text = Datos.Rows[0][4].ToString();
                frm.txt_ap_materno.Text = Datos.Rows[0][5].ToString();
                frm.dateTimePicker_f_nacimiento.Value = Convert.ToDateTime(Datos.Rows[0][6].ToString());

                frm.txt_nro_documento.Text = Datos.Rows[0][7].ToString();
                frm.cb_tipo_documento.Text = Datos.Rows[0][8].ToString();
                frm.cb_estado_civil.Text = Datos.Rows[0][9].ToString();
                frm.cb_sexo.Text = Datos.Rows[0][10].ToString();
                frm.txt_telefono.Text = Datos.Rows[0][11].ToString();

                frm.txt_Descripcion.Text = Datos.Rows[0][12].ToString().Trim();
                frm.cb_zona.Text = Datos.Rows[0][13].ToString();            

                if (Datos.Rows[0][14].ToString() != string.Empty)
                {
                    frm.label11.Visible = true;
                    frm.dateTime_f_retiro.Visible = true;
                    frm.dateTime_f_retiro.Value = Convert.ToDateTime(Datos.Rows[0][14].ToString());
                }
                else
                {
                    frm.label11.Visible = false;
                    frm.dateTime_f_retiro.Visible = false;
                    // frm.dateTime_f_retiro.Value = Convert.ToDateTime(Datos.Rows[0][17].ToString());
                }

                frm.txt_cod_cargo.Text = Datos.Rows[0][15].ToString();
                frm.txt_cargo.Text = Datos.Rows[0][16].ToString();



                if (Program.isnuevoPersonal == true || Program.ismodificarPersonal == true)
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

        private void listadoDeRubrosDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personal_Filtro_Reportes rep = new Personal_Filtro_Reportes();

            rep.ShowDialog();
        }

        private void btn_seleccionar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgv_personal.SelectedRows)
            {
                string[] Codigo=new string[0];
                string co, mombre, paterno, materno, numerodocuento;
                
                Codigo[0] = dgv_personal.CurrentRow.Cells[0].Value.ToString();

                co = dgv_personal.CurrentRow.Cells[0].Value.ToString();
                mombre = dgv_personal.CurrentRow.Cells[2].Value.ToString();
                paterno = dgv_personal.CurrentRow.Cells[3].Value.ToString();
                materno = dgv_personal.CurrentRow.Cells[4].Value.ToString();
                numerodocuento = dgv_personal.CurrentRow.Cells[5].Value.ToString();      

                Detalle_PersonalxRuta_Datos pasar = Detalle_PersonalxRuta_Datos.Get_instancia();

                foreach (Form km in Application.OpenForms)
                {
                    if (km.Name == "Detalle_PersonalxRuta_Datos")
                    {
                        pasar = (Detalle_PersonalxRuta_Datos)km;
                        
                            pasar.dgv_Detalle_PersonalxRutas_detalle.Rows.Add(Codigo, mombre, paterno, materno, numerodocuento);
                            this.Close();
                            break;                       
                    }
                }
            }
        }

        /*public void metododepasardeFranklin()
        {
            if (dgv_personal.Rows.Count < 1)
            {
                MessageBox.Show("Seleccione un registro");

            }
            else
            {


                string[] valor1 = new string[5];

                valor1[0] = this.dgv_personal.CurrentRow.Cells["CODIGO"].Value.ToString();
                valor1[1] = this.dgv_personal.CurrentRow.Cells["NOMBRE"].Value.ToString();
                valor1[2] = this.dgv_personal.CurrentRow.Cells["AP_PATERNO"].Value.ToString();
                valor1[3] = this.dgv_personal.CurrentRow.Cells["AP_MATERNO"].Value.ToString();
                valor1[4] = this.dgv_personal.CurrentRow.Cells["NRO_DOCUMENTO"].Value.ToString();



                Detalle_PersonalxRuta_Datos obj9 = Detalle_PersonalxRuta_Datos.Get_instancia();

                if (obj9.validarRegistroNuevo(valor1[0]))
                {
                    if (obj9.dgv_Detalle_PersonalxRutas.Rows.Count < 1)
                    {

                        obj9.cargarRegistro(valor1);
                        this.Close();
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt = obj9.dgv_Detalle_PersonalxRutas.DataSource as DataTable;

                        DataRow fila;
                        fila = dt.NewRow();

                        fila["CODIGO"] = this.dgv_personal.CurrentRow.Cells["CODIGO"].Value.ToString();
                        fila["NOMBRE"] = this.dgv_personal.CurrentRow.Cells["NOMBRE"].Value.ToString();
                        fila["AP_PATERNO"] = this.dgv_personal.CurrentRow.Cells["AP_PATERNO"].Value.ToString();
                        fila["AP_MATERNO"] = this.dgv_personal.CurrentRow.Cells["AP_MATERNO"].Value.ToString();
                        fila["NRO_DOCUMENTO"] = this.dgv_personal.CurrentRow.Cells["NRO_DOCUMENTO"].Value.ToString();

                        dt.Rows.Add(fila);

                        obj9.dgv_Detalle_PersonalxRutas.DataSource = dt;

                        //  obj9.cargarRegistro(valor1);
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Ya se selecciono el registro");
                }
            }
        }*/

        private void dgv_personal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valor1 = new string[5];

            valor1[0] = this.dgv_personal.CurrentRow.Cells[0].Value.ToString();
            valor1[1] = this.dgv_personal.CurrentRow.Cells[2].Value.ToString();
            valor1[2] = this.dgv_personal.CurrentRow.Cells[3].Value.ToString();
            valor1[3] = this.dgv_personal.CurrentRow.Cells[4].Value.ToString();
            valor1[4] = this.dgv_personal.CurrentRow.Cells[5].Value.ToString();



            Detalle_PersonalxRuta_Datos obj9 = Detalle_PersonalxRuta_Datos.Get_instancia();

            if (obj9.validarRegistroNuevo(valor1[0]))
            {

                obj9.CARGARDATOSPERSONAL(valor1);
                this.Hide();
            }
            else
            {
                MessageBox.Show("ya se selecciono el registro...");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Detalle_PersonalxRuta_Datos ob = Detalle_PersonalxRuta_Datos.Get_instancia();

            DataRow item = Detalle_PersonalxRuta_Datos.formdgv.DTDETALLE_VENTA.NewRow();
            item[0] = dgv_personal.CurrentRow.Cells[0].Value.ToString();
            item[1] = dgv_personal.CurrentRow.Cells[2].Value.ToString();
            item[2] = dgv_personal.CurrentRow.Cells[3].Value.ToString();
            item[3] = dgv_personal.CurrentRow.Cells[4].Value.ToString();
            item[4] = dgv_personal.CurrentRow.Cells[5].Value.ToString();
            if (ob.validarRegistroNuevo(item[0].ToString()))
            {
                Detalle_PersonalxRuta_Datos.formdgv.DTDETALLE_VENTA.Rows.Add(item);
                this.Close();
            }
            else {
                MessageBox.Show("ya se selecciono el registro...");
            }

            //dgv_Detalle_PersonalxRutas_detalle
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BTN_MEMORANDUM_Click(object sender, EventArgs e)
        {
            MEMORANDUM_DATOS fr = (MEMORANDUM_DATOS)Owner;
            fr.txt_nombre_cargo.Text = dgv_personal.CurrentRow.Cells[2].Value.ToString() + " " + dgv_personal.CurrentRow.Cells[3].Value.ToString() + " " + dgv_personal.CurrentRow.Cells[4].Value.ToString();
            fr.lblCodigo_Persona.Text = dgv_personal.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }

        private void BTN_SELECCIONAR_PERMISOS_Click(object sender, EventArgs e)
        {
            PERMISO_DATOS fr = (PERMISO_DATOS)Owner;
            fr.txt_nombre_cargo.Text = dgv_personal.CurrentRow.Cells[2].Value.ToString()+" "+ dgv_personal.CurrentRow.Cells[3].Value.ToString()+" " + dgv_personal.CurrentRow.Cells[4].Value.ToString();
            fr.lblCodigo_Autorizado.Text = dgv_personal.CurrentRow.Cells[0].Value.ToString();
            this.Close();
        }
    }
}
