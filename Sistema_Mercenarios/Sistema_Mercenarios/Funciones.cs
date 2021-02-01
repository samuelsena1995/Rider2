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
    public partial class Funciones : Form
    {
        public string rep = "";
        public string rep2 = "";

        public static Funciones formdgv;

        public Funciones()
        {
            InitializeComponent();
            Funciones.formdgv = this;
            this.CenterToScreen();
        }

        private void Funciones_Load(object sender, EventArgs e)
        {
            Mostrar_Funciones();

            Program.isnuevoUsuario = false;
            Program.ismodificarUsuario = false;

            TamañoDGV();
        }
        public void TamañoDGV()
        {
            dgv_funciones.ColumnHeadersHeight = 40;

            dgv_funciones.Columns["CODIGO"].Width = 20;
            dgv_funciones.Columns["MODULO"].Width = 40;
            dgv_funciones.Columns["DESCRIPCION"].Width = 30;
            dgv_funciones.Columns["ESTADO"].Width = 100;
        }
        public void Mostrar_Funciones()
        {
            // dgv_funciones.DataSource = N_Funciones.Consultar_Todo();

            // lbl_NroRegistros.Text = Convert.ToString(dgv_funciones.Rows.Count) + " registros encontrados";
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (Program.isnuevaFuncion == true)
                {
                    rep = N_Asignacion_Funciones.Registrar(txt_Codigo.Text);

                    if (rep.Equals("ok"))
                    {
                        for (int i = dgv_funciones.RowCount - 1; i >= 0; i--)
                        {
                            DataGridViewRow row = dgv_funciones.Rows[i];
                            if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                            {

                            }
                        }
                    }

                }
                if (Program.ismodificarDetalleRuta == true)
                {
                    //rep = N_Asignacion_Funciones.Editar(Convert.ToInt32(txt_codigo.Text), txt_observaciones.Text, Convert.ToInt32(txt_codigo_ruta.Text), Detalle());
                }

                if (rep.Equals("ok"))
                {

                    if (Program.ismodificarDetalleRuta == true)
                    {
                        MessageBox.Show("Editado correctamente");
                    }
                    if (Program.isnuevoDetalleRuta == true)
                    {
                        MessageBox.Show("Registrado correctamente");
                    }

                }
                else
                {
                    MessageBox.Show(rep);
                }

                //this.dgv_Detalle_PersonalxRutas.Rows.Clear();
                Program.isnuevoDetalleRuta = false;
                Program.ismodificarDetalleRuta = false;
                //Instancias = null;

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
