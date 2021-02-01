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
namespace Sistema_Mercenarios
{
    public partial class Frm_Asignacion_Funciones : Form
    {
       public static Frm_Asignacion_Funciones frm;
        public Frm_Asignacion_Funciones()
        {
            InitializeComponent();
            frm = this;
        }

        private void Frm_Asignacion_Funciones_Load(object sender, EventArgs e)
        {
            
            SP_MOSTRAR_FUNCIONES();
            TamañoDGV();
        }
        public void SP_MOSTRAR_FUNCIONES() {

            dataGridView1.DataSource = Capa_Negocio.N_Usuarios.SP_MOSTRAR_FUNCIONES(txt_Codigo.Text);
        }
        public void TamañoDGV()
        {
            dataGridView1.ColumnHeadersHeight = 40;


            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 190;
          
        }



        string resp = "";
        private void btnRegistrarASigancion_Click(object sender, EventArgs e)
        {
            try
            {
                resp = Capa_Negocio.N_Usuarios.SP_ELIMINAR_USUARIO_ASIGNACION(txt_Codigo.Text); 
                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
                    {
                        resp = Capa_Negocio.N_Usuarios.SP_REGISTRAR_ASIGNACION_FUNCIONES( Convert.ToString(item.Cells["CODIGO"].Value), txt_Codigo.Text);                    
                    }
                }
                if (resp.Equals("OK"))
                {
                    MessageBox.Show("SE REGISTRO DE FORMA CORRECTA LOS PERMISOS");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ck = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Seleccionar"];

                ck.Value = !Convert.ToBoolean(ck.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Usuarios d = new Usuarios();
            AddOwnedForm(d);

            d.Show();
            //try
            //{
            //    if (dataGridView1.Rows.Count == 0)
            //    {
            //        return;
            //    }
            //    SqlConnection sql = new SqlConnection();
            //    sql.ConnectionString = Capa_Datos.D_Conexion.Conexion;
            //    sql.Open();
            //    string insertar = "insert into Asignacion_Funciones values(@IdFuncion,@IdUsuario)";
            //    SqlCommand sqlcm = new SqlCommand(insertar, sql);
            //    foreach (DataGridViewRow item in dataGridView1.Rows)
            //    {
            //        if (Convert.ToBoolean(item.Cells["Seleccionar"].Value))
            //        {
            //            sqlcm.Parameters.Clear();
            //            sqlcm.Parameters.AddWithValue("@IdFuncion", item.Cells["CODIGO"].Value);
            //            sqlcm.Parameters.AddWithValue("@IdUsuario", "1");                        
            //            sqlcm.ExecuteNonQuery();
            //        }
            //    }
            //    sql.Close();

            //    MessageBox.Show("se guardo ");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu_Principal.frm.MOSTRAR_Id_Permiso_Pantalla_principal();
            Menu_Principal.frm.Refresh();
            Menu_Principal.frm.PRIVILEGIOS_MIO();
            Close();

        }

        private void Frm_Asignacion_Funciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu_Principal.frm.MOSTRAR_Id_Permiso_Pantalla_principal();
            Menu_Principal.frm.Refresh();
            Menu_Principal.frm.PRIVILEGIOS_MIO();
        }

        private void Frm_Asignacion_Funciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu_Principal.frm.MOSTRAR_Id_Permiso_Pantalla_principal();
            Menu_Principal.frm.Refresh();
            Menu_Principal.frm.PRIVILEGIOS_MIO();
        }
        #region Instancia
        public static Frm_Asignacion_Funciones Instancias
        {
            get
            {
                return instancias;
            }

            set
            {
                instancias = value;
            }
        }

        // string nodos = "";
        private static Frm_Asignacion_Funciones instancias;

        public static Frm_Asignacion_Funciones Get_instancias()
        {
            if (Instancias == null)
            {
                Instancias = new Frm_Asignacion_Funciones();
            }
            return Instancias;
        }
        #endregion
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Seleccionar"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["Seleccionar"].Value = false;
                }
            }
        }
    }
}
