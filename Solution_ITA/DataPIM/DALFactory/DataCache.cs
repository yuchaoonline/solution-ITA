using System;
using System.Web;

namespace Mis.DALFactory
{
    /// <summary>
    /// ������صĲ����
    /// </summary>
    public class DataCache
    {
        /// <summary>
        /// ��ȡ��ǰӦ�ó���ָ��CacheKey�Cache�ֵ
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];

        }

        /// <summary>
        /// ���õ�ǰӦ�ó���ָ��CacheKey�Cache�ֵ
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }
    }
}
		