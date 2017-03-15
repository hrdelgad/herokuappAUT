using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using POM;

namespace Business
{
  public class HomeB
  {
    private IWebDriver driver;

    public HomeB(IWebDriver driver){

      this.driver = driver;

      if (!driver.Title.Equals("PSL - Ejercicio de automatización"))
      {
        throw new InvalidElementStateException("No se encuentra en la página Home. "+
          "La página actual es: "+driver.Title);
      }
    }

    public void ClicAgendarCita()
    {
      HomePage.agendarCitaLink(this.driver).Click();
    }
  }
}
