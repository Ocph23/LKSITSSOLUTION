using LKSITSSOLUTION.Admin;
using LKSITSSOLUTION.Models;
using System;
using System.Data.SqlClient;
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
            try
            {
                var resultLogin = Employee.Login(tbUserNama.Text, EncriptPassword.CreatePasswordHash(tbPassword.Text));
                if (resultLogin == null)
                {
                    throw new SystemException("User dan Password Anda Salah");
                }
                else
                {
                    var formAdmin = new FormAdmin();
                    formAdmin.Show();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

            //Cek Table Employe masih kosong

            var connection = MyConnection.GetConnection();
            connection.Open();

            var command = new SqlCommand("select count(*) from employee", connection);
            var scalar = command.ExecuteScalar();
            connection.Close();

            if (scalar != null && Convert.ToInt32(scalar) <=0)
            {
                ///insert admin pertama kali
                ///

                var employee = new Employee();
                employee.UserName = "admin";
                employee.Password = EncriptPassword.CreatePasswordHash("Admin123");
                employee.Name = "Admin";
                employee.Email = "admin@mail.com";
                employee.Address = "Jln.";
                employee.DateOfBird = DateTime.Now;
                employee.JobId = 1;

                var result = Employee.Insert(employee);
                if (result == null)
                {
                    this.Close();
                }

            }
        }
    }
}
