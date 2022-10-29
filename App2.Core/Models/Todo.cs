using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Core.Models
{
    public class Todo : BaseViewModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        private string _title = string.Empty;
        private bool _completed = false;
        public string title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public bool completed
        {
            get { return _completed; }
            set { _completed = value; OnPropertyChanged(); }
        }
    }
}
