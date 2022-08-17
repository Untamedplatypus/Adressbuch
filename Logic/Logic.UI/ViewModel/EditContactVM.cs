using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Logic.UI.Services;
using Logic.UI.Models;
using System;
using GalaSoft.MvvmLight.Messaging;

namespace Logic.UI.ViewModel
{
    public class EditContactVM : ViewModelBase, INotifyPropertyChanged
    {
        QueryService queryService = new QueryService();

        public EditContactVM()
        {
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("ContactsGridLoaded"))
                {
                    ContactList = queryService.contactOverviews();
                }
            });

            Pronouns = queryService.PronoumList();

        }

        /// <summary>
        /// Method to clear all textboxes
        /// </summary>
        public void ResetTxtB()
        {
            //FirstnameHeader = null;
            FirstnameTB = null;
            //LastnameHeader = null;
            LastnameTB = null;
            //SexTB = null;
            BirthdayTB = null;
            StreetTB = null;
            HousenumberTB = 0;
            AdressaddTB = null;
            PostcodeTB = 0;
            LocationTB = null;
            TelNumTB = 0;
            EmailTB = null;
        }

        #region ICommands
        /// <summary>
        /// Icommand for the "Bestätigen" Button, passes the new values and calls the EditContact Method, Resets Textboxes after method call
        /// </summary>
        private ICommand _confirmBtn;
        public ICommand ConfirmBtn
        {
            get
            {
                if (_confirmBtn == null)
                {
                    _confirmBtn = new RelayCommand(() =>
                    {
                        if (SelectedContact != null)
                        {
                            if (!string.IsNullOrEmpty(FirstnameTB) && !string.IsNullOrEmpty(LastnameTB) && !string.IsNullOrEmpty(StreetTB) && !string.IsNullOrEmpty(Convert.ToString(HousenumberTB)) && !string.IsNullOrEmpty(Convert.ToString(PostcodeTB)) && !string.IsNullOrEmpty(LocationTB))
                            {

                                var editedContact = new ContactsTbl()
                                {
                                    Firstname = FirstnameTB,
                                    Lastname = LastnameTB,
                                    Sex = PronounSelected,
                                    Birthday = BirthdayTB,
                                    Street = StreetTB,
                                    Housenumber = HousenumberTB,
                                    Adressadd = AdressaddTB,
                                    Postcode = PostcodeTB,
                                    Location = LocationTB,
                                    TelNum1 = TelNumTB,
                                    Email = EmailTB
                                };


                                if (queryService.EditContact(editedContact, SelectedContact.Id) == true)
                                {
                                    MessageBox.Show("Kontakt wurde erfolreich bearbeitet");
                                    ContactList = queryService.contactOverviews();
                                    ResetTxtB();
                                }

                                else
                                {
                                    MessageBox.Show("Kontakt konnte nicht bearbeitet werden");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Klappt nicht");
                            }
                        }
                    });
                }
                return _confirmBtn;
            }
        }

        private ICommand _deleteThisContactBtn;
        public ICommand DeleteThisContactBtn
        {
            get
            {
                if (_deleteThisContactBtn == null)
                {
                    _deleteThisContactBtn = new RelayCommand(() =>
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Kontakt " + _selectedContact.Firstname + " " + _selectedContact.Lastname + " wird gelöscht, sind Sie sicher?", "löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            if (queryService.DeleteContact(_selectedContact.Id))
                            {
                                ContactList = queryService.contactOverviews();
                                ResetTxtB();
                            }

                        }
                    });
                }
                return _deleteThisContactBtn;
            }
            set { _deleteThisContactBtn = value; RaisePropertyChanged("DeleteThisContactBtn"); }
        }

        #endregion ICommands

        #region Properties
        private List<ContactCompleteModel> _contactList;
        public List<ContactCompleteModel> ContactList
        {
            get { return _contactList; }
            set
            {
                _contactList = value;
                RaisePropertyChanged("ContactList");
            }

        }


        private ContactCompleteModel _selectedContact;
        public ContactCompleteModel SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;

                RaisePropertyChanged("SelectedContact");
                if (SelectedContact != null)
                {

                    ContactCompleteModel result = queryService.Selected(SelectedContact.Id);
                    FirstnameHeader = result.Firstname;
                    FirstnameTB = result.Firstname;
                    LastnameHeader = result.Lastname;
                    LastnameTB = result.Lastname;
                    SexTB = result.Sex;
                    BirthdayTB = result.Birthday;
                    StreetTB = result.Street;
                    HousenumberTB = result.Housenumber;
                    AdressaddTB = result.Adressadd;
                    PostcodeTB = result.Postcode;
                    LocationTB = result.Location;
                    TelNumTB = result.TelNum1;
                    EmailTB = result.Email;


                }
            }
        }

        private List<string> _pronouns;
        public List<string> Pronouns
        {
            get { return _pronouns; }
            set { _pronouns = value; RaisePropertyChanged("Pronouns"); }
        }

        private string _pronounSelected;
        public string PronounSelected
        {
            get { return _pronounSelected; }
            set { _pronounSelected = value; RaisePropertyChanged("PronounSelected"); }
        }

        private string _firstnameHeader;
        public string FirstnameHeader
        {
            get { return _firstnameHeader; }
            set
            {
                _firstnameHeader = value;
                RaisePropertyChanged("FirstnameHeader");
            }
        }

        private string _lastnameHeader;
        public string LastnameHeader
        {
            get { return _lastnameHeader; }
            set
            {
                _lastnameHeader = value;
                RaisePropertyChanged("LastnameHeader");
            }
        }

        private string _firstnameTB;
        public string FirstnameTB
        {
            get { return _firstnameTB; }
            set
            {
                _firstnameTB = value;
                RaisePropertyChanged("FirstnameTB");
            }
        }

        private string _lastnameTB;
        public string LastnameTB
        {
            get { return _lastnameTB; }
            set
            {
                _lastnameTB = value;
                RaisePropertyChanged("LastnameTB");
            }
        }

        private string _sexTB;
        public string SexTB
        {
            get { return _sexTB; }
            set
            {
                _sexTB = value;
                RaisePropertyChanged("SexTB");
            }
        }

        private DateTime? _birthdayTB;
        public DateTime? BirthdayTB
        {
            get { return _birthdayTB; }
            set
            {
                _birthdayTB = value;
                RaisePropertyChanged("BirthdayTB");
            }
        }

        private string _streetTB;
        public string StreetTB
        {
            get { return _streetTB; }
            set
            {
                _streetTB = value;
                RaisePropertyChanged("StreetTB");
            }
        }

        private int _housenumberTB;
        public int HousenumberTB
        {
            get { return _housenumberTB; }
            set
            {
                _housenumberTB = value;
                RaisePropertyChanged("HousenumberTB");
            }
        }

        private string _adressaddTB;
        public string AdressaddTB
        {
            get { return _adressaddTB; }
            set
            {
                _adressaddTB = value;
                RaisePropertyChanged("AdressAddTB");
            }
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
            set
            {
                _locationTB = value;
                RaisePropertyChanged("LocationTB");
            }
        }

        private int _telNumTB;
        public int TelNumTB
        {
            get { return _telNumTB; }
            set
            {
                _telNumTB = value;
                RaisePropertyChanged("TelNum1TB");
            }
        }

        private string _emailTB;
        public string EmailTB
        {
            get { return _emailTB; }
            set
            {
                _emailTB = value;
                RaisePropertyChanged("EmailTB");
            }
        }

        #endregion Properties





    }
}
