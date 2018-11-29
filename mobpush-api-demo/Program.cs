using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mobpush.api.client;

namespace mobpush_api_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 第一步设置基本配置信息 
            MobPushConfig.appkey = "moba6b6c6d6";
            MobPushConfig.appSecret = "";

            // 初始化MobPushClient 
            MobPushClient client = new MobPushClient();

            PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                .buildTarget((int)TargetEnum._1, null, null, null, null, null)  // 设置推送范围
                .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                ;

            string batchId = client.push(push);

            PushWork workinfo = client.pushById(batchId);

            Console.WriteLine("batchId : " + batchId);
            Console.WriteLine("workinfo : " + JsonExtension.ToJSON(workinfo));
            Console.ReadLine();
        }
    }
}