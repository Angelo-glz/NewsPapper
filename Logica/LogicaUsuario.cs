using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
  internal class LogicaUsuario:ILogicaUsuario
  {
    private static LogicaUsuario instancia = null;
    private LogicaUsuario() { }
    public static LogicaUsuario getInstance()
    {
      if (instancia == null)
        instancia = new LogicaUsuario();

      return instancia;
    }

    public void Agregar(Usuario U)
    {
      FabricaPersistencia.getPersistenciaUsuario().AgregarUsuario(U);
    }
    public bool Loguear(Usuario U)
    {
      return FabricaPersistencia.getPersistenciaUsuario().Loguear(U);
    }
    public Usuario Buscar(string pNomUsu)
    {
      return FabricaPersistencia.getPersistenciaUsuario().Buscar(pNomUsu);
    }

  }
}
