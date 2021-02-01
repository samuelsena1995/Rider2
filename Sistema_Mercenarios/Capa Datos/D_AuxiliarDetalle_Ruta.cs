using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace Capa_Datos
{
  public  class D_AuxiliarDetalle_Ruta
    {

        private string estado;

        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
        }


        private int _codigoAuxiliar;
        private int _codigoRuta;

        public int _CODIGORUTA
        {
            get { return _codigoRuta; }
            set { _codigoRuta = value; }
        }

        public int _CODIGOAUXILIAR
        {
            get { return _codigoAuxiliar; }
            set { _codigoAuxiliar = value; }
        }


        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        /// <summary>

        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        public string Insertar(D_AuxiliarDetalle_Ruta reser,
        List<D_Detalle_Asignacion_Rutas> detalle_reserva)
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
                Sqlcmd.CommandText = "[RegistrarAuxiliar2]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parValor = new SqlParameter();
                parValor.ParameterName = "@valor";
                parValor.SqlDbType = SqlDbType.Int;
                parValor.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(parValor);

                Sqlcmd.Parameters.AddWithValue("@ESTADO", reser._Estado);
                rpta = Sqlcmd.ExecuteNonQuery() == 1 ? "ok" : "no se puedo realizar a consulta";
                if (rpta.Equals("ok"))
                {
                    this._CODIGOAUXILIAR = Convert.ToInt32(Sqlcmd.Parameters["@valor"].Value);
                    foreach (D_Detalle_Asignacion_Rutas item in detalle_reserva)
                    {
                        item._CodigoAuxiliar = this._CODIGOAUXILIAR;
                        rpta = item.InsertarDetalle(item, ref SqlCn, ref Sqltra);
                        if (!rpta.Equals("ok"))
                        {
                            break;
                        }
                    }
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
