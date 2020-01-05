namespace CADmotelerosco
{
    using CADmotelerosco.DSventasnormalesTableAdapters;
    using System;

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
            DSventasnormales.VentaDataTable miTabla = adaptador.ConsultarVenta_x_IDventa(IDventa);
            if (miTabla.Rows.Count == 0) return miVenta;
            DSventasnormales.VentaRow miRegistro = (DSventasnormales.VentaRow)miTabla.Rows[0];
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

        public static int UltimaVenta()
        {
            if (adaptador.UltimaVenta() == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.UltimaVenta();
            }
        }


    }
}
