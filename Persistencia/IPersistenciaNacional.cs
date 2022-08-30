using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Persistencia
{
  public interface IPersistenciaNacional
  {
    void AgregarNacional(Nacional N);
    void ModificarNacional(Nacional N);
    Nacional BuscarNacional(string pCode);

    List<Nacional> ListarNacionales();
    List<Nacional> ListarNacionalesUlt5Dias();
  }
}
