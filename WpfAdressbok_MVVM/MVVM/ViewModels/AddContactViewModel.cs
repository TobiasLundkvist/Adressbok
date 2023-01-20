using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfAdressbok_MVVM.MVVM.Models;
using WpfAdressbok_MVVM.Services;

namespace WpfAdressbok_MVVM.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();
        }



        [ObservableProperty]
        private string title = "Skapa kontakt";

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string address = string.Empty;

        [ObservableProperty]
        private string postalCode = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;


        [RelayCommand]
        private void Add()
        {
            fileService.AddToList(new ContactModel 
            { 
                FirstName = FirstName, 
                LastName = LastName,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address,
                PostalCode = PostalCode,
                City = City
            });
            ClearField();
        }

        private void ClearField()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
            Address = string.Empty;
            PostalCode = string.Empty;
            City = string.Empty;
        }

    }
}
