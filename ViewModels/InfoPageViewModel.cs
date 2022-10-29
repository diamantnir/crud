using App2.Core.Models;
using App2.Core.Services;
using Basic_Crud.Models;
using Basic_Crud.Views;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Uwp.UI.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Basic_Crud.ViewModels
{
    public class InfoPageViewModel : BaseViewModel
    {
        private User _user = new User();
        public User User
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

       

        public ICommand BackCommand { get; set; }
        public InfoPageViewModel()
        {
            BackCommand = new RelayCommand(OnNavigateBack);

            Todos = new ObservableCollection<Todo>();
            EditTodoCommand = new RelayCommand<int>(EditTodo);
            DeleteTodoCommand = new RelayCommand<int>(OnDeleteTodo);
        }

      




        private void OnNavigateBack()
        {
            var rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }
        public async void OnLoadTodos(DataGrid myDataGrid)
        {
            var data = await DataService.GetGridDataTodosAsync(User.id);
            Todos.Clear();
            foreach (var item in data)
            {
                Todos.Add(item);
            }
            myDataGrid.ItemsSource = null;
            myDataGrid.ItemsSource = Todos;
        }




        public static ObservableCollection<Todo> Todos { get; set; }
        public ICommand EditTodoCommand { get; set; }
        public ICommand DeleteTodoCommand { get; set; }
        public ICommand UpdateTodoCommand { get; set; }
        private bool _isOpen = false;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { _isOpen = value; OnPropertyChanged(); }
        }
        private Todo _selectedTodo = new Todo();
        public Todo SelectedTodo
        {
            get { return _selectedTodo; }
            set { _selectedTodo = value; OnPropertyChanged(); }
        }

       

     

        private void EditTodo(int id)
        {
            IsOpen = true;
            SelectedTodo = Todos.First(x => x.id == id);
        }

        private void OnDeleteTodo(int id)
        {
            Todos.Remove(Todos.First(x => x.id == id));
        }

      

        
    }
}
