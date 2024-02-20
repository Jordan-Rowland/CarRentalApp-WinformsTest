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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditRentalRecord addRentalRecord = new AddEditRentalRecord();
            addRentalRecord.ShowDialog();
            addRentalRecord.MdiParent = this;   
        }

        private void manageVehicleListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageVehicleListing manageVehicleListing = new ManageVehicleListing();
            manageVehicleListing.ShowDialog();
            manageVehicleListing.MdiParent = this;
        }

        private void removeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var manageRentalRecords = new ManageRentalRecords {  MdiParent = this };
            manageRentalRecords.Show();
        }
    }
}
