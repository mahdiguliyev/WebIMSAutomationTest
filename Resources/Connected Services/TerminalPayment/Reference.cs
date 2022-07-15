﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TerminalPayment
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentAmountContract", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class PaymentAmountContract : object
    {
        
        private string ActNumberField;
        
        private string TerminalTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ActNumber
        {
            get
            {
                return this.ActNumberField;
            }
            set
            {
                this.ActNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string TerminalType
        {
            get
            {
                return this.TerminalTypeField;
            }
            set
            {
                this.TerminalTypeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentAmountResult", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class PaymentAmountResult : object
    {
        
        private System.Nullable<decimal> ActAmountField;
        
        private string AgentNameField;
        
        private System.Nullable<decimal> AmountToPayField;
        
        private System.Nullable<int> OrganizationField;
        
        private System.Nullable<decimal> PrePaymentsAmountField;
        
        private string ResultField;
        
        private System.Nullable<decimal> TotalDebtsAmountField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> ActAmount
        {
            get
            {
                return this.ActAmountField;
            }
            set
            {
                this.ActAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AgentName
        {
            get
            {
                return this.AgentNameField;
            }
            set
            {
                this.AgentNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> AmountToPay
        {
            get
            {
                return this.AmountToPayField;
            }
            set
            {
                this.AmountToPayField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> Organization
        {
            get
            {
                return this.OrganizationField;
            }
            set
            {
                this.OrganizationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> PrePaymentsAmount
        {
            get
            {
                return this.PrePaymentsAmountField;
            }
            set
            {
                this.PrePaymentsAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> TotalDebtsAmount
        {
            get
            {
                return this.TotalDebtsAmountField;
            }
            set
            {
                this.TotalDebtsAmountField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterActPaymentContract", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class RegisterActPaymentContract : object
    {
        
        private string ActNumberField;
        
        private decimal AmountPaidField;
        
        private string CurrencyField;
        
        private System.DateTime PaymentDateTimeField;
        
        private string PaymentIdField;
        
        private string TerminalTypeField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ActNumber
        {
            get
            {
                return this.ActNumberField;
            }
            set
            {
                this.ActNumberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal AmountPaid
        {
            get
            {
                return this.AmountPaidField;
            }
            set
            {
                this.AmountPaidField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Currency
        {
            get
            {
                return this.CurrencyField;
            }
            set
            {
                this.CurrencyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime PaymentDateTime
        {
            get
            {
                return this.PaymentDateTimeField;
            }
            set
            {
                this.PaymentDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string PaymentId
        {
            get
            {
                return this.PaymentIdField;
            }
            set
            {
                this.PaymentIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string TerminalType
        {
            get
            {
                return this.TerminalTypeField;
            }
            set
            {
                this.TerminalTypeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RegisterActPaymentResult", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class RegisterActPaymentResult : object
    {
        
        private System.Nullable<System.DateTime> RegDateTimeField;
        
        private string ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> RegDateTime
        {
            get
            {
                return this.RegDateTimeField;
            }
            set
            {
                this.RegDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckPaymentContract", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class CheckPaymentContract : object
    {
        
        private string PaymentIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string PaymentId
        {
            get
            {
                return this.PaymentIdField;
            }
            set
            {
                this.PaymentIdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CheckPaymentResult", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class CheckPaymentResult : object
    {
        
        private System.Nullable<System.DateTime> RegDateTimeField;
        
        private string ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> RegDateTime
        {
            get
            {
                return this.RegDateTimeField;
            }
            set
            {
                this.RegDateTimeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentsReconciliationContract", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class PaymentsReconciliationContract : object
    {
        
        private string CurrencyField;
        
        private System.DateTime FromDateField;
        
        private decimal PaymentsAmountField;
        
        private int PaymentsCountField;
        
        private System.DateTime TillDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string Currency
        {
            get
            {
                return this.CurrencyField;
            }
            set
            {
                this.CurrencyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime FromDate
        {
            get
            {
                return this.FromDateField;
            }
            set
            {
                this.FromDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public decimal PaymentsAmount
        {
            get
            {
                return this.PaymentsAmountField;
            }
            set
            {
                this.PaymentsAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int PaymentsCount
        {
            get
            {
                return this.PaymentsCountField;
            }
            set
            {
                this.PaymentsCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.DateTime TillDate
        {
            get
            {
                return this.TillDateField;
            }
            set
            {
                this.TillDateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PaymentsReconciliationResult", Namespace="http://services.ateshgah.com/Payment/v1")]
    public partial class PaymentsReconciliationResult : object
    {
        
        private System.Nullable<decimal> PaymentsAmountField;
        
        private System.Nullable<int> PaymentsCountField;
        
        private string ResultField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> PaymentsAmount
        {
            get
            {
                return this.PaymentsAmountField;
            }
            set
            {
                this.PaymentsAmountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> PaymentsCount
        {
            get
            {
                return this.PaymentsCountField;
            }
            set
            {
                this.PaymentsCountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Result
        {
            get
            {
                return this.ResultField;
            }
            set
            {
                this.ResultField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://services.ateshgah.com/Payment/v1", ConfigurationName="TerminalPayment.ITerminalPayment")]
    public interface ITerminalPayment
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.ateshgah.com/Payment/v1/ITerminalPayment/GetPaymentAmountAct", ReplyAction="http://services.ateshgah.com/Payment/v1/ITerminalPayment/GetPaymentAmountActRespo" +
            "nse")]
        System.Threading.Tasks.Task<TerminalPayment.PaymentAmountResult> GetPaymentAmountActAsync(TerminalPayment.PaymentAmountContract contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.ateshgah.com/Payment/v1/ITerminalPayment/RegisterActPayment", ReplyAction="http://services.ateshgah.com/Payment/v1/ITerminalPayment/RegisterActPaymentRespon" +
            "se")]
        System.Threading.Tasks.Task<TerminalPayment.RegisterActPaymentResult> RegisterActPaymentAsync(TerminalPayment.RegisterActPaymentContract contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.ateshgah.com/Payment/v1/ITerminalPayment/CheckPayment", ReplyAction="http://services.ateshgah.com/Payment/v1/ITerminalPayment/CheckPaymentResponse")]
        System.Threading.Tasks.Task<TerminalPayment.CheckPaymentResult> CheckPaymentAsync(TerminalPayment.CheckPaymentContract contract);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://services.ateshgah.com/Payment/v1/ITerminalPayment/PaymentsReconciliation", ReplyAction="http://services.ateshgah.com/Payment/v1/ITerminalPayment/PaymentsReconciliationRe" +
            "sponse")]
        System.Threading.Tasks.Task<TerminalPayment.PaymentsReconciliationResult> PaymentsReconciliationAsync(TerminalPayment.PaymentsReconciliationContract contract);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface ITerminalPaymentChannel : TerminalPayment.ITerminalPayment, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class TerminalPaymentClient : System.ServiceModel.ClientBase<TerminalPayment.ITerminalPayment>, TerminalPayment.ITerminalPayment
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public TerminalPaymentClient() : 
                base(TerminalPaymentClient.GetDefaultBinding(), TerminalPaymentClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.wsHttpBinding_TerminalPayment_v1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TerminalPaymentClient(EndpointConfiguration endpointConfiguration) : 
                base(TerminalPaymentClient.GetBindingForEndpoint(endpointConfiguration), TerminalPaymentClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TerminalPaymentClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(TerminalPaymentClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TerminalPaymentClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(TerminalPaymentClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public TerminalPaymentClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<TerminalPayment.PaymentAmountResult> GetPaymentAmountActAsync(TerminalPayment.PaymentAmountContract contract)
        {
            return base.Channel.GetPaymentAmountActAsync(contract);
        }
        
        public System.Threading.Tasks.Task<TerminalPayment.RegisterActPaymentResult> RegisterActPaymentAsync(TerminalPayment.RegisterActPaymentContract contract)
        {
            return base.Channel.RegisterActPaymentAsync(contract);
        }
        
        public System.Threading.Tasks.Task<TerminalPayment.CheckPaymentResult> CheckPaymentAsync(TerminalPayment.CheckPaymentContract contract)
        {
            return base.Channel.CheckPaymentAsync(contract);
        }
        
        public System.Threading.Tasks.Task<TerminalPayment.PaymentsReconciliationResult> PaymentsReconciliationAsync(TerminalPayment.PaymentsReconciliationContract contract)
        {
            return base.Channel.PaymentsReconciliationAsync(contract);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsHttpBinding_TerminalPayment_v1))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TransportSecurityBindingElement userNameOverTransportSecurityBindingElement = System.ServiceModel.Channels.SecurityBindingElement.CreateUserNameOverTransportBindingElement();
                userNameOverTransportSecurityBindingElement.MessageSecurityVersion = System.ServiceModel.MessageSecurityVersion.WSSecurity11WSTrustFebruary2005WSSecureConversationFebruary2005WSSecurityPolicy11BasicSecurityProfile10;
                result.Elements.Add(userNameOverTransportSecurityBindingElement);
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.wsHttpBinding_TerminalPayment_v1))
            {
                return new System.ServiceModel.EndpointAddress("https://test4-polis.ateshgah.com/IAPOSExternal/Service/Financials/v1/TerminalPaym" +
                        "ent.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return TerminalPaymentClient.GetBindingForEndpoint(EndpointConfiguration.wsHttpBinding_TerminalPayment_v1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return TerminalPaymentClient.GetEndpointAddress(EndpointConfiguration.wsHttpBinding_TerminalPayment_v1);
        }
        
        public enum EndpointConfiguration
        {
            
            wsHttpBinding_TerminalPayment_v1,
        }
    }
}
