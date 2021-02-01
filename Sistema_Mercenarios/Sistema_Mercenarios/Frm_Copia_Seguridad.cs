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
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
namespace Sistema_Mercenarios
{
    public partial class Frm_Copia_Seguridad : Form
    {
        public Frm_Copia_Seguridad()
        {
            InitializeComponent();
        }

        private void btnRutaGuardar_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "SQL Backup files|*.bak";
            saveFileDialog1.FileName = "Sistema_Mercenarios" + "-" + DateTime.Today.Date.ToString("dd-MM-yyyy") + "-" + DateTime.Now.ToString("h.mm") + ".bak";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                txtRutaGuardar.Text = saveFileDialog1.FileName;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
          //  progressBar1.Value = 0;
            //string conString = "server=.;uid=sa;pwd=sa; database=Perfil_Usuario";

            SqlConnection conexion = new SqlConnection("SERVER=SAMUEL;uid=sa;pwd=sa; database=Sistema_Mercenarios");
            //conexion.ConnectionString = conString;


               string consulta = "BACKUP DATABASE [Sistema_Mercenarios] TO  DISK = N'" + txtRutaGuardar.Text + "' WITH NOFORMAT, NOINIT,  NAME = N'Perfil_Usuario-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
              SqlCommand sqlcmd = new SqlCommand(consulta, conexion);
            try
            {
               conexion.Open();             
               // Server dbserver = new Server(new ServerConnection(conexion));
               //Backup dbbackup = new Backup() { Action = BackupActionType.Database, Database = "Perfil_Usuario" };
               // dbbackup.Devices.AddDevice(txtRutaGuardar.Text, DeviceType.File);
               // dbbackup.Initialize = true;
                    sqlcmd.ExecuteNonQuery();

                //dbbackup.Complete += DBBackup_Complete;
                //dbbackup.PercentComplete += DBBackup_porcentaje;

                //dbbackup.SqlBackupAsync(dbserver);
               

                  MessageBox.Show("LA COPIA SE HA CREADO EXITOSAMENTE",".:SISTEMA MERCENARIO:.",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PORFAVOR CIERRE LA VENTANA DE COPIA DE SEGURIDAD");
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
        }

        private void DBBackup_porcentaje(object sender, PercentCompleteEventArgs e)
        {
            //throw new NotImplementedException();
            progressBar1.Invoke((MethodInvoker)delegate
            {
                progressBar1.Value = e.Percent;
                progressBar1.Update();
            });
            lblporcentaj.Invoke((MethodInvoker)delegate
            {
                lblporcentaj.Text = $"{e.Percent}%";
            });
        }

        private void DBBackup_Complete(object sender, ServerMessageEventArgs e)
        {
            //    throw new NotImplementedException();
            if (e.Error != null) {
                lblstatus.Invoke((MethodInvoker)delegate
                {
                    lblstatus.Text = e.Error.Message;
                });
            }
        }

        private void btnRutaRestaurar_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "SQL SERVER database BACKUP  FILES|*.bak";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaRestaurar.Text = openFileDialog1.FileName;
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("SERVER=SAMUEL;uid=sa;pwd=sa; database=Sistema_Mercenarios");
            string database = con.Database.ToString();
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            try
            {
                string sqlStmt2 = string.Format("ALTER DATABASE [Sistema_Mercenarios] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                bu2.ExecuteNonQuery();

                string sqlStmt3 = "USE MASTER RESTORE DATABASE [Sistema_Mercenarios] FROM DISK='" + txtRutaRestaurar.Text + "'WITH REPLACE;";
                SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                bu3.ExecuteNonQuery();

                string sqlStmt4 = string.Format("ALTER DATABASE [Sistema_Mercenarios] SET MULTI_USER");
                SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                bu4.ExecuteNonQuery();

                MessageBox.Show("database restoration done successefully");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
