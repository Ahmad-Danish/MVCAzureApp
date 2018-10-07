using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAzureApp.Repository;
using MVCAzureApp.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MVCAzureApp.Repository
{
    public class Employeedata:IEmployee
    {
        public int InsertUpdateEmployee(Employee employee)
        {
            int MemId = 0;
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", employee.Id);
                param.Add("@name", employee.Name);
                param.Add("@DOB", employee.DOB);
                param.Add("@Gender", employee.Gender);
                param.Add("@Email", employee.Email);
                param.Add("@Mobile", employee.Mobile);
                param.Add("@Address", employee.Address);
                param.Add("@JoiningDate", employee.JoiningDate);
                param.Add("@DepartmentID", employee.DepartmentID);
                param.Add("@DesignationID", employee.DesignationID);
                param.Add("@IDOUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                conn.Execute("SP_IUEmployee", param, null, 0, CommandType.StoredProcedure);
                return MemId = param.Get<int>("@IDOUT");

            }
        }

        public List<Employee> Emplist(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                return conn.Query<Employee>("SP_GetEmployee", param, null, true, 0, CommandType.StoredProcedure).ToList();
            }
        }


        public Employee GetEmployeeById(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ToString()))
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Id", Id);
                return conn.Query<Employee>("SP_GetEmployee", param, null, true, 0, CommandType.StoredProcedure).SingleOrDefault();
            }
        }
    }
}