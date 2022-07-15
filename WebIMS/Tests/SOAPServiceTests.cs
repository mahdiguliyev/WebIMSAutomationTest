using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resources.Enums.Users;
using Resources.Functions;
using System;
using System.Threading.Tasks;

namespace WebIMS.Tests
{
    [TestClass]
    [TestCategory("SOAP Services")]
    public class SOAPServiceTests : BaseTest
    {
        //[TestMethod]
        [Description("RegisterActPayment service")]
        public async Task RegisterActPaymentServiceTest()
        {
            var result = await Request.RegisterActPaymentAsycn("LA-022832-CO", 38, "AZN", DateTime.Now, "LA-022832-CO", CompanyType.AteshgahLife);
            if (result != "0")
                Assert.AreEqual("0", result);
        }
        [TestMethod]
        [Description("GetPaymentAmountAct service")]
        public async Task GetPaymentAmountActServiceTest()
        {
            await Request.GetPaymentAmountActAsync("EAC-221737");
        }
    }
}
