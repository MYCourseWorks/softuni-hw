using Hospital.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Hospital.GUI
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }

        private void ClearFields()
        {
            this.FirstName.Text = null; // required
            this.LastName.Text = null; // required
            this.Address.Text = null; // required
            this.Email.Text = null;
            this.DateOfBirth.SelectedDate = null;
            this.HasInsurance.IsChecked = false; // required
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            UserContext ctx = new UserContext();

            string firstName = this.FirstName.Text; // required
            string lastName = this.LastName.Text; // required
            string address = this.Address.Text; // required
            string email = this.Email.Text;
            DateTime? dateOfBirth = this.DateOfBirth.SelectedDate;
            bool? isInsured = this.HasInsurance.IsChecked; // required
            var patientPhoto = this.PatientPhoto.Source;

            if (String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) ||
                String.IsNullOrEmpty(address) || isInsured == null)
            {
                MessageBox.Show("Invalid User Data");
            }
            else {
                var tran = ctx.Database.BeginTransaction();

                try
                {
                    var user = new Patient()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Address = address,
                        Email = email,
                        DateOfBirth = dateOfBirth,
                        IsInshured = isInsured.Value,
                        Picture = ConvertToBinary(patientPhoto)
                    };

                    ctx.Patients.Add(user);
                    ctx.SaveChanges();

                    MessageBox.Show("User Added.");
                    tran.Commit();
                }
                catch (Exception)
                {
                    MessageBox.Show("Could not add user.");
                    tran.Rollback();
                }
            }

            ClearFields();
        }

        private byte[] ConvertToBinary(ImageSource imageSource)
        {
            if (imageSource == null)
                return null;

            var image = imageSource as BitmapSource;
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                this.PatientPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
