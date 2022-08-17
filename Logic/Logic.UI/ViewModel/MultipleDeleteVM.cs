using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Logic.UI.Models;
using Logic.UI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Logic.UI.ViewModel
{
    public class MultipleDeleteVM : ViewModelBase, INotifyPropertyChanged
    {
        QueryService queryService = new QueryService();


        public MultipleDeleteVM()
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
        private ICommand _multipleDeleteBtn;
        public ICommand MultipleDeleteBtn
        {

            get
            {
                if (_multipleDeleteBtn == null)
                {
                    _multipleDeleteBtn = new RelayCommand(() =>
                    {

                        List<int> IdList = new List<int>();
                        foreach (var item in ContactList ) 
                        {
                            if (item.Selected == true)
                            {

                                IdList.Add(item.Id);
                            }
                        }
                        MessageBoxResult messageBoxResult = MessageBox.Show("Kontakte werden gelöscht, sind Sie sicher?", "löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (messageBoxResult == MessageBoxResult.Yes)
                        {

                            queryService.MultipleDelete(IdList);
                            ContactList.Clear();
                            ContactList = queryService.contactOverviews();
                        }

                    });
                }
                return _multipleDeleteBtn;
            }
        }

        #region Properties


        private bool _cbIsChecked;
        public bool CbIsChecked
        {
            get { return _cbIsChecked; }
            set { _cbIsChecked = value; RaisePropertyChanged("CbIsChecked"); }
        }

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
                    FirstnameLabel = result.Firstname;
                    LastnameHeader = result.Lastname;
                    LastnameLabel = result.Lastname;
                    SexLabel = result.Sex;
                    BirthdayLabel = Convert.ToDateTime(result.Birthday);
                    StreetLabel = result.Street;
                    HousenumberLabel = result.Housenumber;
                    AdressAddLabel = result.Adressadd;
                    PostCodeLabel = result.Postcode;
                    LocationLabel = result.Location;
                    TelNum1Label = result.TelNum1;
                    EmailLabel = result.Email;


                }
            }
        }
        private List<ContactCompleteModel> _completeContactList;
        public List<ContactCompleteModel> CompleteContactList
        {
            get { return _completeContactList; }
            set { _completeContactList = value; RaisePropertyChanged("CompleteContactList"); }
        }

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

        private ICommand _editBtn;
        public ICommand EditBtn
        {
            get { return _editBtn; }

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
        {
            get { return _housenumberLabel; }
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
            set
            {
                _adressAddLabel = value;
                RaisePropertyChanged("AdressAddLabel");
            }
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
