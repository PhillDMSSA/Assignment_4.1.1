using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Assignment_4._1._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, Person> phoneBook = new();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            phoneBook = new Dictionary<string, Person>
    {
        { "John Doe", new Person { FirstName = "John", LastName = "Doe", MobilePhone = "555-1234", WorkPhone = "555-5678", Address = "123 Elm St" } },
        { "Jane Smith", new Person { FirstName = "Jane", LastName = "Smith", MobilePhone = "555-8765", WorkPhone = "555-4321", Address = "456 Oak St" } },
        { "Tom Brown", new Person { FirstName = "Tom", LastName = "Brown", MobilePhone = "555-1111", WorkPhone = "555-2222", Address = "789 Pine St" } }
    };
            PersonGrid.ItemsSource = phoneBook.Values.ToList();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddPersonWindow();
            if (addWindow.ShowDialog() == true)
            {
                var person = addWindow.Person;
                if (!phoneBook.ContainsKey(person.FullName))
                {
                    phoneBook[person.FullName] = person;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("A person with this name already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchKey = SearchBox.Text.Trim();
            if (phoneBook.TryGetValue(searchKey, out var person))
            {
                MessageBox.Show($"Name: {person.FullName}\nMobile Phone: {person.MobilePhone}\nWork Phone: {person.WorkPhone}\nAddress: {person.Address}",
                                "Search Result", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Person not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string deleteKey = SearchBox.Text.Trim();
            if (phoneBook.ContainsKey(deleteKey))
            {
                if (MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete",
                                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    phoneBook.Remove(deleteKey);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Person not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}