

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace  Workforce.Data.Associates2.Soap
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFeliceService" in both code and config file together.
  [ServiceContract]
  public interface IFeliceService
  {
    /// <summary>
    /// GETS
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    List<AssociateDao> GetAssociates();

    [OperationContract]
    List<AddressDao> GetAddress();

    [OperationContract]
    List<AssociateAddressDao> GetAssociateAddress();

    [OperationContract]
    List<BatchDao> GetBatches();

    [OperationContract]
    List<InstructorDao> GetInstructor();

    [OperationContract]
    List<GenderDao> GetGender();


    /// <summary>
    /// INSERTS
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    bool InsertAssociate(AssociateDao newassociate);

    [OperationContract]
    bool InsertAddress(AddressDao newaddress);

    [OperationContract]
    bool InsertAssociateAddress(AssociateAddressDao newassocaddress);

    [OperationContract]
    bool InsertBatch(BatchDao newbatch);

    [OperationContract]
    bool InsertGender(GenderDao newgender);

    [OperationContract]
    bool InsertInstructor(InstructorDao newinstructor);



    /// <summary>
    /// UPDATES
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    bool UpdateAssociate(AssociateDao assoc);

    [OperationContract]
    bool UpdateAddress(AddressDao address);

    [OperationContract]
    bool UpdateAssociateAddress(AssociateAddressDao assocadd);

    [OperationContract]
    bool UpdateBatch(BatchDao batch);

    [OperationContract]
    bool UpdateGender(GenderDao gender);

    [OperationContract]
    bool UpdateInstructor(InstructorDao instructor);


    /// <summary>
    /// DELETES
    /// </summary>
    /// <returns></returns>
    [OperationContract]
    bool DeleteAssociate(AssociateDao assoc);

    [OperationContract]
    bool DeleteAddress(AddressDao address);

    [OperationContract]
    bool DeleteAssociateAddress(AssociateAddressDao assocadd);

    [OperationContract]
    bool DeleteBatch(BatchDao batch);

    [OperationContract]
    bool DeleteGender(GenderDao gender);

    [OperationContract]
    bool DeleteInstructor(InstructorDao instructor);
  }

}