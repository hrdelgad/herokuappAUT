using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Business;
using System.Collections.ObjectModel;

namespace EjercicioAutomatizacionPSL
{
  [TestClass]
  public class AgendarCitaTest
  {
    private static IWebDriver driverIE;


    [AssemblyInitialize]
    public static void AssemblySetup(TestContext context)
    {
      WebDriver driver = WebDriver.Instance;

      driverIE = WebDriver.driverIE;

    }

    [TestInitialize]
    public void TestSetup()
    {
      driverIE.Navigate().GoToUrl("http://automatizacion.herokuapp.com/hdelgado/");

      HomeB homePageBusiness = new HomeB(driverIE);

      homePageBusiness.ClicAgendarCita();
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaFechaNoIngresada()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("Ingresar aqui mensaje de error a validar para fecha no ingresada"))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaDocPacienteNoIngresado()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now.AddDays(-1));

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("*El campo 'Documento de identidad' es requerido."))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaDocDoctorNoIngresado()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now.AddDays(-1));

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("*El campo 'Documento de identidad' es requerido."))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaFechaIgualAActual()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now);

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("Ingresar mensaje de error a validar para fecha menor o igual a la actual"))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaFechaMenorAActual()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now);

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("Ingresar mensaje de error a validar para fecha menor o igual a la actual"))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaDocPacienteNoExiste()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now.AddDays(-1));

      agendarCitaBusiness.IngresarDocumentoPaciente("9");

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("*El campo 'Documento de identidad' no se encuentra entre nuestros pacientes registrados."))
        {
          mensajeErrorExiste = true;

          break;
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));

    }

    [TestCategory("Negative")]
    [TestMethod]
    public void AgendarCitaDocDoctorNoExiste()
    {
      bool mensajeErrorExiste = false;

      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now.AddDays(-1));

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.IngresaDocumentoDoctor("9");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      ReadOnlyCollection<IWebElement> mensajesError = agendarCitaBusiness.MensajesError();

      foreach (IWebElement mensaje in mensajesError)
      {
        if (mensaje.Text.Equals("*El campo 'Documento de identidad' no se encuentra entre nuestros doctores."))
        {
          mensajeErrorExiste = true;

          break;  
        }
      }

      Assert.IsTrue(mensajeErrorExiste, String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }

    [TestCategory("Positive")]
    [TestMethod]
    public void AgendarCitaDatosOk()
    {
      AgendarCitaB agendarCitaBusiness = new AgendarCitaB(driverIE);

      agendarCitaBusiness.IngresarFechaCita(DateTime.Now.AddDays(-1));

      agendarCitaBusiness.IngresarDocumentoPaciente("5");

      agendarCitaBusiness.IngresaDocumentoDoctor("4");

      agendarCitaBusiness.SeleccionarOpcionGuardarCita();

      string mensajeExito = agendarCitaBusiness.MensajeExito();

      StringAssert.Contains(mensajeExito, "Datos guardados correctamente.", String.Format("Mensaje esperado no encontrado para el caso de prueba: {0}", System.Reflection.MethodBase.GetCurrentMethod().Name));
    }
  }
}
