using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Persistencia
{
  public interface IPersistenciaUsuario
  {
    void AgregarUsuario(Usuario U);
    bool Loguear(Usuario U);
    Usuario Buscar(string nomUsu);
  }
}
