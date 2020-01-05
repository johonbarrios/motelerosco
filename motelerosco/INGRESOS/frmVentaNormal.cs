namespace motelerosco.INGRESOS
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using CADmotelerosco;
    using motelerosco.CLASES;
    public partial class frmVentaNormal : Form
    {
        #region ARREGLOS

        List<DetalleVenta> misDetalle = new List<DetalleVenta>();
        List<DetalleKardex> misDetalleII = new List<DetalleKardex>();

        List<DetalleAdicionales> misAdicionales = new List<DetalleAdicionales>();
        List<DetalleAdicionalesOrigen> misAdicionalesOrigen = new List<DetalleAdicionalesOrigen>();

        List<DetalleDescuentos> misDescuentos = new List<DetalleDescuentos>();
        List<DetalleDescuentosOrigen> misDescuentosOrigen = new List<DetalleDescuentosOrigen>();

        #endregion ARREGLOS


        #region VARIABLES

        CADproducto UltimoProducto = null;
        CADadicionales ultimoAdicional = null;
        CADdescuentos ultimoDecuento = null;

        private string Auxhab;
        private int ttpocision;
        private Boolean validarPlaca;

        // para los totales de la venta
        public decimal TotalTiempo = 0;
        private decimal TotalProductos = 0;
        private decimal TotalAdicionales = 0;
        private decimal TotalDescuentos = 0;
        private decimal TotalPaga = 0;

        #endregion VARIABLES


        #region PROPIEDADES

        private Boolean tiempoCongelado;
        public Boolean TiempoCongelado
        {
            get { return tiempoCongelado; }
            set { tiempoCongelado = value; }
        }

        private CADusuario usuarioLogueado;
        public CADusuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }
        private Boolean edicion;
        public Boolean Edicion
        {
            get { return edicion; }
            set { edicion = value; }
        }

        private DateTime femovimiento;
        public DateTime FeMovimiento
        {
            get { return femovimiento; }
            set { femovimiento = value; }
        }

        private DateTime feentrada;
        public DateTime FeEntrada
        {
            get { return feentrada; }
            set { feentrada = value; }
        }

        private DateTime fesalida;
        public DateTime FeSalida
        {
            get { return fesalida; }
            set { fesalida = value; }
        }

        private string idhabitacion;
        public string IDhabitacion
        {
            get { return idhabitacion; }
            set { idhabitacion = value; }
        }

        private int idventa;
        public int IDventa
        {
            get { return idventa; }
            set { idventa = value; }
        }

        private string xcliente;
        public string Xcliente
        {
            get { return xcliente; }
            set { xcliente = value; }
        }

        private string xforna;
        public string Xforna
        {
            get { return xforna; }
            set { xforna = value; }
        }

        private string xvehiculo;
        public string Xvehiculo
        {
            get { return xvehiculo; }
            set { xvehiculo = value; }
        }

        private int ximagen;
        public int Ximagen
        {
            get { return ximagen; }
            set { ximagen = value; }
        }

        #endregion PROPIEDADES



        public frmVentaNormal()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOpc_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelAdic_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDesc_Paint(object sender, PaintEventArgs e)
        {

        }



        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }



        private void btnAdicionales_Click(object sender, EventArgs e)
        {
            showSubMenu(panelAdic);
        }

        private void hideSubMenu()
        {
            panelAdic.Visible = false;
        }

        private void frmVentaNormal_Load(object sender, EventArgs e)
        {

        }
    }
}
