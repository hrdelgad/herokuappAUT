using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace POM
{
  public class HomePage
  {
    private static IWebElement element = null;

    private static By opcionBusqueda = null;

    public static IWebElement agendarCitaLink(IWebDriver driver)
    {
      opcionBusqueda = By.LinkText("Agendar Cita");
      element = driver.FindElement(opcionBusqueda);

      return element;
    }
  }
}
