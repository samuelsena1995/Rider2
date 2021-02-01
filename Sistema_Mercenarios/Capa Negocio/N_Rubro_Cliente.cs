using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Rubro_Cliente
    {
        public static string Registrar(string _descripcion, string _estado)
        {
            D_Rubro_Cliente rubro = new D_Rubro_Cliente();

            rubro.Descripcion = _descripcion;
            rubro.Estado = _estado;

            return rubro.Registrar(rubro);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Rubro_Cliente().Consultar_Todo();
        }
        public static string Eliminar(int codigo)
        {
            D_Rubro_Cliente rubro = new D_Rubro_Cliente();
            rubro.Codigo = codigo;

            return rubro.Eliminar(rubro);
        }
        public static string Editar(int _codigo, string _descripcionn)
        {
            D_Rubro_Cliente rubro = new D_Rubro_Cliente();

            rubro.Codigo = _codigo;
            rubro.Descripcion = _descripcionn;

            return rubro.Editar(rubro);
        }
        public static string CambiarEstado(int _codigo, string _estado)
        {
            D_Rubro_Cliente rubro = new D_Rubro_Cliente();

            rubro.Codigo = _codigo;
            rubro.Estado = _estado;

            return rubro.Cambiar_Estado(rubro);
        }

        public static DataTable Buscar(string _txtbuscar, string _festado)
        {
            return new D_Rubro_Cliente().Buscar(_txtbuscar,_festado);
        }

        public static DataTable Consulta_Id(int codigo)
        {
            D_Rubro_Cliente rubro = new D_Rubro_Cliente();

            rubro.Codigo = codigo;

            return rubro.Consulta_Id(rubro);
        }

        public static DataTable Consulta_Nombre(string _nombre)
        {
            D_Rubro_Cliente dato = new D_Rubro_Cliente();
            dato.Descripcion = _nombre;

            return dato.Consulta_Nombre(dato);
        }
    }
}
