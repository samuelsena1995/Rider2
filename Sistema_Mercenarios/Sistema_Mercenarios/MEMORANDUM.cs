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
    public partial class MEMORANDUM : Form
    {
        public static MEMORANDUM frm;
        public MEMORANDUM()
        {
            InitializeComponent();
            frm = this;
        }

        private void ms_Nuevo_Click(object sender, EventArgs e)
        {
            Form ruta = this.MdiChildren.FirstOrDefault(y => y is MEMORANDUM_DATOS);
            if (ruta != null)
            {
                ruta.BringToFront();
                return;
            }
            Program.isnuevo_Memorandum = true;
            MEMORANDUM_DATOS obj = new MEMORANDUM_DATOS();
            obj.ShowDialog();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MEMORANDUM_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        public void mostrar() {
            dgv_Cargos.DataSource = Capa_Negocio.N_MEMORANDUM.MOSTRAR();
        }
    }
}
