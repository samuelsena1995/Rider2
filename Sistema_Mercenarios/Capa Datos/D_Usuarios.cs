using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Usuarios
    {
        /// <summary>
        /// variable de la tabla funciones
        /// 
        private string Copia_Usuario;

        public string _COPIA_USUARIO
        {
            get { return Copia_Usuario; }
            set { Copia_Usuario = value; }
        }

        private string _codigo_funcion;

        public string _Codigo_Funcion
        {
            get { return _codigo_funcion; }
            set { _codigo_funcion = value; }
        }

        /// </summary>


        private string _codigo;
        private string _estado;
        private string _nombre;
        private string _usuario;
        private string _clave;
        private string _observacion;
        private string _ip;

        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;

        #region
        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                _codigo = value;
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

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }

        public string Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                _clave = value;
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
        #endregion

        public string Registrar(D_Usuarios dato)
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
                Sqlcmd.CommandText = "sp_Usuarios_Registrar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);
                Sqlcmd.Parameters.AddWithValue("@Nombre", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Usuario", dato.Usuario);
                Sqlcmd.Parameters.AddWithValue("@Clave", dato.Clave);
                Sqlcmd.Parameters.AddWithValue("@Observaciones", dato.Observacion);

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
                Sqlcmd.CommandText = "sp_Usuarios_Consultar";
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
        public string Eliminar(D_Usuarios dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "[sp_Usuarios_Eliminar]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);

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
        public string Editar(D_Usuarios dato)
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
                Sqlcmd.CommandText = "[sp_Usuarios_Editar]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);
                Sqlcmd.Parameters.AddWithValue("@Nombre", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Usuario", dato.Usuario);
                Sqlcmd.Parameters.AddWithValue("@Clave", dato.Clave);
                Sqlcmd.Parameters.AddWithValue("@Observaciones", dato.Observacion);

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
        public string Cambiar_Estado(D_Usuarios dato)
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
                Sqlcmd.CommandText = "[sp_Usuarios_CambiarEstado]";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);
                Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);

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
                Sqlcmd.CommandText = "sp_Usuarios_Buscar";

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

        public DataTable Consulta_Id(D_Usuarios dato)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[sp_Usuarios_Consulta_Id]";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Codigo";
                ParId.SqlDbType = SqlDbType.Char;
                ParId.Value = dato.Codigo;
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

        public DataTable Consulta_Nombre(D_Usuarios dato)
        {
            DataTable DtResultado = new DataTable("Usuarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_Usuarios_Consulta_Nombre";
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



        //////
        ////
       /*public DataTable SP_MOSTRAR_FUNCIONES()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "SP_MOSTRAR_FUNCIONES";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(Sqlcmd);
                SqlDat.Fill(tablaResultados);

            }
            catch (Exception)
            {
                tablaResultados = null;
            }
            return tablaResultados;

        }*/


        public string SP_REGISTRAR_ASIGNACION_FUNCIONES(D_Usuarios dato)
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
                Sqlcmd.CommandText = "SP_REGISTRAR_ASIGNACION_FUNCIONES";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo_Funcion", dato._Codigo_Funcion);
                Sqlcmd.Parameters.AddWithValue("@Codigo_Usuario", dato.Codigo);
                

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo registrar";

                if (resp.Equals("OK"))
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

        public DataTable SP_MOSTRAR_FUNCIONES(D_Usuarios ID)//pantalla principal mostrar los permisos de ese usuairo
        {
            DataTable Dtresultado = new DataTable();
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                //sqlcmd.CommandText = "MOSTRAR_PERMISOS_ID";
                Sqlcmd.CommandText = "SP_MOSTRAR_FUNCIONES";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Cod_Usuario", ID.Codigo);

                SqlDataAdapter sqldate = new SqlDataAdapter(Sqlcmd);
                sqldate.Fill(Dtresultado);
            }
            catch (Exception)
            {
                Dtresultado = null;
            }
            return Dtresultado;
        }

        public string SP_ELIMINAR_USUARIO_ASIGNACION(D_Usuarios dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "SP_ELIMINAR_USUARIO_ASIGNACION";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@CODIGO_USUARIO", dato.Codigo);

                rpta = Sqlcmd.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo eliminar";

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

        ///login
        public DataTable INICIO_SESION(D_Usuarios usuario)
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();
                SqlCommand Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "SP_INICIO_SESION";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@Usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = usuario.Usuario;
                Sqlcmd.Parameters.Add(ParUsuario);

                SqlParameter ParContra = new SqlParameter();
                ParContra.ParameterName = "@Contraseña";
                ParContra.SqlDbType = SqlDbType.VarChar;
                ParContra.Size = 50;
                ParContra.Value = usuario.Clave;
                Sqlcmd.Parameters.Add(ParContra);

                SqlDataAdapter Sqldat = new SqlDataAdapter(Sqlcmd);
                Sqldat.Fill(tablaResultados);

            }
            catch (Exception)
            {
                tablaResultados = null;
            }

            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }

            return tablaResultados;

        }

        public DataTable MOSTRAR_Id_Permiso_Pantalla_principal(D_Usuarios ID)
        {
            DataTable Dtresultado = new DataTable();
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                //sqlcmd.CommandText = "MOSTRAR_PERMISOS_ID";
                Sqlcmd.CommandText = "MOSTRAR_Id_Permiso_Pantalla_principal";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Id_Usuario", ID.Codigo);

                SqlDataAdapter sqldate = new SqlDataAdapter(Sqlcmd);
                sqldate.Fill(Dtresultado);
            }
            catch (Exception)
            {
                Dtresultado = null;
            }
            return Dtresultado;
        }
        ///

        public string COPIAR_ASIGNACIONPERMISO_NUEVO_USUARIO(D_Usuarios o)
        {
            string result = "";
            try
            {
                SqlCn = new SqlConnection();
                Sqlcmd = new SqlCommand();
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();
                Sqltra = SqlCn.BeginTransaction();

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.Transaction = Sqltra;
                Sqlcmd.CommandText = "SP_COPIAR_PERMISOS";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter parValor = new SqlParameter();
                //parValor.ParameterName = "@valor";
                //parValor.SqlDbType = SqlDbType.Char;
                //parValor.Direction = ParameterDirection.Output;
                //Sqlcmd.Parameters.Add(parValor);


                Sqlcmd.Parameters.AddWithValue("@Cod_Usuario_COPIA", o._COPIA_USUARIO);
                Sqlcmd.Parameters.AddWithValue("@Cod_Nuevo_Usuario", o.Codigo);
                result = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se puede registrar";
                if (result.Equals("ok"))
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
                result = ex.Message;
            }
            finally
            {
                if (SqlCn.State == ConnectionState.Open)
                {
                    SqlCn.Close();
                }
            }
            return result;
        }


        public string Editar_AUDITORIA(D_Usuarios trabajador)
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
                Sqlcmd.CommandText = "sp_Auditoria_Editar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;
                Sqlcmd.Parameters.AddWithValue("@Codigo_Usuario", trabajador.Codigo);
                Sqlcmd.Parameters.AddWithValue("@IP", trabajador.IP);
                Sqlcmd.Parameters.AddWithValue("@Nombre_Usuario", trabajador.Nombre);

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo Editar";


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
