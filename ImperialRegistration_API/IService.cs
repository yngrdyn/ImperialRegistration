using ImperialRegistration_API.DataContractTypes;
using Logic.ResponseTypes;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ImperialRegistration_API
{

    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        RegisterRebelResponse registerRebel(RebelRegisterRequest rebelRequest);

    }

}
