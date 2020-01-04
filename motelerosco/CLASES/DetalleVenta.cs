namespace motelerosco.CLASES
{
    class DetalleVenta
    {
        public int IDdepartamento { get; set; }
        public int IDproducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public int IDkardex { get; set; }
        public decimal Subtotal { get { return Precio * Cantidad; } }
    }
}
