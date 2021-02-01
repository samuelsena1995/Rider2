using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_DETALLE_PERSONAL_TURNO_RUTA
    {
        string resp = "";

        private int _codigoAuxiliar;    
        private int _codigodetalle_turno;
        private int _codigo_ruta;
        private int _codigo_turno;
        private DateTime _fechainicio;
        private DateTime _fechafin;
        private string _observaciones;
        private string _estado;

        public int _CODIGOAUXILIAR
        {
            get { return _codigoAuxiliar; }
            set { _codigoAuxiliar = value; }
        }
        public string _ESTADO
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public string _OBSERVACIONES
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        public DateTime _FECHA_FIN
        {
            get { return _fechafin; }
            set { _fechafin = value; }
        }


        public DateTime _FECHA_INICIO
        {
            get { return _fechainicio; }
            set { _fechainicio = value; }
        }

        public int _CODIGO_TURNO
        {
            get { return _codigo_turno; }
            set { _codigo_turno = value; }
        }

        public int _CODIGO_RUTA
        {
            get { return _codigo_ruta; }
            set { _codigo_ruta = value; }
        }

        public int _CODIGODETALLE_TURNO
        {
            get { return _codigodetalle_turno; }
            set { _codigodetalle_turno = value; }
        }


        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        public string InsertarDetalle(D_DETALLE_PERSONAL_TURNO_RUTA dtreserva,
          ref SqlConnection SqlCon,
          ref SqlTransaction sqltran)
        {
            string rpt = "";
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = SqlCon;
                sqlcmd.Transaction = sqltran;
                sqlcmd.CommandText = "PERSONAL_TURNO_RUTA_REGISTRAR";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@CODIGO_AUXILIAR", dtreserva._CODIGOAUXILIAR);
                sqlcmd.Parameters.AddWithValue("@CODIGO_DETALLE_TURNO", dtreserva._CODIGODETALLE_TURNO);
                sqlcmd.Parameters.AddWithValue("@CODIGO_RUTA", dtreserva._CODIGO_RUTA);
                sqlcmd.Parameters.AddWithValue("@CODIGO_TURNO", dtreserva._CODIGO_TURNO);
                sqlcmd.Parameters.AddWithValue("@FECHA_INICIO", dtreserva._FECHA_INICIO);
                sqlcmd.Parameters.AddWithValue("@FECHA_FIN", dtreserva._FECHA_FIN);
                sqlcmd.Parameters.AddWithValue("@OBSERVACIONES", dtreserva._OBSERVACIONES);
                sqlcmd.Parameters.AddWithValue("@ESTADO", dtreserva._ESTADO);

                rpt = sqlcmd.ExecuteNonQuery() == 1 ? "ok" : "no  se puede registrar detalle";

            }
            catch (Exception ex)
            {
                rpt = ex.Message;
            }
            return rpt;
        }

        public DataTable PERSONAL_TURNO_RUTA_NO_ASIGNADO()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "[PERSONAL_TURNO_RUTA_NO_ASIGNADO]";
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
        ///MOSTRAR EL REGISTRO
        public DataTable Consultar_DETALLE_TURNO_RUTA()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "PERSONAL_TURNO_RUTA_MOSTRAR";
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

        public DataTable Consulta_Id_DETALLE_TURNO_RUTA(D_DETALLE_PERSONAL_TURNO_RUTA dato)
        {
            DataTable DtResultado = new DataTable("");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[SP_CONSULTAR_ID_PERSONAL_DETALLE_TURNO_RUTA]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Codigo";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = dato._CODIGODETALLE_TURNO;
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
        ///

        ///editar
        public string EDITAR_PERSONAL_TURNO_RUTA(D_DETALLE_PERSONAL_TURNO_RUTA dato) {
            try
            {
                SqlCn = new SqlConnection();
                Sqlcmd = new SqlCommand();

                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqltra = SqlCn.BeginTransaction();

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.Transaction = Sqltra;
                Sqlcmd.CommandText = "[PERSONAL_TURNO_RUTA_EDITAR]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@CODIGO_DETALLE_TURNO", dato._CODIGODETALLE_TURNO);
                Sqlcmd.Parameters.AddWithValue("@CODIGO_RUTA", dato._CODIGO_RUTA);
                Sqlcmd.Parameters.AddWithValue("@CODIGO_TURNO", dato._CODIGO_TURNO);
                Sqlcmd.Parameters.AddWithValue("@FECHA_INICIO", dato._FECHA_INICIO);
                Sqlcmd.Parameters.AddWithValue("@FECHA_FIN", dato._FECHA_FIN);
                Sqlcmd.Parameters.AddWithValue("@OBSERVACIONES", dato._OBSERVACIONES);

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo editar";


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
        ///CAMBIAR ESTADO
        public string Cambiar_Estado(D_DETALLE_PERSONAL_TURNO_RUTA dato)
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
                Sqlcmd.CommandText = "[PERSONAL_TURNO_RUTA_CAMBIAR_ESTADO]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato._CODIGODETALLE_TURNO);
                Sqlcmd.Parameters.AddWithValue("@Estado", dato._ESTADO);

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo cambiar el estado";


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


        ///eliminar
        public string Eliminar(D_DETALLE_PERSONAL_TURNO_RUTA dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "PERSONAL_TURNO_RUTA_Eliminar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato._CODIGODETALLE_TURNO);

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
        ///buscar
        public DataTable Buscar(string _txtbuscar, string _estado, string _buscarpor)
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "[PERSONAL_TURNO_RUTA_BUSCAR]";

                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@texto", _txtbuscar);
                Sqlcmd.Parameters.AddWithValue("@Estado", _estado);
                Sqlcmd.Parameters.AddWithValue("@Buscarpor", _buscarpor);

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(tablaResultados);
            }
            catch (Exception)
            {
                tablaResultados = null;
            }
            return tablaResultados;

        }
        ///
    }
}
