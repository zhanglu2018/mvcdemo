using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcdemo1.Models;
using System.Dynamic;

namespace mvcdemo1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()

        {
            return View();
        }

        public ActionResult Main(int id , string password)

        {
       
            var d = new List<PatientInfo>();
            string doctorname;
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;

            doctorname = user.GetUser(id, password).Rows[0][1].ToString();
            ViewData["id"] = id;
            ViewData["password"] = password;

            ViewData["key"] = doctorname;

            for (int i = 0; i < user.GetAllPatient(doctorname).Rows.Count; i++)
            {
                var patientinfo = new PatientInfo();
                patientinfo.id = Convert.ToInt32(user.GetAllPatient(doctorname).Rows[i][0].ToString());
                patientinfo.name = user.GetAllPatient(doctorname).Rows[i][1].ToString();
                patientinfo.sex = user.GetAllPatient(doctorname).Rows[i][2].ToString();
                patientinfo.age = user.GetAllPatient(doctorname).Rows[i][3].ToString();
                patientinfo.department = user.GetAllPatient(doctorname).Rows[i][4].ToString();
                d.Add(patientinfo);
            }


            ViewBag.msg = d;

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewData["key"] = id;
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
            user.GetPatientID(id);

            ViewData["name"] = user.GetPatientID(id).Rows[0][0].ToString();
            ViewData["sex"] = user.GetPatientID(id).Rows[0][1].ToString();
            ViewData["age"] = user.GetPatientID(id).Rows[0][2].ToString();
            ViewData["department"] = user.GetPatientID(id).Rows[0][3].ToString();

    

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Search(string name)
        {
            var patientinfo = new PatientInfo();
            var d = new List<PatientInfo>();

            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
            user.GetPatient(name);


            patientinfo.name = name;
            patientinfo.id = Convert.ToInt32(user.GetPatient(name).Rows[0][0].ToString());
            patientinfo.sex = user.GetPatient(name).Rows[0][2].ToString();
            patientinfo.age = user.GetPatient(name).Rows[0][3].ToString();
            patientinfo.department = user.GetPatient(name).Rows[0][4].ToString();

            d.Add(patientinfo);

            ViewBag.msg = d;
            return View();
        }
        public ActionResult Delete(int id )
        {
            SQLHandle sqlhandle = new SQLHandle();
            IUser user = sqlhandle;
            //if (user.DeletePatient(id))
            if (id != 100)
            {
                return Content("删除成功");

            }
            return Content("删除失败");
        }

    }
}