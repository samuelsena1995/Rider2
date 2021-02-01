using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_DETALLE_PERSONAL_TURNO_RUTA_AUXILIAR
    {
        private int _codigo_auxiliar;
        private string _estado;
        #region propiedades
        public string _ESTADO
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public int _CODIGO_AUXILIAR
        {
            get { return _codigo_auxiliar; }
            set { _codigo_auxiliar = value; }
        }
        #endregion


        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;


        public string Insertar(D_DETALLE_PERSONAL_TURNO_RUTA_AUXILIAR reser, /*List<D_DETALLE_PERSONAL_TURNO_RUTA>*/D_DETALLE_PERSONAL_TURNO_RUTA detalle_reserva)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqltra = SqlCn.BeginTransaction();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.Transaction = Sqltra;
                Sqlcmd.CommandText = "AUXILIAR_PERSONAL_TURNO_RUTA_REGISTRAR";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parValor = new SqlParameter();
                parValor.ParameterName = "@valor";
                parValor.SqlDbType = SqlDbType.Int;
                parValor.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(parValor);

                Sqlcmd.Parameters.AddWithValue("@ESTADO", reser._ESTADO);
                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "ok" : "no se puedo realizar a consulta";
                if (rpta.Equals("ok"))
                {
                    this._CODIGO_AUXILIAR = Convert.ToInt32(Sqlcmd.Parameters["@valor"].Value);
                  //  foreach (D_DETALLE_PERSONAL_TURNO_RUTA item in detalle_reserva)
                   // {
                        detalle_reserva._CODIGODETALLE_TURNO = this._CODIGO_AUXILIAR;
                        rpta = detalle_reserva.InsertarDetalle(detalle_reserva, ref SqlCn, ref Sqltra);
                        if (!rpta.Equals("ok"))
                        {                          
                        }
                    //}
                }
                if (rpta.Equals("ok"))
                {
                    Sqltra.Commit();
                }
                else
                {
                    Sqltra.Rollback();
                }
            }
            catch (Exception EX)
            {
                rpta = EX.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }
            return rpta;
        }

    }
}
