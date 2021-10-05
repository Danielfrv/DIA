namespace P2.Reparaciones
{
    public class ReparacionCompleja : Reparacion
    {
        public ReparacionCompleja(Aparato ap, double precio, double t_reparacion) : base(ap, precio, t_reparacion)
        {
            
        }

        public override string ToString()
        {
            return "\nReparación Compleja. " + base.ToString() + "\nPrecio Total: " + Precio * T_reparacion + " euros";
        }
    }
}