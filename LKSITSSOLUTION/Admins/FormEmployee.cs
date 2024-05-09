using LKSITSSOLUTION.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSITSSOLUTION
{
    public partial class FormEmployee : Form
    {

        public BindingList<Employee> dataSource { get; set; } = new BindingList<Employee>();

        public FormEmployee()
        {
            InitializeComponent();
            dataGridView1.DataSource = dataSource;
            dataGridView1.AutoGenerateColumns = false;
        }


        private void FormEmployee_Load(object sender, EventArgs e)
        {

            cmbJob.DataSource = Job.GetAll();
            cmbJob.DisplayMember = "Name";
            cmbJob.ValueMember = "Id";
            foreach (var item in Employee.GetAll())
            {
                dataSource.Add(item);
            }
            dataGridView1.Refresh();
            Kosongkan();
        }

        private void Kosongkan()
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            tbaddress.Enabled = true;
            tbconfirm.Enabled = true;
            tbpassword.Enabled = true;
            tbemail.Enabled = true;
            tbname.Enabled = true;
            tbUsername.Enabled = true;
            dtDateOfBird.Enabled = true;
            cmbJob.Enabled = true;


            tbaddress.Text = string.Empty;
            tbconfirm.Text = string.Empty;
            tbpassword.Text = string.Empty;
            tbemail.Text = string.Empty;
            tbname.Text = string.Empty;
            tbUsername.Text = string.Empty;
            dtDateOfBird.Value = DateTime.Now;
            cmbJob.SelectedItem = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;




        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertMode();
        }

        private void InsertMode()
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            tbaddress.Enabled = true;
            tbconfirm.Enabled = true;
            tbpassword.Enabled = true;
            tbemail.Enabled = true;
            tbname.Enabled = true;
            tbUsername.Enabled = true;
            dtDateOfBird.Enabled = true;
            cmbJob.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            tbaddress.Enabled = true;
            tbconfirm.Enabled = true;
            tbpassword.Enabled = true;
            tbemail.Enabled = true;
            tbname.Enabled = true;
            tbUsername.Enabled = true;
            dtDateOfBird.Enabled = true;
            cmbJob.Enabled = true;

        }

        private void updateMode()
        {
            throw new NotImplementedException();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Anda Belum Memilih Data");
                return;
            }


            var resultDialog = MessageBox.Show("Yakin Hapus Data", "Hapus Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resultDialog == DialogResult.OK)
            {
                var connection = MyConnection.GetConnection();
                connection.Open();
                var cmd = new SqlCommand("Delete from emloyee where id = @id", connection);
                var data = dataGridView1.CurrentRow.DataBoundItem as Employee;
                cmd.Parameters.Add(new SqlParameter("id", data.Id));
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Data Terhaspus");
                }
                else
                {

                }
            }




        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var data = new Employee();
            data.Name = tbname.Text;
            data.Email = tbemail.Text;
            data.Password = tbemail.Text;
            data.UserName = tbUsername.Text;
            data.Address = tbaddress.Text;
            data.DateOfBird = dtDateOfBird.Value;
            data.Photo = pictureBox1.ImageLocation;
            data.JobId = (cmbJob.SelectedItem as Job).Id;







        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Kosongkan();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openDialog.FileName;
                    pictureBox1.Image = Image.FromFile(filePath);
                }
            }

        }
    }
}
