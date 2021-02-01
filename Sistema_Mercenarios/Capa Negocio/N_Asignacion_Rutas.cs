using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Asignacion_Rutas
    {
       /* public static string Registrar(string _estado, string _observacion, int _id_ruta, int[] _detalle)
        {
            D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

            dato.Estado = _estado;
            dato.Observacion = _observacion;
            dato.Id_ruta = _id_ruta;

            return dato.Registrar(_detalle);
        }*/

        public static DataTable Consultar_Todo_()
        {
            return new D_Asignacion_Rutas().Consultar_Todo();
        }
        //public static string Eliminar(int _codigo)
        //{
        //    D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

        //    dato.Codigo__personal = _codigo;

        //    return dato.Eliminar(dato);
        //}
     /*   public static string Editar(int _codigo, string _observacion, int _id_ruta, int[] _detalle)
        {
            D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

            dato.Codigo = _codigo;
            dato.Observacion = _observacion;
            dato.Id_ruta = _id_ruta;

            return dato.Editar(_detalle);
        }*/
        //public static string CambiarEstado(int _codigo, string _estado)
        //{
        //    D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

        //    dato.Codigo__personal = _codigo;
        //    dato.Estado = _estado;

        //    return dato.Cambiar_Estado(dato);
        //}

        //public static DataTable Buscar(string _txtbuscar, string _estado)
        //{
        //    return new D_Asignacion_Rutas().Buscar(_txtbuscar, _estado);
        //}

        //public static DataTable Consulta_Id(int _codigo)
        //{
        //    D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

        //    dato.Codigo__personal = _codigo;

        //    return dato.Consulta_Id(dato);
        //}
        //7///////7
        //////7
        //public static string REGISTRAR_USUARIO_DETALLE_RUTAS(int codi_ruta, int codigo_personal, string obsercacion, string estado)
        //{
        //    D_Asignacion_Rutas dato = new D_Asignacion_Rutas();

        //    dato.Estado = estado;
        //    dato.Observacion = obsercacion;
        //    dato.Id_ruta = codi_ruta;
        //    dato.Codigo__personal = codigo_personal;

        //    return dato.REGISTRAR_USUARIO_DETALLE_RUTAS(dato);
        //}
    }
}
