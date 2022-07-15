using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resources
{
    [TestClass]
    public static class NamespaceSetup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Report.StartReporter();
        }
    }
}
