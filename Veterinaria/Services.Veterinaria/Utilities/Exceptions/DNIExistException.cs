using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Veterinaria.Utilities.Exceptions
{
    public class DNIExistException : Exception
    {
        public DNIExistException(int dni): base($"Ya existe un Cliente con DNI {dni}") { }
    }
}
