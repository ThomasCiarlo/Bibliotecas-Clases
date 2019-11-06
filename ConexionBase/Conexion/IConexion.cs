using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public interface IConexion
    {
        bool Conexion();
        string Consulta(string consulta);
        bool Operacion();
    }
}
