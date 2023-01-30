using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAdressbok_MVVM.MVVM.Models;
using WpfAdressbok_MVVM.Services;

namespace WpfAdressbok_MVVM.MVVM.ViewModels
{
    public partial class ContactListViewModel : ObservableObject
    {
        private readonly FileService fileService;


        public ContactListViewModel()
        {
            fileService = new FileService();
            contacts = fileService.Contacts();
        }



        [ObservableProperty]
        private string title = "Addressboken";


        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [ObservableProperty]
        private ContactModel selectedContact = null!;

        [RelayCommand]
        public void Remove()
        {
            var result = MessageBox.Show($"Vill du radera {selectedContact.FirstName} {selectedContact.LastName}?", "Confirm", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                fileService.RemoveFromList(selectedContact);
            }
            

        }

        [RelayCommand]
        public void Update()
        {
            var item = contacts.Where(x => x.FirstName == selectedContact.FirstName).FirstOrDefault();
            if(item != null)
            {
                item.FirstName = selectedContact.FirstName;
                item.LastName = selectedContact.LastName;
                item.Email = selectedContact.Email;
                item.PhoneNumber = selectedContact.PhoneNumber;
                item.Address = selectedContact.Address;
                item.PostalCode = selectedContact.PostalCode;
                item.City = selectedContact.City;
            }
            fileService.SaveToFile();
        }

    }
}
