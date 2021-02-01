using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
namespace Capa_Negocio
{
   public class N_DETALLE_PERSONAL_TURNO_RUTA
    {
        public static string Registra_PERSONAL_TURNO_DERUTA(
      string estado, string observacion, string estado_detalle,
      int codigoruta_detalle,int codigo_turnodetalle,DateTime fechainic,
      DateTime fechafin)//, DataTable table_detalle)
        {
            Capa_Datos.D_DETALLE_PERSONAL_TURNO_RUTA_AUXILIAR obj = new Capa_Datos.D_DETALLE_PERSONAL_TURNO_RUTA_AUXILIAR();
            obj._ESTADO = estado;
            List<D_DETALLE_PERSONAL_TURNO_RUTA> detall = new List<D_DETALLE_PERSONAL_TURNO_RUTA>();
            //foreach (DataRow item in table_detalle.Rows)
            //{
                D_DETALLE_PERSONAL_TURNO_RUTA dtres = new D_DETALLE_PERSONAL_TURNO_RUTA();
 
                dtres._CODIGO_RUTA = codigoruta_detalle;
                dtres._CODIGO_TURNO = codigo_turnodetalle;
                dtres._FECHA_INICIO = fechainic;
                dtres._FECHA_FIN = fechafin;
                dtres._OBSERVACIONES = observacion;
                dtres._ESTADO = estado_detalle;
                detall.Add(dtres);
            //}
            return obj.Insertar(obj,dtres);

        }


        public static DataTable MOSTRAR_DETALLE_TURNO_RUTA()
        {
            return new D_DETALLE_PERSONAL_TURNO_RUTA().Consultar_DETALLE_TURNO_RUTA();       
        }
        public static DataTable PERSONAL_TURNO_RUTA_NO_ASIGNADO() {
            return new D_DETALLE_PERSONAL_TURNO_RUTA().PERSONAL_TURNO_RUTA_NO_ASIGNADO();
        }
        public static DataTable SP_CONSULTAR_ID_PERSONAL_DETALLE_TURNO_RUTA(int codigo)
        {
            D_DETALLE_PERSONAL_TURNO_RUTA rubro = new D_DETALLE_PERSONAL_TURNO_RUTA();

            rubro._CODIGODETALLE_TURNO = codigo;

            return rubro.Consulta_Id_DETALLE_TURNO_RUTA(rubro);
        }

        public static string Editar(int _codigo_detalle, int idruta,int idturno,DateTime fecinicio,DateTime fechafin, string _descripcion)
        {
            D_DETALLE_PERSONAL_TURNO_RUTA dato = new D_DETALLE_PERSONAL_TURNO_RUTA();

            dato._CODIGODETALLE_TURNO = _codigo_detalle;
            dato._CODIGO_RUTA = idruta;
            dato._CODIGO_TURNO = idturno;
            dato._FECHA_INICIO = fecinicio;
            dato._FECHA_FIN = fechafin;
            dato._OBSERVACIONES = _descripcion;

            return dato.EDITAR_PERSONAL_TURNO_RUTA(dato);
        }
        public static string CambiarEstado(int codi,string estado) {
            D_DETALLE_PERSONAL_TURNO_RUTA o = new D_DETALLE_PERSONAL_TURNO_RUTA();
            o._CODIGODETALLE_TURNO = codi;
            o._ESTADO = estado;
            return o.Cambiar_Estado(o);
        }
        public static string Eliminar(int codi)
        {
            D_DETALLE_PERSONAL_TURNO_RUTA o = new D_DETALLE_PERSONAL_TURNO_RUTA();
            o._CODIGODETALLE_TURNO = codi;
            return o.Eliminar(o);
        }
        public static DataTable Buscar(string _txtbuscar, string _festado, string _zona)
        {
            return new D_DETALLE_PERSONAL_TURNO_RUTA().Buscar(_txtbuscar, _festado, _zona);
        }
    }
}
