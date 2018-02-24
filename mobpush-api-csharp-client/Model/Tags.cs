using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mobpush.api.client
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Tags
    {
        public string registrationId { get; set; }

        public string[] tags { get; set; }

        public int opType { get; set; }

        public Tags() { }

        public Tags(string registrationId, string[] tags)
        {
            this.tags = tags;
            this.registrationId = registrationId;
        }

        public Tags(string registrationId, string[] tags, int opType)
        {
            this.tags = tags;
            this.registrationId = registrationId;
            this.opType = opType;
        }

        public Tags(string registrationId, int opType)
        { 
            this.registrationId = registrationId;
            this.opType = opType;
        }

    }
}
