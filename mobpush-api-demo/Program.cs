using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mobpush.api.client;

namespace mobpush_api_demo
{
    class Program
    {
        public static void testPush1(){
            try
            {
                Console.Write("【条件】不传appkey或appSecret");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
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
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e) {
                Console.WriteLine("【结果】："+e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush2()
        {
            try
            {
                Console.Write("【条件】错误的appkey或appSecret");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "aaa";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
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
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush3()
        {
            try
            {
                Console.Write("【条件】不传plat或者错误的plat");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                PushWork push = new PushWork(new int[] { }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._1, null, null, null, null, null)  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush4()
        {
            try
            {
                Console.Write("【条件】target=1 广播");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++) {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] {1,2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._1, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "金华", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush5()
        {
            try
            {
                Console.Write("【条件】target=2 别名推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._2, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "金华", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush6()
        {
            try
            {
                Console.Write("【条件】target=3 标签推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._3, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "金华", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush7()
        {
            try
            {
                Console.Write("【条件】target=4 regid推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._4, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "金华", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testPush8()
        {
            try
            {
                Console.Write("【条件】target=5 地理位置金华推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._5, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "金华", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush9()
        {
            try
            {
                Console.Write("【条件】target=5 地理位置杭州推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._5, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush10()
        {
            try
            {
                Console.Write("【条件】target=6 用户分群推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._6, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush11()
        {
            try
            {
                Console.Write("【条件】moblink推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "c# client发送测试", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._4, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush12()
        {
            try
            {
                Console.Write("【条件】推送内容为空");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._4, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush13()
        {
            try
            {
                Console.Write("【条件】自定义消息推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "自定义，哈哈", (int)PushTypeEnum.custom) //初始化基础信息
                    .buildTarget((int)TargetEnum._4, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush14()
        {
            try
            {
                Console.Write("【条件】超过1000个标签推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "自定义，哈哈", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._3, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush15()
        {
            try
            {
                Console.Write("【条件】超过1000个别名推送");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string[] tags = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    tags[i] = "tag_" + i;
                }
                string[] alias = new string[1002];
                for (int i = 1; i < 1002; i++)
                {
                    alias[i] = "alias_" + i;
                }
                PushWork push = new PushWork(new int[] { 1, 2 }, "自定义，哈哈", (int)PushTypeEnum.notify) //初始化基础信息
                    .buildTarget((int)TargetEnum._2, tags, alias, new string[] { "5bf22f1266ffeffe19f93998" }, "杭州", "1")  // 设置推送范围
                    .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                    .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                    .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                    .buildScheme("mlink://com.mob.mobpush.link", "{\"key\":\"value\"}")
                    ;
                string batchId = client.push(push);
                Console.WriteLine("【结果】：" + batchId);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testPush16()
        {
            try
            {
                Console.Write("【条件】传入正确batchId查询");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string batchId = "5bff9cc666ffeffe1a05b162";
                //string batchId = "";
                PushWork work = client.pushById(batchId);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(work));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testPush17()
        {
            try
            {
                Console.Write("【条件】传入正确workno查询");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string workno = "231445347650314240";
                //string workno = "";
                PushWork work = client.pushByWorkno(workno);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(work));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testStats1()
        {
            try
            {
                Console.Write("【条件】传入正确batchId统计");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string batchId = "5bff9cc666ffeffe1a05b162";
                //string batchId = "";
                PushStats stats = client.statsById(batchId);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testStats2()
        {
            try
            {
                Console.Write("【条件】传入正确batchId统计");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string workno = "231445347650314240";
                //string workno = "";
                PushStats stats = client.statsByWorkno(workno);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testDevice1()
        {
            try
            {
                Console.Write("【条件】传入rid查询别名");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                string stats = client.aliasByRegistrationId(rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testDevice2()
        {
            try
            {
                Console.Write("【条件】传入rid设置,修改别名");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                int stats = client.setAlias("alias_1",rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testDevice3()
        {
            try
            {
                Console.Write("【条件】传入rid清除别名");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                int stats = client.cleanAlias(rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }


        public static void testDevice4()
        {
            try
            {
                Console.Write("【条件】传入rid查询标签");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                string[] stats = client.tagsByRegistrationId(rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        public static void testDevice5()
        {
            try
            {
                Console.Write("【条件】传入rid设置,修改标签");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                int stats = client.tagsAdd(new string[] { "tag_1","tag_2"},rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testDevice6()
        {
            try
            {
                Console.Write("【条件】传入rid清除标签");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                string rid = "5bf22f1266ffeffe19f93998";
                int stats = client.tagsClean(rid);
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(stats));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testArea1()
        {
            try
            {
                Console.Write("【条件】parent = 0");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                List<Area> areas = client.area("0");
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(areas));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }

        public static void testArea2()
        {
            try
            {
                Console.Write("【条件】parent = 1");
                // 第一步设置基本配置信息 
                MobPushConfig.appkey = "28cab3f162ef8";
                MobPushConfig.appSecret = "9148284e3337396201415fe78be0f05a";
                // 初始化MobPushClient 
                MobPushClient client = new MobPushClient();
                List<Area> areas = client.area("1");
                Console.WriteLine("【结果】：" + JsonExtension.ToJSON(areas));
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("【结果】：" + e.Message);
                Console.ReadLine();
            }
        }
        static void Main(string[] args)
        {
            //testpush1();
            //testpush2();
            //testpush3();
            //testpush4();
            //testpush5();
            //testpush6();
            //testpush7();
            //testpush8();
            //testpush9();
            //testpush10();
            //testpush11();
            //testpush12();
            //testpush13();
            //testpush14();
            //testpush15();


            //testPush16();
            //testPush17();

            //testStats1();
            //testStats2();

            //testDevice1();
            //testDevice2();
            //testDevice3();
            //testDevice4();
            //testDevice5();
            //testDevice6();

            testArea1();
            testArea2();
        }
    }
}
