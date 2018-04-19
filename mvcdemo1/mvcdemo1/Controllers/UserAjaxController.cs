using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo1.Models;

namespace mvcdemo1.Controllers
{
    public class UserAjaxController : Controller
    {
        // GET: UserAjax

        /// <summary>
        /// 登录
        /// 1：登录成功
        /// 0：登录失败
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult Login(int id, string password)
        {
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
            if (user.GetUser(id, password).Rows.Count == 0)
            {
                return Content("0");
            }
            return Content("1");
        }
        public ActionResult Save(int id,string name, string sex, string age, string department)
        {

            var patientinfo = new PatientInfo();
            patientinfo.id = id;
            patientinfo.name = name;
            patientinfo.sex = sex;
            patientinfo.age = age;
            patientinfo.department = department;
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;

            if (user.UpdatePatient(patientinfo))

            {
                return Content("1");

            }
            return Content("0");
        }

        public ActionResult Add(int id, string name, string sex, string age)
        {

            var patientinfo = new PatientInfo();
            patientinfo.id = id;
            patientinfo.name = name;
            patientinfo.sex = sex;
            patientinfo.age = age;
            patientinfo.department = "11";
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
      
            if (user.AddPatient(patientinfo))

            {
                return Content("1");

            }
            return Content("0");
        }
        public ActionResult Search(string name)
        {
            var patientinfo = new PatientInfo();
            var d = new List<PatientInfo>();

            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
            if (user.GetPatient(name).Rows.Count == 0)
            {
                return Content("0");
            }
            return Content("1");
        }

    }
}