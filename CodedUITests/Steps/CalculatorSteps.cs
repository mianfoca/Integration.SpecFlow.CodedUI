using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Calculator.Test.Steps
{
    [Binding]
    public sealed class CalculatorSteps
    {
        UITestControl calcWindow;

        [BeforeScenario]
        public void Initialize()
        {
            Console.WriteLine("Inicializando");
            ApplicationUnderTest.Launch(@"C:\Windows\System32\calc.exe");

            calcWindow = new UITestControl();
            calcWindow.TechnologyName = "MSAA";
            calcWindow.SearchProperties[UITestControl.PropertyNames.Name] = "Calculadora";
            calcWindow.SearchProperties[UITestControl.PropertyNames.ClassName] = "CalcFrame";
        }

        [Given("I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredSomethingIntoTheCalculator(int number)
        {
            Console.WriteLine("Given a number: " + number);

            UITestControl btnNumber = new WinButton(calcWindow);
            number.ToString().ToList().ForEach(n =>
            {
                btnNumber.SearchProperties[WinButton.PropertyNames.Name] = n.ToString();
                Mouse.Click(btnNumber);
            });
        }

        [Given("I press add")]
        public void WhenIPressAdd()
        {
            Console.WriteLine("When I press add");

            UITestControl btnAdd = new WinButton(calcWindow);
            btnAdd.SearchProperties[WinButton.PropertyNames.Name] = "Sumar";
            Mouse.Click(btnAdd);
        }

        [When("I press equals")]
        public void WhenIPressEquals()
        {
            Console.WriteLine("When I press equals");

            UITestControl btnAdd = new WinButton(calcWindow);
            btnAdd.SearchProperties[WinButton.PropertyNames.Name] = "Igual a";
            Mouse.Click(btnAdd);
        }

        [Then("the result should be (.*) on the screen")]
        public void ThenTheResultShouldBe(int resultExpect)
        {
            Console.WriteLine("Then I should see: " + resultExpect);

            WinText txtResultado = new WinText(calcWindow);
            txtResultado.SearchProperties[WinButton.PropertyNames.Name] = "Resultado";

            Assert.AreEqual(resultExpect.ToString(), txtResultado.DisplayText);
        }
    }
}
