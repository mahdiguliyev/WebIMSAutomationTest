using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Resources;
using Resources.DB;
using Resources.Enums.Users;
using Resources.Functions;
using Resources.Models;
using Resources.Reporter;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebIMS.Pages.ProductsPages
{
    public class BaseProductPage : Waiter
    {
        protected IWebDriver Driver { get; set; }
        public BaseProductPage(IWebDriver driver) : base(driver)
        {
            Driver = driver;
        }
        public IWebElement AgenBroker => Driver.FindElement(By.Id("MediatorData_AgentBrokerGuidText"));
        public IWebElement AgenBrokerItem => Driver.FindElement(By.XPath("//*[contains(text(),'\"Atəşgah\" Sığorta Agentliyi  MMC')]"));
        public IWebElement InsuredPinCode => WaitUntilElementIsClickable(By.Id("Client_SearchParameters_PIN"));
        public IWebElement InsuredIdNumberPrefix => Driver.FindElement(By.Id("Client_SearchParameters_IdSeries"));
        public IWebElement InsuredIdNumber => Driver.FindElement(By.Id("Client_SearchParameters_IdNumber"));
        public IWebElement InsurePhoneNumber => WaitAndFindElement(By.Id("Client_Phone"));
        public IWebElement InsuredEmailAddress => Driver.FindElement(By.Id("Client_Email"));
        public IWebElement SearchInsurer => Driver.FindElement(By.Id("Client_SearchParameters_Search"));

        public IWebElement IssuePolicy => Driver.FindElement(By.Name("PreIssue"));
        public IWebElement NotificationBox => Driver.FindElement(By.ClassName("error"));
        public IWebElement PageMessageBox => WaitAndFindElement(By.Id("PageMessageBox"));
        public IWebElement PolicyNumber => Driver.FindElement(By.Id("M_qavil__n_mr_si"));
        public IWebElement CancelButton => Driver.FindElement(By.XPath("//a[@class='submit dark']/span[contains(text(), 'Ləğv et')]"));
        public IWebElement CalcelPolicyModalFormCalcelButton => WaitAndFindElement(By.Id("AnnulBtn"));
        public IWebElement PolicyStatus => Driver.FindElement(By.Id("Status"));
        public IWebElement PaymentCode => Driver.FindElement(By.XPath("//tr/td[2]"));
        public IWebElement PaymentAmount => Driver.FindElement(By.XPath("//tr/td[5]"));
        public IWebElement PaymentDate => Driver.FindElement(By.XPath("//tr/td[6]"));
        public IWebElement TerminateButton => Driver.FindElement(By.XPath("//a[@class='submit dark']/span[contains(text(), 'Xitam vermək')]"));
        public IWebElement TerminatePolicyModalFormCalcelButton => WaitAndFindElement(By.Id("TerminateBtn"));

        private IWebElement PrintPolicy => WaitUntilElementIsClickable(By.XPath("//span[contains(text(),'Çap etmək')]"));
        

        #region Methods
        public virtual void CancelPolicy()
        {
            CancelButton.Click();
            CalcelPolicyModalFormCalcelButton.Click();
            Thread.Sleep(500);
            bool isCanceled = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polis ləğv edildi");
            if (!isCanceled)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Policy cannot be canceled");
                Assert.IsTrue(isCanceled);
            }
            else
            {
                CheckPolicyStatus(PolicyNumber.Text, "İmtina olunub");
                Report.LogTestStepForBugLogger(Status.Pass, "Policy is canceled");
                Assert.IsTrue(isCanceled);
            }
        }
        public void CheckPolicyStatus(string policyNumber, string status)
        {
            if (PolicyStatus.Text != status)
            {
                Report.LogTestStepForBugLogger(Status.Fail, $"Policy status is not '{status}', current status is '{PolicyStatus.Text}'");
            }
            else if (PolicyStatus.Text == status)
            {
                Report.LogTestStepForBugLogger(Status.Pass, $"Policy status is '{status}'");
            }
            else
            {
                Report.LogTestStepForBugLogger(Status.Warning, $"Policy status is not defined");
            }
        }
        public virtual void TerminatePolicy()
        {
            TerminateButton.Click();
            TerminatePolicyModalFormCalcelButton.Click();
            Thread.Sleep(500);
            bool isTerminated = WaitAndFindElement(By.Id("PageMessageBox")).Text.Contains("Polisə xitam verilib");
            if (!isTerminated)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Policy cannot be terminated");
                Assert.IsTrue(isTerminated);
            }
            else
            {
                Report.LogTestStepForBugLogger(Status.Pass, "Policy is terminated");
                Assert.IsTrue(isTerminated);
            }
        }
        public async Task<string> PolicyActivation()
        {
            var currentDate = DateTime.Now.ToString("yyyy'-'MM'-'dd");
            var startDate = DateTime.Now.AddDays(-1).ToString("yyyy'-'MM'-'dd");
            var endDate = DateTime.Now.AddYears(1).ToString("yyyy'-'MM'-'dd");
            string policyNumber = PolicyNumber.Text;
            string number = policyNumber.Split("-")[1];

            string policyActionGuid = GetPolicyActionGuid(policyNumber);

            var insuredPerson = new InsuredPersonModel
            {
                Address = "BAKI şəh., SABUNÇU QƏS., S.M.ƏFƏNDİYEV KÜÇ., ev.25, m.5",
                DateOfBirth = "1974-11-30",
                FatherName = "CAHANGİR OĞLU",
                Gender = "m",
                Name = "AZƏR",
                Phone = "994557455097",
                Pin = "11W2E5J",
                Surname = "QULİYEV"
            };
            var requestModel = new PolicyKTSIssueModel
            {
                BrokerTaxId = null,
                EndDate = endDate,
                InsuredPerson = insuredPerson,
                Number = number,
                PolicyActionGuid = policyActionGuid,
                PolicyDate = currentDate,
                Premium = 180,
                ProductCode = "KTS01",
                SellerLogin = null,
                Series = "TFS",
                StartDate = startDate
            };
            int[] programs = new int[2];
            programs[0] = 1044;
            programs[1] = 1041;
            requestModel.Programs = programs;

            var response = await Request.Post("https://medical.ateshgah.com:8082/api/kts/issue", requestModel);

            ChangePolicyStatus(policyNumber);
            UpdateRowId(5027, policyNumber);

            return response;
        }
        public void ChangePolicyStatus(string policyNumber)
        {
            string query = $@"declare @policyNumber nvarchar(50) = '{policyNumber}'
                            declare @policyGuid nvarchar(50) = ( select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber )

                            update Policies.PolicyAction set status_code=3 where policy_guid=@policyGuid";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);
            

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);
        }
        public string GetPolicyActionGuid(string policyNumber)
        {
            string query = $@"declare @policyNumber nvarchar(50) = '{policyNumber}'
                            declare @policyGuid nvarchar(50) = ( select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber )
                            select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid=@policyGuid";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            return result.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        public string GetPolicyGuid(string policyNumber)
        {
            string query = $@"declare @policyNumber nvarchar(50) = '{policyNumber}'
                              select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            return result.Tables[0].Rows[0].ItemArray[0].ToString();
        }
        public async Task DoPayment(string policyNumber, decimal amount, CompanyType companyType)
        {
            var result = await Request.RegisterActPaymentAsycn(policyNumber, amount, "AZN", DateTime.Now, policyNumber, companyType);
            if (result != "0")
                Assert.AreEqual("0", result);
        }
        public void UpdateRowId(int rowId,string policyNumber)
        {
            string policyGuid = GetPolicyGuid(policyNumber);
            string queryChangeRowID = $"update Policies.PolicyAction set draft_data ='<VoluntaryHealthPolicyDraft xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">    <ProtechRowId>{rowId}</ProtechRowId>  </VoluntaryHealthPolicyDraft>' where policy_guid='{policyGuid}'";

            QueryResultModel resultQuery = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, queryChangeRowID);

            if (resultQuery.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, resultQuery.Error);
        }
        public virtual void PrintPolicyOperation()
        {
            PrintPolicy.Click();

            var handles = Driver.WindowHandles;

            Driver.SwitchTo().Window(handles[1]);
            string currentBrowserUrl = Driver.Url;
            bool IsContained = currentBrowserUrl.Contains("/webims/Print/Preview");
            if (!IsContained)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Url do not end with '/webims/Print/Preview'");
            }
            Report.LogPassingTestStepForBugLogger("Url end with '/webims/Print/Preview'");
            Assert.IsTrue(IsContained);
            //var pages = StaticMethods.ReadPDFContent("https://test4-polis.ateshgah.com/webims/Covid19/Policy/Print/537e12c6-6711-49cd-bdb8-62c7bd03e975?lob=225&type=Policy");
        }
        public void CheckEmailVsSMS()
        {
            Thread.Sleep(2000);
            var email = InsuredEmailAddress.Text;
            var phoneNumber = InsurePhoneNumber.Text;
            var invoice = PaymentCode.Text;
            var policyNumber = PolicyNumber.Text;
            string query = $@"SELECT  top(2) payload FROM [EAGLE].[dbo].[Queue] 
                                    where recipient='{email}' or recipient='{phoneNumber}' order by id desc";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            if (result == null)
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Any Email or SMS notification do not find for the policy");
            }

            if (result.Tables[0].Rows[0].ItemArray.GetValue(0).ToString().Contains(invoice) || result.Tables[0].Rows[1].ItemArray.GetValue(0).ToString().Contains(invoice))
            {
                Report.LogTestStepForBugLogger(Status.Pass, "Email or SMS notification is sent to recepient");
            }
            else
            {
                Report.LogTestStepForBugLogger(Status.Fail, "Email or SMS notification is not sent to recepient");
            }
        }
        public virtual QueryResultModel RemovePolicyFromDatabase(string policyNumber)
        {
            string query = $@"
                            declare @policyNumber nvarchar(50) = {policyNumber}

                            declare @policyGuid nvarchar(50) = ( select policy_guid from [EAGLE].[Policies].[Policy] where policy_number= @policyNumber )
                            declare @policyActionGuid  nvarchar(50) = (select policy_action_guid from [EAGLE].[Policies].[PolicyAction] where policy_guid = @policyGuid)

                            begin tran
                            declare @policyGuid uniqueidentifier
                            declare @policyActionGuid uniqueidentifier
                            declare @tblInvoiceGuids as table (invoiceGuid uniqueidentifier);

                            select @policyActionGuid = pa.policy_action_guid, @policyGuid = p.policy_guid
                            from Policies.Policy as p
	                            join Policies.PolicyAction as pa		on pa.policy_guid = p.policy_guid
                            where pa.policy_action_guid=@policyActionGuid

                            insert into @tblInvoiceGuids
                            select invoice_guid from Financials.Installment
                            where policy_action_guid = @policyActionGuid
 
                            PRINT 'Policy Guid: ' + convert(varchar(50),@policyGuid)
                            PRINT 'PolicyAction Guid: ' + + convert(varchar(50), @policyActionGuid)

                            PRINT 'delete from Policies.AcibisPolicyAction'
                            delete from Policies.AcibisPolicyAction
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from Policies.Beneficiary'
                            delete from Policies.Beneficiary
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from ObjectRegister.Document'
                            delete from ObjectRegister.Document
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from Policies.Programdetails'
                            delete from Policies.Programdetails
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from MOD.CoverageFleets'
                            delete from MOD.CoverageFleets where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from MOD.CoverageRetailCascoVehicle'
                            delete from MOD.CoverageRetailCascoVehicle where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from MOD.Fleets'
                            delete from MOD.Fleets where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from MOD.VehicleEquipment'
                            delete from MOD.VehicleEquipment where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from MOD.Drivers'
                            delete from MOD.Drivers where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from MOD.Vehicle'
                            delete from MOD.Vehicle where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from PersonalInsurance.CoveragePI'
                            delete from PersonalInsurance.CoveragePI where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from PersonalInsurance.InsuredPersons'
                            delete from PersonalInsurance.InsuredPersons where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from PersonalInsurance.PersonsGroup'
                            delete from PersonalInsurance.PersonsGroup where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from Policies.InsuredRIsk'
                            delete from Policies.InsuredRIsk where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from Mtpl.Coverage'
                            delete from Mtpl.Coverage where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from Property.Coverage'
                            delete from Property.Coverage where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid =  @policyActionGuid)

                            PRINT 'delete from MOD.CoveragePA'
                            delete from MOD.CoveragePA where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)

                            PRINT 'delete from Policies.ObjectCoverage'
                            delete from Policies.ObjectCoverage where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from MOD.VehicleSurveyAct'
                            delete from MOD.VehicleSurveyAct 
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from Policies.ChangeLog'
                            delete from Policies.ChangeLog
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from Financials.Installment'
                            delete from Financials.Installment
                            where policy_action_guid = @policyActionGuid
                            PRINT 'delete from Financials.Invoicelog'
                            delete from Financials.Invoicelog
                            where invoice_guid in (select invoiceGuid from @tblInvoiceGuids)
                            PRINT 'delete from Financials.InvoiceAmounts'
                            delete from Financials.InvoiceAmounts
                            where invoice_guid in (select invoiceGuid from @tblInvoiceGuids)
                            PRINT 'delete from Financials.InvoiceHistory'
                            delete from Financials.InvoiceHistory
                            where invoice_guid in (select invoiceGuid from @tblInvoiceGuids)
                            PRINT 'delete from InvoiceTaxExportLog'
                            delete from dbo.InvoiceTaxExportLog
                            where invoice_guid in (select invoiceGuid from @tblInvoiceGuids)
                            PRINT 'delete from Financials.Invoice'
                            delete from Financials.Invoice
                            where invoice_guid in (select invoiceGuid from @tblInvoiceGuids)

                            PRINT 'delete from Property.Property'
                            delete from Property.Property where object_guid in (
                            select object_guid from Policies.InsuredObject
                            where policy_action_guid = @policyActionGuid)


                            PRINT 'delete from Policies.InsuredObject'
                            delete from Policies.InsuredObject
                            where policy_action_guid  = @policyActionGuid


                            PRINT 'delete from Policies.PolicyCoverageVariant'
                            delete from Policies.PolicyCoverageVariant
                            where policy_action_guid  = @policyActionGuid

                            print 'delete from Policies.ExpertLog'
                            delete from Policies.ExpertLog
                            where policy_action_guid = @policyActionGuid

                            PRINT 'delete from Policies.Clause'
                            delete from Policies.Clause 
                            where policy_action_guid=@policyActionGuid

                            PRINT 'delete from Policies.policyaction'
                            delete from policies.policyaction
                            where policy_action_guid = @policyActionGuid

                            commit";
            QueryResultModel result = MSSQL.GetQueryResult(ConnectionStrings.EAGLE_TEST4, query);

            if (result.Error != null)
                Report.LogTestStepForBugLogger(Status.Fail, result.Error);

            return result;
        }
        #endregion
    }
}
