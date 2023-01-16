using Adressbok_ConsoleApp.Interfaces;
using Adressbok_ConsoleApp.Models;
using Newtonsoft.Json;

namespace Adressbok_ConsoleApp.Services;

internal class MenuManager
{
    private List<Contact> contacts = new List<Contact>();

    private FileService file = new FileService();


    public void AddressBookMenu()
    {
        file.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

        TestLista();

        Console.WriteLine(" \nVälkommen till Adressboken \n");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en Specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        
        Console.Write(" \nVälj ett av alternativen ovan: ");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1":
                CreateContact();
                break; 

            case "2":
                ShowAllContacts();
                break;

            case "3":
                ShowOneContact();
                break;

            case "4":
                DeleteOneContact();
                break;
        }

    }

    private void TestLista()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<List<Contact>>(file.Read());
            if(items != null)
                contacts = items;
        }
        catch { }
    }

    // Create Contact
    private void CreateContact()
    {
        Console.Clear();
        Console.WriteLine("Skapa en kontakt: ");

        Contact contact = new Contact();
        Console.WriteLine("Förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine("Efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.WriteLine("E-postadress: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.WriteLine("Mobilnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.WriteLine("Adress: ");
        contact.Address = Console.ReadLine() ?? "";
        Console.WriteLine("Postnummer: ");
        contact.PostalCode = Console.ReadLine() ?? "";
        Console.WriteLine("Ort: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);

        file.Save(JsonConvert.SerializeObject(contacts));
    }

    // Show All contacts
    private void ShowAllContacts()
    {
        Console.Clear();
        foreach(Contact contact in contacts)
        {
            if(contacts != null)
            {
                Console.WriteLine($"Förnamn: {contact.FirstName}");
                Console.WriteLine($"Efternamn: {contact.LastName}");
                Console.WriteLine($"E-postadress: {contact.Email} \n");
            }
            else 
            {
                Console.WriteLine("Finns inga kontakter");
            }

        }
        Console.ReadKey();
    }

    private void ShowOneContact()
    {
        Console.Clear();

        Console.WriteLine("Sök efter förnamn: ");
        var FirstNameSearch = Console.ReadLine();

        foreach(Contact contact in contacts)
        {
            if (FirstNameSearch == contact.FirstName)
            {
                Console.WriteLine($"Förnamn: {contact.FirstName}");
                Console.WriteLine($"Efternamn: {contact.LastName}");
                Console.WriteLine($"E-postadress: {contact.Email}");
                Console.WriteLine($"Telefonnummer: {contact.PhoneNumber}");
                Console.WriteLine($"Adress: {contact.Address}, {contact.PostalCode} {contact.City}");

                Console.ReadKey();
            }
            else
                Console.WriteLine("Finns ingen kontakt med det förnamnet");
        }
    }

    private void DeleteOneContact()
    {
        Console.Clear();
        Console.WriteLine("Skriv förnamnet på kontakten du vill ta bort: ");
        var FirstNameSearchAndDelete = Console.ReadLine();

        for(int i = 0; i < contacts.Count; i++)
        {
            if(contacts[i].FirstName == FirstNameSearchAndDelete)
            {
                Console.WriteLine($"Vill du ta bort {FirstNameSearchAndDelete} från adressboken(Y/N)?");
                var answer = Console.ReadLine();
                switch(answer.ToLower())
                {
                    case "y":
                        contacts.RemoveAll(v => v.FirstName == FirstNameSearchAndDelete);
                        Console.WriteLine($"{FirstNameSearchAndDelete} är borttagen");
                        break;
                    case "n":
                        Console.WriteLine("Kontakten kvarstår i adressboken");
                        break; 
                    default: 
                        Console.WriteLine("Något gick fel");
                        break;
                };

            }
            else if(contacts[i].FirstName != FirstNameSearchAndDelete)
            {
                Console.WriteLine("Kontakten finns inte");
            }
        }
        file.Save(JsonConvert.SerializeObject(contacts));
        Console.ReadKey();

        /*        foreach (Contact contact in contacts)
                {
                    if (FirstNameSearchAndDelete == contact.FirstName)
                    {
                        Console.WriteLine($"Vill du ta bort {contact.FirstName} {contact.LastName} från adressboken (Y/N)?");
                        var answer = Console.ReadLine();
                        if (answer == "y")
                        {
                            contacts.Remove(contact);
                        }
                        else if (answer == "n")
                        {
                            Console.WriteLine("Kontakten kvarstår i Adressboken");
                        }
                    }

                }*/


        /*        contacts.RemoveAll(v => v.FirstName == FirstNameSearchAndDelete);*/


        /*        List<Contact> contactToRemove = new List<Contact>();

                foreach(Contact contact in contacts)
                {
                    if(contact.FirstName == FirstNameSearchAndDelete)
                    {
                        contactToRemove.Add(contact);
                        Console.WriteLine(contactToRemove.Count);
                    }

                }

                foreach(Contact contact in contactToRemove)
                {
                    contacts.Remove(contact);
                }
                Console.WriteLine(contacts.Count);*/

    }

}
