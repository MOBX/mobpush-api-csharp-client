using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class DeviceClient
    {         

        /// <summary>
        /// 清空设备标签 -- （仅200表示成功）
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int cleanDeviceTags(string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            } 
            String path = MobPushConfig.deviceUrl + "/tags";
            Tags t = new Tags(registrationId, 3);
            try
            {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(t));
                return mr.status;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }

        /// <summary>
        /// 删除设备指定标签 -- （仅200表示成功）
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int removeDeviceTags(string[] tags, string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            }
            if (tags == null || tags.Count() < 1)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "tags is null");
            }
            String path = MobPushConfig.deviceUrl + "/tags";
            Tags t = new Tags(registrationId, tags, 2);
            try
            {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(t));
                return mr.status;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }

        /// <summary>
        /// 设备绑定标签 -- （仅200表示成功）
        /// </summary>
        /// <param name="tags"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int addDeviceTags(string[] tags, string registrationId) {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            }
            if (tags == null || tags.Count() < 1)
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "tags is null");
            }
            String path = MobPushConfig.deviceUrl + "/tags";
            Tags t = new Tags(registrationId, tags,1);
            try
            {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(t));
                return mr.status;
            }
            catch (ApiException api)
            {
                throw api;
            }  
        }

        /// <summary>
        /// 获取设备标签
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public string[] getDeviceTags(string registrationId) {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            }
            string path = MobPushConfig.deviceUrl + "/tags/" + registrationId;
            try
            {
                MobResult mr = Commons.WebClientGet(path);
                if (mr == null || mr.res == null)
                {
                    return null;
                }
                string res = mr.res.ToString();
                Tags t = JsonExtension.FromJSON<Tags>(res);
                if (t == null) {
                    return null;
                }
                return t.tags;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }

        /// <summary>
        /// 清空设备别名 -- （仅200表示成功）
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int cleanDeviceAlias(string registrationId) {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            } 
            String path = MobPushConfig.deviceUrl + "/alias";
            Alias a = new Alias(registrationId, "");
            try
            {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(a));
                return mr.status;
            }
            catch (ApiException api)
            {
                throw api;
            } 
        }

        /// <summary>
        /// 绑定设备别名，如果存在则覆盖原有别名 -- （仅200表示成功）
        /// </summary>
        /// <param name="alias"></param>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public int setDeviceAlias(string alias, string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            }
            if (string.IsNullOrEmpty(alias)) {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "alias is null");
            }
            String path = MobPushConfig.deviceUrl + "/alias";
            Alias a = new Alias(registrationId, alias);
            try {
                MobResult mr = Commons.WebClientPost(path, JsonExtension.ToJSON(a));
                return mr.status;
            }
            catch (ApiException api)
            {
                throw api;
            } 
        }

        /// <summary>
        /// 获取设备别名
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        public string getDeviceAlias(string registrationId)
        {
            if (string.IsNullOrEmpty(registrationId))
            {
                throw new ApiException(Commons.HTTP_STATUS_400, -1, "registrationId is null");
            }
            string path = MobPushConfig.deviceUrl + "/alias/" + registrationId;
            try
            {
                MobResult mr = Commons.WebClientGet(path);
                if (mr == null || mr.res == null)
                {
                    return null;
                }
                string res = mr.res.ToString();
                Alias alias = JsonExtension.FromJSON<Alias>(res);
                return alias.alias;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }
    }
}
