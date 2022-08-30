using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesCompartidas
{
  public abstract class Noticia
  {
    private string _codigo;
    private DateTime _fechaPublicacion;
    private string _titulo;
    private string _contenido;
    private int _importancia;
    private Usuario _usu;
    private List<Periodista> _periodistas;

    public string Codigo
    {
      get { return _codigo; }
      set
      {
        if (value.ToString().Length == 5)
          _codigo = value;
        else
          throw new Exception("Introduzca un codigo valido de 5 caracteres de largo exactamente.");
      }
    }

    public DateTime FechaPublicacion
    {
      get { return _fechaPublicacion; }
      set { _fechaPublicacion = value; }
    }

    public string Titulo
    {
      get { return _titulo; }
      set
      {
        if (value.Trim().Length >= 10 && value.Trim().Length <= 50)
          _titulo = value.Trim();
        else
          throw new Exception("El titulo debe tener entre 30 y 100 caracteres inclusive.");
      }
    }

    public string Contenido
    {
      get { return _contenido; }
      set
      {
        if (value.Trim().Length >= 50 && value.Trim().Length <= 500)
          _contenido = value.Trim();
        else
          throw new Exception("El contenido debe tener entre 50 y 500 caracteres inclusive.");
      }
    }
    
    public int Importancia
    {
      get { return _importancia; }
      set
      {
        if (value > 0 && value <= 5)
          _importancia = value;
        else
          throw new Exception("Error al asignar la importancia introduzca un numero entre 1 y 5.");
      }
    }

    public Usuario Usuario
    {
      get { return _usu; }
      set
      {
        if (value != null)
          _usu = value;
        else
          throw new Exception("El usuario debe ser valido.");
      }
    }

    public List<Periodista> Periodistas
    {
      get { return _periodistas; }
      set
      {
        if (value != null)
          _periodistas = value;
        else
          throw new Exception("La noticia debe tener un autor valido.");
      }
    }

    public virtual string Tipo
    {
      get { return "Noticia base"; }
    }

    public Noticia(string pCodigo, DateTime pFecha, string pTitulo, string pContenido, int pImportancia, Usuario pUsu, List<Periodista> pPerio)
    {
      Codigo = pCodigo;
      FechaPublicacion = pFecha;
      Titulo = pTitulo;
      Contenido = pContenido;
      Importancia = pImportancia;
      Usuario = pUsu;
      Periodistas = pPerio;
    }

    public override string ToString()
    {
      return "Codigo: " + Codigo + " Fecha: " + FechaPublicacion.ToString() + " Titulo: " + Titulo + " Contenido: " + Contenido + " Importancia: " + Importancia.ToString() + " Ultimo usuario en modificar: " + Usuario.NombreUsuario;
    }

    //public string Tipo()
    //{
    //  if (this is Internacional)
    //    return "Internacional";
    //  else
    //    return "Nacional";
    //}
  }
}
