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
   public class N_Detalle_Asignacion_Rutas
    {
        //////
        public static string Registra_Reserva(
          string estado,string observacion,string estado_detalle,int codigoruta_detalle, DataTable table_detalle)
        {
            D_AuxiliarDetalle_Ruta obj = new D_AuxiliarDetalle_Ruta();
            obj._Estado = estado;
            List<D_Detalle_Asignacion_Rutas> detall = new List<D_Detalle_Asignacion_Rutas>();
            foreach (DataRow item in table_detalle.Rows)
            {
                D_Detalle_Asignacion_Rutas dtres = new D_Detalle_Asignacion_Rutas();
                //   dtres.Idreserva = Convert.ToInt32(item["IDRESERVA"].ToString());
                //dtres._CodigoRuta = Convert.ToInt32(item["Codigo_ruta"].ToString());
                // dtres._CodPersonal = Convert.ToInt32(item["Codigo_personal"].ToString());

                //dtres._Estado = Convert.ToString(item["ESTADO"].ToString());
                //dtres._CodigoRuta = 
                dtres._CodigoRuta = codigoruta_detalle;
                dtres._Observacion = observacion;
                dtres._Estado = estado_detalle;
                dtres._CodPersonal = Convert.ToInt32(item["CODIGO"].ToString());
                //dtres._Observacion=Convert.ToString()
                detall.Add(dtres);
            }
            return obj.Insertar(obj, detall);

        }

        ///ver los datos en el datagridview
        public static DataTable Consultar_Todo_detalle_asignacionrutas()
        {
            return new D_Detalle_Asignacion_Rutas().Consultar_Todo_detalle_asignacionrutas();
        }

        /// <summary>
        /// OCULTAR LOS QUE ESTAN REGISTRADO EN LA TABLA DE PERSONALXTURNOXRUTA
        public static DataTable Consultar_Todo_detalle_no_asignados()
        {
            return new D_Detalle_Asignacion_Rutas().Consultar_Todo_detalle__NO_ASIGNADOS();
        }
        /// </summary>
        /// <param name="_codigo"></param>
        /// <returns></returns>
        public static DataTable Consulta_Id_DETALLE_RUTA(int _codigo)//
        {
            D_Detalle_Asignacion_Rutas dato = new D_Detalle_Asignacion_Rutas();

            dato._CodigoAuxiliar = _codigo;

            return dato.Consulta_Id_DETALLE_RUTA(dato);
        }
        public static DataTable Consulta_persona_mostrar(int _codigoAUX/*, int CODIRUTA*/)
        {
            D_Detalle_Asignacion_Rutas dato = new D_Detalle_Asignacion_Rutas();

            dato._CodigoAuxiliar = _codigoAUX;
          //  dato._CodigoRuta = CODIRUTA;

            return dato.Consulta_Id_persona_mostrar(dato);
        }
        //cambiarestado
        public static string CAMBIO_ESTADO(int cod,string estado) {
            D_Detalle_Asignacion_Rutas o = new D_Detalle_Asignacion_Rutas();
            o._CodigoAuxiliar = cod;
            o._Estado = estado;
            return o.Cambiar_Estado(o);
        }
        ///eliminar
        public static string eliminar(int codi) {
            D_Detalle_Asignacion_Rutas o = new D_Detalle_Asignacion_Rutas();
            o._CodigoAuxiliar = codi;
            return o.Eliminar(o);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado, string _buscarpor)
        {
            return new D_Detalle_Asignacion_Rutas().Buscar(_txtbuscar, _estado, _buscarpor);
        }

    }
}
