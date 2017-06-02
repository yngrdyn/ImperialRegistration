using ImperialRegistration_API.DataContractTypes;
using Logic;
using Logic.ResponseTypes;
using Data;

namespace ImperialRegistration_API
{

    public class Service : IService
    {
        private IRebelRegister adapter;

        public Service()
        {

        }

        private IRebelRegister Adapter
        {
            get
            {
                IRebelRegisterData rebelRegisterData = new RebelRegisterData();
                return adapter ?? (adapter = new RebelRegister(rebelRegisterData));
            }
        }


        public RegisterRebelResponse registerRebel(RebelRegisterRequest rebelRequest)
        {
            return Adapter.RegisterRebel(rebelRequest.username, rebelRequest.planet);
        } 
    }
}
