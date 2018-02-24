using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mobpush.api.client
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Alias
    {  
        public string registrationId { get; set; }

        public string alias { get; set; }

        public Alias(string registrationId, string alias) {
            this.alias = alias;
            this.registrationId = registrationId;
        }
         
    }
}
