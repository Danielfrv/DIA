using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Proveedores.Core
{
    public class RegistroProveedores : ObservableCollection<Proveedor>
    {
        public RegistroProveedores() : this(new List<Proveedor>())
        {

        }

        public RegistroProveedores(IEnumerable<Proveedor> proveedores) : base(proveedores)
        {

        }

        public override string ToString()
        {
            var toret = new StringBuilder();

            foreach (Proveedor v in this)
            {
                toret.AppendLine(v.ToString());
            }

            return toret.ToString();
        }
    }
}