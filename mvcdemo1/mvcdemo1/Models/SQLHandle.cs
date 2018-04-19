using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace mvcdemo1.Models
{
    public class SQLHandle:IUser
    {
        public DataTable GetUser(int userid, string userpwd)
        {
            SqlParameter[] prams = new SqlParameter[]
            {
                new SqlParameter("@duid",SqlDbType.Int),
                new SqlParameter("@dpsw",SqlDbType.NChar,10)
            };
            prams[0].Value = userid;
            prams[1].Value = userpwd;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteDataTable("selectdoctor", prams);
        }
        public DataTable GetPatient( string patientname)
        {
            SqlParameter[] prams = new SqlParameter[]
            {
               
                new SqlParameter("@pname",SqlDbType.NChar,10)
            };

            prams[0].Value = patientname;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteDataTable("searchpatient", prams);
        }
        public DataTable GetPatientID(int patientid)
        {
            SqlParameter[] prams = new SqlParameter[]
            {

                new SqlParameter("@puid",SqlDbType.Int)
            };

            prams[0].Value = patientid;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteDataTable("searchpatientid", prams);
        }
        public DataTable GetAllPatient(string patientname)
        {
            SqlParameter[] prams = new SqlParameter[]
            {

                new SqlParameter("@pname",SqlDbType.NChar,10)
            };

            prams[0].Value = patientname;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteDataTable("searchallpatient", prams);
        }

        public bool DeletePatient(int patientid)
        {
            SqlParameter[] prams = new SqlParameter[]
            {

                new SqlParameter("@patientid",SqlDbType.Int)
            };

            prams[0].Value = patientid ;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteNonQuery("deletepatient", prams);
        }
        public bool AddPatient(PatientInfo patientinfo)
        {
            SqlParameter[] prams = new SqlParameter[]
            {

                new SqlParameter("@patientid", SqlDbType.Int),
                new SqlParameter("@patientname", SqlDbType.Char,10),
                new SqlParameter("@patientsex", SqlDbType.Char,10),
                new SqlParameter("@patientage", SqlDbType.Int)
            };

            prams[0].Value = patientinfo.id;
            prams[1].Value = patientinfo.name;
            prams[2].Value = patientinfo.sex;
            prams[3].Value = patientinfo.age;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteNonQuery("addpatient", prams);
        }
        public bool UpdatePatient(PatientInfo patientinfo)
        {
            SqlParameter[] prams = new SqlParameter[]
            {

                new SqlParameter("@patientid", SqlDbType.Int),
                new SqlParameter("@patientname", SqlDbType.Char,10),
                new SqlParameter("@patientsex", SqlDbType.Char,10),
                new SqlParameter("@patientage", SqlDbType.Int),
                new SqlParameter("@patientdepartment", SqlDbType.Char,10)
            };

            prams[0].Value = patientinfo.id;
            prams[1].Value = patientinfo.name;
            prams[2].Value = patientinfo.sex;
            prams[3].Value = patientinfo.age;
            prams[4].Value = patientinfo.department;
            SQLHelper helper = new SQLHelper();
            return helper.ExcuteNonQuery("updatepatient", prams);
        }
    }
}