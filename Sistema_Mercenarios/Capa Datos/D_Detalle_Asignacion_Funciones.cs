using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Detalle_Asignacion_Funciones
    {
        private string _cod_asignacion;
        private string _cod_funcion;

        SqlCommand Sqlcmd;
        SqlConnection SqlCn;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        private string resp = "";

        #region
        public string Cod_asignacion
        {
            get
            {
                return _cod_asignacion;
            }

            set
            {
                _cod_asignacion = value;
            }
        }

        public string Cod_Funcion
        {
            get
            {
                return _cod_funcion;
            }

            set
            {
                _cod_funcion = value;
            }
        }
        #endregion

        public string Registrar(D_Detalle_Asignacion_Funciones dato)
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
                Sqlcmd.CommandText = "[sp_Detalle_Asignacion_Funciones_Registrar]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Id_asignacion", dato.Cod_asignacion);
                Sqlcmd.Parameters.AddWithValue("@Id_funcion", dato.Cod_Funcion);

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
        //public string Registrar()
        //{
        //    string resp = "";
        //    try
        //    {
        //        SqlCn = new SqlConnection();
        //        SqlCn.ConnectionString = D_Conexion.Conexion;
        //        SqlCn.Open();

        //        string consulta = "insert into Detalle_Asignacion_Funciones(Id_asignacion,Id_funcion)values(" + Cod_asignacion + "," + Cod_Funcion + ")";

        //        Sqlcmd = new SqlCommand(consulta, SqlCn);

        //        resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "no se ejecuto la consulta";

        //    }
        //    catch (Exception ex)
        //    {
        //        resp = ex.Message + "Metodo que produjo el error: " + ex.TargetSite;
        //    }
        //    finally
        //    {
        //        if (SqlCn.State == ConnectionState.Open)
        //            SqlCn.Close();
        //    }
        //    return resp;
        //}
        public string Eliminar(D_Detalle_Asignacion_Funciones dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "[sp_Detalle_Asignacion_Funciones_Eliminar]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Cod_asignacion);

                rpta = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo eliminar";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open) SqlCn.Close();
            }
            return rpta;
        }
        public DataTable Consulta_Id(D_Detalle_Asignacion_Funciones dato)
        {
            DataTable DtResultado = new DataTable("Funciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[sp_Detalle_Asignacion_Funciones_Consultar]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Cod_detalle";
                ParId.SqlDbType = SqlDbType.Char;
                ParId.Value = dato.Cod_asignacion;
                SqlCmd.Parameters.Add(ParId);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
