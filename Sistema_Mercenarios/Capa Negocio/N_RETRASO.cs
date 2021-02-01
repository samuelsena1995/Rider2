using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
namespace Capa_Negocio
{
   public class N_RETRASO
    {
        public static string Registrar(int cod, DateTime fec,string observacion, string minuto)
        {
            D_RETRASO r = new D_RETRASO();
            r.CODIGO_CONTROL = cod;
            r.FECHA = fec;
            r.OBSERVACION = observacion;
            r.MINUTO = minuto;
            return r.Registrar(r);

        }
    }
}
