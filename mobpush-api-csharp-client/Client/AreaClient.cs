using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mobpush.api.client
{
    public class AreaClient
    {

        /// <summary>
        /// 获取地理位置列表 -- 中国下省份列表
        /// </summary>
        /// <returns></returns>
        public List<Area> getArea()
        {
            return getArea(null);
        }

        /// <summary>
        /// 获取地理位置列表 -- 子级列表 
        /// 如果查询最上级则传入null即可
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<Area> getArea(string parentId)
        {
            if (string.IsNullOrEmpty(parentId))
            {
                parentId = "0";
            }
            string path = MobPushConfig.baseUrl + "/area/" + parentId;
            try
            {
                MobResult mr = Commons.WebClientGet(path);
                if (mr == null || mr.res == null)
                {
                    return new List<Area>();
                }
                string res = mr.res.ToString();
                List<Area> list = JsonExtension.DeserializeJsonToList<Area>(res);
                return list;
            }
            catch (ApiException api)
            {
                throw api;
            }
        }
    }
}
