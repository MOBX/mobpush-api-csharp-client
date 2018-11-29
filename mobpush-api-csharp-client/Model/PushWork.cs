using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class PushWork
    {
        /// <summary>
        /// MobPush 生产唯一编号
        /// </summary>
        public string batchId { get; set; }

        /// <summary>
        /// 应用APPKEY
        /// </summary>
        public string appkey { get; set; }

        /// <summary>
        /// workno:调用方提供的唯一编号，需要在当前appkey下唯一不可重复
        /// </summary>
        public string workno { get; set; }

        /// <summary>
        /// plats：接受平台，1、android ； 2、ios ；如包含ios和android则为[1,2]
        /// </summary>
        public int[] plats { get; set; }

        /// <summary>
        /// iosProduction:plat = 2下，0测试环境，1生产环境，默认1
        /// </summary>
        public int? iosProduction { get; set; }

        /// <summary>
        /// target:推送范围:1广播；2别名；3标签；4regid；5地理位置 ； 6用户分群
        ///枚举： TargetEnum
        /// </summary>
        public int? target { get; set; }

        /// <summary>
        /// tags:设置推送标签集合["tag1","tag2"]，target=2则必选
        /// </summary>
        public string[] tags { get; set; }

        /// <summary>
        /// alias: 设置推送别名集合["alias1","alias2"]，target=3则必选
        /// </summary>
        public string[] alias { get; set; }

        /// <summary>
        /// registrationIds:设置推送Registration Id集合["id1","id2"]，target=4则必选
        /// </summary>
        public string[] registrationIds { get; set; }

        /// <summary>
        /// city: 推送地理位置(城市)，target=5则必选
        /// </summary>
        public string city { get; set; }

        /// <summary>
        ///  block: 用户分群ID，target=6则必选
        /// </summary>
        public string block { get; set; }

        /// <summary>
        /// content: 推送内容
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// unlineTime: 离线时间为0，或者在1~10天以内，单位天， 默认1天
        /// </summary>
        public int? unlineTime { get; set; }

        /// <summary>
        /// type: 推送类型：1通知；2自定义
        /// 枚举 PushTypeEnum
        /// </summary>
        public int? type { get; set; }

        /// <summary>
        /// extras:附加字段键值对的方式，扩展数据 json
        /// </summary>
        public string extras { get; set; }

        /// <summary>
        /// 推送任务状态：0删除；1创建中；2正在发送；3部分发送完成；4发送完成；5发送失败；6停止发送；
        /// 枚举 WorkDetailStatusEnum
        /// </summary>
        public int? status { get; set; }

        /// <summary>
        /// 是否重新发送,true是，默认false否
        /// </summary>
        public bool? repate { get; set; }

        /// <summary>
        /// android 通知标题
        /// </summary>
        public string androidTitle { get; set; }

        /// <summary>
        /// android 显示样式标识
        /// </summary>
        public int? androidstyle { get; set; }

        /// <summary>
        /// androidContent:样式具体内容： 0、默认通知无； 1、长内容则为内容数据； 2、大图则为图片地址； 3、横幅则为多行内容
        /// </summary>
        public string[] androidContent { get; set; }

        /// <summary>
        /// warn:  提醒类型： 提示音； 
        /// </summary>
        public bool? androidVoice { get; set; }

        /// <summary>
        /// androidShake:震动
        /// </summary>
        public bool? androidShake { get; set; }

        /// <summary>
        /// androidLight:指示灯
        /// </summary>
        public bool? androidLight { get; set; }

        /// <summary>
        /// IOS标题- 不填写则为应用名称
        /// </summary>
        public string iosTitle { get; set; }

        /// <summary>
        ///IOS  副标题
        /// </summary>
        public string iosSubtitle { get; set; }

        /// <summary>
        /// APNs通知，通过这个字段指定声音。默认为default，即系统默认声音。 如果设置为空值，则为静音。 如果设置为特殊的名称，则需要你的App里配置了该声音才可以正常。
        /// </summary>
        public string iosSound { get; set; }

        /// <summary>
        /// 可直接指定 APNs 推送通知的 badge，直接展示在桌面应用图标的右上角，含义是应用未读的消息数。也支持如 +12，-3 等运算操作， 会针对每一个用户当前的 badge 做单独的运算，例：接受者 A，B 的角标分别为 1 和 2，那么推送 +2 后 A的角标变为 3，B 的角标变为 4。默认值为 1。
        /// </summary>
        public int? iosBadge { get; set; }

        /// <summary>
        /// 只有IOS8及以上系统才支持此参数推送
        /// </summary>
        public string iosCategory { get; set; }

        /// <summary>
        /// 如果只携带content-available: 1,不携带任何badge，sound 和消息内容等参数， 则可以不打扰用户的情况下进行内容更新等操作即为“Silent Remote Notifications”。
        /// </summary>
        public int? iosSlientPush { get; set; }

        public int? iosContentAvailable { get; set; }

        /// <summary>
        /// 需要在附加字段中配置相应参数
        /// </summary>
        public int? iosMutableContent { get; set; }

        /// <summary>
        /// 需要在附加字段中配置相应参数
        /// </summary>
        public string scheme { get; set; }

        /// <summary>
        /// 需要在附加字段中配置相应参数
        /// </summary>
        public string data { get; set; }

        public PushWork()
        {

        }

        public PushWork(int[] plats, String content, int type)
        {
            this.plats = plats;
            this.content = content;
            this.type = type;
        }

        public PushWork(String workno, int[] plats, String content, int type)
        {
            this.workno = workno;
            this.plats = plats;
            this.content = content;
            this.type = type;
        }

        public PushWork(string appkey, string workno, int[] plats, string content, int type)
        {
            this.appkey = appkey;
            this.workno = workno;
            this.plats = plats;
            this.content = content;
            this.type = type;
        }

        /// <summary>
        /// 设置扩展信息
        /// </summary>
        /// <param name="unlineTime"></param>
        /// <param name="extras"></param>
        /// <param name="iosProduction"></param>
        /// <returns></returns>
        public PushWork buildExtra(int? unlineTime, string extras, int? iosProduction)
        {
            if (unlineTime != null)
                this.unlineTime = unlineTime;
            if (!string.IsNullOrEmpty(extras))
                this.extras = extras;
            if (iosProduction != null)
                this.iosProduction = iosProduction;
            return this;
        }

        /// <summary>
        /// 设置moblink
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public PushWork buildScheme(string scheme, string data)
        {
            if (!string.IsNullOrEmpty(scheme))
                this.scheme = scheme;
            if (!string.IsNullOrEmpty(data))
                this.data = data;
            return this;
        }

        /// <summary>
        /// 设置推送范围
        /// </summary>
        /// <param name="target"></param>
        /// <param name="tags"></param>
        /// <param name="alias"></param>
        /// <param name="registrationIds"></param>
        /// <param name="city"></param>
        /// <param name="block"></param>
        /// <returns></returns>
        public PushWork buildTarget(int? target, string[] tags, string[] alias, string[] registrationIds, string city, string block)
        {
            if (target == null || target == (int?)TargetEnum._1)
            {
                this.target = target;
                return this;
            }
            if (target == (int?)TargetEnum._2 && alias != null)
            {
                this.alias = alias;
            }
            else if (target == (int?)TargetEnum._3 && tags != null)
            {
                this.tags = tags;
            } if (target == (int?)TargetEnum._4 && registrationIds != null)
            {
                this.registrationIds = registrationIds;
            } if (target == (int?)TargetEnum._5 && !string.IsNullOrEmpty(city))
            {
                this.city = city;
            } if (target == (int?)TargetEnum._6 && !string.IsNullOrEmpty(block))
            {
                this.block = block;
            }
            this.target = target;
            return this;
        }

        /// <summary>
        /// 设置Android信息
        /// </summary>
        /// <param name="androidTitle"></param>
        /// <param name="androidstyle"></param>
        /// <param name="androidContent"></param>
        /// <param name="androidVoice"></param>
        /// <param name="androidShake"></param>
        /// <param name="androidLight"></param>
        /// <returns></returns>
        public PushWork buildAndroid(string androidTitle, int? androidstyle, string[] androidContent,
                bool? androidVoice, bool? androidShake, bool? androidLight)
        {
            if (!string.IsNullOrEmpty(androidTitle))
                this.androidTitle = androidTitle;
            if (androidstyle != null)
                this.androidstyle = androidstyle;
            if (androidContent != null)
                this.androidContent = androidContent;
            if (androidVoice != null)
                this.androidVoice = androidVoice;
            if (androidShake != null)
                this.androidShake = androidShake;
            if (androidLight != null)
                this.androidLight = androidLight;
            return this;
        }

        /// <summary>
        ///  设置IOS信息
        /// </summary>
        /// <param name="iosTitle"></param>
        /// <param name="iosSubtitle"></param>
        /// <param name="iosSound"></param>
        /// <param name="iosBadge"></param>
        /// <param name="iosCategory"></param>
        /// <param name="iosSlientPush"></param>
        /// <param name="iosContentAvailable"></param>
        /// <param name="iosMutableContent"></param>
        /// <returns></returns>
        public PushWork bulidIos(string iosTitle, string iosSubtitle, string iosSound, int? iosBadge, string iosCategory,
                int? iosSlientPush, int? iosContentAvailable, int? iosMutableContent)
        {
            if (!string.IsNullOrEmpty(iosTitle))
                this.iosTitle = iosTitle;
            if (!string.IsNullOrEmpty(iosSubtitle))
                this.iosSubtitle = iosSubtitle;
            if (!string.IsNullOrEmpty(iosSound))
                this.iosSound = iosSound;
            if (iosBadge != null)
                this.iosBadge = iosBadge;
            if (!string.IsNullOrEmpty(iosCategory))
                this.iosCategory = iosCategory;
            if (iosSlientPush != null)
                this.iosSlientPush = iosSlientPush;
            if (iosContentAvailable != null)
                this.iosContentAvailable = iosContentAvailable;
            if (iosMutableContent != null)
                this.iosMutableContent = iosMutableContent;
            return this;
        }

    }
}
