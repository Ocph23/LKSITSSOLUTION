using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKSITSSOLUTION.Models
{
    public class Job
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static List<Job> GetAll()
        {
            ///Get All Data RoomType From Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand("select *  from job", connection);
                var reader = command.ExecuteReader();

                //mapping data
                List<Job> list = new List<Job>();

                while (reader.Read())
                {
                    var data = new Job();
                    data.Id = reader.GetInt32(0);
                    data.Name = reader.GetString(1);
                   
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


        public static Job Insert(Job model)
        {
            ///Insert RoomType To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"insert into job values('{model.Name}')", connection);
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


        public static bool Update(Job model)
        {
            ///Insert RoomType To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"update roomtype set name={model.Name} where id = {model.Id}", connection);
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
            ///Delete RoomType To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"delete from job where id={id}", connection);
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
