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
    public partial class ManageVehicleListing : Form
    {

        private readonly CarRentalEntities carRentalEntities;
        public ManageVehicleListing()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void PopulateGrid()
        {
            var cars = carRentalEntities.CarTypes
                .Select(q => new
                {
                    Make = q.make,
                    Model = q.model,
                    VIN = q.vin,
                    Year = q.year,
                    LicensePlateNumber = q.licensePlateNumber,
                    q.id,
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns["id"].Visible = false;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            AddEditVehicle addEditVehicle = new AddEditVehicle
            {
                MdiParent = MdiParent
            };
            addEditVehicle.Show();
            gvVehicleList.Refresh();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;
                var car = carRentalEntities.CarTypes.FirstOrDefault(q => q.id == id);
                AddEditVehicle addEditVehicle = new AddEditVehicle(car) { MdiParent = MdiParent };
                addEditVehicle.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a grid row to edit");
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            var id = (int)gvVehicleList.SelectedRows[0].Cells["id"].Value;
            var car = carRentalEntities.CarTypes.FirstOrDefault(q => q.id == id);
            carRentalEntities.CarTypes.Remove(car);
            carRentalEntities.SaveChanges();
            MessageBox.Show("Car Record deleted. Please refresh to see changes.");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGrid();
        }
    }
}
