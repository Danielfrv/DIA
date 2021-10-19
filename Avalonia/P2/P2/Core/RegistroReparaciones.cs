using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace P2.Core
{
    public class RegistroReparaciones : ObservableCollection<Reparacion>
    {
        public RegistroReparaciones(): this(new List<Reparacion>())
        {
        }
        
        public RegistroReparaciones(IEnumerable<Reparacion> reparaciones)
            :base(reparaciones)
        {
        }
        
        public override string ToString()
        {
            var toret = new StringBuilder();
			
            foreach(Reparacion v in this) {
                toret.AppendLine( v.ToString() );
            }

            return toret.ToString();
        }
    }
}