using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
namespace Capa_Negocio
{
   public class N_FALTA
    {
        public static string Registrar(int codi, DateTime fec, string obser) {
            D_FALTA o = new D_FALTA();
            o.CODIGO_CONTROL = codi;
            o.FECHA = fec;
            o.OBSERVACION = obser;
            return o.Registrar(o);
        }
    }
}
