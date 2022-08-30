using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
  public class Internacional:Noticia
  {
    private string _pais;

    public string Pais
    {
      get { return _pais; }
      set
      {
        if (value.Length >= 3 && value.Length <= 20)
          _pais = value;
        else
          throw new Exception("El pais debe contener entre 3 y 20 caracteres.");
      }
    }

    public override string Tipo
    {
      get { return "Internacional"; }
    }

    public Internacional(string pCodigo, DateTime pFecha, string pTitulo, string pContenido, int pImportancia, Usuario pUsu, string pPais, List<Periodista> pLista)
      :base(pCodigo, pFecha, pTitulo, pContenido, pImportancia, pUsu, pLista)
    {
      Pais = pPais;
    }

    public override string ToString()
    {
      return base.ToString() + " Pais: " + Pais;
    }

  }
}
