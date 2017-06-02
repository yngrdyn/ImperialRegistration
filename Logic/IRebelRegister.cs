using Logic.ResponseTypes;
using System.ServiceModel;

namespace Logic
{
    public interface IRebelRegister
    {
        RegisterRebelResponse RegisterRebel(string username, string planet);
    }

}
