using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class MobPushConfig
    {
        /**
	    * appkey: 需要先设置此数据，怎样获取appkey，请查看http://bbs.mob.com/forum.php?mod=viewthread&tid=8212&extra=page%3D1
	    */
        public static string appkey = "";

        /**
         * appSecret: appkey对应密钥,需要先设置此数据
         */
        public static string appSecret = "";

        /** 
         * baseUrl: webapi http 接口基础url
         */
        public static string baseUrl = "http://api.push.mob.com";

        /**
         * deviceUrl: 设备操作类接口基础URL
         */
        public static string deviceUrl = "http://api.push.mob.com"; 

        /**
         * pushUrl: 推送操作接口基础URL
         */
        public static string pushUrl = "http://api.push.mob.com";

        /**
         * statsUrl: 推送任务统计接口基础URL
         */
        public static string statsUrl = "http://api.push.mob.com";
    }
}
