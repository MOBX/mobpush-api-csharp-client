using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class PushStats
    {
        /// <summary>
        /// MobPush 唯一标识
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 第三方ID
        /// </summary>
        public string workno { get; set; }

        /// <summary>
        /// 应用APPKEY
        /// </summary>
        public string appkey { get; set; }

        /// <summary>
        /// 取消推送数 – android
        /// </summary>
        public long androidCancelNum { get; set; }

        /// <summary>
        /// 取消推送数 – ios
        /// </summary>
        public long iosCancelNum { get; set; }

        /// <summary>
        /// 已完成推送数--android
        /// </summary>
        public long androidSuccessNum { get; set; }

        /// <summary>
        /// 已完成推送数--ios
        /// </summary>
        public long iosSuccessNum { get; set; }

        /// <summary>
        /// 推送目标设备数量 – android
        /// </summary>
        public long androidDeviceNum { get; set; }

        /// <summary>
        /// Android 回执数
        /// </summary>
        public long androidReportNum { get; set; }

        /// <summary>
        /// IOS 回执数
        /// </summary>
        public long iosReportNum { get; set; }

        /// <summary>
        /// 推送目标设备数量 – ios
        /// </summary>
        public long iosDeviceNum { get; set; }

        /// <summary>
        /// 点击数量，通知消息点击数量--android
        /// </summary>
        public long androidClickNum { get; set; }

        /// <summary>
        /// 点击数量，通知消息点击数量--ios
        /// </summary>
        public long iosClickNum { get; set; }
    }
}
