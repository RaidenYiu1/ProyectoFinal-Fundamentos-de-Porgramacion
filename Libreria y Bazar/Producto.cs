using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_y_Bazar
{
    public class Producto
    {
        public string Codigo { get; set; }
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Nombre { get; set; }
        public string UnidadMedida { get; set; }
        public double PrecioCompra { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
    }
}
