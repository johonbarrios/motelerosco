using System;
using CADmotelerosco.DSmoteleroscoTableAdapters;
using System.Data.SqlClient;


namespace CADmotelerosco
{
    public class CADusuario
    {
        public string IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public int IDRol { get; set; }
        public string Correo { get; set; }

        private static UsuarioTableAdapter adaptador = new UsuarioTableAdapter();


        public static bool ValidarUsuario(string IDUsuario, string Clave)
        {
            if (adaptador.ValidarUsuario(IDUsuario, Clave) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Metodo que devuelve un objeto (empaquetado) de la clase CADusuario
        public static CADusuario ConsultarRegistroUsuario(string IDUsuario)
        {
            CADusuario miUsuario = null;
            DSmotelerosco.UsuarioDataTable miTabla = adaptador.ConsultarRegistroUsuario(IDUsuario);
            if (miTabla.Rows.Count == 0) return miUsuario;
            DSmotelerosco.UsuarioRow miRegistro = (DSmotelerosco.UsuarioRow)miTabla.Rows[0];
            miUsuario = new CADusuario();
            miUsuario.Apellido = miRegistro.Apellidos;
            miUsuario.Nombre = miRegistro.Nombres;
            miUsuario.Clave = miRegistro.Clave;
            miUsuario.Correo = miRegistro.Correo;
            miUsuario.IDRol = miRegistro.IDRol;
            miUsuario.IDUsuario = miRegistro.IDUsuario;
            return miUsuario;
        }

    }
}
