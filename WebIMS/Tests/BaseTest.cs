using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using Resources;
using Resources.Enums;
using Resources.Reporter;
using System;

namespace WebIMS.Tests
{
    public class BaseTest
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public IWebDriver Driver { get; private set; }
        public TestContext TestContext { get; set; }
        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Logger.Debug("******************************************************* TEST STARTED");
            Logger.Debug("******************************************************* TEST STARTED");
            Report.AddTestCaseMetadataToHtmlReport(TestContext);
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }
        [TestCleanup]
        public void CleanUp()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailue();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("******************************************************* TEST STOPPED");
                Logger.Debug("******************************************************* TEST STOPPED");
            }
        }
        private void TakeScreenshotForTestFailue()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Report.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Report.ReportTestOutcome("");
            }
        }
        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully!");
        }
    }
}
