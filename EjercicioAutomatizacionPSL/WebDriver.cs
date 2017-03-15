using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace EjercicioAutomatizacionPSL
{
  public class WebDriver
  {
    private static WebDriver instance;
    public static IWebDriver driverIE;
    public static IWebDriver driverChrome;
    public static IWebDriver driverFirefox;

    private WebDriver()
    {
      
      InternetExplorerOptions options = new InternetExplorerOptions();
      options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
      InternetExplorerDriverService service = InternetExplorerDriverService.CreateDefaultService(
        String.Format(@"C:\Users\USUARIO\Documents\Visual Studio 2013\Projects\EjercicioAutomatizacionPSL\packages\Selenium.WebDriver.3.3.0")
        );      

      if (driverIE == null)
      {
        //Inicializar con Internet Explorer
        driverIE = new InternetExplorerDriver(service, options);

        
      }
    }

    public static WebDriver Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new WebDriver();
        }
        return instance;
      }
    }
  }
}
