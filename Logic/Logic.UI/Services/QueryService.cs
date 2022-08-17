using Logic.UI.Models;
using Logic.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Logic.UI.Services
{
    public class QueryService
    {
        /// <summary>
        /// Method that gets to contacts out of the database
        /// </summary>
        /// <returns></returns>
        public List<ContactCompleteModel> contactOverviews()
        {
            List<ContactCompleteModel> contactList;
            contactList = new List<ContactCompleteModel>();
            contactList.Clear();


            //Database query to fill DG of Contacts
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {

                var contactInfo = from a in ctx.ContactsTbl
                                  select new { a.ContactID, a.Firstname, a.Lastname };
                foreach (var contact in contactInfo)
                {
                    ContactCompleteModel info = new ContactCompleteModel();
                    info.Id = contact.ContactID;
                    info.Firstname = contact.Firstname;
                    info.Lastname = contact.Lastname;
                    contactList.Add(info);
                }
                return contactList;
            }
        }

        /// <summary>
        /// Method takes ID of the contact that shall be edited as parameter and the values that have been entered into the Textboxes then overwrites the old values in the database
        /// returns true if accomplished and throws Exception if not
        /// </summary>
        /// <param name="contacts"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool EditContact(ContactsTbl contacts, int id)
        {
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {
                var editSelectedContact = from a in ctx.ContactsTbl
                                          where a.ContactID == id
                                          select a;
                try
                {
                    foreach (var item in editSelectedContact)
                    {
                        item.Firstname = contacts.Firstname;
                        item.Lastname = contacts.Lastname;
                        item.Sex = contacts.Sex;
                        item.Birthday = contacts.Birthday;
                        item.Street = contacts.Street;
                        item.Housenumber = contacts.Housenumber;
                        item.Adressadd = contacts.Adressadd;
                        item.Postcode = contacts.Postcode;
                        item.Location = contacts.Location;
                        item.TelNum1 = contacts.TelNum1;
                        item.Email = contacts.Email;
                    }
                    ctx.SaveChanges();
                    return true;
                   
                }
                catch(Exception ex)
                {
                    return false;
                    throw ex;
                }
               
            }
        }

        /// <summary>
        /// Method that takes the ID of the selected contact and passes the information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ContactCompleteModel Selected(int Id)
        {
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {
                var contactInfo = from a in ctx.ContactsTbl
                                  where a.ContactID == Id
                                  select a;

                ContactsTbl contactsTbl = contactInfo.FirstOrDefault();

                ContactCompleteModel info = new ContactCompleteModel();
                info.Firstname = contactsTbl.Firstname;
                info.Lastname = contactsTbl.Lastname;
                info.Sex = contactsTbl.Sex;
                info.Birthday = contactsTbl.Birthday;
                info.Street = contactsTbl.Street;
                info.Housenumber = contactsTbl.Housenumber;
                info.Adressadd = contactsTbl.Adressadd;
                info.Postcode = contactsTbl.Postcode;
                info.Location = contactsTbl.Location;
                info.TelNum1 = contactsTbl.TelNum1;
                info.Email = contactsTbl.Email;
                return info;

            }
        }

        /// <summary>
        /// Method takes the ID of the contact that shall be deleted and deletes it from the database
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteContact(int Id)
        {
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {
                var contact = from a in ctx.ContactsTbl
                              where a.ContactID == Id
                              select a;
                if (contact == null)
                {
                    return false;
                }
                else
                {
                    var delete = from a in ctx.ContactsTbl
                                 where a.ContactID == Id
                                 select a;
                    foreach (var del in delete)
                    { ctx.ContactsTbl.Remove(del); }
                    ctx.SaveChanges();
                    return true;
                }
            }
        }

        /// <summary>
        /// Takes the list of ID of the contacts that shall be deleted and calls the delete method for every contact
        /// </summary>
        /// <param name="IDs"></param>
        /// <returns></returns>
        public bool MultipleDelete (List<int> IDs)
        {
            foreach (int item in IDs)
            {
                DeleteContact(item);
            }
            return true;
        }

        /// <summary>
        /// List with possible pronouns
        /// </summary>
        /// <returns></returns>
        public List<string> PronoumList()
        {
            var liste = new List<string>();
            liste.Add("Herr");
            liste.Add("Frau");
            liste.Add("Divers");
            return liste;
        }
        
        /// <summary>
        /// Method takes the Values of a new contact and inserts it to the database
        /// </summary>
        /// <param name="newContact"></param>
        /// <returns></returns>
        public bool InsertContact(ContactsTbl newContact)
        {
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {
                
                try
                {
                    ctx.ContactsTbl.Add(newContact);
                    ctx.SaveChanges();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                    throw ex;
                }
            
            }
        }
        
        /// <summary>
        /// Method checks if given parameters already exist in DB
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <returns></returns>
        public bool ContactPresent (string firstname, string lastname)
        {
            using (AdressbuchEntities ctx = new AdressbuchEntities())
            {
                var contactPresent = from b in ctx.ContactsTbl
                                     where b.Firstname == firstname && b.Lastname == lastname
                                     select b;
                if (contactPresent.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }



    }
}

