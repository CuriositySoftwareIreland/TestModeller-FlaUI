using FlaUI.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestModellerCSharp.Utilities;
using Utilities;

namespace Pages
{
    public class BasePage
    {
        protected FlaUIApplication app { get; set; }

        public BasePage(FlaUIApplication app)
        {
            this.app = app;
        }

        public void passStep(String msg)
        {
            TestModellerLogger.PassStep(app.app, msg);
        }

        public void passStepWithScreenshot(String msg)
        {
            TestModellerLogger.PassStepWithScreenshot(app.app, msg);
        }

        public void failStep(String msg)
        {
            TestModellerLogger.FailStepWithScreenshot(app.app, msg);

            app.app.Close(true);

            Assert.Fail(msg);
        }

        public void failStep(String msg, String details)
        {
            TestModellerLogger.FailStepWithScreenshot(app.app, msg + "; " + details);

            app.app.Close(true);

            Assert.Fail(msg + "; " + details);
        }


    }
}
