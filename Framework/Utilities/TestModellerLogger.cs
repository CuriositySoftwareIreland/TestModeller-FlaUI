using CuriositySoftware.RunResult.Entities;
using FlaUI.Core;
using FlaUI.Core.Capturing;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Utilities
{
    public class TestModellerLogger
    {
        public static List<TestPathRunStep> steps = new List<TestPathRunStep>();

        public static String LastNodeGuid;

        public static void LogMessage(String name, String description, TestPathRunStatus status)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (name);
            step.stepDescription = (description);
            step.testStatus = (status);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void LogMessageWithScreenshot(String name, String description, byte[] image, TestPathRunStatus status)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (name);
            step.stepDescription = (description);
            step.image = (image);
            step.testStatus = (status);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void FailStep(String stepName, String details)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (stepName);
            step.stepDescription = (details);
            step.testStatus = (TestPathRunStatus.Failed);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void PassStep(Application app, String stepName)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (stepName);
            step.testStatus = (TestPathRunStatus.Passed);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void PassStepWithScreenshot(Application app, String stepName)
        {
            PassStepWithScreenshot(app, stepName, stepName);
        }

        public static void PassStepWithScreenshot(Application app, String stepName, String details)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (stepName);
            step.stepDescription = (details);
            step.image = ImageToByte(Capture.Screen().Bitmap);
            step.testStatus = (TestPathRunStatus.Passed);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void FailStepWithScreenshot(Application app, String stepName)
        {
            FailStepWithScreenshot(app, stepName, stepName);
        }

        public static void FailStepWithScreenshot(Application app, String stepName, String details)
        {
            TestPathRunStep step = new TestPathRunStep();

            step.stepName = (stepName);
            step.stepDescription = (details);
            step.image = ImageToByte(Capture.Screen().Bitmap);
            step.testStatus = (TestPathRunStatus.Failed);
            step.nodeGuid = (LastNodeGuid);

            steps.Add(step);
        }

        public static void SetLastNodeGuid(String guid)
        {
            LastNodeGuid = guid;
        }

        public static void ClearMessages()
        {
            steps.Clear();
        }

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
    }
}