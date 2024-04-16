using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Mobile_Computing_Lab.Layers
{
    public class InmatesDataAccessModule
    {
        public String connectionString()
        {
            return ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }

        public void addInmate(string firstname, string lastname, bool male, int block_num, int year_incarcerated, int offence_num, int release_year)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            SqlCommand sqlCommand = new SqlCommand("create_inmate", sqlConnection_DBcnn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@last_name", lastname);
            sqlCommand.Parameters.AddWithValue("@first_name", firstname);
            sqlCommand.Parameters.AddWithValue("@male", male);
            sqlCommand.Parameters.AddWithValue("@block_num", block_num);
            sqlCommand.Parameters.AddWithValue("@year_incarcerated", year_incarcerated);
            sqlCommand.Parameters.AddWithValue("@offence_num", offence_num);
            sqlCommand.Parameters.AddWithValue("@release_year", release_year);


            sqlConnection_DBcnn.Open();
            sqlCommand.ExecuteNonQuery();

            sqlConnection_DBcnn.Close();

            sqlCommand.Dispose();
            sqlConnection_DBcnn.Dispose();


        }

        public DataTable getBlocks()
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_blocks", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getInmatesInBlock(int block_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_block_inmates", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@block_num", SqlDbType.Int).Value = block_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getInmate(int inmate_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_inmate", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@inmate_num", SqlDbType.Int).Value = inmate_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable getOffenses()
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_convictions", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }

        public DataTable relocateInmate()
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_get_convictions", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }


        public DataTable relocateInmate(int inmate_num, int block_num)
        {
            SqlConnection sqlConnection_DBcnn = new SqlConnection(connectionString());
            DataTable dtable;
            SqlDataAdapter sqlDataAdapter_SQLda = new SqlDataAdapter();
            SqlCommand sqlCommand = new SqlCommand("mc_relocate_inmate", sqlConnection_DBcnn);

            dtable = new DataTable("type");

            sqlConnection_DBcnn.Open();
            sqlDataAdapter_SQLda.SelectCommand = sqlCommand;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.Add("@inmate_num", SqlDbType.Int).Value = inmate_num;
            sqlCommand.Parameters.Add("@block_num", SqlDbType.Int).Value = block_num;
            sqlDataAdapter_SQLda.Fill(dtable);

            sqlConnection_DBcnn.Close();
            sqlDataAdapter_SQLda.Dispose();

            return dtable;
        }
    }
}