using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace EntidadesCompartidas
{
  public class Usuario
  {
    private string _nomUsu;
    private string _contrasena;

    public string NombreUsuario
    {
      get { return _nomUsu; }
      set
      {
        if (value.Trim().Length == 10)
          _nomUsu = value.Trim();
        else
          throw new Exception("Inserte un nombre con un largo exacto de 10.");
      }
    }

    public string Contrasena
    {
      get { return _contrasena; }
      set
      {
        if (validarContrasena(value.Trim()))
          _contrasena = value.Trim();
        else
          throw new Exception("Introduzca una contraseña valida(4 caracteres y luego 3 numeros).");
      }
    }

    private static bool validarContrasena(string contra)
    {
      string pattern = @"[a-z][a-z][a-z][a-z][0-9][0-9][0-9]";
      var regex = new Regex(pattern, RegexOptions.IgnoreCase);
      return regex.IsMatch(contra);
    }

    public Usuario(string pNomUsu, string pContra)
    {
      NombreUsuario = pNomUsu;
      Contrasena = pContra;
    }

  }
}
