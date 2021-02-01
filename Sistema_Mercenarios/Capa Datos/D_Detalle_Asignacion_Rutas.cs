using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Detalle_Asignacion_Rutas
    {
        private int _cod_ruta;
        private int _cod_personal;
        private string observacion;
        private string estado;
        private int _codigoAuxiliar;

        public int _CodigoAuxiliar
        {
            get { return _codigoAuxiliar; }
            set { _codigoAuxiliar = value; }
        }


        public int _CodPersonal {
            get { return _cod_personal; }
            set { _cod_personal = value; }
        }
        public int _CodigoRuta {
            get { return _cod_ruta; }
            set { _cod_ruta = value; }
        }
        public string _Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public string _Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        DataTable tablaResultados;
        SqlCommand Sqlcmd;
        SqlConnection SqlCn;
        SqlTransaction Sqltra;
        string resp = "";
        public string InsertarDetalle(D_Detalle_Asignacion_Rutas dtreserva,
         ref SqlConnection SqlCon,
         ref SqlTransaction sqltran)
        {
            string rpt = "";
            try
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = SqlCon;
                sqlcmd.Transaction = sqltran;
                sqlcmd.CommandText = "[SP_REGISTRAR_DETALLE_RUTAS2]";
                sqlcmd.CommandType = CommandType.StoredProcedure;

                sqlcmd.Parameters.AddWithValue("@Codigo_ruta", dtreserva._CodigoRuta);
                sqlcmd.Parameters.AddWithValue("@Codigo_personal", dtreserva._CodPersonal);
                sqlcmd.Parameters.AddWithValue("@Descripcion", dtreserva._Observacion);
                sqlcmd.Parameters.AddWithValue("@Estado", dtreserva._Estado);
                sqlcmd.Parameters.AddWithValue("@CodigoAuxiliar", dtreserva._CodigoAuxiliar);

                rpt = sqlcmd.ExecuteNonQuery() == 1 ? "ok" : "no  se puede registrar detalle";

            }
            catch (Exception ex)
            {
                rpt = ex.Message;
            }
            return rpt;
        }


        public DataTable Consultar_Todo_detalle_asignacionrutas()//ESTOY USANDO
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                
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

        public DataTable Consultar_Todo_detalle__NO_ASIGNADOS()//ESTOY USANDO D_Detalle_Asignacion_Rutas
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;

                Sqlcmd.CommandText = "[SP_MOSTRAR_DETALLE_RUTAS2_NO_ASIGNADO]";
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

        //PARA MOSTRAR LOS DATOSDEL DATAGRIDVIEW A LAS CAJA DE TEXTO
        public DataTable Consulta_Id_DETALLE_RUTA(D_Detalle_Asignacion_Rutas dato)
        {
            DataTable DtResultado = new DataTable("DETALLE_RUTAS");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[sp_Asignacion_Rutas_Consulta_Id2]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Codigo";
                ParId.SqlDbType = SqlDbType.Int;
                ParId.Value = dato._codigoAuxiliar;
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


        ///mostrar las personal de ese detalle seleccionado
        public DataTable Consulta_Id_persona_mostrar(D_Detalle_Asignacion_Rutas dato)
        {
            DataTable DtResultado = new DataTable("");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[MOSTRAR_PERSONA_DETALLE_RUTAS2]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlCmd.Parameters.AddWithValue("@CODIGO_DETALLE", dato._CodigoAuxiliar);
                //SqlCmd.Parameters.AddWithValue("@CODIGO_RUTA", dato._CodigoRuta);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
        ///cambiar estado
        public string Cambiar_Estado(D_Detalle_Asignacion_Rutas dato)
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
                Sqlcmd.CommandText = "SP_CAMBIO_ESTADO_DETALLE_RUTAS2";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato._CodigoAuxiliar);
                Sqlcmd.Parameters.AddWithValue("@Estado", dato._Estado);

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
        public string Eliminar(D_Detalle_Asignacion_Rutas dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "[SP_ELIMINAR_DETALLE_RUTAS]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@CODIGO_AUX", dato._CodigoAuxiliar);

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
                Sqlcmd.CommandText = "[SP_BUSCAR_DETALLE_RUTAS2]";

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

        /// <summary>
        /// registrar los datos de las personas o trabajadores

        /// </summary>


















    }
}
