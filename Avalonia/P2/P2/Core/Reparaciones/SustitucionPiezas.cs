namespace P2.Reparaciones
{
    public class SustitucionPiezas : Reparacion
    {
        public SustitucionPiezas(Aparato ap, double precio, double t_reparacion) : base(ap, precio, t_reparacion)
        {
            
        }

        public override string ToString()
        {
            return "\nSustitución de Piezas. " + base.ToString() + "\nPrecio Total: " + Precio + " euros";
        }
    }
}