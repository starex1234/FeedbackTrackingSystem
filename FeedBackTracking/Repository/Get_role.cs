using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;

namespace FeedBackTracking.Repository
{
    public class Get_role
    {
        public SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            con = new SqlConnection(constr);
        }

        public  string getrolebyusername(string username)
        {
            try
            {
                string role = "";
                DynamicParameters param = new DynamicParameters();
                param.Add("@MUserName", username);
                connection();
                con.Open();
                IDataReader dr = con.ExecuteReader("GetRole", param, commandType: CommandType.StoredProcedure);

                while (dr.Read())
                {
                    role = dr["RoleName"].ToString();
                }
                con.Close();
                
                return role;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string getmanaging_agentstatus(string username)
        {
            try
            {
                string status = "";
                DynamicParameters param = new DynamicParameters();
                param.Add("@Musername", username);
                connection();
                con.Open();
                IDataReader dr = con.ExecuteReader("get_managing_agent_status", param, commandType: CommandType.StoredProcedure);

                while (dr.Read())
                {
                    status = dr["Status_"].ToString();
                }
                con.Close();

                return status;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}