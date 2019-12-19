using CADmotelerosco.DSmoteleroscoTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADmotelerosco
{
    public class CADventas
    {
        public int IDventa { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public int IDdocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public int Imagen { get; set; }
        public decimal TotalTiempo { get; set; }
        public decimal TotalProducto { get; set; }
        public decimal TotalAdicional { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalFactura { get; set; }
        public string Emitido { get; set; }
        public string Forma { get; set; }


        private static VentaTableAdapter adaptador = new VentaTableAdapter();

        public static CADventas ConsultarVenta_x_IDventa(int IDventa)
        {
            CADventas miVenta = null;
            DSmotelerosco.VentaDataTable miTabla = adaptador.ConsultarVenta_x_IDventa(IDventa);
            if (miTabla.Rows.Count == 0) return miVenta;
            DSmotelerosco.VentaRow miRegistro = (DSmotelerosco.VentaRow)miTabla.Rows[0];
            miVenta = new CADventas();
            miVenta.IDventa = miRegistro.IDventa;
            miVenta.FechaMovimiento = miRegistro.FechaMovimiento;
            miVenta.IDdocumento = miRegistro.IDdocumento;
            miVenta.Documento = miRegistro.Documento;
            miVenta.Nombre = miRegistro.Nombre;
            miVenta.Imagen = miRegistro.Imagen;
            miVenta.TotalTiempo = miRegistro.TotalTiempo;
            miVenta.TotalProducto = miRegistro.TotalProductos;
            miVenta.TotalAdicional = miRegistro.TotalAdicional;
            miVenta.TotalDescuento = miRegistro.TotalDescuento;
            miVenta.TotalFactura = miRegistro.TotalFactura;
            miVenta.Emitido = miRegistro.Emitido;
            miVenta.Forma = miRegistro.Forma;
            return miVenta;
        }


    }
}
