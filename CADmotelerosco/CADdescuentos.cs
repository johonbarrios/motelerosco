namespace CADmotelerosco
{
    using CADmotelerosco.DSmoteleroscoTableAdapters;
    public class CADdescuentos
    {
        public int IDdescuentos { get; set; }
        public int IDventa { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }

        private static ventaDescuentosTableAdapter adaptador = new ventaDescuentosTableAdapter();


        public static int UltimaVentaDescuento()
        {
            if (adaptador.UltimaVentaDescuento() == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.UltimaVentaDescuento();
            }
        }

        /*
        public static DSzeusaplicacion.ventaDescuentosDataTable RegistrosVentaDescuentos_IDventa(int IDventa)
        {
            return adaptador.RegistrosVentaDescuentos_IDventa(IDventa);
        }

        // metodo que nos permite insertar registros en - VentaDescuentos
        public static void InsertarDescuentos(int IdDescuento, int IDventa, string Detalle, decimal Importe)
        {
            adaptador.InsertarDescuentos(IdDescuento, IDventa, Detalle, Importe);
        }

        //método eliminar registros de ventaDescuentos
        public static void EliminarVentaDescuentos_IDdescuentos(int IDdescuentos)
        {
            adaptador.EliminarVentaDescuentos_IDdescuentos(IDdescuentos);
        }


        public static void InsertarVentaDescuento(int IdDescuentos, int IDventa, string Detalle, decimal Importe)
        {
            adaptador.InsertarVentaDescuento(IdDescuentos, IDventa, Detalle, Importe);
        }

        
        */
    }
}
