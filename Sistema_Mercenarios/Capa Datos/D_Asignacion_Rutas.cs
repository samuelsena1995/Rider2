using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Asignacion_Rutas
    {
        private int _codigo_personal;
        private string _estado;
        private string _observacion;
        private int _id_ruta;

        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        #region
        public int Codigo__personal
        {
            get
            {
                return _codigo_personal;
            }

            set
            {
                _codigo_personal = value;
            }
        }

        public string Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                _estado = value;
            }
        }

        public string Observacion
        {
            get
            {
                return _observacion;
            }

            set
            {
                _observacion = value;
            }
        }

        public int Id_ruta
        {
            get
            {
                return _id_ruta;
            }

            set
            {
                _id_ruta = value;
            }
        }
        #endregion
   
        public DataTable Consultar_Todo()//ESTOY USANDO
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                //Sqlcmd.CommandText = "SP_MOSTRAR_DETALLE_RUTAS";
                Sqlcmd.CommandText = "[SP_MOSTRAR_DETALLE_RUTAS2]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(tablaResultados);

            }
            catch (Exception)
            {
                tablaResultados = null;
            }
            return tablaResultados;

        }
        //public string Eliminar(D_Asignacion_Rutas dato)
        //{
        //    string rpta = "";
        //    SqlCn = new SqlConnection();
        //    try
        //    {
        //        SqlCn.ConnectionString = D_Conexion.Conexion;
        //        SqlCn.Open();

        //        Sqlcmd = new SqlCommand();
        //        Sqlcmd.Connection = SqlCn;
        //        Sqlcmd.CommandText = "[sp_Asignacion_Rutas_Eliminar]";
        //        Sqlcmd.CommandType = CommandType.StoredProcedure;

        //        Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo__personal);

        //        rpta = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo eliminar";

        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = ex.Message;
        //    }
        //    finally
        //    {
        //        if (SqlCn.State == ConnectionState.Open) SqlCn.Close();
        //    }
        //    return rpta;
        //}
    
        //public string Cambiar_Estado(D_Asignacion_Rutas dato)
        //{
        //    try
        //    {
        //        SqlCn = new SqlConnection();
        //        Sqlcmd = new SqlCommand();

        //        SqlCn.ConnectionString = D_Conexion.Conexion;
        //        SqlCn.Open();

        //        Sqltra = SqlCn.BeginTransaction();

        //        Sqlcmd.Connection = SqlCn;
        //        Sqlcmd.Transaction = Sqltra;
        //        Sqlcmd.CommandText = "[sp_Asignacion_Rutas_CambiarEstado]";
        //        Sqlcmd.CommandType = CommandType.StoredProcedure;

        //        Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo__personal);
        //        Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);

        //        resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo cambiar el estado";


        //        if (resp.Equals("ok"))
        //        {
        //            Sqltra.Commit();
        //        }
        //        else
        //        {
        //            Sqltra.Rollback();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        resp = ex.Message;

        //    }
        //    finally
        //    {
        //        if (SqlCn.State == ConnectionState.Open)
        //            SqlCn.Close();
        //    }
        //    return resp;
        //}

        //public DataTable Buscar(string _txtbuscar, string _estado)
        //{
        //    tablaResultados = new DataTable();
        //    SqlCn = new SqlConnection();
        //    Sqlcmd = new SqlCommand();
        //    try
        //    {
        //        SqlCn.ConnectionString = D_Conexion.Conexion;

        //        Sqlcmd.Connection = SqlCn;
        //        Sqlcmd.CommandText = "[sp_Asignacion_Rutas_Buscar]";

        //        Sqlcmd.CommandType = CommandType.StoredProcedure;
        //        Sqlcmd.Parameters.AddWithValue("@texto", _txtbuscar);
        //        Sqlcmd.Parameters.AddWithValue("@Estado", _estado);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
        //        SqlDat.Fill(tablaResultados);
        //    }
        //    catch (Exception)
        //    {
        //        tablaResultados = null;
        //    }
        //    return tablaResultados;

        //}

        //public DataTable Consulta_Id(D_Asignacion_Rutas dato)
        //{
        //    DataTable DtResultado = new DataTable("Asignacion_Rutas");
        //    SqlConnection SqlCon = new SqlConnection();
        //    try
        //    {
        //        SqlCon.ConnectionString = D_Conexion.Conexion;
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "[sp_Asignacion_Rutas_Consulta_Id]";
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        SqlParameter ParId = new SqlParameter();
        //        ParId.ParameterName = "@Codigo";
        //        ParId.SqlDbType = SqlDbType.Int;
        //        ParId.Value = dato.Codigo__personal;
        //        SqlCmd.Parameters.Add(ParId);

        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(DtResultado);

        //    }
        //    catch (Exception)
        //    {
        //        DtResultado = null;
        //    }
        //    return DtResultado;

        //}



        ///////////////////
        //public string REGISTRAR_USUARIO_DETALLE_RUTAS(D_Asignacion_Rutas lista)
        //{
        //    try
        //    {
        //        SqlCn = new SqlConnection();
        //        Sqlcmd = new SqlCommand();
        //        SqlCn.ConnectionString = D_Conexion.Conexion;
        //        SqlCn.Open();
        //        Sqltra = SqlCn.BeginTransaction();

        //        Sqlcmd.Connection = SqlCn;
        //        Sqlcmd.Transaction = Sqltra;
        //        Sqlcmd.CommandText = "SP_REGISTRAR_DETALLE_RUTAS";
        //        Sqlcmd.CommandType = CommandType.StoredProcedure;

        //        Sqlcmd.Parameters.AddWithValue("@Codigo_personal", lista._codigo_personal);
        //        Sqlcmd.Parameters.AddWithValue("@Codigo_ruta", lista.Id_ruta);
        //        Sqlcmd.Parameters.AddWithValue("@Descripcion", lista.Observacion);
        //        Sqlcmd.Parameters.AddWithValue("@Estado", lista.Estado);                
        //        resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "OK" : "No se puede registrar";
        //        if (resp.Equals("OK"))
        //        {
        //            Sqltra.Commit();
        //        }
        //        else
        //        {
        //            Sqltra.Rollback();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resp = ex.Message;
        //    }
        //    finally
        //    {
        //        if (SqlCn.State == ConnectionState.Open)
        //        {
        //            SqlCn.Close();
        //        }
        //    }
        //    return resp;
        //}
    }
}
