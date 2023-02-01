using Adressbok_ConsoleApp.Models;
using Adressbok_ConsoleApp.Services;

namespace WpfAdressbook_Tests
{
    public class Adressbok_ConsoleApp_Tests
    {
        private MenuManager menuManager;
        Contact contact;

        public Adressbok_ConsoleApp_Tests()
        {
            menuManager = new MenuManager();
            contact = new Contact();
        }

        [Fact]
        public void Should_Add_Contact_To_List() 
        { 
            menuManager.contacts.Add(contact);
            menuManager.contacts.Add(contact);

            Assert.Equal(2, menuManager.contacts.Count);
        }
    }
}
