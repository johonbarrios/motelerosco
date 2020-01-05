

namespace motelerosco.INGRESOS
{
    using CADmotelerosco;
    using motelerosco.CLASES;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;


    public partial class frmMenuVentas : Form
    {
        private const string MiConex = @"Data Source=.\MSQLEXPRESS;Initial Catalog=EROSco;Integrated Security=True;";

        private CADusuario usuarioLogueado;
        public CADusuario UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set { usuarioLogueado = value; }
        }


        private DateTime fechaMto;

        public DateTime FechaMto
        {
            get { return fechaMto; }
            set { fechaMto = value; }
        }
        public frmMenuVentas()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMenuVentas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            fechamtoDateTimePicker.Value = Convert.ToDateTime(VariablesUso.FeMovimiento);
            HabitacionesActivas();
        }

        private Image ObtenerVehiculoBDD(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(MiConex))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select [Foto] from fotoVehiculos where [IDfoto]=@IDfoto";
                    cmd.Parameters.Add("@IDfoto", SqlDbType.Int).Value = id;
                    byte[] arrImg = (byte[])cmd.ExecuteScalar();
                    MemoryStream ms = new MemoryStream(arrImg);
                    Image img = Image.FromStream(ms);
                    ms.Close();
                    return img;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void HabitacionesActivas()
        {
            int x;

            string aux;

            for (int contador = 1; contador < 16; contador++)
            {
                x = contador;
                if (x < 10)
                {
                    aux = "0" + Convert.ToString(x);
                }
                else
                {
                    aux = Convert.ToString(x);
                }


                // habitación 01
                // -------------
                if (x == 1)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        paHab1.Visible = true;

                        fra01.Visible = true;
                        dia01.Visible = true;
                        he01.Visible = true;
                        hs01.Visible = true;
                        tp01.Visible = true;
                        vh01.Visible = true;
                        vp01.Visible = true;
                        vad01.Visible = true;
                        vde01.Visible = true;
                        vt01.Visible = true;
                        imp01.Visible = true;
                        fra01.Text = Convert.ToString(miEstado.IdFactura);
                        et01.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto01.Image = null; return; }
                        try
                        {
                            Foto01.Image = ObtenerVehiculoBDD(str);
                            Foto01.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra01.Text));

                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra01.Text));

                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he01.Text = (myHoraEntrada.Substring(11, 8));
                        hee01.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp01.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad01.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde01.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip01.Text = Convert.ToString(miCliente.Nombre);
                        ruta01.Text = Convert.ToString(miCliente.Imagen);

                        fmto01.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss01.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss01.Text = string.Empty; }

                        forma01.Text = Convert.ToString(miEstado.Forma);

                    }
                }


                // habitación 02
                // -------------
                if (x == 2)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra02.Visible = true;
                        dia02.Visible = true;
                        he02.Visible = true;
                        hs02.Visible = true;
                        tp02.Visible = true;
                        vh02.Visible = true;
                        vp02.Visible = true;
                        vad02.Visible = true;
                        vde02.Visible = true;
                        vt02.Visible = true;
                        imp02.Visible = true;
                        fra02.Text = Convert.ToString(miEstado.IdFactura);
                        et02.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto02.Image = null; return; }
                        try
                        {
                            Foto02.Image = ObtenerVehiculoBDD(str);
                            Foto02.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra02.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra02.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he02.Text = (myHoraEntrada.Substring(11, 8));
                        hee02.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp02.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad02.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde02.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip02.Text = Convert.ToString(miCliente.Nombre);
                        ruta02.Text = Convert.ToString(miCliente.Imagen);
                        fmto02.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss02.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss02.Text = string.Empty; }

                        forma02.Text = Convert.ToString(miEstado.Forma);
                    }
                }



                // habitación 03
                // -------------
                if (x == 3)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        paHab3.Visible = true;
                        ett03.ForeColor = Color.Black;
                           

                       
                        fra03.Text = Convert.ToString(miEstado.IdFactura);
                        et03.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt32(miCliente.Imagen);
                        if (str == 0) { Foto03.Image = null; return; }
                        try
                        {
                            Foto03.Image = ObtenerVehiculoBDD(str);
                            Foto03.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra03.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra03.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he03.Text = (myHoraEntrada.Substring(11, 8));
                        hee03.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp03.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad03.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde03.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip03.Text = Convert.ToString(miCliente.Nombre);
                        ruta03.Text = Convert.ToString(miCliente.Imagen);
                        fmto03.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss03.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss03.Text = string.Empty; }

                        forma03.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 04
                // -------------
                if (x == 4)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra04.Visible = true;
                        dia04.Visible = true;
                        he04.Visible = true;
                        hs04.Visible = true;
                        tp04.Visible = true;
                        vh04.Visible = true;
                        vp04.Visible = true;
                        vad04.Visible = true;
                        vde04.Visible = true;
                        vt04.Visible = true;
                        imp04.Visible = true;
                        fra04.Text = Convert.ToString(miEstado.IdFactura);
                        et04.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto04.Image = null; return; }
                        try
                        {
                            Foto04.Image = ObtenerVehiculoBDD(str);
                            Foto04.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra04.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra04.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he04.Text = (myHoraEntrada.Substring(11, 8));
                        hee04.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp04.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad04.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde04.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip04.Text = Convert.ToString(miCliente.Nombre);
                        ruta04.Text = Convert.ToString(miCliente.Imagen);
                        fmto04.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss04.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss04.Text = string.Empty; }

                        forma04.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 05
                // -------------
                if (x == 5)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra05.Visible = true;
                        dia05.Visible = true;
                        he05.Visible = true;
                        hs05.Visible = true;
                        tp05.Visible = true;
                        vh05.Visible = true;
                        vp05.Visible = true;
                        vad05.Visible = true;
                        vde05.Visible = true;
                        vt05.Visible = true;
                        imp05.Visible = true;
                        fra05.Text = Convert.ToString(miEstado.IdFactura);
                        et05.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto05.Image = null; return; }
                        try
                        {
                            Foto05.Image = ObtenerVehiculoBDD(str);
                            Foto05.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra05.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra05.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he05.Text = (myHoraEntrada.Substring(11, 8));
                        hee05.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp05.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad05.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde05.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip05.Text = Convert.ToString(miCliente.Nombre);
                        ruta05.Text = Convert.ToString(miCliente.Imagen);
                        fmto05.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss05.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss05.Text = string.Empty; }

                        forma05.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 06
                // -------------
                if (x == 6)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra06.Visible = true;
                        dia06.Visible = true;
                        he06.Visible = true;
                        hs06.Visible = true;
                        tp06.Visible = true;
                        vh06.Visible = true;
                        vp06.Visible = true;
                        vad06.Visible = true;
                        vde06.Visible = true;
                        vt06.Visible = true;
                        imp06.Visible = true;
                        fra06.Text = Convert.ToString(miEstado.IdFactura);
                        et06.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);

                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto06.Image = null; return; }
                        try
                        {
                            Foto06.Image = ObtenerVehiculoBDD(str);
                            Foto06.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra06.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra06.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he06.Text = (myHoraEntrada.Substring(11, 8));
                        hee06.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp06.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad06.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde06.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip06.Text = Convert.ToString(miCliente.Nombre);
                        ruta06.Text = Convert.ToString(miCliente.Imagen);
                        fmto06.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss06.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss06.Text = string.Empty; }

                        forma06.Text = Convert.ToString(miEstado.Forma);
                    }
                }



                // habitación 07
                // -------------
                if (x == 7)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra07.Visible = true;
                        dia07.Visible = true;
                        he07.Visible = true;
                        hs07.Visible = true;
                        tp07.Visible = true;
                        vh07.Visible = true;
                        vp07.Visible = true;
                        vad07.Visible = true;
                        vde07.Visible = true;
                        vt07.Visible = true;
                        imp07.Visible = true;
                        fra07.Text = Convert.ToString(miEstado.IdFactura);
                        et07.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto07.Image = null; return; }
                        try
                        {
                            Foto07.Image = ObtenerVehiculoBDD(str);
                            Foto07.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra07.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra07.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he07.Text = (myHoraEntrada.Substring(11, 8));
                        hee07.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp07.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad07.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde07.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip07.Text = Convert.ToString(miCliente.Nombre);
                        ruta07.Text = Convert.ToString(miCliente.Imagen);
                        fmto07.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss07.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss07.Text = string.Empty; }

                        forma07.Text = Convert.ToString(miEstado.Forma);
                    }
                }




                // habitación 08
                // -------------
                if (x == 8)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra08.Visible = true;
                        dia08.Visible = true;
                        he08.Visible = true;
                        hs08.Visible = true;
                        tp08.Visible = true;
                        vh08.Visible = true;
                        vp08.Visible = true;
                        vad08.Visible = true;
                        vde08.Visible = true;
                        vt08.Visible = true;
                        imp08.Visible = true;
                        fra08.Text = Convert.ToString(miEstado.IdFactura);
                        et08.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto08.Image = null; return; }
                        try
                        {
                            Foto08.Image = ObtenerVehiculoBDD(str);
                            Foto08.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra08.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra08.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he08.Text = (myHoraEntrada.Substring(11, 8));
                        hee08.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp08.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad08.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde08.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip08.Text = Convert.ToString(miCliente.Nombre);
                        ruta08.Text = Convert.ToString(miCliente.Imagen);
                        fmto08.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss08.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss08.Text = string.Empty; }

                        forma08.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 09
                // -------------
                if (x == 9)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra09.Visible = true;
                        dia09.Visible = true;
                        he09.Visible = true;
                        hs09.Visible = true;
                        tp09.Visible = true;
                        vh09.Visible = true;
                        vp09.Visible = true;
                        vad09.Visible = true;
                        vde09.Visible = true;
                        vt09.Visible = true;
                        imp09.Visible = true;
                        fra09.Text = Convert.ToString(miEstado.IdFactura);
                        et09.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto09.Image = null; return; }
                        try
                        {
                            Foto09.Image = ObtenerVehiculoBDD(str);
                            Foto09.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra09.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra09.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he09.Text = (myHoraEntrada.Substring(11, 8));
                        hee09.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp09.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad09.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde09.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip09.Text = Convert.ToString(miCliente.Nombre);
                        ruta09.Text = Convert.ToString(miCliente.Imagen);
                        fmto09.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss09.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss09.Text = string.Empty; }

                        forma09.Text = Convert.ToString(miEstado.Forma);
                    }
                }



                // habitación 10
                // -------------
                if (x == 10)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra10.Visible = true;
                        dia10.Visible = true;
                        he10.Visible = true;
                        hs10.Visible = true;
                        tp10.Visible = true;
                        vh10.Visible = true;
                        vp10.Visible = true;
                        vad10.Visible = true;
                        vde10.Visible = true;
                        vt10.Visible = true;
                        imp10.Visible = true;
                        fra10.Text = Convert.ToString(miEstado.IdFactura);
                        et10.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto10.Image = null; return; }
                        try
                        {
                            Foto10.Image = ObtenerVehiculoBDD(str);
                            Foto10.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra10.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra10.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he10.Text = (myHoraEntrada.Substring(11, 8));
                        hee10.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp10.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad10.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde10.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip10.Text = Convert.ToString(miCliente.Nombre);
                        ruta10.Text = Convert.ToString(miCliente.Imagen);
                        fmto10.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss10.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss10.Text = string.Empty; }

                        forma10.Text = Convert.ToString(miEstado.Forma);
                    }
                }



                // habitación 11
                // -------------
                if (x == 11)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra11.Visible = true;
                        dia11.Visible = true;
                        he11.Visible = true;
                        hs11.Visible = true;
                        tp11.Visible = true;
                        vh11.Visible = true;
                        vp11.Visible = true;
                        vad11.Visible = true;
                        vde11.Visible = true;
                        vt11.Visible = true;
                        imp11.Visible = true;
                        fra11.Text = Convert.ToString(miEstado.IdFactura);
                        et11.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto11.Image = null; return; }
                        try
                        {
                            Foto11.Image = ObtenerVehiculoBDD(str);
                            Foto11.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra11.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra11.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he11.Text = (myHoraEntrada.Substring(11, 8));
                        hee11.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp11.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad11.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde11.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip11.Text = Convert.ToString(miCliente.Nombre);
                        ruta11.Text = Convert.ToString(miCliente.Imagen);
                        fmto11.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss11.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss11.Text = string.Empty; }

                        forma11.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 12
                // -------------
                if (x == 12)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra12.Visible = true;
                        dia12.Visible = true;
                        he12.Visible = true;
                        hs12.Visible = true;
                        tp12.Visible = true;
                        vh12.Visible = true;
                        vp12.Visible = true;
                        vad12.Visible = true;
                        vde12.Visible = true;
                        vt12.Visible = true;
                        imp12.Visible = true;
                        fra12.Text = Convert.ToString(miEstado.IdFactura);
                        et12.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto12.Image = null; return; }
                        try
                        {
                            Foto12.Image = ObtenerVehiculoBDD(str);
                            Foto12.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra12.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra12.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he12.Text = (myHoraEntrada.Substring(11, 8));
                        hee12.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp12.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad12.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde12.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip12.Text = Convert.ToString(miCliente.Nombre);
                        ruta12.Text = Convert.ToString(miCliente.Imagen);
                        fmto12.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss12.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss12.Text = string.Empty; }

                        forma12.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 13
                // -------------
                if (x == 13)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra13.Visible = true;
                        dia13.Visible = true;
                        he13.Visible = true;
                        hs13.Visible = true;
                        tp13.Visible = true;
                        vh13.Visible = true;
                        vp13.Visible = true;
                        vad13.Visible = true;
                        vde13.Visible = true;
                        vt13.Visible = true;
                        imp13.Visible = true;
                        fra13.Text = Convert.ToString(miEstado.IdFactura);
                        et13.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto13.Image = null; return; }
                        try
                        {
                            Foto13.Image = ObtenerVehiculoBDD(str);
                            Foto13.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra13.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra13.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he13.Text = (myHoraEntrada.Substring(11, 8));
                        hee13.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp13.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad13.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde13.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip13.Text = Convert.ToString(miCliente.Nombre);
                        ruta13.Text = Convert.ToString(miCliente.Imagen);
                        fmto13.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss13.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss13.Text = string.Empty; }

                        forma13.Text = Convert.ToString(miEstado.Forma);
                    }
                }


                // habitación 14
                // -------------
                if (x == 14)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra14.Visible = true;
                        dia14.Visible = true;
                        he14.Visible = true;
                        hs14.Visible = true;
                        tp14.Visible = true;
                        vh14.Visible = true;
                        vp14.Visible = true;
                        vad14.Visible = true;
                        vde14.Visible = true;
                        vt14.Visible = true;
                        imp14.Visible = true;
                        fra14.Text = Convert.ToString(miEstado.IdFactura);
                        et14.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto14.Image = null; return; }
                        try
                        {
                            Foto14.Image = ObtenerVehiculoBDD(str);
                            Foto14.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra14.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra14.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he14.Text = (myHoraEntrada.Substring(11, 8));
                        hee14.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp14.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad14.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde14.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip14.Text = Convert.ToString(miCliente.Nombre);
                        ruta14.Text = Convert.ToString(miCliente.Imagen);
                        fmto14.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss14.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss14.Text = string.Empty; }

                        forma14.Text = Convert.ToString(miEstado.Forma);
                    }
                }

                // habitación 15
                // -------------
                if (x == 15)
                {
                    CADestadohab miEstado = CADestadohab.VerificarEstado(aux);
                    if (miEstado.Estado == "OCUPADA")
                    {
                        fra15.Visible = true;
                        dia15.Visible = true;
                        he15.Visible = true;
                        hs15.Visible = true;
                        tp15.Visible = true;
                        vh15.Visible = true;
                        vp15.Visible = true;
                        vad15.Visible = true;
                        vde15.Visible = true;
                        vt15.Visible = true;
                        imp15.Visible = true;
                        fra15.Text = Convert.ToString(miEstado.IdFactura);
                        et15.Text = (string)miEstado.IdCliente;
                        CADclientes miCliente = CADclientes.ConsultarCliente_x_IDdocumento_Documento(miEstado.IdDocumento, miEstado.IdCliente);
                        // IMAGEN
                        // ------
                        int str = Convert.ToInt16(miCliente.Imagen);
                        if (str == 0) { Foto15.Image = null; return; }
                        try
                        {
                            Foto15.Image = ObtenerVehiculoBDD(str);
                            Foto15.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        CADventas miVenta = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra15.Text));
                        CADhospedajes miVentaHospedaje = CADhospedajes.ConsultarVentaHospedaje_IDventa(Int32.Parse(fra15.Text));
                        String myHoraEntrada = Convert.ToString(miVentaHospedaje.Hentrada);
                        he15.Text = (myHoraEntrada.Substring(11, 8));
                        hee15.Text = Convert.ToString(miVentaHospedaje.Hentrada);
                        vp15.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalProducto));
                        vad15.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalAdicional));
                        vde15.Text = string.Format("{0:###,###,###}", Convert.ToDouble(miVenta.TotalDescuento));
                        descrip15.Text = Convert.ToString(miCliente.Nombre);
                        ruta15.Text = Convert.ToString(miCliente.Imagen);
                        fmto15.Text = Convert.ToString(miVenta.FechaMovimiento);

                        // Congelado ó Descongelado.
                        if (miEstado.Tiempo == "Congelado") { hss15.Text = Convert.ToString(miVentaHospedaje.Hsalida); }
                        else { hss15.Text = string.Empty; }

                        forma15.Text = Convert.ToString(miEstado.Forma);
                    }
                }


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fechamtoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void HoraSistema_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            String myHora = DateTime.Now.ToString();
            DateTime h = Convert.ToDateTime(myHora);
            HoraSistema.Text = (myHora.Substring(11, 8));
        }

        private void ett01_Click(object sender, EventArgs e)
        {
            showSubMenu(paHab1);

            /*
            if (et01.Text == string.Empty)
            {
                // Nueva Factura Venta 
                // -------------------
                String myFecha = DateTime.Now.ToString();
                int NoVenta = Convert.ToInt32(CADventas.UltimaVenta()) + 1;
                frmVenta miForm = new frmVenta();
                miForm.Edicion = false;
                miForm.IDhabitacion = "01";
                miForm.FeMovimiento = Convert.ToDateTime(fechamtoDateTimePicker.Value);
                miForm.FeEntrada = Convert.ToDateTime(myFecha);
                miForm.IDventa = NoVenta;
                miForm.UsuarioLogueado = UsuarioLogueado;
                miForm.ShowDialog();
            }
            else
            {
                // Editar Factura Venta
                // --------------------
                CADventas miVenta01 = CADventas.ConsultarVenta_x_IDventa(Int32.Parse(fra01.Text));
                frmVenta miForm = new frmVenta();

                if (hss01.Text == string.Empty)
                {
                    miForm.TiempoCongelado = false;
                }
                else
                {
                    miForm.TiempoCongelado = true;
                    miForm.FeSalida = Convert.ToDateTime(hss01.Text);
                }


                if (forma01.Text == "Crédito")
                {
                    miForm.Xforna = "Crédito";
                }
                else
                {
                    miForm.Xforna = "Contado";
                }

                miForm.Edicion = true;
                miForm.Xcliente = Convert.ToString(miVenta01.Documento);
                miForm.Xvehiculo = Convert.ToString(miVenta01.Nombre);
                miForm.Ximagen = Convert.ToInt16(miVenta01.Imagen);
                miForm.IDhabitacion = "01";
                miForm.FeMovimiento = Convert.ToDateTime(fechamtoDateTimePicker.Value);
                miForm.FeEntrada = Convert.ToDateTime(hee01.Text);
                miForm.IDventa = Int32.Parse(fra01.Text);
                miForm.UsuarioLogueado = UsuarioLogueado;
                miForm.ShowDialog();
            }
            */
        }


        private void showSubMenu(Panel paHab1)
        {
            if (paHab1.Visible == false)
            {
                
                if (et01.Text == string.Empty)
                {
                    // Nueva Factura Venta 
                    // -------------------
                    String myFecha = DateTime.Now.ToString();
                    int NoVenta = Convert.ToInt32(CADventas.UltimaVenta()) + 1;
                    frmVentaNormal miForm = new frmVentaNormal();
                    miForm.Edicion = false;
                    miForm.IDhabitacion = "01";
                    miForm.FeMovimiento = Convert.ToDateTime(fechamtoDateTimePicker.Value);
                    miForm.FeEntrada = Convert.ToDateTime(myFecha);
                    miForm.IDventa = NoVenta;
                    miForm.UsuarioLogueado = UsuarioLogueado;
                    miForm.ShowDialog();
                }
                paHab1.Visible = true;


            }
            else
                paHab1.Visible = false;
        }

        private void ett02_Click(object sender, EventArgs e)
        {
            showHab2(paHab2);
        }

        private void showHab2(Panel paHab2)
        {
            if (paHab2.Visible == false)
            {
                paHab2.Visible = true;
            }
            else
                paHab2.Visible = false;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void ett03_Click(object sender, EventArgs e)
        {

        }

        private void primeraFILA_Paint(object sender, PaintEventArgs e)
        {

        }


        private void ett04_Click(object sender, EventArgs e)
        {

        }

        private void ett05_Click(object sender, EventArgs e)
        {

        }
    }
}
