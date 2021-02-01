using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
namespace Capa_Negocio
{
    public class N_PERMISO
    {
        public static string Registrar(int cod, DateTime fec, string obse, int codi_autor) {
            D_PERMISO p = new D_PERMISO();
            p.CODIGO_CONTROL = cod;
            p.FECHA = fec;
            p.OBSERVACION = obse;
            p.CODIGO_AUTORIZACION = codi_autor;
            return p.Registrar(p);
        }
    }
}
