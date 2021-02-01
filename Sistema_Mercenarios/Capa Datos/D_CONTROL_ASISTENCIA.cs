using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Capa_Datos
{
   public class D_CONTROL_ASISTENCIA
    {
        private int Codigo;
        private DateTime Fecha;
        private int _CodigoPersonalTurnoRuta;
        private string _Descripcion;
        private string _Estado;

        public string _ESTADO { 
        
            get { return _Estado; }
            set { _Estado = value; }
        }

        public string _DESCRIPCION
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int _CODIGO_PERSONALTURNO_RUTA
        {
            get { return _CodigoPersonalTurnoRuta; }
            set { _CodigoPersonalTurnoRuta = value; }
        }

        public DateTime _FECHA
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public int _CODIGO
        {
            get { return Codigo; }
            set { Codigo = value; }
        }

        public D_CONTROL_ASISTENCIA() {

        }
        public D_CONTROL_ASISTENCIA(int CODO, DateTime FEC, int IDEDETLA, string DESCI, string ESATDO) {
            this._CODIGO = CODO;
            this._FECHA = FEC;
            this._CODIGO_PERSONALTURNO_RUTA = IDEDETLA;
            this._DESCRIPCION = DESCI;
            this._ESTADO = ESATDO;
        }
        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        public string Registrar(D_CONTROL_ASISTENCIA dato)
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
                Sqlcmd.CommandText = "[CONTROL_ASISTENCIA_REGISTRAR]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Fecha", dato._FECHA);
                Sqlcmd.Parameters.AddWithValue("@Codigo_PersonalxTurnoxRuta", dato._CODIGO_PERSONALTURNO_RUTA);
                Sqlcmd.Parameters.AddWithValue("@Estado", dato._ESTADO);
                Sqlcmd.Parameters.AddWithValue("@Observacion", dato._DESCRIPCION);                
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
        public DataTable Consultar_Todo()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "CONTROL_ASISTENCIA_MOSTRAR";
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
            
        public string Cambiar_Estado(D_CONTROL_ASISTENCIA dato)
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
                Sqlcmd.CommandText = "[CONTROL_ASISTENCIA_CAMBIAR_ESTADO]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato._CODIGO);
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

        public DataTable Buscar(string _txtbuscar, string _estado)
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Cargos_Buscar";

                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@texto", _txtbuscar);
                Sqlcmd.Parameters.AddWithValue("@Estado", _estado);

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(tablaResultados);
            }
            catch (Exception)
            {
                tablaResultados = null;
            }
            return tablaResultados;

        }

        public DataTable Consulta_Id(D_CONTROL_ASISTENCIA dato)
        {
            DataTable DtResultado = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[CONTROL_ASISTENCIA_ID]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Codigo";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = dato._CODIGO;
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

        public DataTable Consulta_Nombre(D_Cargos dato)
        {
            DataTable DtResultado = new DataTable("Cargos");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_Cargos_Consulta_Nombre";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Value = dato.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

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
