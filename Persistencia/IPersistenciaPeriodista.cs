using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;


namespace Persistencia
{
  public interface IPersistenciaPeriodista
  {
    void AgregarPeriodista(Periodista P);
    void ModificarPeriodista(Periodista P);
    void EliminarPeriodista(Periodista P);

    Periodista BuscarPeriodista(int pCed);

    List<Periodista> ListarPeriodistas();
  }
}
