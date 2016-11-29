using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Workforce.Logic.Associates2
{
  public static class LogHelper
  {
    public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
    {
      return log4net.LogManager.GetLogger(filename);
    }

    public static void ErrorLogger(log4net.ILog log, Exception ex)
    {
      if (ex.InnerException != null)
      {
        log.Error("The error was: " + ex);
      }

      else
      {
        log.Error("The error was: " + ex.InnerException);
      }
    }
  }
}