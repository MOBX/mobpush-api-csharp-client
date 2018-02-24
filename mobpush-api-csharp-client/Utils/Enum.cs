using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public enum AndroidNotifyStyleEnum
    {
        /// <summary>
        /// 普通通知
        /// </summary>
        normal = 0,

        /// <summary>
        /// BigTextStyle通知，点击后显示大段文字内容
        /// </summary>
        bigtext = 1,

        /// <summary>
        /// BigPictureStyle，大图模式
        /// </summary>
        bigpicture = 2,


        /// <summary>
        /// 横幅通知
        /// </summary>
        hangup = 3,
    }

    public  enum TargetEnum
    {
        /// <summary>
        /// 广播
        /// </summary>
        _1 = 1,
        /// <summary>
        /// 别名
        /// </summary>
        _2 = 2,
        /// <summary>
        /// 标签
        /// </summary>
        _3 = 3,
        /// <summary>
        /// 用户RegId
        /// </summary>
        _4 = 4,

        /// <summary>
        /// 地理位置
        /// </summary>
        _5 = 5,

        /// <summary>
        /// 用户分群
        /// </summary>
        _6 = 6,
    }

    public enum PushTypeEnum
    {
        /// <summary>
        /// 通知
        /// </summary>
        notify = 1,

        /// <summary>
        /// 自定义消息
        /// </summary>
        custom = 2,

    } 

    public enum AndroidWarnEnum
    {
        /// <summary>
        /// 提示音
        /// </summary>
        voice = 1,

        /// <summary>
        /// 震动
        /// </summary>
        shake = 2,

        /// <summary>
        /// 指示灯
        /// </summary>
        light = 3,
    }

}
