using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKSITSSOLUTION.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBird { get; set; }
        public string Photo { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }

        [Obsolete]
        public static Employee Insert(Employee emp)
        {
            try
            {
                var connection = MyConnection.GetConnection();
                var command = new SqlCommand("Insert into employee values (@username, @password, @name, @email, @address,@dob,@photo, @jobid) ; select SCOPE_IDENTITY()", connection);
                command.Parameters.Add("username", emp.UserName);
                command.Parameters.Add("password", emp.Password);
                command.Parameters.Add("name", emp.Name);
                command.Parameters.Add("email", emp.Email);
                command.Parameters.Add("address", emp.Address);
                command.Parameters.Add("dob", emp.DateOfBird);
                command.Parameters.Add("photo", emp.Photo);
                command.Parameters.Add("jobid", emp.JobId);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    emp.Id = Convert.ToInt32(result);
                }
                return emp;

            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public static List<Employee> GetAll()
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var cmd = new SqlCommand("select employee.*, job.* from employee inner join job on employee.jobid = job.id ", connection);
                var reader = cmd.ExecuteReader();
                List<Employee> list = new List<Employee>();
                while (reader.Read())
                {
                    var employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.UserName = reader.GetString(1);
                    employee.Name = reader.GetString(3);
                    employee.Email = reader.GetString(4);
                    employee.Address = reader.GetString(5);
                    employee.DateOfBird = reader.GetDateTime(6);
                    employee.Photo = reader.GetString(7);
                    employee.JobId = reader.GetInt32(8);
                    employee.JobName = reader.GetString(10);
                    list.Add(employee);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }



    }
}
