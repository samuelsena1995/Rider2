using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_PERMISO
    {
        private int _codigo_control;
        private DateTime _fecha;
        private string _observacion;
        private int _codigo_autorizacion;

        public int CODIGO_AUTORIZACION
        {
            get { return _codigo_autorizacion; }
            set { _codigo_autorizacion = value; }
        }


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

        public D_PERMISO() { }

        public D_PERMISO(int codi, DateTime fec, string obser, int codi_autorizacion) {
            this.CODIGO_CONTROL = codi;
            this.FECHA = fec;
            this.OBSERVACION = obser;
            this.CODIGO_AUTORIZACION = codi_autorizacion;
        }

        public string Registrar(D_PERMISO dato)
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
                Sqlcmd.CommandText = "PERMISO_REGISTRAR";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo_Control", dato.CODIGO_CONTROL);
                Sqlcmd.Parameters.AddWithValue("@Fecha", dato.FECHA);
                Sqlcmd.Parameters.AddWithValue("@Observacion", dato.OBSERVACION);
                Sqlcmd.Parameters.AddWithValue("@Autorizado_por", dato.CODIGO_AUTORIZACION);

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
