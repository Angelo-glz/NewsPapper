using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Persistencia
{
  public interface IPersistenciaSeccion
  {
    void AgregarSeccion(Seccion S);
    void EliminarSeccion(Seccion S);
    void ModificarSeccion(Seccion S);
    Seccion BuscarSeccion(string pCod);
    List<Seccion> Listar();
  }
}
