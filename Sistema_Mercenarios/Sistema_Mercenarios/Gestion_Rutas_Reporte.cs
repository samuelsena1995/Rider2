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
    public partial class Gestion_Rutas_Reporte : Form
    {

        public string _estado_ = "";
        public string _zona_ = "";
        public string _texto_ = "";

        public Gestion_Rutas_Reporte()
        {
            InitializeComponent();

            this.CenterToScreen();

        }

        private static Gestion_Rutas_Reporte _instancias;

        public static Gestion_Rutas_Reporte Instancias
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
        public static Gestion_Rutas_Reporte Get_instancia()
        {
            if (Instancias == null)
            {
                Instancias = new Gestion_Rutas_Reporte();
            }
            return Instancias;
        }

        private void Gestion_Rutas_Reporte_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            // TODO: esta línea de código carga datos en la tabla 'DataSet.sp_Rutas_Buscar' Puede moverla o quitarla según sea necesario.
            this.sp_Rutas_BuscarTableAdapter.Fill(this.DataSet.sp_Rutas_Buscar,_texto_,_estado_,_zona_);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
