using System;
using Services.Veterinaria.Model;
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
        public Cliente ClienteDueño { get; set; }
        public Especie Especie { get; set; }

        
        public override string ToString()
        {
            return this.Nombre;
        }


        public string NombreCliente => ClienteDueño?.NombreCompleto ?? "Sin dueño";
        public string NombreEspecie => Especie?.Nombre ?? "Sin especie";


    }
}
