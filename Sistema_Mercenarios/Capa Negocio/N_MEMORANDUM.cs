using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;
namespace Capa_Negocio
{
    public class N_MEMORANDUM
    {
        public static string Registrar(int codi, DateTime fec, string obser, int autorizado) {
            D_MEMORANDUM o = new D_MEMORANDUM();
            o.CODIGO_CONTROL = codi;
            o.FECHA = fec;
            o.OBSERVACION = obser;
            o.CODIGO_AUTORIZACION = autorizado;
            return o.Registrar(o);
        }
        public static DataTable MOSTRAR() {
            return new D_MEMORANDUM().Consultar_Todo();
        }
    }
}
