using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class MobPushClient
    {
        AreaClient _areaClient = new AreaClient();

        DeviceClient _deviceClient = new DeviceClient();

        PushClient _pushClient = new PushClient();

        StatsClient _statsClient = new StatsClient();

         
        /// <summary>
        /// 推送接口 -- 发送推送
        /// </summary>
        /// <param name="pushWork"></param>
        /// <returns></returns>
        public string push(PushWork pushWork)
        {
            return _pushClient.sendPush(pushWork);
        }

        /// <summary>
        /// 推送接口 -- 查询推送 根据BatchId 
        /// 根据创建id查询推送消息详情
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public PushWork pushById(string batchId)
        {
            return _pushClient.getPushByBatchId(batchId);
        }

        /// <summary>
        /// 推送接口 -- 查询推送 根据workno 
        /// 根据自定义编号查询消息详情
        /// </summary>
        /// <param name="workno"></param>
        /// <returns></returns>
        public PushWork pushByWorkno(string workno)
        {
            return _pushClient.getPushByWorkno(workno);
        }

        /// <summary>
        /// 推送统计-- 查询推送统计 
        /// 根据创建id查询推送统计
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public PushStats statsById(string batchId)
        {
            return _statsClient.getStatsByBatchId(batchId);
        }

        /// <summary>
        /// 推送统计-- 查询推送统计  
        /// 根据自定义编号查询推送统计
        /// </summary>
        /// <param name="workno"></param>
        /// <returns></returns>
        public PushStats statsByWorkno(string workno)
        {
            return _statsClient.getStatsByWorkno(workno);
        }

        /// <summary>
        /// 查询标签 根据设备registrationId查询标签信息
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public string[] tagsByRegistrationId(string registrationId)
        {
            return _deviceClient.getDeviceTags(registrationId);
        }

        /// <summary>
        /// 设备绑定标签
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int tagsAdd(string[] tags, string registrationId)
        {
            return _deviceClient.addDeviceTags(tags, registrationId);
        }

        /// <summary>
        /// 删除指定设备标签
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int tagsRemove(string[] tags, string registrationId)
        {
            return _deviceClient.removeDeviceTags(tags, registrationId);
        }

        /// <summary>
        /// 清除指定标签
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int tagsClean(string registrationId)
        {
            return _deviceClient.cleanDeviceTags(registrationId);
        }

        /// <summary>
        /// 获取指定设备别名
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public string aliasByRegistrationId(string registrationId)
        {
            return _deviceClient.getDeviceAlias(registrationId);
        }

        /// <summary>
        /// 设备绑定别名（仅200表示成功）
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int setAlias(string alias, string registrationId)
        {
            return _deviceClient.setDeviceAlias(alias, registrationId);
        }

        /// <summary>
        /// 清除设备别名
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int cleanAlias(string registrationId)
        {
            return _deviceClient.cleanDeviceAlias(registrationId);
        }

        /// <summary>
        /// 获取地理位置列表 -- 中国下省份列表
        /// </summary>
        /// <returns></returns>
        public List<Area> area()
        {
            return _areaClient.getArea();
        }

        /// <summary>
        /// 获取地理位置列表 -- 子级列表
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Area> area(String parentId)
        {
            return _areaClient.getArea(parentId);
        }
    }
}
