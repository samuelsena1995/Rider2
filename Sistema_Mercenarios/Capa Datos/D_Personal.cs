using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Personal
    {
        private int _codigo;
        private string _estado;
        private DateTime _f_registro;
        private string _nombre;
        private string _ap_paterno;
        private string _ap_materno;
        private DateTime _f_nacimiento;
        private int _nro_documento;
        private string _tipo_documento;
        private string _estado_civil;
        private string _sexo;
        private int _telefono;
        private string _direccion;
        private string _zona;
        private DateTime _f_retiro;

        private int _id_cargo;

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

        public DateTime F_nacimiento
        {
            get
            {
                return _f_nacimiento;
            }

            set
            {
                _f_nacimiento = value;
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

        public string Estado_civil
        {
            get
            {
                return _estado_civil;
            }

            set
            {
                _estado_civil = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
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

        public string Zona
        {
            get
            {
                return _zona;
            }

            set
            {
                _zona = value;
            }
        }

        public DateTime F_retiro
        {
            get
            {
                return _f_retiro;
            }

            set
            {
                _f_retiro = value;
            }
        }

        public int Id_cargo
        {
            get
            {
                return _id_cargo;
            }

            set
            {
                _id_cargo = value;
            }
        }

        #endregion

        public string Registrar(D_Personal dato)
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
                Sqlcmd.CommandText = "sp_Personal_Registrar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);
                Sqlcmd.Parameters.AddWithValue("@F_registro", dato.F_registro);
                Sqlcmd.Parameters.AddWithValue("@Nombres", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Ap_paterno", dato.Ap_paterno);
                Sqlcmd.Parameters.AddWithValue("@Ap_materno", dato.Ap_materno);
                Sqlcmd.Parameters.AddWithValue("@F_nacimiento", dato.F_nacimiento);
                Sqlcmd.Parameters.AddWithValue("@Nro_documento", dato.Nro_documento);
                Sqlcmd.Parameters.AddWithValue("@Tipo_documento", dato.Tipo_documento);
                Sqlcmd.Parameters.AddWithValue("@Estado_civil", dato.Estado_civil);
                Sqlcmd.Parameters.AddWithValue("@Sexo", dato.Sexo);

                Sqlcmd.Parameters.AddWithValue("@Telefono", dato.Telefono);
                Sqlcmd.Parameters.AddWithValue("@Direccion", dato.Direccion);
                Sqlcmd.Parameters.AddWithValue("@Zona", dato.Zona);

                Sqlcmd.Parameters.AddWithValue("@Id_cargo", dato.Id_cargo);

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
                Sqlcmd.CommandText = "sp_Personal_Consultar";
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
        public string Eliminar(D_Personal dato)
        {
            string rpta = "";
            SqlCn = new SqlConnection();
            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;
                SqlCn.Open();

                Sqlcmd = new SqlCommand();
                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Personal_Eliminar";
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
        public string Editar(D_Personal dato)
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
                Sqlcmd.CommandText = "sp_Personal_Editar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);
                Sqlcmd.Parameters.AddWithValue("@Nombres", dato.Nombre);
                Sqlcmd.Parameters.AddWithValue("@Ap_paterno", dato.Ap_paterno);
                Sqlcmd.Parameters.AddWithValue("@Ap_materno", dato.Ap_materno);
                Sqlcmd.Parameters.AddWithValue("@F_nacimiento", dato.F_nacimiento);
                Sqlcmd.Parameters.AddWithValue("@Nro_documento", dato.Nro_documento);
                Sqlcmd.Parameters.AddWithValue("@Tipo_documento", dato.Tipo_documento);
                Sqlcmd.Parameters.AddWithValue("@Estado_civil", dato.Estado_civil);
                Sqlcmd.Parameters.AddWithValue("@Sexo", dato.Sexo);

                Sqlcmd.Parameters.AddWithValue("@Telefono", dato.Telefono);
                Sqlcmd.Parameters.AddWithValue("@Direccion",dato.Direccion);
                Sqlcmd.Parameters.AddWithValue("@Zona", dato.Zona);

                Sqlcmd.Parameters.AddWithValue("@Id_cargo", dato.Id_cargo);

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
        public string Cambiar_Estado(D_Personal dato)
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
                Sqlcmd.CommandText = "sp_Personal_CambiarEstado";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                Sqlcmd.Parameters.AddWithValue("@Codigo", dato.Codigo);
                Sqlcmd.Parameters.AddWithValue("@Estado", dato.Estado);
                Sqlcmd.Parameters.AddWithValue("@F_retiro", dato.F_retiro);

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
                Sqlcmd.CommandText = "sp_Personal_Buscar";

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

        public DataTable Consulta_Id(D_Personal dato)
        {
            DataTable DtResultado = new DataTable("Personal");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "sp_Personal_Consulta_Id";
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
        public DataTable Consultar_No_Asignados()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Personal_Consultar_No_Asignados";
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

        public DataTable sp_Personal_No_Asignado()
        {
            tablaResultados = new DataTable();
            SqlCn = new SqlConnection();
            Sqlcmd = new SqlCommand();

            try
            {
                SqlCn.ConnectionString = D_Conexion.Conexion;

                Sqlcmd.Connection = SqlCn;
                Sqlcmd.CommandText = "sp_Personal_No_Asignado";
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
    }
}
