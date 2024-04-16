using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Mobile_Computing_Lab
{
    public class DataAcessModules
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

        public DataTable getModules(int student_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_modules_get_all", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@student_num", SqlDbType.Int).Value = student_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public void updateStudent(int student_num, string first_name, string last_name)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand sqlCommand = new SqlCommand("mc_update_student", sqlConnection_DBcnn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@student_num", student_num);
            sqlCommand.Parameters.AddWithValue("@student_fname", first_name);
            sqlCommand.Parameters.AddWithValue("@student_lname", last_name);


            sqlConnection_DBcnn.Open();
            sqlCommand.ExecuteNonQuery();

            sqlConnection_DBcnn.Close();

            sqlCommand.Dispose();
            sqlConnection_DBcnn.Dispose();

     
        }

        public DataTable getSingleModule(int student_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_modules_get_single", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@module_num", SqlDbType.Int).Value = student_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getSingleStudent(int student_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_students_get_single", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@student_num", SqlDbType.Int).Value = student_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getStudentsDoingModule(int module_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_students_doing_module", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@module_num", SqlDbType.Int).Value = module_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public void addStudent(string fname, string lname)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand sqlCommand = new SqlCommand("mc_create_student", sqlConnection_DBcnn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@student_fname", fname);
            sqlCommand.Parameters.AddWithValue("@student_lname", lname);


            sqlConnection_DBcnn.Open();
            sqlCommand.ExecuteNonQuery();

            sqlConnection_DBcnn.Close();

            sqlCommand.Dispose();
            sqlConnection_DBcnn.Dispose();
        }
    }
}