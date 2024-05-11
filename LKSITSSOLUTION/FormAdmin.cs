using LKSITSSOLUTION.Admins;
using System;
using System.Windows.Forms;

namespace LKSITSSOLUTION
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            this.FormClosed += FormAdmin_FormClosed;
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormEmployee();
            form.ShowDialog();
        }

        private void roomTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRoomType();
            form.ShowDialog();
        }

        private void roomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormRoom();
            form.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            var formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
