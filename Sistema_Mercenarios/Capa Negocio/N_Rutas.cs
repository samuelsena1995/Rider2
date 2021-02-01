using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Rutas
    {
        public static string Registrar(string _descripcion, string _zona, string _estado)
        {
            D_Rutas ruta = new D_Rutas();

            ruta.Descripcion = _descripcion;
            ruta.Zona = _zona;
            ruta.Estado = _estado;

            return ruta.Registrar(ruta);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Rutas().Consultar_Todo();
        }
        public static string Eliminar(int codigo)
        {
            D_Rutas ruta = new D_Rutas();
            ruta.Codigo = codigo;

            return ruta.Eliminar(ruta);
        }
        public static string Editar(int _codigo, string _descripcion, string _zona)
        {
            D_Rutas ruta = new D_Rutas();

            ruta.Codigo = _codigo;
            ruta.Descripcion = _descripcion;
            ruta.Zona = _zona;


            return ruta.Editar(ruta);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_Rutas ruta = new D_Rutas();

            ruta.Codigo = _codigo;
            ruta.Estado = _estado;

            return ruta.Cambiar_Estado(ruta);
        }

        public static DataTable Buscar(string _txtbuscar, string _festado, string _zona)
        {
            return new D_Rutas().Buscar(_txtbuscar, _festado, _zona);
        }

        public static DataTable Consulta_Id(int codigo)
        {
            D_Rutas rubro = new D_Rutas();

            rubro.Codigo = codigo;

            return rubro.Consulta_Id(rubro);
        }
        public static DataTable Consulta_Nombre(string _zona)
        {
            D_Rutas dato = new D_Rutas();

            dato.Zona = _zona;

            return dato.Consulta_Nombre(dato);
        }
    }

}
