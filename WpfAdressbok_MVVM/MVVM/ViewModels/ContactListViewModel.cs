using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        [RelayCommand]
        private void Delete()
        {
            
        }


    }
}
