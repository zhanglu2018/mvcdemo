using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcdemo1
{
    public sealed class Configuration
    {
        static Configuration()
        {
            //读取web.config中连接字符串的值
            dbConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
        }
        private static string dbConnectionString;
        /// <summary>
        /// 连接字符串
        /// </summary>
        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }

   

    }
}