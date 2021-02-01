using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Turnos
    {
        public static string Registrar(string _estado, string _nombre, string _descripcion)
        {
            D_Turnos dato = new D_Turnos();

            dato.Estado = _estado;
            dato.Nombre = _nombre;
            dato.Descripcion = _descripcion;

            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Turnos().Consultar_Todo();
        }
        public static string Eliminar(int _codigo)
        {
            D_Turnos dato = new D_Turnos();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(int _codigo, string _nombre, string _descripcion)
        {
            D_Turnos dato = new D_Turnos();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Descripcion = _descripcion;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_Turnos dato = new D_Turnos();

            dato.Codigo = _codigo;
            dato.Estado = _estado;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado)
        {
            return new D_Turnos().Buscar(_txtbuscar, _estado);
        }

        public static DataTable Consulta_Id(int _codigo)
        {
            D_Turnos dato = new D_Turnos();

            dato.Codigo = _codigo;

            return dato.Consulta_Id(dato);
        }

        public static DataTable Consulta_Nombre(string _nombre)
        {
            D_Turnos dato = new D_Turnos();
            dato.Nombre = _nombre;

            return dato.Consulta_Nombre(dato);
        }
    }
}
