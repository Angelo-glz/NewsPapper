using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;

namespace Logica
{
  public interface ILogicaSeccion
  {
    void Agregar(Seccion S);
    void Eliminar(Seccion S);
    void Modificar(Seccion S);

    Seccion Buscar(string pCodigoSec);
    List<Seccion> Listar();
  }
}
