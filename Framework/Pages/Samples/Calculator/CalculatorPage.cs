using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using NUnit.Framework;
using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModellerCSharp.Utilities;

namespace TestModellerCSharp.Pages.Samples.Calculator
{
    public class CalculatorPage : BasePage
    {
        protected Window calcWindow {get; set;}

        public CalculatorPage(FlaUIApplication app)
            : base(app)
        {
            calcWindow = app.app.GetMainWindow(new UIA3Automation());

            System.Threading.Thread.Sleep(2000);
        }

        public void ClickButton1()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num1Button"))?.AsButton();
            button1?.Invoke();
        }

        public void ClickButton2()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num2Button"))?.AsButton();
            button1?.Invoke();
        }
        public void ClickButton3()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num3Button"))?.AsButton();
            button1?.Invoke();


        }

        public void ClickButton4()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num4Button"))?.AsButton();
            button1?.Invoke();
        }
        public void ClickButton5()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num5Button"))?.AsButton();
            button1?.Invoke();
        }
        public void ClickButton6()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num6Button"))?.AsButton();
            button1?.Invoke();
        }
        public void ClickButton7()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num7Button"))?.AsButton();
            button1?.Invoke();
        }
        public void ClickButton8()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num8Button"))?.AsButton();
            button1?.Invoke();
        }

        public void ClickButton9()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("num9Button"))?.AsButton();
            button1?.Invoke();
        }

        public void ClickButtonEquals()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("equalButton"))?.AsButton();
            button1?.Invoke();
        }

        public void ClickButtonAddition()
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var button1 = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("plusButton"))?.AsButton();
            button1?.Invoke();
        }

        public void AssertResult(String res)
        {
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            var resultLabel = calcWindow.FindFirstDescendant(cfA => cf.ByAutomationId("CalculatorResults"))?.AsLabel();

            Console.WriteLine(resultLabel.Text);

            Assert.True(resultLabel.Text.Contains(res));
        }
    }
}
