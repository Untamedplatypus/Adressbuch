
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Logic.UI.Services;
using Logic.UI.Messageses;
using System.Windows.Input;
using Logic.UI.ViewModel;

namespace UI.Desktop
{
    /// <summary>
    /// Interaktionslogik für UserControl2.xaml
    /// </summary>
    public partial class AddContactView : UserControl
    {
        EditContactVM EditContactVM = new EditContactVM();
        

        public AddContactView()
        {
            InitializeComponent();
            Messenger.Default.Register(this, (SuccessMessage success) =>
             {
                 if (success.UpdateSuccess == true)
                 { MessageBox.Show("Hinzufügen war erfolgreich");
                     
                     ContactsView contacts = new ContactsView();
                     Content = contacts;
                     EditContactVM.ResetTxtB();
                 }
                 else
                 { MessageBox.Show("Hinzufügen war leider nicht erfolgreich"); }
             });
        }

        private void EditContacts_Click(object sender, RoutedEventArgs e)
        {
            EditContactView editContactView = new EditContactView();
            Content= editContactView;

        }
        private void DeleteContacts_Click(object sender, RoutedEventArgs e)
        {
            MultipleDeleteView multipleDelete = new MultipleDeleteView();
            Content= multipleDelete;
        }

        private void AbbrechenBtn_Click(object sender, RoutedEventArgs e)
        {

            ContactsView contactsView = new ContactsView();
            Content = contactsView;
        }
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            int input;
            if(!(int.TryParse(e.Text, out input)))
            {
                e.Handled = true;
            }
        }
     

        private void CheckInput(KeyEventArgs e)
        {
            if (e.Key == Key.Space && e.Key ==Key.OemQuestion && e.Key== Key.Decimal && e.Key == Key.OemPeriod)
            {
                e.Handled = true;
            }
        }


        private void Housenumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckInput(e);
        }

        private void Postcode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckInput(e);
        }

        private void TelNum_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            CheckInput(e);
        }

        private void Housenum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }

        private void Postcode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
            
        }

        private void TelNum_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
    }
}
