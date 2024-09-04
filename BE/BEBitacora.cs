namespace BE
{
    public class BEBitacora
    {
        public BEBitacora()
        {
            
        }
        public BEBitacora(string fecha, string usuario, string movimiento, string modulo)
        {
            Fecha = fecha;
            Usuario = usuario;
            Movimiento = movimiento;
            Modulo = modulo;
        }
        public string Fecha { get; set; }
        public string Usuario { get; set; }
        public string Movimiento { get; set; }
        public string Modulo { get; set; }
    }
}
