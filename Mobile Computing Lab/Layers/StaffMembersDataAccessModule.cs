using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mobile_Computing_Lab.Layers
{
    public class StaffMembersDataAccessModule
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

        public DataTable getDepartments()
        {
            return callProceedure("mc_get_departments", null);
        }

        public DataTable getStaffPastCountries(int member_num)
        {
            return callProceedure("mc_get_staff_past_countries", new Param("member_num", member_num));
        }

        public DataTable getDepartmentStaff(int department_num)
        {
            return callProceedure("mc_get_department_staff", new Param("department_num", department_num));
        }

        public DataTable getStaffDetails(int member_num)
        {
            return callProceedure("mc_get_staff_details", new Param("member_num", member_num));
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
            if(param != null )
            {
                sqlCommand.Parameters.Add("@"+param.name, SqlDbType.Int).Value = param.value;
            }
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }
    }

    class Param
    {
        public String name;
        public int value;
        public Param(String name, int value)
        {
            this.name  = name;
            this.value = value;
        }
    }
}