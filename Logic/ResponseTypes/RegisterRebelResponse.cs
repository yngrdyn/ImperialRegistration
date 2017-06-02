using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ResponseTypes
{
    [DataContract]
    public class RegisterRebelResponse
    {
        public RegisterRebelResponse()
        {

        }

        [DataMember]
        public string Status { get; set; }

        [DataMember]
        public string Message { get; set; }

    }
}
