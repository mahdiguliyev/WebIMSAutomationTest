using Resources.Enums.Users;
using Resources.Models;
using Resources.Reporter;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TerminalPayment;

namespace Resources.Functions
{
    public static class Request
    {
        public async static Task<string> Post(string url, PolicyKTSIssueModel body = null, string header = null)
        {
            HttpClient client = new HttpClient();
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true,  };

            var serializedContent = JsonSerializer.Serialize(body);
            var requestContect = new StringContent(serializedContent, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, requestContect);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            //string deserializedContent = JsonSerializer.Deserialize<string>(content, options);

            return content;
        }
        public async static Task<string> GetPaymentAmountActAsync(string actNumber)
        {
            TerminalPaymentClient terminalPaymentClient = new TerminalPaymentClient();
            terminalPaymentClient.ClientCredentials.UserName.UserName = "1-1-2067-8321";
            terminalPaymentClient.ClientCredentials.UserName.Password = "3aUwgFe4";

            PaymentAmountContract paymentAmountContract = new PaymentAmountContract
            {
                ActNumber = actNumber
            };
            var response = await terminalPaymentClient.GetPaymentAmountActAsync(paymentAmountContract);
            var result = response.Result;

            await terminalPaymentClient.CloseAsync();

            if (result != "0")
                Report.LogPassingTestStepForBugLogger("GetPaymentAmountAct is not working or given information is wrong.");
            else if(result == "0")
                Report.LogPassingTestStepForBugLogger($"GetPaymentAmountAct is working. Paymount amount to pay is {response.AmountToPay} AZN, Agen name: {response.AgentName}.");

            return result;
        }
        public async static Task<string> RegisterActPaymentAsycn(string actNumber, decimal amountPaid, string currency, DateTime paymentDatetime, string paymentId, CompanyType companyType)
        {
            TerminalPaymentClient terminalPaymentClient = new TerminalPaymentClient();
            if (companyType == CompanyType.AteshgahLife)
            {
                terminalPaymentClient.ClientCredentials.UserName.UserName = Users.UsernameForAteshgahLife;
                terminalPaymentClient.ClientCredentials.UserName.Password = Users.PasswordForAteshgahLife;
            }
            else if (companyType == CompanyType.Ateshgah)
            {
                terminalPaymentClient.ClientCredentials.UserName.UserName = Users.UsernameForAteshgah;
                terminalPaymentClient.ClientCredentials.UserName.Password = Users.PasswordForAteshgah;
            }

            RegisterActPaymentContract registerActPaymentContract = new RegisterActPaymentContract
            {
                ActNumber = actNumber,
                AmountPaid = amountPaid,
                Currency = currency,
                PaymentDateTime = paymentDatetime,
                PaymentId = paymentId
            };
            var response = await terminalPaymentClient.RegisterActPaymentAsync(registerActPaymentContract);
            var result = response.Result;

            await terminalPaymentClient.CloseAsync();

            if (result != "0")
                Report.LogPassingTestStepForBugLogger("RegisterActPayment is not working or given information is wrong.");
            else if (result == "0")
                Report.LogPassingTestStepForBugLogger("RegisterActPayment is working.");

            return result;
        }
    }
}
