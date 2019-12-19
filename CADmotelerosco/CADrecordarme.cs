namespace CADmotelerosco
{
    using CADmotelerosco.DSmoteleroscoTableAdapters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CADrecordarme
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }


        private static RecordarmeTableAdapter adaptador = new RecordarmeTableAdapter();

        //Metodo que devuelve un objeto (empaquetado) de la clase CADrecordarme
        public static CADrecordarme GetRecordarmeID(int ID)
        {
            CADrecordarme miRecordarme = null;
            DSmotelerosco.RecordarmeDataTable miTabla = adaptador.GetRecordarmeID(ID);
            if (miTabla.Rows.Count == 0) return miRecordarme;
            DSmotelerosco.RecordarmeRow miRegistro = (DSmotelerosco.RecordarmeRow)miTabla.Rows[0];
            miRecordarme = new CADrecordarme();
            miRecordarme.ID = miRegistro.ID;
            miRecordarme.Usuario = miRegistro.Usuario;
            miRecordarme.Clave = miRegistro.Clave;
            miRecordarme.Estado = miRegistro.Estado;
            return miRecordarme;
        }


        public static void EditarRecordarme(int ID, string Usuario, string Clave, string Estado)
        {
            adaptador.EditarRecordarme(ID, Usuario, Clave, Estado);
        }
    }
}
