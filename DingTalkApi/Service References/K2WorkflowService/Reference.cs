﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace DingTalkApi.K2WorkflowService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ApprovalWorklistItem", Namespace="http://schemas.datacontract.org/2004/07/K2Application.Common")]
    [System.SerializableAttribute()]
    public partial class ApprovalWorklistItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApplyUserField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CurActivityNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FolioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProcInstIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProcessNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SNField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string URLField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApplyUser {
            get {
                return this.ApplyUserField;
            }
            set {
                if ((object.ReferenceEquals(this.ApplyUserField, value) != true)) {
                    this.ApplyUserField = value;
                    this.RaisePropertyChanged("ApplyUser");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CurActivityName {
            get {
                return this.CurActivityNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CurActivityNameField, value) != true)) {
                    this.CurActivityNameField = value;
                    this.RaisePropertyChanged("CurActivityName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Folio {
            get {
                return this.FolioField;
            }
            set {
                if ((object.ReferenceEquals(this.FolioField, value) != true)) {
                    this.FolioField = value;
                    this.RaisePropertyChanged("Folio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcInstID {
            get {
                return this.ProcInstIDField;
            }
            set {
                if ((object.ReferenceEquals(this.ProcInstIDField, value) != true)) {
                    this.ProcInstIDField = value;
                    this.RaisePropertyChanged("ProcInstID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProcessName {
            get {
                return this.ProcessNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProcessNameField, value) != true)) {
                    this.ProcessNameField = value;
                    this.RaisePropertyChanged("ProcessName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SN {
            get {
                return this.SNField;
            }
            set {
                if ((object.ReferenceEquals(this.SNField, value) != true)) {
                    this.SNField = value;
                    this.RaisePropertyChanged("SN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((object.ReferenceEquals(this.StartDateField, value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string URL {
            get {
                return this.URLField;
            }
            set {
                if ((object.ReferenceEquals(this.URLField, value) != true)) {
                    this.URLField = value;
                    this.RaisePropertyChanged("URL");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="K2WorkflowService.IK2WorkflowService")]
    public interface IK2WorkflowService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/StartProcessInstance", ReplyAction="http://tempuri.org/IK2WorkflowService/StartProcessInstanceResponse")]
        void StartProcessInstance(string WorkflowTypeName, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApplyUserInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/StartProcessInstance", ReplyAction="http://tempuri.org/IK2WorkflowService/StartProcessInstanceResponse")]
        System.Threading.Tasks.Task StartProcessInstanceAsync(string WorkflowTypeName, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApplyUserInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetCurrentUserWorkListItem", ReplyAction="http://tempuri.org/IK2WorkflowService/GetCurrentUserWorkListItemResponse")]
        DingTalkApi.K2WorkflowService.ApprovalWorklistItem[] GetCurrentUserWorkListItem(string ApprovalUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetCurrentUserWorkListItem", ReplyAction="http://tempuri.org/IK2WorkflowService/GetCurrentUserWorkListItemResponse")]
        System.Threading.Tasks.Task<DingTalkApi.K2WorkflowService.ApprovalWorklistItem[]> GetCurrentUserWorkListItemAsync(string ApprovalUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/ApprovalProcessInstance", ReplyAction="http://tempuri.org/IK2WorkflowService/ApprovalProcessInstanceResponse")]
        void ApprovalProcessInstance(string SN, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApprovalUserInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/ApprovalProcessInstance", ReplyAction="http://tempuri.org/IK2WorkflowService/ApprovalProcessInstanceResponse")]
        System.Threading.Tasks.Task ApprovalProcessInstanceAsync(string SN, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApprovalUserInfo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetProcessInstanceApprovalHistory", ReplyAction="http://tempuri.org/IK2WorkflowService/GetProcessInstanceApprovalHistoryResponse")]
        string GetProcessInstanceApprovalHistory(string SN, string ApprovalUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetProcessInstanceApprovalHistory", ReplyAction="http://tempuri.org/IK2WorkflowService/GetProcessInstanceApprovalHistoryResponse")]
        System.Threading.Tasks.Task<string> GetProcessInstanceApprovalHistoryAsync(string SN, string ApprovalUserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetCurrentUserCompletedWorkListItem", ReplyAction="http://tempuri.org/IK2WorkflowService/GetCurrentUserCompletedWorkListItemResponse" +
            "")]
        string GetCurrentUserCompletedWorkListItem(string ApprovalUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IK2WorkflowService/GetCurrentUserCompletedWorkListItem", ReplyAction="http://tempuri.org/IK2WorkflowService/GetCurrentUserCompletedWorkListItemResponse" +
            "")]
        System.Threading.Tasks.Task<string> GetCurrentUserCompletedWorkListItemAsync(string ApprovalUser);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IK2WorkflowServiceChannel : DingTalkApi.K2WorkflowService.IK2WorkflowService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class K2WorkflowServiceClient : System.ServiceModel.ClientBase<DingTalkApi.K2WorkflowService.IK2WorkflowService>, DingTalkApi.K2WorkflowService.IK2WorkflowService {
        
        public K2WorkflowServiceClient() {
        }
        
        public K2WorkflowServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public K2WorkflowServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public K2WorkflowServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public K2WorkflowServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void StartProcessInstance(string WorkflowTypeName, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApplyUserInfo) {
            base.Channel.StartProcessInstance(WorkflowTypeName, dicDataFields, ApplyUserInfo);
        }
        
        public System.Threading.Tasks.Task StartProcessInstanceAsync(string WorkflowTypeName, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApplyUserInfo) {
            return base.Channel.StartProcessInstanceAsync(WorkflowTypeName, dicDataFields, ApplyUserInfo);
        }
        
        public DingTalkApi.K2WorkflowService.ApprovalWorklistItem[] GetCurrentUserWorkListItem(string ApprovalUser) {
            return base.Channel.GetCurrentUserWorkListItem(ApprovalUser);
        }
        
        public System.Threading.Tasks.Task<DingTalkApi.K2WorkflowService.ApprovalWorklistItem[]> GetCurrentUserWorkListItemAsync(string ApprovalUser) {
            return base.Channel.GetCurrentUserWorkListItemAsync(ApprovalUser);
        }
        
        public void ApprovalProcessInstance(string SN, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApprovalUserInfo) {
            base.Channel.ApprovalProcessInstance(SN, dicDataFields, ApprovalUserInfo);
        }
        
        public System.Threading.Tasks.Task ApprovalProcessInstanceAsync(string SN, System.Collections.Generic.Dictionary<string, object> dicDataFields, string ApprovalUserInfo) {
            return base.Channel.ApprovalProcessInstanceAsync(SN, dicDataFields, ApprovalUserInfo);
        }
        
        public string GetProcessInstanceApprovalHistory(string SN, string ApprovalUserId) {
            return base.Channel.GetProcessInstanceApprovalHistory(SN, ApprovalUserId);
        }
        
        public System.Threading.Tasks.Task<string> GetProcessInstanceApprovalHistoryAsync(string SN, string ApprovalUserId) {
            return base.Channel.GetProcessInstanceApprovalHistoryAsync(SN, ApprovalUserId);
        }
        
        public string GetCurrentUserCompletedWorkListItem(string ApprovalUser) {
            return base.Channel.GetCurrentUserCompletedWorkListItem(ApprovalUser);
        }
        
        public System.Threading.Tasks.Task<string> GetCurrentUserCompletedWorkListItemAsync(string ApprovalUser) {
            return base.Channel.GetCurrentUserCompletedWorkListItemAsync(ApprovalUser);
        }
    }
}
