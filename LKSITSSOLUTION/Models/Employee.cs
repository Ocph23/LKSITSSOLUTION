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
        public static Employee Insert(Employee data)
        {
            try
            {
                var connection = MyConnection.GetConnection();
                var command = new SqlCommand("Insert into dataloyee values (@username, @password, @name, @email, @address,@dob,@photo, @jobid) ; select SCOPE_IDENTITY()", connection);
                command.Parameters.Add("username", data.UserName);
                command.Parameters.Add("password", data.Password);
                command.Parameters.Add("name", data.Name);
                command.Parameters.Add("email", data.Email);
                command.Parameters.Add("address", data.Address);
                command.Parameters.Add("dob", data.DateOfBird);
                command.Parameters.Add("photo", data.Photo);
                command.Parameters.Add("jobid", data.JobId);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    data.Id = Convert.ToInt32(result);
                }
                return data;

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
                var cmd = new SqlCommand("select dataloyee.*, job.* from dataloyee inner join job on dataloyee.jobid = job.id ", connection);
                var reader = cmd.ExecuteReader();
                List<Employee> list = new List<Employee>();
                while (reader.Read())
                {
                    var dataloyee = new Employee();
                    dataloyee.Id = reader.GetInt32(0);
                    dataloyee.UserName = reader.GetString(1);
                    dataloyee.Name = reader.GetString(3);
                    dataloyee.Email = reader.GetString(4);
                    dataloyee.Address = reader.GetString(5);
                    dataloyee.DateOfBird = reader.GetDateTime(6);
                    dataloyee.Photo = reader.GetString(7);
                    dataloyee.JobId = reader.GetInt32(8);
                    dataloyee.JobName = reader.GetString(10);
                    list.Add(dataloyee);
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

        [Obsolete]
        public static bool Update(Employee data)
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var command = new SqlCommand("update employee set username=@usernama, name=@name, email=@email, " +
                    "address=@address, dateofbird=@dob, jobid=@jobid  photo=@photo where id=@id", connection);
                command.Parameters.Add("username", data.UserName);
                command.Parameters.Add("password", data.Password);
                command.Parameters.Add("name", data.Name);
                command.Parameters.Add("email", data.Email);
                command.Parameters.Add("address", data.Address);
                command.Parameters.Add("dob", data.DateOfBird);
                command.Parameters.Add("photo", data.Photo);
                command.Parameters.Add("jobid", data.JobId);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


        public static bool Delete(int id)
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var command = new SqlCommand("delete from employee where id=@id", connection);
                command.Parameters.Add("id", id);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

    }
}
