using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Persistencia
{
  public interface IPersistenciaInternacional
  {
    void AgregarInternacional(Internacional N);
    void ModificarInternacional(Internacional N);
    Internacional BuscarInternacional(string pCode);

    List<Internacional> ListarInternacional();
    List<Internacional> ListarInternacionalUlt5Dias();
  }
}
