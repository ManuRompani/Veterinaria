using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Services.Veterinaria.Model
{
    public class Cliente
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        /// <summary>
        /// Propiedad que devuelve el nombre y apellido en un solo string
        /// </summary>
        public string NombreCompleto => $"{this.Nombre} {this.Apellido}";

        public override string ToString()
        {
            return this.Nombre;
        }
        
    }

}
