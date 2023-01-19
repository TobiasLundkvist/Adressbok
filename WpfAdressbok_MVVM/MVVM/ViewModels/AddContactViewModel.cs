using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAdressbok_MVVM.MVVM.Models;
namespace WpfAdressbok_MVVM.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {


        [ObservableProperty]
        private string title = "Skapa kontakt";

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = null!;

        [ObservableProperty]
        private string email = null!;

        [ObservableProperty]
        private string phoneNumber = null!;

        [ObservableProperty]
        private string address = null!;

        [ObservableProperty]
        private string postalCode = null!;

        [ObservableProperty]
        private string city = null!;

        [RelayCommand]
        private void Add()
        {

        }

    }
}
