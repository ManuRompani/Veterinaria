using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.Model
{
    public class Animal
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Peso { get; set; }
        public int Edad {  get; set; }
        public Cliente Cliente { get; set; }
        public Especie Especie { get; set; }
        
    }
}
