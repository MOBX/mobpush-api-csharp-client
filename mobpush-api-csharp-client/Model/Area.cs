using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mobpush.api.client
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Area
    { 

        /**
	    * id: 地理位置ID
	    */
        public string id { get; set; }

        /**
         * city: 城市信息
         */
        public string city { get; set; }

        /**
	     * country: 国家
        */
        public string country { get; set; }

        /**
         * province: 省份
         */
        public string province { get; set; }

        /**
         * parentId: 上级ID 
         */
        public string parentId { get; set; }

        public Area() { }

    }
}
