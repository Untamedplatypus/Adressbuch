using Logic.UI.Models;
using System;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.ComponentModel;
using Logic.UI.Services;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Logic.UI.Messageses;
using System.Collections.Generic;

namespace Logic.UI.ViewModel
{
    public class NewContactVM : ViewModelBase, INotifyPropertyChanged
    {
        QueryService queryService = new QueryService();
       /// <summary>
       /// Method to clear Textboxes
       /// </summary>
        public void ResetTBs()
        {
            #region Textboxen zurücksetzen
            FirstnameTB = null;
            LastnameTB = null;
            PronounsSelected = null;
            BirthdayTB = null;
            StreetTB = null;
            HousenumberTB = 0;
            AdressaddTB = null;
            PostcodeTB = 0;
            LocationTB = null;
            TelNumTB = 0;
            EmailTB = null;
            #endregion Textboxen zurücksetzen
        }

        public NewContactVM()
        {
            ResetTBs();
            Pronouns = queryService.PronoumList();           

        }

        #region ICommands
        /// <summary>
        /// ICommand that gathers Values of the new Contact and passes it to the InsertContact Method
        /// </summary>
        private ICommand _newContact;
        public ICommand NewContact
        {
            get
            {
                if (_newContact == null)
                {
                    _newContact = new RelayCommand(() =>
                    {
                        if (!string.IsNullOrEmpty(PronounsSelected) && !string.IsNullOrEmpty(FirstnameTB) && !string.IsNullOrEmpty(LastnameTB) && !string.IsNullOrEmpty(StreetTB) && !string.IsNullOrEmpty(Convert.ToString(HousenumberTB)) && !string.IsNullOrEmpty(Convert.ToString(PostcodeTB)) && !string.IsNullOrEmpty(LocationTB))
                        {
                            var newContact = new ContactsTbl()
                            {
                                Firstname = FirstnameTB,
                                Lastname = LastnameTB,
                                Sex = PronounsSelected.ToString(),
                                Birthday = BirthdayTB,
                                Street = StreetTB,
                                Housenumber = HousenumberTB,
                                Adressadd = AdressaddTB,
                                Postcode = PostcodeTB,
                                Location = LocationTB,
                                TelNum1 = TelNumTB,
                                Email = EmailTB

                            };
                            if (queryService.ContactPresent(newContact.Firstname, newContact.Lastname) == false)
                            {

                                Messenger.Default.Send(new SuccessMessage { UpdateSuccess = queryService.InsertContact(newContact) });
                                ResetTBs();
                            }
                            else
                            {
                                MessageBox.Show("Kontakt mit dem Namen " + newContact.Firstname + " " + newContact.Lastname + " existiert bereits.");
                            }


                        }
                        #region MessageBoxes
                        else if (string.IsNullOrEmpty(PronounsSelected))
                        {
                            MessageBox.Show("Bitte wähle eine Anrede aus");
                        }
                        else if (string.IsNullOrEmpty(FirstnameTB))
                        {
                            MessageBox.Show("Bitte gib einen Vornamen ein");
                        }
                        else if (string.IsNullOrEmpty(LastnameTB))
                        {
                            MessageBox.Show("Bitte gib einen Nachnamen ein");
                        }
                        else if (string.IsNullOrEmpty(StreetTB))
                        {
                            MessageBox.Show("Bitte gib eine Straße an");
                        }
                        else if (HousenumberTB == 0)
                        {
                            MessageBox.Show("Bitte gib einen Hausnummer ein");
                        }
                        else if (PostcodeTB == 0)
                        {
                            MessageBox.Show("Bitte gib eine Postleitzahl ein");
                        }

                        else if (string.IsNullOrEmpty(LocationTB))
                        {
                            MessageBox.Show("Bitte gib einen Ort an");
                        }
                        #endregion MessageBoxes
                    });
                }
                return _newContact;
            }
        }

        #endregion ICommands

        #region Properties
        private List<string> _pronouns;
        public List<string> Pronouns
        {
            get { return _pronouns; }
            set { _pronouns = value; RaisePropertyChanged("Pronouns"); }
        }

        private string _pronounsSelected;
        public string PronounsSelected
        {
            get { return _pronounsSelected; }
            set { _pronounsSelected = value; RaisePropertyChanged("PronounsSelected"); }
        }

        private string _firstnameHeader;
        public string FirstnameHeader
        {
            get { return _firstnameHeader; }
            set { _firstnameHeader = value; RaisePropertyChanged("FirstnameHeader"); }
        }

        private string _lastnameHeader;
        public string LastnameHeader
        {
            get { return _lastnameHeader; }
            set { _lastnameHeader = value; RaisePropertyChanged("LastnameHeader"); }
        }

        private string _firstnameTB;
        public string FirstnameTB
        {
            get { return _firstnameTB; }
            set { _firstnameTB = value; RaisePropertyChanged("FirstnameTB"); }
        }

        private string _lastnameTB;
        public string LastnameTB
        {
            get { return _lastnameTB; }
            set { _lastnameTB = value; RaisePropertyChanged("LastnameTB"); }
        }
        private DateTime? _birthdayTB;
        public DateTime? BirthdayTB
        {
            get { return _birthdayTB; }
            set { _birthdayTB = value; RaisePropertyChanged("BirthdayTB"); }
        }

        private string _streetTB;
        public string StreetTB
        {
            get { return _streetTB; }
            set { _streetTB = value; RaisePropertyChanged("BirthdayTB"); }
        }
        private int _housenumberTB;
        public int HousenumberTB
        {
            get { return _housenumberTB; }
            set { _housenumberTB = value; RaisePropertyChanged("HousenumberTB"); }
        }

        private string _adressaddTB;
        public string AdressaddTB
        {
            get { return _adressaddTB; }
            set { _adressaddTB = value; RaisePropertyChanged("AdressaddTB"); }
        }

        private int _postcodeTB;
        public int PostcodeTB
        {
            get { return _postcodeTB; }
            set { _postcodeTB = value; RaisePropertyChanged("PostcodeTB"); }
        }

        private string _locationTB;
        public string LocationTB
        {
            get { return _locationTB; }
            set { _locationTB = value; RaisePropertyChanged("LocationTB"); }
        }

        private int _telNumTB;
        public int TelNumTB
        {
            get { return _telNumTB; }
            set { _telNumTB = value; RaisePropertyChanged("TelNumTB"); }
        }

        private string _emailTB;
        public string EmailTB
        {
            get { return _emailTB; }
            set { _emailTB = value; RaisePropertyChanged("EmailTB"); }
        }
        #endregion Properties
    }
}