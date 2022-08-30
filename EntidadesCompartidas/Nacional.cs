using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
  public class Nacional:Noticia
  {
    private Seccion _seccion;

    public Seccion Seccion
    {
      get { return _seccion; }
      set
      {
        if (value != null)
          _seccion = value;
        else
          throw new Exception("La noticia debe hacer referencia a una seccion valida.");

      }
    }

    public override string Tipo
    {
      get { return "Nacional"; }
    }

    public Nacional(string pCodigo, DateTime pFecha, string pTitulo, string pContenido, int pImportancia, Usuario pUsu,List<Periodista> pPerio,Seccion pSec)
      :base(pCodigo, pFecha, pTitulo, pContenido, pImportancia, pUsu, pPerio)
    {
      Seccion = pSec;
    }

    public override string ToString()
    {
      return base.ToString();
    }
  }
}
