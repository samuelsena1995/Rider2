using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace Capa_Datos
{
    public class D_Asignacion_Funciones
    {
        private string _codigo;
        private string _id_usuario;

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

        public string Id_usuario
        {
            get
            {
                return _id_usuario;
            }

            set
            {
                _id_usuario = value;
            }
        }
        #endregion

        public string Registrar(D_Asignacion_Funciones dato)
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
                Sqlcmd.CommandText = "sp_Asignacion_Funciones_Registrar";
                Sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParCodPersonal = new SqlParameter();
                ParCodPersonal.ParameterName = "@Cod_asignacion";
                ParCodPersonal.SqlDbType = SqlDbType.Char;
                ParCodPersonal.Direction = ParameterDirection.Output;
                Sqlcmd.Parameters.Add(ParCodPersonal);

                Sqlcmd.Parameters.AddWithValue("@Id_usuario", dato.Id_usuario);

                resp = Sqlcmd.ExecuteNonQuery() >= 1 ? "ok" : "No se pudo registrar";

               // Codigo = Convert.ToString(Sqlcmd.Parameters["@Cod_asignacion"].Value);

                if (resp.Equals("ok"))
                {
                    Sqltra.Commit();
                //    D_Detalle_Asignacion_Funciones obj = new D_Detalle_Asignacion_Funciones();

                 

                   // resp = obj.Registrar();
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
        public DataTable Consulta_Id_Asignacion(D_Asignacion_Funciones dato)
        {
            DataTable DtResultado = new DataTable("Asignacion_Funciones");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = D_Conexion.Conexion;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "[sp_Detalle_Asignacion_Funciones_Consulta_Id_Asignacion]";
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
    }
}
