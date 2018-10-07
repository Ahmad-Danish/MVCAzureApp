using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MVCAzureApp.Models;

namespace MVCAzureApp.Repository
{
    public class Designationdata:IDesignation
    {
        public int InsertUpdateDesignation(Designation designation)
        {
            int MemId = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DesigId", designation.DesigId);
                param.Add("@DesignationName", designation.DesignationName);
                param.Add("@Desigdesc", designation.Desigdesc);
                param.Add("@IDOUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Execute("SP_IUDesig", param, null, 0, CommandType.StoredProcedure);
                return MemId = param.Get<int>("@IDOUT");

            }
        }

        public string IsDesignationExist(Designation designation)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DesignationName", designation.DesignationName);
                param.Add("@DesigId", designation.DesigId);
                return conn.Query<string>("SP_IsDesigExists", param, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();

            }
        }


        public List<Designation> DesignationList()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                return conn.Query<Designation>("SP_Designations", null, null, true, 0, CommandType.StoredProcedure).ToList();
            }
        }


        public Designation GetDesignationById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DesigId", id);
                return conn.Query<Designation>("SP_GetDesignationById", param, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();
            }
        }


        public List<Designation> DDLdesignations()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                return conn.Query<Designation>("SP_DDLDesignation", null, null, true, 0, CommandType.StoredProcedure).ToList();
            }
        }
    }
}