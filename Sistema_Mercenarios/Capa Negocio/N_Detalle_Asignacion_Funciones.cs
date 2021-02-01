using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Detalle_Asignacion_Funciones
    {
        public static string Registrar(string _id_asignacion, string _id_funcion)
        {
            D_Detalle_Asignacion_Funciones dato = new D_Detalle_Asignacion_Funciones();

            dato.Cod_asignacion = _id_asignacion;
            dato.Cod_Funcion = _id_funcion;

            return dato.Registrar(dato);
        }


    }
}
