using LKSITSSOLUTION.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSITSSOLUTION
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tbUserName.Text) || string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show("Lengkapi User dan Password");
                return;
            }

            var connection = MyConnection.GetConnection();
            connection.Open();
            try
            {
                var command = new SqlCommand("Select Job.Name from Employee left join Job on Employee.JobId=Job.ID where Employee.UserName = @username and Employee.Password=@password", connection);
                command.Parameters.Add(new SqlParameter("username", tbUserName.Text));
                command.Parameters.Add(new SqlParameter("password", CreatePasswordHash(tbPassword.Text)));
                var reader = command.ExecuteReader();
                string role = string.Empty;
                if (reader.Read())
                {
                    role = reader.GetString(0);
                }

                if (role == "Admin")
                {
                    var formAdmin = new FormAdmin();
                    formAdmin.FormClosed += FormAdmin_FormClosed;
                    formAdmin.Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        [Obsolete]
        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                var connection = MyConnection.GetConnection();
                connection.Open();
                var command = new SqlCommand("select count(*) from employee", connection);
                var result = command.ExecuteScalar();
                if (result != null)
                {
                    var countRow = Convert.ToInt32(result);
                    if (countRow <= 0)
                    {

                        string passwordHash = CreatePasswordHash("Admin123");

                        var emp = new Employee()
                        {
                            UserName = "Admin",
                            Password = passwordHash,
                            Name = "Admin",
                            Email = "admin@gmail.com",
                            DateOfBird = DateTime.Now,
                            Address = "",
                            Photo = "",
                            JobId = 1
                        };

                        var employee = Employee.Insert(emp);

                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private string CreatePasswordHash(string pwd)
        {

            var inputByte = Encoding.UTF8.GetBytes(pwd);
            StringBuilder stringBuilder = new StringBuilder();
            using (var sha = new SHA256Managed())
            {
                var byteHash = sha.ComputeHash(inputByte);

                foreach (var item in byteHash)
                {
                    stringBuilder.Append($"{item:x2}");
                }
            }

            return stringBuilder.ToString();


        }
    }
}
