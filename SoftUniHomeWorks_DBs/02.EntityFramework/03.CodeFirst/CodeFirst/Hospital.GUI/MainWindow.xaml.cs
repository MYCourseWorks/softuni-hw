using Hospital.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListAllUsers();
        }

        public void ListAllUsers()
        {
            UserContext ctx = new UserContext();
            var patients = ctx.Patients.ToArray();

            foreach (var p in patients)
            {
                var item = new ListBoxItem();
                item.Content = $"{p.FirstName} {p.LastName} {p.IsInshured}";
                this.ListOfUsers.Items.Add(item);
            }
        }

        private void AddNewUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUsser = new AddUserWindow();
            this.Close();
            addUsser.Show();
        }
    }
}
