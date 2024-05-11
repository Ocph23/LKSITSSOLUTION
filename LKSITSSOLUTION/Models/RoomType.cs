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
        public int Capacity { get; set; }
        public double RoomPrice { get; set; }
        public string Photo { get; set; }


        public static List<RoomType> GetAll()
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var cmd = new SqlCommand("select * from roomtype", connection);
                var reader = cmd.ExecuteReader();
                List<RoomType> list = new List<RoomType>();
                while (reader.Read())
                {
                    var row = new RoomType();
                    row.Id = reader.GetInt32(0);
                    row.Name = reader.GetString(1);
                    row.Capacity= reader.GetInt32(2);
                    row.RoomPrice= reader.GetDouble(3);
                    row.Photo = reader.GetString(4);
                    list.Add(row);
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
        public static RoomType Insert(RoomType data)
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var command = new SqlCommand("Insert into roomtype values (@name, @capacity, @roomprice, @photo) ; select SCOPE_IDENTITY()", connection);
                command.Parameters.Add("name", data.Name);
                command.Parameters.Add("capacity", data.Capacity);
                command.Parameters.Add("roomprice", data.RoomPrice);
                command.Parameters.Add("photo", data.Photo);
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
            finally
            {
                connection.Close();
            }
        }


        [Obsolete]
        public static bool Update(RoomType data)
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var command = new SqlCommand("update employee set name=@name, capacity=@capacity, roomprice=@roomprice, photo=@photo where id=@id", connection);
                command.Parameters.Add("id", data.Id);
                command.Parameters.Add("name", data.Name);
                command.Parameters.Add("capacity", data.Capacity);
                command.Parameters.Add("roomprice", data.RoomPrice);
                command.Parameters.Add("photo", data.Photo);
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
                var command = new SqlCommand("delete from roomtype where id=@id", connection);
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
