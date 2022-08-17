using GalaSoft.MvvmLight.Messaging;
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

namespace UI.Desktop
{
    /// <summary>
    /// Interaktionslogik für MultipleDeleteView.xaml
    /// </summary>
    public partial class MultipleDeleteView : UserControl
    {
        public MultipleDeleteView()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ContactsView contactsView = new ContactsView();
            Content = contactsView;
        }

    

        private void NewContact_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddContactView addContactView = new AddContactView();
            Content = addContactView;
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("ContactsGridLoaded");
        }
        private void BackToOverview_Click(object sender, RoutedEventArgs e)
        {
            ContactsView contacts = new ContactsView();
            Content = contacts;
        }

        private void EditContacts_Click(object sender, RoutedEventArgs e)
        {
            EditContactView editContactView = new EditContactView();
            Content= editContactView;
        }
    }
}
