﻿using DesktopContactsApp.Classes;
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
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window {
        public NewContactWindow() {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            //SaveContact
            Contact contact = new Contact {

                Name = tbName.Text,
                Email = tbEmail.Text,
                Phone = tbPhone.Text, 
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Contact>();
                connection.Insert(contact);
            }
            this.Close();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) {

            this.Close();
        }
    }
}
