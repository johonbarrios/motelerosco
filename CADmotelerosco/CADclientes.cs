using CADmotelerosco.DSmoteleroscoTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CADmotelerosco
{
    public class CADclientes
    {
        public int IDCliente { get; set; }
        public int IDdocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Notas { get; set; }
        public int Imagen { get; set; }

        private static ClienteTableAdapter adaptador = new ClienteTableAdapter();

        //public static bool ExisteCliente_x_IDdocumento_Documento(int IDdocumento, string Documento)
        //{
        //    if (adaptador.ExisteCliente_x_IDdocumento_Documento(IDdocumento, Documento) == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


        //public static int NoRepetirCliente(string Documento)
        //{
        //    if (adaptador.NoRepetirCliente(Documento) == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return 1;
        //    }
        //}

        public static CADclientes ConsultarCliente_x_IDdocumento_Documento(int IDdocumento, string Documento)
        {
            CADclientes miCliente = null;
            DSmotelerosco.ClienteDataTable miTabla = adaptador.ConsultarCliente_x_IDdocumento_Documento(IDdocumento, Documento);
            if (miTabla.Rows.Count == 0) return miCliente;
            DSmotelerosco.ClienteRow miRegistro = (DSmotelerosco.ClienteRow)miTabla.Rows[0];
            miCliente = new CADclientes();
            miCliente.IDCliente = miRegistro.IDCliente;
            miCliente.IDdocumento = miRegistro.IDdocumento;
            miCliente.Documento = miRegistro.Documento;
            miCliente.Nombre = miRegistro.Nombre;
            miCliente.Telefono = miRegistro.Telefono;
            miCliente.Notas = miRegistro.Notas;
            miCliente.Imagen = miRegistro.Imagen;
            return miCliente;
        }


        //public static void InsertarClientes(int IDcliente, int IDdocumento, string Documento, string Nombre, string Telefono, string Notas, int Imagen)
        //{
        //    adaptador.InsertarClientes(IDcliente, IDdocumento, Documento, Nombre, Telefono, Notas, Imagen);

        //}

        //public static void EditarClientes(int IDCliente, int IDdocumento, string Documento, string Nombre, string Telefono, string Notas, int Imagen)
        //{
        //    adaptador.EditarClientes(IDCliente, IDdocumento, Documento, Nombre, Telefono, Notas, Imagen);
        //}

        //public static int num_regs_clientes()
        //{
        //    if (adaptador.num_regs_clientes() == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return (int)adaptador.num_regs_clientes();
        //    }
        //}

        //public static int UltimoCliente()
        //{

        //    if (adaptador.UltimoCliente() == null)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        return (int)adaptador.UltimoCliente();
        //    }
        //}
    }
}
