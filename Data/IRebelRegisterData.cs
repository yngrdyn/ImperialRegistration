using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Data
{
    public interface IRebelRegisterData
    {
        bool registerRebel(string username, string planet);
    }

}
