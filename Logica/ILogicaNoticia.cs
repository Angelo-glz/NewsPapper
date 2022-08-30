using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

using EntidadesCompartidas;

namespace Logica
{
  public interface ILogicaNoticia
  {
    Noticia Buscar(string C);
    void Agregar(Noticia N);
    void Modificar(Noticia N);

    XmlDocument EstadisticaNoticias();


    List<Noticia> Listar();
    List<Noticia> ListarUlt5Dias();
  }
}
