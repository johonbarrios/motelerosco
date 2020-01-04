namespace CADmotelerosco
{
    using CADmotelerosco.DSmoteleroscoTableAdapters;
    public class CADpermisorol
    {
        private static PermisoRolTableAdapter adaptador = new PermisoRolTableAdapter();

        public static bool PuedeVer(int IDRol, string Formulario)
        {
            if (adaptador.PuedeVer(IDRol, Formulario) == null) return false;
            return true;
        }

        public static bool PuedeModificar(int IDRol, string Formulario)
        {
            if (adaptador.PuedeModificar(IDRol, Formulario) == null) return false;
            return true;
        }

        public static bool PuedeBorrar(int IDRol, string Formulario)
        {
            if (adaptador.PuedeBorrar(IDRol, Formulario) == null) return false;
            return true;
        }
    }
}
