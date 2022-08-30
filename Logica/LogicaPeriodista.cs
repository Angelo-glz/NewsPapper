using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
  internal class LogicaPeriodista:ILogicaPeriodista
  {
    private static LogicaPeriodista instancia = null;
    private LogicaPeriodista() { }
    public static LogicaPeriodista GetInstance()
    {
      if (instancia == null)
        instancia = new LogicaPeriodista();

      return instancia;
    }

    public void Agregar(Periodista P)
    {
      FabricaPersistencia.getPersistenciaPeriodista().AgregarPeriodista(P);
    }
    public void Eliminar(Periodista P)
    {
      FabricaPersistencia.getPersistenciaPeriodista().EliminarPeriodista(P);
    }
    public void Modificar(Periodista P)
    {
      FabricaPersistencia.getPersistenciaPeriodista().ModificarPeriodista(P);
    }
    public Periodista Buscar(int pCed)
    {
      return FabricaPersistencia.getPersistenciaPeriodista().BuscarPeriodista(pCed);
    }
    public List<Periodista> Listar()
    {
      return FabricaPersistencia.getPersistenciaPeriodista().ListarPeriodistas();
    }
  }
}
