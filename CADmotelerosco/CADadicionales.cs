namespace CADmotelerosco
{
    using CADmotelerosco.DSventasnormalesTableAdapters;
    public class CADadicionales
    {
        public int IDadicionales { get; set; }
        public int IDventa { get; set; }
        public string Detalle { get; set; }
        public decimal Importe { get; set; }


        private static ventaAdicionalesTableAdapter adaptador = new ventaAdicionalesTableAdapter();

        public static int ConsultarCodigoAdicionales(string Detalle)
        {
            return (int)adaptador.ConsultarCodigoAdicionales(Detalle);
        }


        public static DSventasnormales.ventaAdicionalesDataTable RegistrosVentaAdicionales_IDventa(int IDventa)
        {
            return adaptador.RegistrosVentaAdicionales_IDventa(IDventa);
        }

        //método eliminar registros de ventadetalle
        public static void EliminarVentaAdicionales_IDadicionales(int IDadicionales)
        {
            adaptador.EliminarVentaAdicionales_IDadicionales(IDadicionales);
        }



        // metodo que nos permite insertar registros en - VentaAdicionales
        public static void InsertarAdicionales(int IDadicionales, int IDventa, string Detalle, decimal Importe)
        {
            adaptador.InsertarAdicionales(IDadicionales, IDventa, Detalle, Importe);
        }


        public static int UltimaVentaAdicional()
        {
            if (adaptador.UltimaVentaAdicional() == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.UltimaVentaAdicional();
            }
        }
    }
}
