using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
  public class FabricaLogica
  {
    public static ILogicaNoticia GetLogicaNoticia()
    {
      return (LogicaNoticia.GetInstance());
    }

    public static ILogicaPeriodista GetLogicaPeriodista()
    {
      return (LogicaPeriodista.GetInstance());
    }

    public static ILogicaSeccion GetLogicaSeccion()
    {
      return (LogicaSeccion.getInstance());
    }

    public static ILogicaUsuario GetLogicaUsuario()
    {
      return (LogicaUsuario.getInstance());
    }
  }
}
