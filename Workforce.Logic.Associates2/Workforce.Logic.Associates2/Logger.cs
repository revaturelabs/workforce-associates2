using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: log4net.Config.XmlConfigurator(Watch=true)]

namespace Workforce.Logic.Associates2
{
  public class Logger
  {
    //reflection can be slow
    private static readonly log4net.ILog log = LogHelper.GetLogger(); //log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    public void ErrorLog()
    {
      log.Error("This is an error message");
    }

    public void InfoLog()
    {
      log.Info("This is an info message");
    }

    public void WarningLog()
    {
      log.Warn("This is a warning message");
    }

    public void FatalLog()
    {
      log.Fatal("This is a fatal log");
    }
  }
}