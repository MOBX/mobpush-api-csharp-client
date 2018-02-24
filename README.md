# [MobPush API for C#](http://wiki.mob.com/mobpush-rest-api-接口文档/)

![image](https://github.com/MOBX/MOB-SMS-WEBAPI/blob/master/doc/images/logo.png)

**[MobPush API for C#](http://wiki.mob.com/mobpush-rest-api-接口文档/)** 
为了帮助开发者更方便接入MobPush免费推送SDK，提供完整的API接口的C#实现，包含设备操作相关接口、推送操作相关接口以及公共接口。

了解更多 [MobPush 免费推送SDK.](http://mobpush.mob.com)


## 优势

**免费使用**、**自定义UI**、**稳定服务**、**流程体验**、**数据同步**、**专业技术团队服务**

## 接口
* 推送接口
	* 发送推送
	* 查询推送（根据batchId）
	* 查询推送（根据workno）
* 推送统计接口
	* 查询推送统计（根据batchId）
	* 查询推送统计（根据workno）
* 别名操作接口
	* 查询别名
	* 设置别名
* 标签操作接口
	* 查询标签
	* 设置标签
* 公共接口
	* 地理位置信息接口	

## 代码说明
* mobpush-api-csharp-client 接口实现代码
* mobpush-api-demo 实现创建推送的DEMO
* [MobPushConfig.cs](https://github.com/MOBX/mobpush-api-csharp-client/blob/master/mobpush-api-csharp-client/MobPushConfig.cs) 基础配置
* [MobPushClient.cs](https://github.com/MOBX/mobpush-api-csharp-client/blob/master/mobpush-api-csharp-client/MobPushClient.cs) API接口调用入口

 
## 使用注意事项
* 可以直接使用项目中bin目录下mobpush-api-csharp-client.dll文件,然后使用引用
```xml
   using mobpush.api.client;
```
* 可以导入项目到本地build使用
* **本API接口需要依赖Newtonsoft.Json.dll**
* 需要首先初始化
 ```xml
   MobPushConfig.appkey = "你的appkey";
   MobPushConfig.appSecret = "你的appkey对应秘钥 ";
 ```
* 错误码请参考 
  [MobPush Api 错误码](http://wiki.mob.com/mobpush-rest-api-接口文档/#map-6)

## 使用DEMO 

发送推送示例片段代码

```xml    
   // 第一步设置基本配置信息 
   MobPushConfig.appkey = "你的appkey";
   MobPushConfig.appSecret = "你的appkey对应秘钥 ";
        
   // 第二步初始化client
   MobPushClient client = new MobPushClient();

   // 调用具体方法，如下是发送推送例
   PushWork push = new PushWork(new int[] { 1, 2 }, "c# client 测试发送", (int)PushTypeEnum.notify) //初始化基础信息
                .buildTarget((int)TargetEnum._1, null, null, null, null, null)  // 设置推送范围
                .buildAndroid("Android Title", (int)AndroidNotifyStyleEnum.normal, null, true, true, true) //定制android样式
                .bulidIos("ios Title", "ios Subtitle", null, 1, null, null, null, null) //定制ios设置
                .buildExtra(1, "{\"key1\":\"value\"}", 1) // 设置扩展信息
                ; 
   // 发送推送消息
   string batchId = client.push(push);
    
   // 如下是根据batchId获取推送详情
   PushWork workinfo = client.pushById(batchId);

   Console.WriteLine("batchId : " + batchId);
   Console.WriteLine("workinfo : " + JsonExtension.ToJSON(workinfo));
   Console.ReadLine();

 
```