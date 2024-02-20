using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalApp
{
    public partial class AddEditRentalRecord : Form
    {

        private readonly CarRentalEntities carRentalEntities = new CarRentalEntities();
        bool isEditMode = false;
        public AddEditRentalRecord()
        {
            InitializeComponent();
        }

        public AddEditRentalRecord(CarRentalRecord record)
        {
            InitializeComponent();
            isEditMode = true;
            PopulateFields(record);
        }

        private void PopulateFields(CarRentalRecord record)
        {
            lblId.Text = record.id.ToString();
            tbCustomerName.Text = record.CustomerName;
            dtRentalStart.Value = (DateTime)record.RentalStart;
            dtRentalEnd.Value = (DateTime)record.RentalEnd;
            tbCost.Text = record.Cost.ToString();
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                string customerName = tbCustomerName.Text;
                DateTime rentalStart = dtRentalStart.Value;
                DateTime rentalEnd = dtRentalEnd.Value;
                string carType = cbCarType.Text;
                double cost = Convert.ToDouble(tbCost.Text);
                bool isValid = true;
                string errorMessage = "";

                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(carType))
                {
                    errorMessage += "Error: Please add missing data.\n\r";
                    isValid = false;
                }

                if (rentalStart > rentalEnd)
                {
                    errorMessage += "Start date must be before end date.\n\r";
                    isValid = false;
                }

                if (isValid)
                {
                    if (isEditMode)
                    {
                        int id = int.Parse(lblId.Text);
                        var record = carRentalEntities.CarRentalRecords.FirstOrDefault(q => q.id == id);
                        record.CustomerName = customerName;
                        record.RentalStart = rentalStart;
                        record.RentalEnd = rentalEnd;
                        record.Cost = (decimal)cost;
                        record.CarTypeId = (int)cbCarType.SelectedValue;
                        carRentalEntities.SaveChanges();
                        MessageBox.Show("Changes have been saved. Please refresh to see your changes.");
                    }
                    else
                    {
                        var rentalRecord = new CarRentalRecord
                        {
                            CustomerName = customerName,
                            RentalStart = rentalStart,
                            RentalEnd = rentalEnd,
                            Cost = (decimal)cost,
                            CarTypeId = (int)cbCarType.SelectedValue
                        };

                        carRentalEntities.CarRentalRecords.Add(rentalRecord);
                        carRentalEntities.SaveChanges();

                        MessageBox.Show(
                            $"Thank you for renting, {customerName}!\n\r" +
                            $"Your rental starts on {rentalStart} and " +
                            $"ends on on {rentalEnd}.\n\rYour car is a {carType}. " +
                            $"The cost is {cost}."
                        );
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var cars = carRentalEntities.CarTypes
                .Select(q => new { q.id, Name = q.make + " " + q.model})
                .ToList();
            cbCarType.DisplayMember = "Name";
            cbCarType.ValueMember = "id";
            cbCarType.DataSource = cars;
        }

    }
}
