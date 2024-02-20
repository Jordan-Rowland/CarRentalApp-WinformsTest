using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class ManageRentalRecords : Form
    {

        private readonly CarRentalEntities carRentalEntities = new CarRentalEntities();
        public ManageRentalRecords()
        {
            InitializeComponent();
        }
        private void PopulateGrid()
        {
            var records = carRentalEntities.CarRentalRecords
                .Select(q => new
                {
                    q.CustomerName,
                    q.RentalStart,
                    q.RentalEnd,
                    q.Cost,
                    Car = q.CarType.make + " " + q.CarType.model,
                    q.id,
                })
                .ToList();
            gvRecordList.DataSource = records;
            gvRecordList.Columns["CustomerName"].HeaderText = "Customer Name";
            gvRecordList.Columns["RentalStart"].HeaderText = "Rental Start";
            gvRecordList.Columns["RentalEnd"].HeaderText = "Rental End";
            gvRecordList.Columns["id"].Visible = false;
        }

        private void btnAddRentalRecord_Click(object sender, EventArgs e)
        {
            var addEditRentalRecord = new AddEditRentalRecord() { MdiParent = MdiParent };
            addEditRentalRecord.Show();
        }

        private void btnEditRentalRecord_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvRecordList.SelectedRows[0].Cells["id"].Value;
                var record = carRentalEntities.CarRentalRecords.FirstOrDefault(q => q.id == id);
                AddEditRentalRecord addEditRentalRecord = new AddEditRentalRecord(record) { MdiParent = MdiParent };
                addEditRentalRecord.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a grid row to edit");
            }
        }

        private void btnDeleteRentalRecord_Click(object sender, EventArgs e)
        {
            var id = (int)gvRecordList.SelectedRows[0].Cells["id"].Value;
            var record = carRentalEntities.CarRentalRecords.FirstOrDefault(q => q.id == id);
            carRentalEntities.CarRentalRecords.Remove(record);
            carRentalEntities.SaveChanges();
            MessageBox.Show("Rental Record deleted.");
            PopulateGrid();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void ManageRentalRecords_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
