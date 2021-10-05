using System;
using P2.Reparaciones;

namespace P2
{
    public abstract class Reparacion
    {
        protected Reparacion(Aparato ap, double precio, double t_reparacion)
        {
            this.Ap = ap;
            this.Precio = precio;
            this.T_reparacion = t_reparacion;
            this.Precio_media_hora = precio * 0.5;
        }

        public static Reparacion Crea(Aparato ap, int precio, double t_reparacion)
        {
            Reparacion toret = null;
            
            if(t_reparacion > 0 && t_reparacion <= 1)
            {
                toret = new SustitucionPiezas(ap, precio, t_reparacion);
            }
            
            if(t_reparacion > 1)
            {
                toret = new ReparacionCompleja(ap, precio, t_reparacion);
            }

            return toret;
        }
        
        public Aparato Ap
        {
            get;
            set;
        }

        public double Precio
        {
            get;
            set;
        }

        public double T_reparacion
        {
            get;
            set;
        }

        public double Precio_media_hora
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Ap.ToString() + "\nTiempo de reparación: " + T_reparacion + " hora/s" 
                                 + "\nPrecio media hora: " + Precio_media_hora + " euros";
        }
    }
}