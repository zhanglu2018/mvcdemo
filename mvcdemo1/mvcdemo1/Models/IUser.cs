using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace mvcdemo1.Models
{
    public interface IUser
    {
        /// <summary>
        /// 获取某个已知用户名的用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>该用户信息的表</returns>
        DataTable GetUser(int userid, string userpwd);

        DataTable GetPatient(string patientname);
        DataTable GetAllPatient(string patient);
        DataTable GetPatientID(int patientid);
        bool DeletePatient(int patientid);
        bool UpdatePatient(PatientInfo patientinfo);
        bool AddPatient(PatientInfo patientinfo);
    }
}
