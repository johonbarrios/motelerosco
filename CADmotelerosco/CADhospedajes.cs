
namespace CADmotelerosco
{
    using CADmotelerosco.DSventasnormalesTableAdapters;
    using System;
    using System.Linq;

    public class CADhospedajes
    {
        public int IDhospedaje { get; set; }
        public int IDventa { get; set; }
        public string IDhabitacion { get; set; }
        public DateTime Hentrada { get; set; }
        public DateTime Hsalida { get; set; }
        public string Tiempo { get; set; }
        public decimal Importe { get; set; }


        private static ventaHospedajeTableAdapter adaptador = new ventaHospedajeTableAdapter();

        public static CADhospedajes ConsultarVentaHospedaje_IDventa(int IDventa)
        {
            CADhospedajes miVentaHospedaje = null;
            DSventasnormales.ventaHospedajeDataTable miTabla = adaptador.ConsultarVentaHospedaje_IDventa(IDventa);
            if (miTabla.Rows.Count == 0) return miVentaHospedaje;
            DSventasnormales.ventaHospedajeRow miRegistro = (DSventasnormales.ventaHospedajeRow)miTabla.Rows[0];
            miVentaHospedaje = new CADhospedajes();
            miVentaHospedaje.IDhospedaje = miRegistro.IDhospedaje;
            miVentaHospedaje.IDventa = miRegistro.IDventa;
            miVentaHospedaje.IDhabitacion = miRegistro.IDhabitacion;
            miVentaHospedaje.Hentrada = miRegistro.Hentrada;
            miVentaHospedaje.Hsalida = miRegistro.Hsalida;
            miVentaHospedaje.Tiempo = miRegistro.Tiempo;
            miVentaHospedaje.Importe = miRegistro.Importe;
            return miVentaHospedaje;
        }
    }
}
