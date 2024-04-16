using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Mobile_Computing_Lab.Layers
{
    public class SkoolersDataAccessModule
    {
        public String connectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        public DataTable getAllStudents()
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("MC_students_get_all", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getStudentPassword(string userId)
        {
            return callProceedureStringArg("mc_get_user_password", new StringParam("user_id", userId));
        }

        public DataTable createHighSchool(string highSchoolName)
        {
            return callProceedureStringArg("mc_new_high_school", new StringParam("high_school_name", highSchoolName));
        }

        public DataTable getHighSchools()
        {
            return callProceedure("mc_get_high_schools", null);
        }

        public DataTable updateHighSchool(int highschoolId, string highschoolName)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_update_high_school", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@" + "highschool_id", SqlDbType.Int).Value = highschoolId;
            sqlCommand.Parameters.Add("@" + "highschool_name", SqlDbType.NChar).Value = highschoolName;

            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getStaffPastCountries(int member_num)
        {
            return callProceedure("mc_get_staff_past_countries", new Param("member_num", member_num));
        }

        public DataTable getHighSchoolStudents()
        {
            return callProceedure("mc_get_high_school_students", null);
        }

        public DataTable getHighSchoolHeadStudent(int school_num)
        {
            return callProceedure("mc_get_highschool_head_student", new Param("school_num", school_num));
        }
        public DataTable removeHighSchool(int highschool_num)
        {
            return callProceedure("mc_remove_high_school", new Param("highschool_num", highschool_num));
        }

        public DataTable getDepartmentStaff(int department_num)
        {
            return callProceedure("mc_get_department_staff", new Param("department_num", department_num));
        }

        public DataTable getStaffDetails(int member_num)
        {
            return callProceedure("mc_get_staff_details", new Param("member_num", member_num));
        }

        public DataTable setHighSchoolHeadStudent(int school_num, int student_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_set_highschool_head_student", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.Add("@" + "school_num", SqlDbType.Int).Value = school_num;
            sqlCommand.Parameters.Add("@" + "student_num", SqlDbType.Int).Value = student_num;

            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        private DataTable callProceedure(String proceedureName, Param param)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(proceedureName, sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.Add("@" + param.name, SqlDbType.Int).Value = param.value;
            }
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        private DataTable callProceedureStringArg(String proceedureName, StringParam param)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand(proceedureName, sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            if (param != null)
            {
                sqlCommand.Parameters.Add("@" + param.name, SqlDbType.NVarChar).Value = param.value;
            }
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        class StringParam
        {
            public string name;
            public string value;
            public StringParam(string name, string value)
            {
                this.name = name;
                this.value = value;
            }
        }
    }
}
