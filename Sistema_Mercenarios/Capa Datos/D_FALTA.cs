using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_FALTA
    {
        private int _codigo_control;
        private DateTime _fecha;
        private string _observacion;

        public string OBSERVACION
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        public DateTime FECHA
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public int CODIGO_CONTROL
        {
            get { return _codigo_control; }
            set { _codigo_control = value; }
        }


        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        public D_FALTA() { }
        public D_FALTA(int CODI, DateTime FEC, string OBSE) {
            this.CODIGO_CONTROL = CODI;
            this.FECHA = FEC;
            this.OBSERVACION = OBSE;
        }

        public string Registrar(D_FALTA dato)
        {
            try
            {
                SqlCn = new SqlConnection();
                Sqlcmd = new SqlCommand();

                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqltra = SqlCn.BeginTransaction();

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.Transaction = Sqltra;
                Sqlcmd.CommandText = "FALTA_REGISTRAR";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo_Control", dato.CODIGO_CONTROL);
                Sqlcmd.Parameters.AddWithValue("@Fecha_Arastrada", dato.FECHA);
                Sqlcmd.Parameters.AddWithValue("@Observacion", dato.OBSERVACION);

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo registrar";

                if (resp.Equals("ok"))
                {
                    Sqltra.Commit();
                }
                else
                {
                    Sqltra.Rollback();

                }
            }

            catch (Exception ex)
            {
                resp = ex.Message;

            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                    SqlCn.Close();
            }
            return resp;
        }
    }
}
