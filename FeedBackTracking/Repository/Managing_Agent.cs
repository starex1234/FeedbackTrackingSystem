using Dapper;
using FeedBackTracking.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FeedBackTracking.Repository
{
    public class Managing_Agent
    {
      
        public SqlConnection con;
        private void connection()
        {
             string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            con = new SqlConnection(constr);
            
        }

        public static IEnumerable<T> ReturnMList<T>()
        {
          string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
           using(SqlConnection con = new SqlConnection(constr))
           {
               con.Open();
               return con.Query<T>("get_managingagent", commandType: CommandType.StoredProcedure);
           }
        }

       

        public static Managing_agent_Data get_managingById(int id)
        {
            DynamicParameters param = new DynamicParameters();
             param.Add("@Mid", id);
            Managing_agent_Data md = new Managing_agent_Data();
            string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
            using (SqlConnection con = new SqlConnection(constr))
            {
                md = con.Query<Managing_agent_Data>("Get_Managing_Agent_By_Id",param,commandType:CommandType.StoredProcedure).SingleOrDefault();
            }
            return md; 
        }

      
            public static IEnumerable<SelectListItem> GetStateList()
            {
                IList<SelectListItem> States = new List<SelectListItem>
            {
               new SelectListItem { Value = "Active" , Text = "Active" },
               new SelectListItem { Value = "InActive" , Text = "InActive" }
            };
             return States;
            }

           public static void Update_Managing_Agent(Managing_agent_Data dt,string username,DateTime date,int id)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Muserid", id);
                param.Add("@MCompany", dt.companyName);
                param.Add("@MEmail", dt.Email);
                param.Add("@MPhone_Number", dt.phone_number);
                param.Add("@MContact_Name", dt.contact_name);
                param.Add("@MUpdated_By", username);
                param.Add("@MUpdated_On", date);
                param.Add("@MIs_Active", dt.status_);
                
                string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();
                    con.Execute("update_managing_agent", param, commandType: CommandType.StoredProcedure);
                    con.Close();
                }
               
            }

         public static void Delete_managing_agent(int id)
           {
               DynamicParameters param = new DynamicParameters();
               param.Add("@Mid", id);
              
               string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
               using (SqlConnection con = new SqlConnection(constr))
               {
                   con.Open();
                   con.Query<Managing_agent_Data>("Delete_managing_agent", param, commandType: CommandType.StoredProcedure).SingleOrDefault();
                   con.Close();
               }
           }

         public static string get_email(string username)
         {
             try
             {
                 string email = "";
                 DynamicParameters param = new DynamicParameters();
                 param.Add("@Rusername", username);
                 string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
                 using (SqlConnection con = new SqlConnection(constr))
                 {
                     IDataReader dr = con.ExecuteReader("Get_Email_For_Resetpassword", param, commandType: CommandType.StoredProcedure);

                     while (dr.Read())
                     {
                         email = dr["Email"].ToString();
                     }
                     con.Close();
                 }
                 return email;
                
             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }

         public static int get_userid(string username)
         {
             try
             {
                 int id =0;
                 DynamicParameters param = new DynamicParameters();
                 param.Add("@pusername", username);
                 string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
                 using (SqlConnection con = new SqlConnection(constr))
                 {
                     IDataReader dr = con.ExecuteReader("get_userid", param, commandType: CommandType.StoredProcedure);

                     while (dr.Read())
                     {
                         id = Convert.ToInt32(dr["UserId"].ToString());
                     }
                     con.Close();
                 }
                 return id;

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
         public static int get_userid_bytoken(string token)
         {
             try
             {
                 int id = 0;
                 DynamicParameters param = new DynamicParameters();
                 param.Add("@ptoken", token);
                 string constr = ConfigurationManager.ConnectionStrings["myconnection"].ToString();
                 using (SqlConnection con = new SqlConnection(constr))
                 {
                     IDataReader dr = con.ExecuteReader("get_userId_token", param, commandType: CommandType.StoredProcedure);

                     while (dr.Read())
                     {
                         id = Convert.ToInt32(dr["UserId"].ToString());
                     }
                     con.Close();
                 }
                 return id;

             }
             catch (Exception ex)
             {
                 throw ex;
             }
         }
        
    }
}