using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace POM
{
  public class ResultadoPage
  {
    private static ReadOnlyCollection<IWebElement> elements = null;
    private static IWebElement element = null;

    private static By opcionBusqueda = null;

    public static ReadOnlyCollection<IWebElement> ObtenerMensajesError(IWebDriver driver)
    {
      opcionBusqueda = By.ClassName("text-danger");

      elements = driver.FindElements(opcionBusqueda);

      return elements;
    }

    public static IWebElement ObtenerMensajeExito(IWebDriver driver)
    {
      opcionBusqueda = By.ClassName("panel-body");

      element = driver.FindElement(opcionBusqueda);

      return element;
    }
  }
}
