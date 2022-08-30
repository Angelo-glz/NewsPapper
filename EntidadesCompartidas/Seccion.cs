using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
  public class Seccion
  {
    private string _codigoSeccion;
    private string _nombre;
    
    public string CodigoSeccion
    {
      get { return _codigoSeccion; }
      set
      {
        if (value.Length == 5)
          _codigoSeccion = value;
        else
          throw new Exception("El codigo de seccion debe contener exactamente 5 caracteres de largo.");
      }
    }

    public string Nombre
    {
      get { return _nombre; }
      set
      {
        if (value.Length >= 3 && value.Length <= 20)
          _nombre = value;
        else
          throw new Exception("El nombre de la seccion debe contener entre 3 y 20 caracteres.");
      }
    }

    public Seccion(string pCod, string pNombre)
    {
      CodigoSeccion = pCod;
      Nombre = pNombre;
    }

  }
}
