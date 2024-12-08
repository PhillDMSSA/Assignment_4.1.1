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
using System.Windows.Shapes;

namespace Assignment_4._1._1
{
    /// <summary>
    /// Interaction logic for AddPersonWindow.xaml
    /// </summary>
    public partial class AddPersonWindow : Window
    {
        public Person Person { get; private set; }
        public AddPersonWindow()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Person = new Person
            {
                FirstName = FirstNameBox.Text.Trim(),
                LastName = LastNameBox.Text.Trim(),
                MobilePhone = MobilePhoneBox.Text.Trim(),
                WorkPhone = WorkPhoneBox.Text.Trim(),
                Address = AddressBox.Text.Trim()
            };

            if (string.IsNullOrWhiteSpace(Person.FirstName) || string.IsNullOrWhiteSpace(Person.LastName))
            {
                MessageBox.Show("First Name and Last Name are required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}
