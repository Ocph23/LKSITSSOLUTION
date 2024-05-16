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
        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public DateTime DateOfBird { get; set; }
        public string Photo { get; set; }

        public int JobId { get; set; }

        public string JobName { get; set; }


        public static List<Employee> GetAll()
        {
            ///Get All Data Employee From Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand("select employee.*, job.name from employee left join job on employee.jobid=job.id", connection);
                var reader = command.ExecuteReader();

                //mapping data
                List<Employee> list = new List<Employee>();

                while (reader.Read())
                {
                    var data = new Employee();
                    data.Id = reader.GetInt32(0);
                    data.UserName = reader.GetString(1);
                    data.Password = reader.GetString(2);
                    data.Name = reader.GetString(3);
                    data.Email = reader.GetString(4);
                    data.Address = reader.GetString(5);
                    data.DateOfBird = reader.GetDateTime(6);
                    data.Photo = reader.GetString(7);
                    data.JobId = reader.GetInt32(8);
                    data.JobName = reader.GetString(9);
                    list.Add(data);
                }

                return list;

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


        public static Employee Login(string username, string password)
        {

            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand("select employee.*, job.name from employee left join job on employee.jobid=job.id where username=@un and password=@pwd", connection);
                command.Parameters.Add("un", username);
                command.Parameters.Add("pwd", password);

                var reader = command.ExecuteReader();

                //mapping data

                if (reader.HasRows)
                {
                    reader.Read();
                    var data = new Employee();
                    data.Id = reader.GetInt32(0);
                    data.UserName = reader.GetString(1);
                    data.Password = reader.GetString(2);
                    data.Name = reader.GetString(3);
                    data.Email = reader.GetString(4);
                    data.Address = reader.GetString(5);
                    data.DateOfBird = reader.GetDateTime(6);
                    data.Photo = reader.GetString(7);
                    data.JobId = reader.GetInt32(8);
                    data.JobName = reader.GetString(9);
                    return data;

                }else
                {
                    return null;
                }
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


        public static Employee Insert(Employee model)
        {
            ///Insert Employee To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"insert into employee values({model.UserName}, {model.Password}, {model.Name}, {model.Email}, {model.Address}, " +
                    $"{model.DateOfBird}, {model.Photo}, {model.JobId}); select scope_identity()", connection);
                var scalar = command.ExecuteScalar();


                //mapping data
                if (scalar != null)
                {
                    model.Id = Convert.ToInt32(scalar);
                }
                return model;

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


        public static bool Update(Employee model)
        {
            ///Insert Employee To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"update employee set username={model.UserName}, password={model.Password}, name={model.Name},email= {model.Email}, address={model.Address}, " +
                    $"date0fbird={model.DateOfBird}, photo={model.Photo},jobid={model.JobId}) where id = {model.Id}", connection);
                var result = command.ExecuteNonQuery();
                //mapping data
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
            ///Delete Employee To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"delete from employee where id={id}", connection);
                var result = command.ExecuteNonQuery();
                //mapping data
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
