using Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestModellerCSharp.Utilities;

namespace TestModellerCSharp.Pages
{
    public class AssertionActions : BasePage
    {
        public AssertionActions(FlaUIApplication app) : base(app)
        {
            this.app = app;
        }

        /**
         * Pass the current step and take a screenshot.
         * @name Pass Step with Screenshot
         * @param message Message to use for logging
         */
        public void PassStepWithScreenshot(String message)
        {
            passStepWithScreenshot(message);
        }

        /**
         * Pass the current step
         * @name Pass Step
         * @param message Message to use for logging
         */
        public void PassStep(String message)
        {
            passStep(message);
        }

        /**
         * Fail the current step
         * @name Fail Step
         * @param message Message to use for logging
         */
        public void FailStep (String message)
        {
            failStep(message);
        }

        /**
         * Assert two values are equal
         * @name Assert Equal
         * @param expected The expected result
         * @param actual The actual result
         */
        public void AssertEqual(string expected, string actual)
        {
            if (expected == actual)
                passStep("Assert equals '" + expected + "' = '" + actual + "'");
            else
                failStep("Assert equals failed '" + expected + "' = '" + actual + "'");
        }

        /**
         * Assert two values are not equal
         * @name Assert Not Equal
         * @param expected The expected result
         * @param actual The actual result
         */
        public void AssertNotEqual(string expected, string actual)
        {
            if (expected != actual)
                passStep("Assert not equals '" + expected + "' = '" + actual + "'");
            else
                failStep("Assert not equals failed '" + expected + "' = '" + actual + "'");

        }
    }
}
