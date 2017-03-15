using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace POM
{
  public class AgendarCitaPage
  {
    private static IWebElement element = null;

    private static By opcionBusqueda = null;
    public static IWebElement DiaCitaInput(IWebDriver driver){

      opcionBusqueda = By.Id("datepicker");

      element = driver.FindElement(opcionBusqueda);
      
      return element;
    }

    public static IWebElement NroDocPacienteInput(IWebDriver driver)
    {
      opcionBusqueda = By.XPath("//div[@class='container-fluid']/div[3]/div/div[2]/input");

      element = driver.FindElement(opcionBusqueda);

      return element;
    }

    public static IWebElement NroDocDoctorInput(IWebDriver driver)
    {
      opcionBusqueda = By.XPath("//div[@class='container-fluid']/div[3]/div/div[3]/input");

      element = driver.FindElement(opcionBusqueda);

      return element;
    }

    public static IWebElement ObservacionesTextArea(IWebDriver driver)
    {
      opcionBusqueda = By.XPath("//div[@class='container-fluid']/div[3]/div/div[4]/input");

      element = driver.FindElement(opcionBusqueda);

      return element;
    }

    public static IWebElement GuardarButton(IWebDriver driver)
    {
      opcionBusqueda = By.XPath("//div[@class='container-fluid']/div[3]/div/a");

      element = driver.FindElement(opcionBusqueda);

      return element;
    }
  }
}
