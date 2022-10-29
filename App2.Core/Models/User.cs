using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Core.Models
{
    public class User : BaseViewModel
    {
        public int id { get; set; }
        private string _name = string.Empty;
        private string _phone = string.Empty;
        public string name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
        }
        public string phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
    }
}
