using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSITSSOLUTION.Admin
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEmployee = new FormEmployee();
            formEmployee.ShowDialog();
        }

        private void roomTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Admin.FormRoomType();
        }
    }
}
