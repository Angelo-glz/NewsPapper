using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
  internal class LogicaSeccion:ILogicaSeccion
  {
    private static LogicaSeccion instancia = null;
    private LogicaSeccion() { }
    public static LogicaSeccion getInstance()
    {
      if (instancia == null)
        instancia = new LogicaSeccion();

      return instancia;
    }

    public void Agregar(Seccion S)
    {
      FabricaPersistencia.getPersistenciaSeccion().AgregarSeccion(S);
    }
    public void Eliminar(Seccion S)
    {
      FabricaPersistencia.getPersistenciaSeccion().EliminarSeccion(S);
    }
    public void Modificar(Seccion S)
    {
      FabricaPersistencia.getPersistenciaSeccion().ModificarSeccion(S);
    }
    public Seccion Buscar(string pCodSec)
    {
      return FabricaPersistencia.getPersistenciaSeccion().BuscarSeccion(pCodSec);
    }
    public List<Seccion> Listar()
    {
      return FabricaPersistencia.getPersistenciaSeccion().Listar();
    }
  }
}
