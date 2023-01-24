using FluentAssertions;
using System.Collections.ObjectModel;
using WpfAdressbok_MVVM.MVVM.Models;
using WpfAdressbok_MVVM.MVVM.ViewModels;

namespace WpfAdressbook_Tests
{
    public class ContactListViewModel_Tests
    {
        private ContactListViewModel contactListViewModel;

        public ContactListViewModel_Tests()
        {
            contactListViewModel = new ContactListViewModel();
        }

        [Fact]
        public void Add_Contact_To_AddressBook()
        {
            // act
            ContactModel contact = new ContactModel();
            contactListViewModel.Contacts.Add(contact);

            // arrange
            contactListViewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();
        }
    }
}