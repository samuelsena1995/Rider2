using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Tipo_Herramientas_Uniformes
    {
        public static string Registrar(string _estado, DateTime _f_registro, string _nombre, string _tipo, string _talla, int _stock, string _descripcion)
        {
            D_Tipo_Herramientas_Uniformes dato = new D_Tipo_Herramientas_Uniformes();

            dato.Estado = _estado;
            dato.F_registro = _f_registro;
            dato.Nombre = _nombre;
            dato.Tipo = _tipo;
            dato.Talla = _talla;
            dato.Stock = _stock;
            dato.Descripcion = _descripcion;

            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Tipo_Herramientas_Uniformes().Consultar_Todo();
        }
        public static string Eliminar(int _codigo)
        {
            D_Tipo_Herramientas_Uniformes dato = new D_Tipo_Herramientas_Uniformes();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(int _codigo, string _nombre, string _tipo, string _talla, int _stock, string _descripcion)
        {
            D_Tipo_Herramientas_Uniformes dato = new D_Tipo_Herramientas_Uniformes();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Tipo = _tipo;
            dato.Talla = _talla;
            dato.Stock = _stock;
            dato.Descripcion = _descripcion;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_Tipo_Herramientas_Uniformes dato = new D_Tipo_Herramientas_Uniformes();

            dato.Codigo = _codigo;
            dato.Estado = _estado;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado, string _tipo)
        {
            return new D_Tipo_Herramientas_Uniformes().Buscar(_txtbuscar, _estado, _tipo);
        }

        public static DataTable Consulta_Id(int _codigo)
        {
            D_Tipo_Herramientas_Uniformes dato = new D_Tipo_Herramientas_Uniformes();

            dato.Codigo = _codigo;

            return dato.Consulta_Id(dato);
        }
    }
}
