using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesCompartidas;
using Persistencia;
using System.Xml;

using System.Threading;
using System.Globalization;

namespace Logica
{
  internal class LogicaNoticia: ILogicaNoticia
  {
    private static LogicaNoticia instancia = null;
    private LogicaNoticia() { }
    public static LogicaNoticia GetInstance()
    {
      if (instancia == null)
        instancia = new LogicaNoticia();

      return instancia;
    }

    public Noticia Buscar(string C)
    {
      Noticia N = null;
      N = FabricaPersistencia.getPersistenciaInternacional().BuscarInternacional(C);
      if(N == null)
        N = FabricaPersistencia.getPersistenciaNacional().BuscarNacional(C);
      return N;
    }

    public void Agregar(Noticia N)
    {
      if (N.FechaPublicacion < DateTime.Now)
        throw new Exception("No se puede crear una noticia para el pasado");

      if (N is Internacional)
        FabricaPersistencia.getPersistenciaInternacional().AgregarInternacional((Internacional)N);
      else
        FabricaPersistencia.getPersistenciaNacional().AgregarNacional((Nacional)N);
    }
    public void Modificar(Noticia N)
    {
      //if (N.FechaPublicacion < DateTime.Now)
      //  throw new Exception("No se puede crear una noticia para el pasado");

      if (N is Internacional)
        FabricaPersistencia.getPersistenciaInternacional().ModificarInternacional((Internacional)N);
      else
        FabricaPersistencia.getPersistenciaNacional().ModificarNacional((Nacional)N);
    }
    public List<Noticia> Listar()
    {
      List<Noticia> list = new List<Noticia>();
      list.AddRange(FabricaPersistencia.getPersistenciaInternacional().ListarInternacional());
      list.AddRange(FabricaPersistencia.getPersistenciaNacional().ListarNacionales());
      return list;
    }
    public List<Noticia> ListarUlt5Dias()
    {
      List<Noticia> list = new List<Noticia>();
      list.AddRange(FabricaPersistencia.getPersistenciaInternacional().ListarInternacionalUlt5Dias());
      list.AddRange(FabricaPersistencia.getPersistenciaNacional().ListarNacionalesUlt5Dias());
      return list;
    }

    //operacion extra que no se corresponde con nignuna de persistencia y que 
    //devuelva un xml document para la pagina de estadistica.
    public XmlDocument EstadisticaNoticias()
    {
      List<Noticia> lNotics = FabricaLogica.GetLogicaNoticia().Listar();

      XmlDocument docm = new XmlDocument();
      docm.LoadXml("<Noticias></Noticias>");
      XmlNode raiz = docm.DocumentElement;

      foreach (Noticia N in lNotics)
      {
        XmlElement codigo = docm.CreateElement("Codigo");
        codigo.InnerText = N.Codigo;

        XmlElement fechaPub = docm.CreateElement("FechaPubli");
        fechaPub.InnerText = N.FechaPublicacion.ToLongDateString();

        XmlElement tipo = docm.CreateElement("Tipo");
        tipo.InnerText = N.Tipo;

        XmlElement titulo = docm.CreateElement("Titulo");
        titulo.InnerText = N.Titulo;

        XmlElement contenido = docm.CreateElement("Contenido");
        contenido.InnerText = N.Contenido;

        XmlElement importancia = docm.CreateElement("Importancia");
        importancia.InnerText = N.Importancia.ToString();

        XmlElement node = docm.CreateElement("Noticia");
        node.AppendChild(codigo);
        node.AppendChild(fechaPub);
        node.AppendChild(tipo);
        node.AppendChild(titulo);
        node.AppendChild(contenido);
        node.AppendChild(importancia);

        raiz.AppendChild(node);
      }
      return docm;
    }
  }
}
