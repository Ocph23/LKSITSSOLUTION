using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LKSITSSOLUTION.Admins
{
    public partial class FormRoomType : Form
    {
        public FormRoomType()
        {
            InitializeComponent();
        }

        private void FormRoomType_Load(object sender, EventArgs e)
        {
            Kosongkan();
        }

       

        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertMode();
        }

     

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            SelectMode();
        }

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Kosongkan();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMode();
        }


        private void Kosongkan()
        {
            btnInsert.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        private void InsertMode()
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
        private void SelectMode()
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = true;
        }

   
        private void UpdateMode()
        {

            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }
    }
}
