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
    /// Interaktionslogik für EditContactView.xaml
    /// </summary>
    public partial class EditContactView : UserControl
    {
        public EditContactView()
        {
            InitializeComponent();
            
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactsView contactsView = new ContactsView();
            Content = contactsView;
        }
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("ContactsGridLoaded");
        }
        private void DataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("ContactSelection");
        }

        private void BackToOverview_Click(object sender, RoutedEventArgs e)
        {
            ContactsView contacts = new ContactsView();
            Content = contacts;
        }

        private void DeleteMultipleContacts_Click(object sender, RoutedEventArgs e)
        {
            MultipleDeleteView multipleDeleteView = new MultipleDeleteView();
            Content= multipleDeleteView;
        }
    }
}
