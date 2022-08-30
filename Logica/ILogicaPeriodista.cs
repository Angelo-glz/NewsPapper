using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Logica
{
  public interface ILogicaPeriodista
  {
    void Agregar(Periodista P);
    void Eliminar(Periodista P);
    void Modificar(Periodista P);

    Periodista Buscar(int pCed);

    List<Periodista> Listar();
  }
}
