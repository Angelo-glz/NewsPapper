using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
  public class FabricaPersistencia
  {
    public static IPersistenciaInternacional getPersistenciaInternacional()
    {
      return PersistenciaInternacional.GetInstancia();
    }
    public static IPersistenciaNacional getPersistenciaNacional()
    {
      return PersistenciaNacional.GetInstancia();
    }
    public static IPersistenciaPeriodista getPersistenciaPeriodista()
    {
      return PersistenciaPeriodista.GetInstancia();
    }
    public static IPersistenciaSeccion getPersistenciaSeccion()
    {
      return PersistenciaSeccion.GetInstance();
    }
    public static IPersistenciaUsuario getPersistenciaUsuario()
    {
      return PersistenciaUsuario.GetInstance();
    }
  }
}
