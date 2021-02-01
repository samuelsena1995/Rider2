using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
namespace Sistema_Mercenarios
{
    static class Program
    {
        public static string USUARIO_GLOBAL;
        public static string PASSWORD_GLOBAL;
        public static int ID_USUARIO_GLOBAL;
        public static string NOMBRECOMPLETO_USUARIO_GLOBAL;

        public static string IP() {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        #region Variables
        public static bool isnuevo = false;
        public static bool ismodificar = false;

        public static bool isnuevoPersonal = false;
        public static bool ismodificarPersonal = false;

        public static bool isnuevoCargo = false;
        public static bool ismodificarCargo = false;

        public static bool Cambio_Estado = false;
        public static bool SeleccionarCliente = false;

        public static bool isnuevoTurno = false;
        public static bool ismodificarTurno = false;

        public static bool isnuevoUsuario = false;
        public static bool ismodificarUsuario = false;

        public static bool isnuevoDetalleRuta = false;
        public static bool ismodificarDetalleRuta = false;

        public static bool isnuevaFuncion = false;
        public static bool ismodificarFuncion = false;


        public static bool isnuevoPersonalTurnoRuta = false;
        public static bool ismodificarPersonalTurnoRuta = false;
        //public static string Nombre_Cargo;
        //public static string Nombre_Usuario;
        //public static string Nombre_Trabajador;
        //public static int Id_Usuario;
        //public static int Id_Rol;

        public static int Menu_Principal;
        public static int[] resultado_funcion = new int[60];

        public static int Tiene_Cliente = 0;
        public static int Tiene_Trabajador = 0;
        public static int Tiene_Rol = 0;
        public static int Tiene_Usuario = 0;
        public static int Tiene_Sucursal = 0;

        #endregion

        public static bool isnuevo_falta = false;
        public static bool isnuevo_Retraso = false;
        public static bool isnuevo_Memorandum = false;
        public static bool isnuevo_permiso = false;
        public static bool isnuevo_control_asistencia = false;
        public static bool ismodificar_control_asistencia = false;
        public static bool isnuevoControlAsistencia = false;
        public static bool ismodificarControlASistencia = false;

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new INICIO_SESION());
        }
    }
}
