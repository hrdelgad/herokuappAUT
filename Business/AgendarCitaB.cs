using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using POM;

namespace Business
{
  public class AgendarCitaB
  {
    private IWebDriver driver;
    public AgendarCitaB(IWebDriver driver)
    {
      this.driver = driver;

      if (!driver.Title.Equals("PSL - Agendar Cita"))
      {
        throw new InvalidElementStateException("No se encuentra en la página de Agendar Cita. "+
        "La página actual es: " + driver.Title);
      }
    }

    public void IngresarDocumentoPaciente(string nroDocPaciente)
    {
      AgendarCitaPage.NroDocPacienteInput(this.driver).SendKeys(nroDocPaciente);
    }

    public void IngresaDocumentoDoctor(string nroDocDoctor)
    {
      AgendarCitaPage.NroDocDoctorInput(this.driver).SendKeys(nroDocDoctor);
    }

    public void IngresarFechaCita(DateTime fechaCita)
    {
      AgendarCitaPage.DiaCitaInput(this.driver).SendKeys(fechaCita.ToString("MM/dd/yyyy"));
    }

    public void SeleccionarOpcionGuardarCita()
    {
      AgendarCitaPage.GuardarButton(this.driver).Click();
    }

    public string MensajeExito()
    {
      return ResultadoPage.ObtenerMensajeExito(this.driver).Text;
    }

    public ReadOnlyCollection<IWebElement> MensajesError()
    {
      return ResultadoPage.ObtenerMensajesError(this.driver);
    }
  }
}
