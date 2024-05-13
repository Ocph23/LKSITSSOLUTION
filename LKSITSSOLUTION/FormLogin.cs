using LKSITSSOLUTION.Admin;
using LKSITSSOLUTION.Models;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
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
                if(resultLogin==null)
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
                throw;
            }
        }
    }
}
