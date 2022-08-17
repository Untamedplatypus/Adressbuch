using Logic.UI.Models;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.ComponentModel;
using Logic.UI.Services;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace Logic.UI.ViewModel
{
    public class ContactOverviewVM : ViewModelBase, INotifyPropertyChanged
    {
        QueryService queryService = new QueryService();
       
     
        public ContactOverviewVM()
        {
            //Fills DG with ID, Firstname and Lastname 
            Messenger.Default.Register<string>(this, (prop) =>
            {
                if (prop.Equals("ContactsGridLoaded"))
                {
                    ContactList = queryService.contactOverviews();
                }
            });
      
        }
        #region ICommands
        /// <summary>
        /// If the delete button gets clicked, query service to delete contact gets executed after reasurment trough messagebox
        /// </summary>
        private ICommand _deleteContactBtn;
        public ICommand DeleteContactBtn
        {

            get
            {
                if (_deleteContactBtn == null)
                {
                    _deleteContactBtn = new RelayCommand(() =>
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("Kontakt "+_selectedListItem.Firstname+" "+_selectedListItem.Lastname+ " wird gelöscht, sind Sie sicher?", "löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {
                            if (queryService.DeleteContact(_selectedListItem.Id))
                            {
                                ContactList = queryService.contactOverviews();
                            }

                        }
                    });
                }
                return _deleteContactBtn;
            }
        }
        #endregion ICommands

        #region Properties

        /// <summary>
        /// recognizes selected contact in DG and fills Labels with infos
        /// </summary>
        private ContactCompleteModel _selectedListItem;
        public ContactCompleteModel SelectedListItem
        {
            get { return _selectedListItem; }
            set
            {
                _selectedListItem = value;
                RaisePropertyChanged("SelectedListItem");
                if (SelectedListItem != null)
                {
                    ContactCompleteModel result = queryService.Selected(SelectedListItem.Id);
                    FirstnameHeader = result.Firstname;
                    FirstnameLabel=result.Firstname;
                    LastnameHeader = result.Lastname;
                    LastnameLabel=result.Lastname;
                    SexLabel = result.Sex;
                    BirthdayLabel =Convert.ToDateTime(result.Birthday);
                    StreetLabel = result.Street;
                    HousenumberLabel = result.Housenumber;
                    AdressAddLabel = result.Adressadd;
                    PostCodeLabel = result.Postcode;
                    LocationLabel = result.Location;
                    TelNum1Label = result.TelNum1;
                    EmailLabel = result.Email;

                    Messenger.Default.Send(SelectedListItem.Id);
                }
            }
        }
        private List<ContactCompleteModel> _completeContactList;
        public List <ContactCompleteModel> CompleteContactList
        {
            get { return _completeContactList; }
            set { _completeContactList = value; RaisePropertyChanged("CompleteContactList"); }
        }

        private List<ContactCompleteModel> _contactList;
        public List<ContactCompleteModel> ContactList
        {
            get { return _contactList; }
            set { _contactList = value;
                RaisePropertyChanged("ContactList");}

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

        private string _firstnameLabel;
        public string FirstnameLabel
        {
            get { return _firstnameLabel; }
            set
            {
                _firstnameLabel = value;
                RaisePropertyChanged("FirstnameLabel");
            }
        }

        private string _lastnameLabel;
        public string LastnameLabel
        {
            get { return _lastnameLabel; }
            set
            {
                _lastnameLabel = value;
                RaisePropertyChanged("LastnameLabel");
            }
        }

        private string _sexLabel;
        public string SexLabel
        {
            get { return _sexLabel; }
            set
            {
                _sexLabel = value;
                RaisePropertyChanged("SexLabel");
            }
        }

        private DateTime _birthdayLabel;
        public DateTime BirthdayLabel
        {
            get { return _birthdayLabel; }
            set
            {
                _birthdayLabel = value;
                RaisePropertyChanged("BirthdayLabel");
            }
        }

        private string _streetLabel;
        public string StreetLabel
        {
            get { return _streetLabel; }
            set
            {
                _streetLabel = value;
                RaisePropertyChanged("StreetLabel");
            }
        }

        private int _housenumberLabel;
        public int HousenumberLabel
        { get { return _housenumberLabel; }
            set
            {
                _housenumberLabel = value;
                RaisePropertyChanged("HousenumberLabel");
            }
        }

        private string _adressAddLabel;
        public string AdressAddLabel
        {
            get { return _adressAddLabel; }
            set { _adressAddLabel = value;
                RaisePropertyChanged("AdressAddLabel");}
        }

        private int _postCodeLabel;
        public int PostCodeLabel
        {
            get { return _postCodeLabel; }
            set
            {
                _postCodeLabel = value;
                RaisePropertyChanged("PostCodeLabel");
            }
        }

        private string _locationLabel;
        public string LocationLabel
        {
            get { return _locationLabel; }
            set
            {
                _locationLabel = value;
                RaisePropertyChanged("LocationLabel");
            }
        }

        private int _telNum1Label;
        public int TelNum1Label
        {
            get { return _telNum1Label; }
            set
            {
                _telNum1Label = value;
                RaisePropertyChanged("TelNum1Label");
            }
        }

        private string _emailLabel;
        public string EmailLabel
        {
            get { return _emailLabel; }
            set
            {
                _emailLabel = value;
                RaisePropertyChanged("EmailLabel");
            }
        }
    
        #endregion Properties

    }
}
