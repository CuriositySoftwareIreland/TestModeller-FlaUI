using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestModellerCSharp.Pages;
using TestModellerCSharp.Pages.Samples.Calculator;
using Tests;

namespace TestModellerCSharp.Tests
{
    [TestFixture]
    public class CalculatorTest : TestBase
    {
        [Test]
        public void AdditionTest()
        {
            app.app = Application.LaunchStoreApp("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            // Switch to default mode
            CalculatorPage calculatorPage = new CalculatorPage(app);
            calculatorPage.ClickButton1();

            calculatorPage.ClickButtonAddition();

            calculatorPage.ClickButton7();

            calculatorPage.ClickButtonEquals();
            calculatorPage.AssertResult("8");
        }

        [Test]
        public void AdditionTest2()
        {
            DesktopActions desktopActions = new DesktopActions(app);

            desktopActions.OpenApplication("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");

            // Switch to default mode
            desktopActions.Click("num7Button");

            desktopActions.Click("plusButton");

            desktopActions.Click("num1Button");

            desktopActions.Click("equalButton");

            desktopActions.AssertLabelText("CalculatorResults", "8");
        }
    }
}
