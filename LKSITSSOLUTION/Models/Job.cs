using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LKSITSSOLUTION.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public static Job Insert(Job data)
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var cmd = new SqlCommand("insert into job values(@name); select SCOPE_IDENTITY()");
                cmd.Parameters.Add(new SqlParameter("name", data.Name));
                var resultScalar = cmd.ExecuteScalar();
                data.Id = Convert.ToInt32(resultScalar);
                return data;
            }
            catch (System.Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }



        public static List<Job> GetAll()
        {
            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var cmd = new SqlCommand("select * from job ", connection);
                var jobReader = cmd.ExecuteReader();
                var listJob = new List<Job>();
                while (jobReader.Read())
                {
                    var job = new Job();
                    job.Id = jobReader.GetInt32(0);
                    job.Name = jobReader.GetString(1);
                    listJob.Add(job);
                }

                return listJob;
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