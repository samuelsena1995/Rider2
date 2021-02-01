using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Personal
    {
        public static string Registrar(string _estado, DateTime _f_registro, string _nombre, string _ap_paterno, string _ap_materno, DateTime _f_nacimiento ,int _nro_documento, string _tipo_documento, string _estado_civil, string _sexo, int _telefono, string _direccion, string _zona, int _id_cargo)
        {
            D_Personal dato = new D_Personal();

            dato.Estado = _estado;
            dato.F_registro = _f_registro;
            dato.Nombre = _nombre;
            dato.Ap_paterno = _ap_paterno;
            dato.Ap_materno = _ap_materno;
            dato.F_nacimiento = _f_nacimiento;
            dato.Nro_documento = _nro_documento;
            dato.Tipo_documento = _tipo_documento;
            dato.Estado_civil = _estado_civil;
            dato.Sexo = _sexo;
            dato.Telefono = _telefono;
            dato.Direccion = _direccion;
            dato.Zona = _zona;
            dato.Id_cargo = _id_cargo;

            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Personal().Consultar_Todo();
        }
        public static string Eliminar(int _codigo)
        {
            D_Personal dato = new D_Personal();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(int _codigo, string _nombre, string _ap_paterno, string _ap_materno,DateTime _f_nacimiento, int _nro_documento, string _tipo_documento, string _estado_civil, string _sexo, int _telefono, string _direccion, string _zona, int _id_cargo)
        {
            D_Personal dato = new D_Personal();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Ap_paterno = _ap_paterno;
            dato.Ap_materno = _ap_materno;
            dato.F_nacimiento = _f_nacimiento;
            dato.Nro_documento = _nro_documento;
            dato.Tipo_documento = _tipo_documento;
            dato.Estado_civil = _estado_civil;
            dato.Sexo = _sexo;
            dato.Telefono = _telefono;
            dato.Direccion = _direccion;
            dato.Zona = _zona;
            dato.Id_cargo = _id_cargo;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(int _codigo, string _estado, DateTime _f_retiro)
        {
            D_Personal dato = new D_Personal();

            dato.Codigo = _codigo;
            dato.Estado = _estado;
            dato.F_retiro = _f_retiro;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado, string _buscarpor)
        {
            return new D_Personal().Buscar(_txtbuscar, _estado, _buscarpor);
        }

        public static DataTable Consulta_Id(int _codigo)
        {
            D_Personal dato = new D_Personal();

            dato.Codigo = _codigo;

            return dato.Consulta_Id(dato);
        }
        public static DataTable Consultar_No_Asignados()
        {
            return new D_Personal().Consultar_No_Asignados();
        }
        public static DataTable sp_Personal_No_Asignado_MEMORANDUM()
        {
            return new D_Personal().sp_Personal_No_Asignado();
        }
    }
}
