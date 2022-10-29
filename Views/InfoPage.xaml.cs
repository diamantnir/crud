using App2.Core.Models;
using Basic_Crud.Models;
using Basic_Crud.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Basic_Crud.Views
{
    public sealed partial class InfoPage : Page
    {
        InfoPageViewModel viewModel;
        public InfoPage()
        {
            this.InitializeComponent();
            viewModel = new InfoPageViewModel();
            DataContext = viewModel;
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                viewModel.User = e.Parameter as User;

            viewModel.OnLoadTodos(myDataGrid);

        }
    }
}
