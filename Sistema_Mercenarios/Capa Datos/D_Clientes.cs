using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Clientes
    {
        private int _codigo;
        private string _estado;
        private DateTime _f_registro;
        private string _nombre;
        private string _ap_paterno;
        private string _ap_materno;
        private int _nro_documento;
        private string _tipo_documento;
        private string _correo;
        private int _telefono;
        private string _direccion;

        private int _id_rubro;

        private string resp = "";

        SqlConnection SqlCn;
        SqlCommand Sqlcmd;
        SqlTransaction Sqltra;
        DataTable tablaResultados;


        #region
        public int Codigo
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

        public DateTime F_registro
        {
            get
            {
                return _f_registro;
            }

            set
            {
                _f_registro = value;
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

        public string Ap_paterno
        {
            get
            {
                return _ap_paterno;
            }

            set
            {
                _ap_paterno = value;
            }
        }

        public string Ap_materno
        {
            get
            {
                return _ap_materno;
            }

            set
            {
                _ap_materno = value;
            }
        }

        public int Nro_documento
        {
            get
            {
                return _nro_documento;
            }

            set
            {
                _nro_documento = value;
            }
        }

        public string Tipo_documento
        {
            get
            {
                return _tipo_documento;
            }

            set
            {
                _tipo_documento = value;
            }
        }

        public string Correo
        {
            get
            {
                return _correo;
            }

            set
            {
                _correo = value;
            }
        }

        public int Telefono
        {
            get
            {
                return _telefono;
            }

            set
            {
                _telefono = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }

            set
            {
                _direccion = value;
            }
        }

        public int Id_rubro
        {
            get
            {
                return _id_rubro;
            }

            set
            {
                _id_rubro = value;
            }
        }

        #endregion

        public string Registrar(D_Clientes dato)
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
                Sqlcmd.CommandText = "sp_Clientes_Registrar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);
                Sqlcmd.Parameters.AddWithValue("@F_registro", dato.F_registro);
                Sqlcmd.Parameters.AddWithValue("@Nombres", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Ap_paterno", dato.Ap_paterno);
                Sqlcmd.Parameters.AddWithValue("@Ap_materno", dato.Ap_materno);
                Sqlcmd.Parameters.AddWithValue("@Nro_documento", dato.Nro_documento);
                Sqlcmd.Parameters.AddWithValue("@Tipo_documento", dato.Tipo_documento);
                Sqlcmd.Parameters.AddWithValue("@Correo", dato.Correo);
                Sqlcmd.Parameters.AddWithValue("@Telefono", dato.Telefono);
                Sqlcmd.Parameters.AddWithValue("@Direccion", dato.Direccion);
                Sqlcmd.Parameters.AddWithValue("@Id_rubro", dato.Id_rubro);

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
                Sqlcmd.CommandText = "sp_Clientes_Consultar";
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
        public string Eliminar(D_Clientes dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Clientes_Eliminar";
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
        public string Editar(D_Clientes dato)
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
                Sqlcmd.CommandText = "sp_Clientes_Editar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);
                Sqlcmd.Parameters.AddWithValue("@Nombres", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Ap_paterno", dato.Ap_paterno);
                Sqlcmd.Parameters.AddWithValue("@Ap_materno", dato.Ap_materno);
                Sqlcmd.Parameters.AddWithValue("@Nro_documento", dato.Nro_documento);
                Sqlcmd.Parameters.AddWithValue("@Tipo_documento", dato.Tipo_documento);
                Sqlcmd.Parameters.AddWithValue("@Correo", dato.Correo);
                Sqlcmd.Parameters.AddWithValue("@Telefono", dato.Telefono);
                Sqlcmd.Parameters.AddWithValue("@Direccion", dato.Direccion);
                Sqlcmd.Parameters.AddWithValue("@Id_rubro", dato.Id_rubro);

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
        public string Cambiar_Estado(D_Clientes dato)
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
                Sqlcmd.CommandText = "sp_Clientes_CambiarEstado";
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

        public DataTable Buscar(string _txtbuscar, string _estado, string _buscarpor)
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Clientes_Buscar";

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

        public DataTable Consulta_Id(D_Clientes dato)
        {
            DataTable DtResultado = new DataTable("Cliente");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_Clientes_Consulta_Id";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParId = new SqlParameter();
                ParId.ParameterName = "@Codigo";
                ParId.SqlDbType = SqlDbType.Int;
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
    }
}
