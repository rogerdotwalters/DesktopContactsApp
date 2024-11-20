﻿using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        List<Contact> contacts;
        public MainWindow() {
            InitializeComponent();
            contacts = new List<Contact>();
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDatabase();
        }

        void ReadDatabase() {

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.databasePath)) {

                conn.CreateTable<Contact>();
                contacts = (conn.Table<Contact>().ToList()).OrderBy(c => c.Name).ToList();
            }

            if (contacts != null) {

                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) {

            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if (selectedContact != null) {

                ContactDetailsWIndow contactDetailsWindow = new ContactDetailsWIndow(selectedContact);
                contactDetailsWindow.OnContactChanged += ContactDetailsWindow_OnContactChanged;
                contactDetailsWindow.ShowDialog();
            }
        }

        private void ContactDetailsWindow_OnContactChanged(object? sender, EventArgs e) {
            
            ReadDatabase();
        }
    }
}