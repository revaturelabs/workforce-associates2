﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Workforce.Logic.Associates2.WFSReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WFSReference.IAssociateService")]
    public interface IAssociateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAssociates", ReplyAction="http://tempuri.org/IAssociateService/GetAssociatesResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao[] GetAssociates();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAssociates", ReplyAction="http://tempuri.org/IAssociateService/GetAssociatesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao[]> GetAssociatesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAddress", ReplyAction="http://tempuri.org/IAssociateService/GetAddressResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.AddressDao[] GetAddress();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAddress", ReplyAction="http://tempuri.org/IAssociateService/GetAddressResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AddressDao[]> GetAddressAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/GetAssociateAddressResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao[] GetAssociateAddress();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/GetAssociateAddressResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao[]> GetAssociateAddressAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetBatches", ReplyAction="http://tempuri.org/IAssociateService/GetBatchesResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.BatchDao[] GetBatches();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetBatches", ReplyAction="http://tempuri.org/IAssociateService/GetBatchesResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.BatchDao[]> GetBatchesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetInstructor", ReplyAction="http://tempuri.org/IAssociateService/GetInstructorResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao[] GetInstructor();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetInstructor", ReplyAction="http://tempuri.org/IAssociateService/GetInstructorResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao[]> GetInstructorAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetGender", ReplyAction="http://tempuri.org/IAssociateService/GetGenderResponse")]
        Workforce.Logic.Associates2.Domain.WFSReference.GenderDao[] GetGender();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/GetGender", ReplyAction="http://tempuri.org/IAssociateService/GetGenderResponse")]
        System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.GenderDao[]> GetGenderAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAssociate", ReplyAction="http://tempuri.org/IAssociateService/InsertAssociateResponse")]
        bool InsertAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao newassociate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAssociate", ReplyAction="http://tempuri.org/IAssociateService/InsertAssociateResponse")]
        System.Threading.Tasks.Task<bool> InsertAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao newassociate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAddress", ReplyAction="http://tempuri.org/IAssociateService/InsertAddressResponse")]
        bool InsertAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao newaddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAddress", ReplyAction="http://tempuri.org/IAssociateService/InsertAddressResponse")]
        System.Threading.Tasks.Task<bool> InsertAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao newaddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/InsertAssociateAddressResponse")]
        bool InsertAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao newassocaddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/InsertAssociateAddressResponse")]
        System.Threading.Tasks.Task<bool> InsertAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao newassocaddress);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertBatch", ReplyAction="http://tempuri.org/IAssociateService/InsertBatchResponse")]
        bool InsertBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao newbatch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertBatch", ReplyAction="http://tempuri.org/IAssociateService/InsertBatchResponse")]
        System.Threading.Tasks.Task<bool> InsertBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao newbatch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertGender", ReplyAction="http://tempuri.org/IAssociateService/InsertGenderResponse")]
        bool InsertGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao newgender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertGender", ReplyAction="http://tempuri.org/IAssociateService/InsertGenderResponse")]
        System.Threading.Tasks.Task<bool> InsertGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao newgender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertInstructor", ReplyAction="http://tempuri.org/IAssociateService/InsertInstructorResponse")]
        bool InsertInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao newinstructor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/InsertInstructor", ReplyAction="http://tempuri.org/IAssociateService/InsertInstructorResponse")]
        System.Threading.Tasks.Task<bool> InsertInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao newinstructor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAssociate", ReplyAction="http://tempuri.org/IAssociateService/UpdateAssociateResponse")]
        bool UpdateAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAssociate", ReplyAction="http://tempuri.org/IAssociateService/UpdateAssociateResponse")]
        System.Threading.Tasks.Task<bool> UpdateAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAddress", ReplyAction="http://tempuri.org/IAssociateService/UpdateAddressResponse")]
        bool UpdateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAddress", ReplyAction="http://tempuri.org/IAssociateService/UpdateAddressResponse")]
        System.Threading.Tasks.Task<bool> UpdateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/UpdateAssociateAddressResponse")]
        bool UpdateAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/UpdateAssociateAddressResponse")]
        System.Threading.Tasks.Task<bool> UpdateAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateBatch", ReplyAction="http://tempuri.org/IAssociateService/UpdateBatchResponse")]
        bool UpdateBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateBatch", ReplyAction="http://tempuri.org/IAssociateService/UpdateBatchResponse")]
        System.Threading.Tasks.Task<bool> UpdateBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateGender", ReplyAction="http://tempuri.org/IAssociateService/UpdateGenderResponse")]
        bool UpdateGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateGender", ReplyAction="http://tempuri.org/IAssociateService/UpdateGenderResponse")]
        System.Threading.Tasks.Task<bool> UpdateGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateInstructor", ReplyAction="http://tempuri.org/IAssociateService/UpdateInstructorResponse")]
        bool UpdateInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/UpdateInstructor", ReplyAction="http://tempuri.org/IAssociateService/UpdateInstructorResponse")]
        System.Threading.Tasks.Task<bool> UpdateInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAssociate", ReplyAction="http://tempuri.org/IAssociateService/DeleteAssociateResponse")]
        bool DeleteAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAssociate", ReplyAction="http://tempuri.org/IAssociateService/DeleteAssociateResponse")]
        System.Threading.Tasks.Task<bool> DeleteAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAddress", ReplyAction="http://tempuri.org/IAssociateService/DeleteAddressResponse")]
        bool DeleteAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAddress", ReplyAction="http://tempuri.org/IAssociateService/DeleteAddressResponse")]
        System.Threading.Tasks.Task<bool> DeleteAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/DeleteAssociateAddressResponse")]
        bool DeleteAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteAssociateAddress", ReplyAction="http://tempuri.org/IAssociateService/DeleteAssociateAddressResponse")]
        System.Threading.Tasks.Task<bool> DeleteAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteBatch", ReplyAction="http://tempuri.org/IAssociateService/DeleteBatchResponse")]
        bool DeleteBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteBatch", ReplyAction="http://tempuri.org/IAssociateService/DeleteBatchResponse")]
        System.Threading.Tasks.Task<bool> DeleteBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteGender", ReplyAction="http://tempuri.org/IAssociateService/DeleteGenderResponse")]
        bool DeleteGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteGender", ReplyAction="http://tempuri.org/IAssociateService/DeleteGenderResponse")]
        System.Threading.Tasks.Task<bool> DeleteGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteInstructor", ReplyAction="http://tempuri.org/IAssociateService/DeleteInstructorResponse")]
        bool DeleteInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAssociateService/DeleteInstructor", ReplyAction="http://tempuri.org/IAssociateService/DeleteInstructorResponse")]
        System.Threading.Tasks.Task<bool> DeleteInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAssociateServiceChannel : Workforce.Logic.Associates2.WFSReference.IAssociateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AssociateServiceClient : System.ServiceModel.ClientBase<Workforce.Logic.Associates2.WFSReference.IAssociateService>, Workforce.Logic.Associates2.WFSReference.IAssociateService {
        
        public AssociateServiceClient() {
        }
        
        public AssociateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AssociateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AssociateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AssociateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao[] GetAssociates() {
            return base.Channel.GetAssociates();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao[]> GetAssociatesAsync() {
            return base.Channel.GetAssociatesAsync();
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.AddressDao[] GetAddress() {
            return base.Channel.GetAddress();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AddressDao[]> GetAddressAsync() {
            return base.Channel.GetAddressAsync();
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao[] GetAssociateAddress() {
            return base.Channel.GetAssociateAddress();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao[]> GetAssociateAddressAsync() {
            return base.Channel.GetAssociateAddressAsync();
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.BatchDao[] GetBatches() {
            return base.Channel.GetBatches();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.BatchDao[]> GetBatchesAsync() {
            return base.Channel.GetBatchesAsync();
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao[] GetInstructor() {
            return base.Channel.GetInstructor();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao[]> GetInstructorAsync() {
            return base.Channel.GetInstructorAsync();
        }
        
        public Workforce.Logic.Associates2.Domain.WFSReference.GenderDao[] GetGender() {
            return base.Channel.GetGender();
        }
        
        public System.Threading.Tasks.Task<Workforce.Logic.Associates2.Domain.WFSReference.GenderDao[]> GetGenderAsync() {
            return base.Channel.GetGenderAsync();
        }
        
        public bool InsertAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao newassociate) {
            return base.Channel.InsertAssociate(newassociate);
        }
        
        public System.Threading.Tasks.Task<bool> InsertAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao newassociate) {
            return base.Channel.InsertAssociateAsync(newassociate);
        }
        
        public bool InsertAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao newaddress) {
            return base.Channel.InsertAddress(newaddress);
        }
        
        public System.Threading.Tasks.Task<bool> InsertAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao newaddress) {
            return base.Channel.InsertAddressAsync(newaddress);
        }
        
        public bool InsertAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao newassocaddress) {
            return base.Channel.InsertAssociateAddress(newassocaddress);
        }
        
        public System.Threading.Tasks.Task<bool> InsertAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao newassocaddress) {
            return base.Channel.InsertAssociateAddressAsync(newassocaddress);
        }
        
        public bool InsertBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao newbatch) {
            return base.Channel.InsertBatch(newbatch);
        }
        
        public System.Threading.Tasks.Task<bool> InsertBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao newbatch) {
            return base.Channel.InsertBatchAsync(newbatch);
        }
        
        public bool InsertGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao newgender) {
            return base.Channel.InsertGender(newgender);
        }
        
        public System.Threading.Tasks.Task<bool> InsertGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao newgender) {
            return base.Channel.InsertGenderAsync(newgender);
        }
        
        public bool InsertInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao newinstructor) {
            return base.Channel.InsertInstructor(newinstructor);
        }
        
        public System.Threading.Tasks.Task<bool> InsertInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao newinstructor) {
            return base.Channel.InsertInstructorAsync(newinstructor);
        }
        
        public bool UpdateAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc) {
            return base.Channel.UpdateAssociate(assoc);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc) {
            return base.Channel.UpdateAssociateAsync(assoc);
        }
        
        public bool UpdateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address) {
            return base.Channel.UpdateAddress(address);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address) {
            return base.Channel.UpdateAddressAsync(address);
        }
        
        public bool UpdateAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd) {
            return base.Channel.UpdateAssociateAddress(assocadd);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd) {
            return base.Channel.UpdateAssociateAddressAsync(assocadd);
        }
        
        public bool UpdateBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch) {
            return base.Channel.UpdateBatch(batch);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch) {
            return base.Channel.UpdateBatchAsync(batch);
        }
        
        public bool UpdateGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender) {
            return base.Channel.UpdateGender(gender);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender) {
            return base.Channel.UpdateGenderAsync(gender);
        }
        
        public bool UpdateInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor) {
            return base.Channel.UpdateInstructor(instructor);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor) {
            return base.Channel.UpdateInstructorAsync(instructor);
        }
        
        public bool DeleteAssociate(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc) {
            return base.Channel.DeleteAssociate(assoc);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAssociateAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateDao assoc) {
            return base.Channel.DeleteAssociateAsync(assoc);
        }
        
        public bool DeleteAddress(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address) {
            return base.Channel.DeleteAddress(address);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AddressDao address) {
            return base.Channel.DeleteAddressAsync(address);
        }
        
        public bool DeleteAssociateAddress(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd) {
            return base.Channel.DeleteAssociateAddress(assocadd);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteAssociateAddressAsync(Workforce.Logic.Associates2.Domain.WFSReference.AssociateAddressDao assocadd) {
            return base.Channel.DeleteAssociateAddressAsync(assocadd);
        }
        
        public bool DeleteBatch(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch) {
            return base.Channel.DeleteBatch(batch);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteBatchAsync(Workforce.Logic.Associates2.Domain.WFSReference.BatchDao batch) {
            return base.Channel.DeleteBatchAsync(batch);
        }
        
        public bool DeleteGender(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender) {
            return base.Channel.DeleteGender(gender);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteGenderAsync(Workforce.Logic.Associates2.Domain.WFSReference.GenderDao gender) {
            return base.Channel.DeleteGenderAsync(gender);
        }
        
        public bool DeleteInstructor(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor) {
            return base.Channel.DeleteInstructor(instructor);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteInstructorAsync(Workforce.Logic.Associates2.Domain.WFSReference.InstructorDao instructor) {
            return base.Channel.DeleteInstructorAsync(instructor);
        }
    }
}
