namespace CADmotelerosco
{
    using CADmotelerosco.DSmoteleroscoTableAdapters;
    public class CADtarifahabitaciones
    {
        private static Tarifa_HabitacionesTableAdapter adaptador = new Tarifa_HabitacionesTableAdapter();

        // Estado
        public static bool ExisteTarifa(string IDhabitacion)
        {
            if (adaptador.ExisteTarifa(IDhabitacion) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // Consultar
        public static decimal TarifaHabitacionActual(string IDhabitacion, string Tiempo)
        {
            return (decimal)adaptador.TarifaHabitacionActual(IDhabitacion, Tiempo);
        }

        // Insertar
        public static void InsertarTarifa(string IDhabitacion, int IDtiempo, decimal Valor)
        {
            adaptador.InsertarTarifa(IDhabitacion, IDtiempo, Valor);
        }

        // Editar
        public static void EditarTarifaHabitaciones(string IDhabitacion, int IDtiempo, decimal Valor)
        {
            adaptador.EditarTarifaHabitaciones(IDhabitacion, IDtiempo, Valor);
        }

        // Eliminar
        public static void EliminarTarifa(string IDhabitacion, int IDtiempo)
        {
            adaptador.EliminarTarifa(IDhabitacion, IDtiempo);
        }
    }
}
