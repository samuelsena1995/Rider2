using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;


namespace Capa_Negocio
{
    public class N_Clientes
    {
        public static string Registrar(string _estado, DateTime _f_registro, string _nombre, string _ap_paterno, string _ap_materno, int _nro_documento, string _tipo_documento, string _correo, int _telefono, string _direccion, int _id_rubro)
        {
            D_Clientes dato = new D_Clientes();

            dato.Estado = _estado;
            dato.F_registro = _f_registro;
            dato.Nombre = _nombre;
            dato.Ap_paterno = _ap_paterno;
            dato.Ap_materno = _ap_materno;
            dato.Nro_documento = _nro_documento;
            dato.Tipo_documento = _tipo_documento;
            dato.Correo = _correo;
            dato.Telefono = _telefono;
            dato.Direccion = _direccion;
            dato.Id_rubro = _id_rubro;

            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Clientes().Consultar_Todo();
        }
        public static string Eliminar(int _codigo)
        {
            D_Clientes dato = new D_Clientes();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(int _codigo, string _nombre, string _ap_paterno, string _ap_materno, int _nro_documento, string _tipo_documento, string _correo, int _telefono, string _direccion, int _id_rubro)
        {
            D_Clientes dato = new D_Clientes();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Ap_paterno = _ap_paterno;
            dato.Ap_materno = _ap_materno;
            dato.Nro_documento = _nro_documento;
            dato.Tipo_documento = _tipo_documento;
            dato.Correo = _correo;
            dato.Telefono = _telefono;
            dato.Direccion = _direccion;
            dato.Id_rubro = _id_rubro;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_Clientes dato = new D_Clientes();

            dato.Codigo = _codigo;
            dato.Estado = _estado;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado, string _buscarpor)
        {
            return new D_Clientes().Buscar(_txtbuscar, _estado, _buscarpor);
        }

        public static DataTable Consulta_Id(int _codigo)
        {
            D_Clientes dato = new D_Clientes();

            dato.Codigo = _codigo;

            return dato.Consulta_Id(dato);
        }
    }
}
