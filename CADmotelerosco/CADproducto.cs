namespace CADmotelerosco
{
    using CADmotelerosco.DSproductosTableAdapters;

    public class CADproducto
    {
        public int IDProducto { get; set; }
        public string Descripcion { get; set; }
        public int IDDepartamento { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public string Notas { get; set; }
        public int IDPresentacion { get; set; }
        public float Medida { get; set; }
        //public string Imagen { get; set; }

        private static ProductoTableAdapter adaptador = new ProductoTableAdapter();

        //Metodo que devuelve un objeto (empaquetado) de la clase CADusuario
        public static CADproducto ConsultarProducto_x_Barra(long Barra)
        {
            CADproducto miProducto = null;
            DSproductos.ProductoDataTable miTabla = adaptador.ConsultarProducto_x_Barra(Barra);
            if (miTabla.Rows.Count == 0) return miProducto;
            DSproductos.ProductoRow miRegistro = (DSproductos.ProductoRow)miTabla.Rows[0];
            miProducto = new CADproducto();
            miProducto.IDProducto = miRegistro.IDProducto;
            miProducto.Descripcion = miRegistro.Descripcion;
            miProducto.IDDepartamento = miRegistro.IDDepartamento;
            miProducto.Precio = miRegistro.Precio;
            miProducto.Notas = miRegistro.Notas;
            //miProducto.Imagen = miRegistro.Imagen;
            miProducto.IDPresentacion = miRegistro.IDPresentacion;
            miProducto.Medida = miRegistro.Medida;
            return miProducto;
        }

        //Metodo que devuelve un objeto (empaquetado) de la clase CADusuario
        public static CADproducto ConsultarProducto_x_IDProducto(int IDProducto)
        {
            CADproducto miProducto = null;
            DSproductos.ProductoDataTable miTabla = adaptador.ConsultarProducto_x_IDProducto(IDProducto);
            if (miTabla.Rows.Count == 0) return miProducto;
            DSproductos.ProductoRow miRegistro = (DSproductos.ProductoRow)miTabla.Rows[0];
            miProducto = new CADproducto();
            miProducto.IDProducto = (int)miRegistro.IDProducto;
            miProducto.Descripcion = miRegistro.Descripcion;
            miProducto.IDDepartamento = miRegistro.IDDepartamento;
            miProducto.Costo = miRegistro.Costo;
            miProducto.Precio = miRegistro.Precio;
            miProducto.Notas = miRegistro.Notas;
            miProducto.IDPresentacion = miRegistro.IDPresentacion;
            miProducto.Medida = miRegistro.Medida;
            //miProducto.Imagen = miRegistro.Imagen;
            return miProducto;
        }


        //Metodo que devuelve un objeto (empaquetado) de la clase CADusuario
        public static CADproducto ConsultarByIDProducto(int IDProducto)
        {
            CADproducto miProducto = null;
            DSproductos.ProductoDataTable miTabla = adaptador.ConsultaByIDProducto(IDProducto);
            if (miTabla.Rows.Count == 0) return miProducto;
            DSproductos.ProductoRow miRegistro = (DSproductos.ProductoRow)miTabla.Rows[0];
            miProducto = new CADproducto();
            miProducto.IDProducto = miRegistro.IDProducto;
            miProducto.Descripcion = miRegistro.Descripcion;
            miProducto.IDDepartamento = miRegistro.IDDepartamento;
            miProducto.Costo = miRegistro.Costo;
            miProducto.Precio = miRegistro.Precio;
            return miProducto;
        }

        //public static DSproductos.ProductoDataTable ConsultarProductosID2()
        //{
        //    return adaptador.ConsultarProductosID2();
        //}


        // Editar el costo del producto
        public static void EditarCostoProducto_IDproducto(decimal Costo, int IDProducto)
        {
            adaptador.EditarCostoProducto_IDproducto(Costo, IDProducto);
        }

        // Saber cual es el ultimo producto
        public static int UltimoProducto()
        {

            if (adaptador.UltimoProducto() == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.UltimoProducto();
            }
        }

        // Insertar producto
        public static void InsertarProducto(int IDproducto, string Descripcion, int IDDepartamento, decimal Costo, decimal Precio, string Notas, byte[] Imagen, int IDPresentacion, int Medida)
        {
            adaptador.InsertarProducto(IDproducto, Descripcion, IDDepartamento, Costo, Precio, Notas, Imagen, IDPresentacion, Medida);
        }

        public static int ConsultarProducto_x_Descripcion(string Descripcion)
        {

            if (adaptador.ConsultarProducto_x_Descripcion(Descripcion) == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.ConsultarProducto_x_Descripcion(Descripcion);
            }
        }

        public static int num_reg_productos()
        {
            if (adaptador.num_reg_productos() == null)
            {
                return 0;
            }
            else
            {
                return (int)adaptador.num_reg_productos();
            }
        }

        public static int NoRepetirProducto(int IDproducto)
        {
            if (adaptador.NoRepetirProducto(IDproducto) == null)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public static void EditarProductos(int IDProducto, string Descripcion, int IDDepartamento, decimal Costo, decimal Precio, string Notas, int IDPresentacion, int Medida, byte[] Imagen)
        {
            adaptador.EditarProductos(IDProducto, Descripcion, IDDepartamento, Costo, Precio, Notas, IDPresentacion, Medida, Imagen);
        }

        public static DSproductos.ProductoDataTable ConsultarProducto_x_IDdepartamento(int IDdepartamento)
        {
            return adaptador.ConsultarProducto_x_IDdepartamento(IDdepartamento);
        }
    }
}
