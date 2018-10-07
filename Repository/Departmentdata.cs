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
    public class Departmentdata:IDepartment
    {
        public int InsertUpdateDepartment(Department department)
        {
            int MemId = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", department.Id);
                param.Add("@DepartmentName", department.DepartmentName);
                param.Add("@DepartmentDesc", department.DepartmentDesc);
                param.Add("@IDOUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Execute("SP_IUDepartment", param, null, 0, CommandType.StoredProcedure);
                return MemId = param.Get<int>("@IDOUT");

            }
        }


        public string IsDepartmentExists(Department department)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@DepartmentName", department.DepartmentName);
                param.Add("@Id", department.Id);
                return conn.Query<string>("SP_IsDeptExists", param, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();

            }
        }


        public List<Department> DepartmentList()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                return conn.Query<Department>("sp_departments", null, null, true, 0, CommandType.StoredProcedure).ToList();
            }
        }
        

        public Department GetDepartmentById(int id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", id);
                return conn.Query<Department>("SP_GetDepartmentById", param, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();

            }
        }


        public List<Department> DDLdepartments()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                return conn.Query<Department>("SP_DDLdepartment", null, null, true, 0, CommandType.StoredProcedure).ToList();
            }
        }
    }
}