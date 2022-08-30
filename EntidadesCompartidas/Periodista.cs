using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;


namespace EntidadesCompartidas
{
  public class Periodista
  {
    private int _cedula;
    private string _nombre;
    private string _mail;

    public int Cedula
    {
      get { return _cedula; }
      set
      {
        if (value.ToString().Length == 8)
          _cedula = value;
        else
          throw new Exception("El largo de la cedula no es correcto.");
      }
    }

    public string Nombre
    {
      get { return _nombre; }
      set
      {
        if (value.Trim().Length >= 3 && value.Trim().Length <= 30)
          _nombre = value.Trim();
        else
          throw new Exception("Inserte un nombre con un largo de 3 a 30 caracteres.");
      }
    }

    public string Mail
    {
      get { return _mail; }
      set
      {
        if (validarCorreo(value))
          _mail = value;
        else
          throw new Exception("Inserte un correo electronico valido.");
      }
    }

    public Periodista(int pCedula, string pNombre, string pMail)
    {
      Nombre = pNombre;
      Cedula = pCedula;
      Mail = pMail;
    }

    private static bool validarCorreo(string email)
    {
      string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
      var regex = new Regex(pattern, RegexOptions.IgnoreCase);
      return regex.IsMatch(email);
    }

    public override string ToString()
    {
      return "Nombre: " + Nombre + " Correo: " + Mail + " Cedula: " + Cedula.ToString();
    }
  }
}
