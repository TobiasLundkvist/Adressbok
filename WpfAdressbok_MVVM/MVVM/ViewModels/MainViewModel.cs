using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAdressbok_MVVM.MVVM.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableObject currentViewModel;

        [RelayCommand]
        private void GoToAddContact()
        {
            CurrentViewModel = new AddContactViewModel();
        }

        [RelayCommand]
        private void GoToContactList()
        {
            CurrentViewModel = new ContactListViewModel();
        }

        public MainViewModel()
        {
            CurrentViewModel = new ContactListViewModel();
        }



    }
}
