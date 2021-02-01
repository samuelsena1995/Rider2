using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
namespace Capa_Negocio
{
  public  class N_CONTROL_ASISTENCIA
    {
        public static string Registrar(
            DateTime _fecha ,int CodigoxPErosnalxTurnoxRuta ,
            string _descripcion,string estado)
        {
            D_CONTROL_ASISTENCIA dato = new D_CONTROL_ASISTENCIA();
            dato._FECHA = _fecha;
            dato._CODIGO_PERSONALTURNO_RUTA = CodigoxPErosnalxTurnoxRuta;
            dato._DESCRIPCION = _descripcion;
            dato._ESTADO = estado;        
            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_CONTROL_ASISTENCIA().Consultar_Todo();
        }
        public static string Eliminar(int _codigo)
        {
            D_Cargos dato = new D_Cargos();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(int _codigo, string _nombre, decimal _sueldo, string _descripcion)
        {
            D_Cargos dato = new D_Cargos();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Sueldo = _sueldo;
            dato.Descripcion = _descripcion;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_CONTROL_ASISTENCIA dato = new D_CONTROL_ASISTENCIA();

            dato._CODIGO = _codigo;
            dato._ESTADO = _estado;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado)
        {
            return new D_Cargos().Buscar(_txtbuscar, _estado);
        }

        public static DataTable Consulta_Id(int _codigo)
        {
            D_CONTROL_ASISTENCIA dato = new D_CONTROL_ASISTENCIA();

            dato._CODIGO = _codigo;

            return dato.Consulta_Id(dato);
        }
    }
}
