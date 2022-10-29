using Basic_Crud.ViewModels;

namespace Basic_Crud.Models
{
    public class Profile : BaseViewModel
    {
        public int Id { get; set; }
        private string _firstName = string.Empty;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(); }
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; OnPropertyChanged(); }
        }
    }
}
