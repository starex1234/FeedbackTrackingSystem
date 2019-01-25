using Dapper;
using FeedBackTracking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FeedBackTracking.Repository
{
    public class Managing_agent_repository
    {

        public static void Add_Loc(Add_Location_Category lc, string username, DateTime date)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@Lname", lc.Name);
            param.Add("@Lcreated_by",username);
            param.Add("@Lcreated_on",date);
            param.Add("@Lis_active","Active");
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                con.Execute("Add_Location", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }
        }

        public static List<T> ReturnMList<T>()
        {
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                return con.Query<T>("get_location", commandType: CommandType.StoredProcedure).ToList();
            }
        }

    }
}