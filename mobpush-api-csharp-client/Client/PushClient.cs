using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class PushClient
    { 
         
        /// <summary>
        /// 推送详情（根据batchId查询）
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public PushWork getPushByBatchId(String batchId)
        {
            if (string.IsNullOrEmpty(batchId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "batchId is null");
            }
            String path = MobPushConfig.pushUrl + "/push/id/" + batchId;
            return this.pullPush(path);
        }

        /// <summary>
        /// 推送详情（根据workno查询）
        /// </summary>
        /// <param name="workno"></param>
        /// <returns></returns>
        public PushWork getPushByWorkno(string workno)
        {
            if (string.IsNullOrEmpty(workno))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "workno is null");
            }
            String path = MobPushConfig.pushUrl + "/push/workno/" + workno;
            return this.pullPush(path);
        }


        /// <summary>
        /// 获取推送详情基础
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private PushWork pullPush(string path)
        {
            try
            {
                MobResult result = Commons.WebClientGet(path);
                if (result != null)
                {
                    if (result.res == null)
                    {
                        return null;
                    }
                    PushWork work = JsonExtension.FromJSON<PushWork>(result.res.ToJSON());
                    return work;
                }
                return null;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }

        /// <summary>
        /// 创建通知消息 -- 所有平台、广播-- 返回MobPush唯一标识
        /// </summary>
        /// <param name="workno"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public string createPushDefaultNotify(string workno, string content)
        {
            PushWork work = new PushWork(MobPushConfig.appkey, workno, new int[] { 1, 2 }, content, (int)PushTypeEnum.notify).buildTarget((int)TargetEnum._1, null, null, null, null, null);
            return this.sendPush(work);
        }

        /// <summary>
        /// 自定义消息 -- 所有平台、广播 -- 返回MobPush唯一标识
        /// </summary>
        /// <param name="workno"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public string createPushByDefaultCustom(string workno, string content)
        {
            PushWork work = new PushWork(MobPushConfig.appkey, workno, new int[] { 1, 2 }, content, (int)PushTypeEnum.custom).buildTarget((int)TargetEnum._1, null, null, null, null, null);
            return this.sendPush(work);
        }

        /// <summary>
        /// 发送推送 -- 返回MobPush唯一标识
        /// </summary>
        /// <param name="pushWork"></param>
        /// <returns></returns>
        public string sendPush(PushWork pushWork)
        {
            if (pushWork == null)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "pushWork is null");
            }
            pushWork.appkey = MobPushConfig.appkey;
            if (string.IsNullOrEmpty(pushWork.content))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "content is null");
            }
            if (pushWork.target == null)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "target is null");
            }
            if (pushWork.type == null)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "type is null");
            }
            if (pushWork.plats == null)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "plats is null");
            }
            if (pushWork.unlineTime == null)
            {//默认保留时间
                pushWork.unlineTime = 1;
            }
            if (pushWork.plats.Contains(1))
            { // Android默认参数
                if (pushWork.androidstyle == null)
                {
                    pushWork.androidstyle = (int?)AndroidNotifyStyleEnum.normal;
                }
            }
            if (pushWork.plats.Contains(2))
            { // IOS 的默认参数
                if (pushWork.iosBadge == null)
                {
                    pushWork.iosBadge = 1;
                }
                if (string.IsNullOrEmpty(pushWork.iosSound))
                {
                    pushWork.iosSound = "default";
                }
                if (pushWork.iosProduction == null)
                {
                    pushWork.iosProduction = 1;
                }
            }
            string path = MobPushConfig.pushUrl + "/v2/push";
            try
            {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(pushWork));

                pushWork = JsonExtension.FromJSON<PushWork>(mr.res.ToJSON());

                return pushWork.batchId;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }
    }


}
