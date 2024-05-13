using LKSITSSOLUTION.Models;
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
    public partial class FormEmployee : Form
    {

        public BindingList<Employee> source { get; set; }

        public Employee model;
        public FormEmployee()
        {
            InitializeComponent();
            source = new BindingList<Employee>(Employee.GetAll());
            dataGridView1.DataSource = source;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteMode();

                var dialog = MessageBox.Show("Yakin Hapus Data ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    var data = dataGridView1.CurrentRow.DataBoundItem as Employee;
                    var deleted = Employee.Delete(data.Id);
                    if (deleted)
                    {
                        source.Remove(data);
                        dataGridView1.Refresh();
                    }
                }
                KondisiAwal();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }


        public void KondisiAwal()
        {
            btnSave.Enabled = false;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            //tbName.Enabled = false;
            //tbCapacity.Enabled = false;
            //tbPrice.Enabled = false;
        }


        public void InsertMode()
        {
            model = new Employee();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //tbName.Enabled = true;
            //tbCapacity.Enabled = true;
            //tbPrice.Enabled = true;


            //tbName.Text = string.Empty;
            //tbCapacity.Value = 0;
            //tbPrice.Text = string.Empty;
        }


        public void UpdateMode()
        {
            model = dataGridView1.CurrentRow.DataBoundItem as Employee;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //tbName.Enabled = true;
            //tbCapacity.Enabled = true;
            //tbPrice.Enabled = true;


        }


        public void DeleteMode()
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = false;
            btnCancel.Enabled = true;

            //tbName.Enabled = true;
            //tbCapacity.Enabled = true;
            //tbPrice.Enabled = true;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMode();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertMode();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                DeleteMode();

                var dialog = MessageBox.Show("Yakin Hapus Data ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    var data = dataGridView1.CurrentRow.DataBoundItem as Employee;
                    var deleted = Employee.Delete(data.Id);
                    if (deleted)
                    {
                        source.Remove(data);
                        dataGridView1.Refresh();
                    }
                }
                KondisiAwal();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
