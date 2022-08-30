using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
  internal class Conexion
  {
    private static string cnx = "Data Source=.; Initial Catalog = BiosNews; Integrated Security = true";

    internal static string Cnx
    {
      get { return cnx; }
    }
  }
}
