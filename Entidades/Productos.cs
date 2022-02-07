using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jose_Gonzalez_Ap1_p1.Entidades
{
    public class Productos
    {
        public int Productoid { get; set; }
        public string? Descripcion { get; set; }
        public string? Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }
    }
}