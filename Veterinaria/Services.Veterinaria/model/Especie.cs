using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.Model
{
    public class Especie
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int EdadMadurez { get; set; }
        public decimal PesoPromedio { get; set; }
    }
}
