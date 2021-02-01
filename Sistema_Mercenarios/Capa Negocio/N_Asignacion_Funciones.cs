using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Asignacion_Funciones
    {
        public static string Registrar(string _id_usuario)
        {
            D_Asignacion_Funciones dato = new D_Asignacion_Funciones();

            dato.Id_usuario = _id_usuario;

            return dato.Registrar(dato);
        }

        public static DataTable Consulta_Id_Asignacion(string _codigo)
        {
            D_Asignacion_Funciones dato = new D_Asignacion_Funciones();

            dato.Codigo = _codigo;

            return dato.Consulta_Id_Asignacion(dato);
        }
    }
}
