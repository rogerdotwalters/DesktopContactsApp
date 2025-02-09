﻿using DesktopContactsApp.Classes;
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

namespace DesktopContactsApp.Controls {
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    /// 
    public partial class ContactControl : UserControl {



        public Contact Contact {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register(
                "Contact", 
                typeof(Contact), 
                typeof(ContactControl), 
                new PropertyMetadata(new Contact() {
                    Name = "Firstname Lastname", 
                    Email = "exampleemail@domain.com", 
                    Phone = "(123) 456 7890",
                }
                ,SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e) {

            ContactControl control = d as ContactControl;

            if (control != null) {

                control.tbName.Text = (e.NewValue as Contact).Name;
                control.tbEmail.Text = (e.NewValue as Contact).Email;
                control.tbPhone.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl() {
            InitializeComponent();
        }
    }
}
