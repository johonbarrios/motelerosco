using System;
using CADmotelerosco.DSmoteleroscoTableAdapters;
using System.Data.SqlClient;

namespace CADmotelerosco
{
    public class CADestadohab
    {
        public string IdHabitacion { get; set; }
        public string Estado { get; set; }
        public int IdFactura { get; set; }
        public int IdDocumento { get; set; }
        public string IdCliente { get; set; }
        public string Forma { get; set; }
        public string Tiempo { get; set; }


        private static Estado_HabitacionesTableAdapter adaptador = new Estado_HabitacionesTableAdapter();

        public static CADestadohab VerificarEstado(string IdHabitacion)
        {
            CADestadohab miEstado = null;
            DSmotelerosco.Estado_HabitacionesDataTable miTabla = adaptador.VerificarEstado(IdHabitacion);
            if (miTabla.Rows.Count == 0) return miEstado;
            DSmotelerosco.Estado_HabitacionesRow miRegistro = (DSmotelerosco.Estado_HabitacionesRow)miTabla.Rows[0];
            miEstado = new CADestadohab();
            miEstado.IdHabitacion = miRegistro.IdHabitacion;
            miEstado.Estado = miRegistro.Estado;
            miEstado.IdFactura = miRegistro.IdFactura;
            miEstado.IdDocumento = miRegistro.IdDocumento;
            miEstado.IdCliente = miRegistro.IdCliente;
            miEstado.Forma = miRegistro.Forma;
            miEstado.Tiempo = miRegistro.Tiempo;
            return miEstado;
        }

        public static void ModificarEstado(string IdHabitacion, string Estado, int IdFactura, int IdDocumento, string IdCliente, string Forma, string Tiempo)
        {
            adaptador.ModificarEstado(IdHabitacion, Estado, IdFactura, IdDocumento, IdCliente, Forma, Tiempo);
        }

    }
}
