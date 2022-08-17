using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.UI.Models
{
    public class ContactCompleteModel
    {
        public bool Selected { get; set; }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string Street { get; set; }
        public int Housenumber { get; set; }
        public string Adressadd { get; set; }
        public int Postcode { get; set; }
        public string Location  { get; set; }
        public int TelNum1 { get; set; }
        public int TelNum2 { get; set; }
        public int TelNum3 { get; set; }
        public string Email { get; set; }
    }
}
