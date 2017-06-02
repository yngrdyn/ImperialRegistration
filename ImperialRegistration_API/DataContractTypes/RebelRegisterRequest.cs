using System;
using System.Collections.Generic;
using System.Web;
using System.Runtime.Serialization;

namespace ImperialRegistration_API.DataContractTypes
{

    [DataContract]
    public class RebelRegisterRequest
    {
        public RebelRegisterRequest()
        {

        }

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string planet { get; set; }

    }

    
}