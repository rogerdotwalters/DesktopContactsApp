using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp {
    /// <summary>
    /// Interaction logic for ContactDetailsWIndow.xaml
    /// </summary>
    public partial class ContactDetailsWIndow : Window {

        Contact contact;

        public event EventHandler OnContactChanged;
        public ContactDetailsWIndow(Contact contact) {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            this.contact = contact;
            tbName.Text = contact.Name;
            tbEmail.Text = contact.Email;
            tbPhone.Text = contact.Phone;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e) {

            contact.Name = tbName.Text;
            contact.Email = tbEmail.Text;
            contact.Phone = tbPhone.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {

                connection.CreateTable<Contact>();
                connection.Update(contact);
            }

            OnContactChanged?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {

                connection.CreateTable<Contact>();
                connection.Delete(contact);
            }

            OnContactChanged?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {

            Close();
        }
    }
}
