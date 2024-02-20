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
    public partial class AddEditVehicle : Form
    {
        private readonly CarRentalEntities carRentalEntities = new CarRentalEntities();
        private bool isEditMode;
        public AddEditVehicle()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
        }

        public AddEditVehicle(CarType car)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            isEditMode = true;
            PopulateFields(car);
        }

        private void PopulateFields(CarType car)
        {
            lblId.Text = car.id.ToString();
            tbMake.Text = car.make;
            tbModel.Text = car.model;
            tbVin.Text = car.vin;
            tbYear.Text = car.year.ToString();
            tbLicensePlateNumber.Text = car.licensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                int id = int.Parse(lblId.Text);
                var car = carRentalEntities.CarTypes.FirstOrDefault(q => q.id == id);
                car.make = tbMake.Text;
                car.model = tbModel.Text;
                car.vin = tbVin.Text;
                car.year = int.Parse(tbYear.Text);
                car.licensePlateNumber = tbLicensePlateNumber.Text;
                carRentalEntities.SaveChanges();
                MessageBox.Show("Changes have been saved. Please refresh to see your changes.");
                Close();
            }
            else
            {
                try
                {
                    var newCar = new CarType
                    {
                        make = tbMake.Text,
                        model = tbModel.Text,
                        vin = tbVin.Text,
                        year = int.Parse(tbYear.Text),
                        licensePlateNumber = tbLicensePlateNumber.Text,
                    };
                    carRentalEntities.CarTypes.Add(newCar);
                    carRentalEntities.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Error processing:\n\r{ex}");
                }
                MessageBox.Show("Changes have been saved. Please refresh to see your changes.");
                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddEditVehicle_Load(object sender, EventArgs e)
        {

        }
    }
}
