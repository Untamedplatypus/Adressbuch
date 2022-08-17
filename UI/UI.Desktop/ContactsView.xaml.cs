using GalaSoft.MvvmLight.Messaging;
using UI.Desktop;
using System.Windows;
using System.Windows.Controls;
using Logic.UI.Services;
using System.Windows.Input;


namespace UI.Desktop
{
    /// <summary>
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class ContactsView : UserControl
    {
        public ContactsView()
        {
            InitializeComponent();
        }

        private void ButtonBearbeiten_Click(object sender, RoutedEventArgs e)
        {
            EditContactView edit = new EditContactView();
            Content = edit;
            
        }
      
        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send("ContactsGridLoaded");
        }
        private void DataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Messenger.Default.Send("ContactSelection");
        }

        private void NewContact_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddContactView addContact = new AddContactView();
            Content = addContact;
        }

        private void MultipleDelete_Click(object sender, RoutedEventArgs e)
        {
            MultipleDeleteView multipleDeleteView = new MultipleDeleteView();
            Content = multipleDeleteView;
        }
    }
}
