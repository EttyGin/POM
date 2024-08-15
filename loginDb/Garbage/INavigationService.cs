using loginDb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginDb.Models
{
    public interface INavigationService
    {
        void NavigateTo(ViewModelBase viewModel);
    }

    public class NavigationService : INavigationService
    {
        private readonly MainViewModel _mainViewModel;

        public NavigationService(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        public void NavigateTo(ViewModelBase viewModel)
        {
            _mainViewModel.CurrentChildView = viewModel;
        }
    }

}
