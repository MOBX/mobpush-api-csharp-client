using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class StatsClient
    {

        /// <summary>
        /// 获取统计数据(根据batchId查询)
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public PushStats getStatsByBatchId(string batchId)
        {
            if (string.IsNullOrEmpty(batchId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "batchId is null");
            }
            String path = MobPushConfig.statsUrl + "/stats/id/" + batchId;
            return this.pullStats(path);
        }

        /// <summary>
        /// 获取统计数据(根据workno查询)
        /// </summary>
        /// <param name="workno"></param>
        /// <returns></returns>
        public PushStats getStatsByWorkno(string workno)
        {
            if (string.IsNullOrEmpty(workno))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "workno is null");
            }
            String path = MobPushConfig.statsUrl + "/stats/workno/" + workno;
            return this.pullStats(path);
        }

        /// <summary>
        /// 获取推送任务统计信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private PushStats pullStats(String path)
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
                    PushStats stats = JsonExtension.FromJSON<PushStats>(result.res.ToJSON());
                    return stats;
                }
                return null;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }

    }
}
