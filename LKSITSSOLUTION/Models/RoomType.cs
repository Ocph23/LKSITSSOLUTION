using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKSITSSOLUTION.Models
{
    public class RoomType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity{ get; set; }
        public int RoomPrice { get; set; }
        public string Photo { get;  set; }

        public static List<RoomType> GetAll()
        {
            ///Get All Data RoomType From Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand("select *  from roomtype", connection);
                var reader = command.ExecuteReader();

                //mapping data
                List<RoomType> list = new List<RoomType>();

                while (reader.Read())
                {
                    var data = new RoomType();
                    data.Id = reader.GetInt32(0);
                    data.Name = reader.GetString(1);
                    data.Capacity= reader.GetInt32(2);
                    data.RoomPrice= reader.GetInt32(3);
                    data.Photo= reader.GetString(4);
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


        public static RoomType Insert(RoomType model)
        {
            ///Insert RoomType To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"insert into roomtype values('{model.Name}', {model.Capacity}, {model.RoomPrice}, '{model.Photo}')", connection);
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


        public static bool Update(RoomType model)
        {
            ///Insert RoomType To Database
            ///


            //Connection
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                //Command
                var command = new SqlCommand($"update roomtype set name={model.Name}, capacity={model.Capacity}, roomprice={model.RoomPrice}) where id = {model.Id}", connection);
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
                var command = new SqlCommand($"delete from roomtype where id={id}", connection);
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
