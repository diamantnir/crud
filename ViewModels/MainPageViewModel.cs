using App2.Core.Models;
using App2.Core.Services;
using Basic_Crud.Models;
using Basic_Crud.Views;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Basic_Crud.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand UserInfoCommand { get; set; }
        public ICommand EditUserCommand { get; set; }
        public ICommand DeleteUserCommand { get; set; }
        public ICommand UpdateUserCommand { get; set; }
        private bool _isOpen = false;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; OnPropertyChanged(); }
        }
        private User _selectedUser = new User();
        public User SelectedUser
        {
            get { return _selectedUser; }
            set { _selectedUser = value; OnPropertyChanged(); }
        }

        public MainPageViewModel()
        {
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            Users = new ObservableCollection<User>();
            UserInfoCommand = new RelayCommand<int>(ShowUser);
            EditUserCommand = new RelayCommand<int>(EditUser);
            DeleteUserCommand = new RelayCommand<int>(OnDeleteUser);
            UpdateUserCommand = new RelayCommand(OnUpdateUser);
            LoadUsers();
        }

        private void OnUpdateUser()
        {
            IsOpen = false;
            var id = SelectedUser.id;
            var name = SelectedUser.name;
            var phone = SelectedUser.phone;
            Users.First(x => x.id == SelectedUser.id).name = SelectedUser.name;
            Users.First(x => x.id == SelectedUser.id).phone = SelectedUser.phone;
        }

        private void EditUser(int id)
        {
            IsOpen = true;
            SelectedUser = Users.First(x => x.id == id);
        }

        private void OnDeleteUser(int id)
        {
            Users.Remove(Users.First(x => x.id == id));
        }

        private void ShowUser(int id)
        {
            var user = Users.First(x => x.id == id);
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(InfoPage), user);
        }

        private async void LoadUsers()
        {
            var data = await DataService.GetGridDataUsersAsync();

            foreach (var item in data)
            {
                Users.Add(item);
            }
        }
    }
}
