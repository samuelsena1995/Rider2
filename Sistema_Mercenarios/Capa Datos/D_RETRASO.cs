using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_RETRASO
    {

        private int codigo_control;
        private DateTime fecha;
        private string minuto;
        private string observacion;

        public string OBSERVACION
        {
            get { return observacion; }
            set { observacion = value; }
        }

        public string MINUTO
        {
            get { return minuto; }
            set { minuto = value; }
        }

        public DateTime FECHA
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public int CODIGO_CONTROL
        {
            get { return codigo_control; }
            set { codigo_control = value; }
        }

        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;
        public D_RETRASO() { }

        public D_RETRASO(int cod,DateTime fec, string obse, string minut) {
            this.CODIGO_CONTROL = cod;
            this.FECHA = fec;
            this.OBSERVACION = obse;
            this.MINUTO = minut;
        }
        public string Registrar(D_RETRASO dato)
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
                Sqlcmd.CommandText = "RETRASO_REGISTRAR";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo_Control", dato.CODIGO_CONTROL);
                Sqlcmd.Parameters.AddWithValue("@Fecha", dato.FECHA);
                Sqlcmd.Parameters.AddWithValue("@Observacion", dato.OBSERVACION);
                Sqlcmd.Parameters.AddWithValue("@MinutosRetraso", dato.MINUTO);

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
