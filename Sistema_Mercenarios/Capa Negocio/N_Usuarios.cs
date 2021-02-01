using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

using System.Data;
using Capa_Datos;

namespace Capa_Negocio
{
    public class N_Usuarios
    {

        public static string Registrar(string _estado, string _nombre, string _usuario, string _clave, string _observacion)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Estado = _estado;
            dato.Nombre = _nombre;
            dato.Usuario = _usuario;
            dato.Clave = _clave;
            dato.Observacion = _observacion;

            return dato.Registrar(dato);
        }

        public static DataTable Consultar_Todo()
        {
            return new D_Usuarios().Consultar_Todo();
        }
        public static string Eliminar(string _codigo)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = _codigo;

            return dato.Eliminar(dato);
        }
        public static string Editar(string _codigo, string _nombre, string _usuario, string _clave, string _observacion)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = _codigo;
            dato.Nombre = _nombre;
            dato.Usuario = _usuario;
            dato.Clave = _clave;
            dato.Observacion = _observacion;

            return dato.Editar(dato);
        }
        public static string CambiarEstado(string _codigo, string _estado)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = _codigo;
            dato.Estado = _estado;

            return dato.Cambiar_Estado(dato);
        }

        public static DataTable Buscar(string _txtbuscar, string _estado)
        {
            return new D_Usuarios().Buscar(_txtbuscar, _estado);
        }

        public static DataTable Consulta_Id(string _codigo)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = _codigo;

            return dato.Consulta_Id(dato);
        }

        public static DataTable Consulta_Nombre(string _nombre)
        {
            D_Usuarios dato = new D_Usuarios();
            dato.Nombre = _nombre;

            return dato.Consulta_Nombre(dato);
        }

        public static string Encriptar(string cadena)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

            byte[] keyArray;
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public static string Desencriptar(string clave)
        {
            string key = "ABCDEFG54669525PQRSTUVWXYZabcdef852846opqrstuvwxyz";

            byte[] keyArray;
            byte[] Arreglo_a_Descifrar = Convert.FromBase64String(clave);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Descifrar, 0, Arreglo_a_Descifrar.Length);
            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(ArrayResultado);
        }


        /// <summary>
        /// /
        /// </summary>
        /// <returns></returns>
       
        public static string SP_REGISTRAR_ASIGNACION_FUNCIONES( string codFunci,string codi_usu)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = codi_usu;
            dato._Codigo_Funcion = codFunci;
  
            return dato.SP_REGISTRAR_ASIGNACION_FUNCIONES(dato);
        }
        public static DataTable SP_MOSTRAR_FUNCIONES(string codigo)//mostrar en la pantalla principal los permisos de ese usuario
        {
            D_Usuarios o = new D_Usuarios();
            o.Codigo = codigo;
            return o.SP_MOSTRAR_FUNCIONES(o);
        }
        public static string SP_ELIMINAR_USUARIO_ASIGNACION(string _codigo)
        {
            D_Usuarios dato = new D_Usuarios();

            dato.Codigo = _codigo;

            return dato.SP_ELIMINAR_USUARIO_ASIGNACION(dato);
        }


        ////login
        public static DataTable INICIO_SESION_NUEVO(string usuario, string password)
        {
            D_Usuarios obj = new D_Usuarios();

            obj.Usuario = usuario;
            obj.Clave = password;

            return obj.INICIO_SESION(obj);
        }
        public static DataTable MOSTRAR_Id_Permiso_Pantalla_principal(string codi)
        {
            D_Usuarios o = new D_Usuarios();
            o.Codigo = codi;
            return o.MOSTRAR_Id_Permiso_Pantalla_principal(o);
        }

        public static string COPIAR_ASIGNACIONPERMISO_NUEVO_USUARIO(string idusuario_nuevo, string idcopia_usuario)
        {
            D_Usuarios obj = new D_Usuarios();
            obj.Codigo = idusuario_nuevo;
            obj._COPIA_USUARIO = idcopia_usuario;
            return obj.COPIAR_ASIGNACIONPERMISO_NUEVO_USUARIO(obj);
        }

        public static string EditaR_Audi(string codigo, string ip1, string nombre) {
            D_Usuarios o = new D_Usuarios();
            o.Nombre = nombre;
            o.IP = ip1;
            o.Codigo = codigo;
            return o.Editar_AUDITORIA(o);
        }
    }
}
