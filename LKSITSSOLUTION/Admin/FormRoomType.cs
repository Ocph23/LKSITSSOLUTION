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
    public partial class FormRoomType : Form
    {


        public BindingList<RoomType> source { get; set; }

        private RoomType model;

        public FormRoomType()
        {
            InitializeComponent();
            source = new BindingList<RoomType>(RoomType.GetAll());
            dataGridView1.DataSource = source;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormRoomType_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }



        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            var data = dataGridView1.CurrentRow.DataBoundItem as RoomType;
            tbName.Text = data.Name;
            tbCapacity.Value = data.Capacity;
            tbPrice.Text = data.RoomPrice.ToString();
            if (!string.IsNullOrEmpty(data.Photo))
            {
                pictureBox1.Load(data.Photo);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            KondisiAwal();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            InsertMode();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateMode();
        }

        public void KondisiAwal()
        {
            btnSave.Enabled = false;

            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            tbName.Enabled = false;
            tbCapacity.Enabled = false;
            tbPrice.Enabled = false;
        }


        public void InsertMode()
        {
            model = new RoomType();
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            tbName.Enabled = true;
            tbCapacity.Enabled = true;
            tbPrice.Enabled = true;


            tbName.Text = string.Empty;
            tbCapacity.Value = 0;
            tbPrice.Text = string.Empty;
        }


        public void UpdateMode()
        {
            model = dataGridView1.CurrentRow.DataBoundItem as RoomType;
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = true;

            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            tbName.Enabled = true;
            tbCapacity.Enabled = true;
            tbPrice.Enabled = true;


        }


        public void DeleteMode()
        {
            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = false;
            btnCancel.Enabled = true;

            tbName.Enabled = true;
            tbCapacity.Enabled = true;
            tbPrice.Enabled = true;


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteMode();

                var dialog = MessageBox.Show("Yakin Hapus Data ?", "Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    var data = dataGridView1.CurrentRow.DataBoundItem as RoomType;
                    var deleted = RoomType.Delete(data.Id);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ValidasiData();
                model.Name = tbName.Text;
                model.RoomPrice = Convert.ToInt32(tbPrice.Text);
                model.Capacity = Convert.ToInt32( tbCapacity.Value);
                model.Photo = pictureBox1.ImageLocation;


                if (model.Id <= 0)
                {
                    //insert
                   var result  =  RoomType.Insert(model);
                    if (result != null)
                    {
                        source.Add(result);
                        dataGridView1.Refresh();
                    }
                }
                else
                {
                    //update
                   if(RoomType.Update(model))
                    {
                        dataGridView1.Refresh();
                    }
                }

                MessageBox.Show("Data Berhasil Disimpan");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ValidasiData()
        {
            if (string.IsNullOrEmpty(tbName.Text))
                throw new SystemException("Name Tidak boleh kosong");

            if (tbCapacity.Value <= 0)
                throw new SystemException("Capacity harus lebih besar dari nol");
                

            if (string.IsNullOrEmpty(tbPrice.Text))
                throw new SystemException("Harga Tidak boleh kosong");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = dialog.FileName;
                pictureBox1.Load(fileName);
            }
        }
    }
}
