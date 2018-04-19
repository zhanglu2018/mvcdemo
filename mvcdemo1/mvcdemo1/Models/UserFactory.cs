using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;//Assembly类在此命名空间中

namespace mvcdemo1.Models
{
    public sealed class UserFactory
    {
        public static IUser Create()
        {
            string path = "mvcdemo1.Models";
            string className = path + ".SQLHandle";
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }
    }
}