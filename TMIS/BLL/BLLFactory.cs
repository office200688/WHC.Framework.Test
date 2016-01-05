using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace TMIS.BLL
{
    public class BLLFactory<T> where T : class
    {
        private static Hashtable objCache = new Hashtable();
        private static object syncRoot = new Object();

        public static T Instance
        {
            get
            {
                string CacheKey = typeof(T).FullName;
                T bll = (T)objCache[CacheKey];　 //从缓存读取  
                if (bll == null)
                {
                    lock (syncRoot)
                    {
                        if (bll == null)
                        {
                            bll = Reflect<T>.Create(typeof(T).FullName, "TMIS"); //反射创建，并缓存
                        }
                    }
                }
                return bll;
            }
        }
    }    
}
