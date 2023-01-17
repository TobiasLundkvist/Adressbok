﻿using Adressbok_ConsoleApp.Interfaces;
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

        ReadList();

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

    private void ReadList()
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
                Console.WriteLine("------------------------------------------------------------------------------------");
            }
            else 
            {
                Console.WriteLine("Kontakten finns inte");
            }
        }
        Console.ReadKey();
    }

    private void ShowOneContact()
    {
        Console.Clear();
        Console.WriteLine("Sök efter förnamn: ");
        var FirstNameSearch = Console.ReadLine();


        Contact FoundContact = contacts.Where(x => x.FirstName == FirstNameSearch).FirstOrDefault();
        if(FoundContact != null)
        {
            Console.WriteLine($"Förnamn: {FoundContact.FirstName}");
            Console.WriteLine($"Efternamn: {FoundContact.LastName}");
            Console.WriteLine($"E-postadress: {FoundContact.Email}");
            Console.WriteLine($"Telefonnummer: {FoundContact.PhoneNumber}");
            Console.WriteLine($"Adress: {FoundContact.Address}, {FoundContact.PostalCode} {FoundContact.City}");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Kontakten finns inte");
            Console.ReadKey();
        }
    }

    private void DeleteOneContact()
    {
        Console.Clear();
        Console.WriteLine("Skriv förnamnet på kontakten du vill ta bort: ");
        var FirstNameSearchAndDelete = Console.ReadLine();

        Console.WriteLine("Skriv efternamnet på kontakten du vill ta bort: ");
        var LastNameSearchAndDelete = Console.ReadLine();


        List<Contact> FoundContacts = contacts.Where(x => x.FirstName == FirstNameSearchAndDelete && x.LastName == LastNameSearchAndDelete).ToList();
        
        foreach(var contact in FoundContacts)
        {
            Console.WriteLine($"Är du säker på att du vill ta bort {contact.FirstName} {contact.LastName} från adressboken? (true/false)");
            string answer = Console.ReadLine();
            bool confirm = true;
            if(bool.TryParse(answer, out confirm))
            {
                //Baka in detta i en switch för att få y/n?
                if(confirm)
                {
                    contacts.Remove(contact);
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} har raderats från adressboken");
                }
                else
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName} kvartstår i adressboken");
                }
            }
            else
            {
                Console.WriteLine($"Felaktigt svar! {contact.FirstName} {contact.LastName} har inte blivit bortagen från adressboken");
            }
        }




/*        bool Exist = false;

        for (int i = 0; i < contacts.Count; i++)
        {
            if (contacts[i].FirstName == FirstNameSearchAndDelete)
            {
                Exist = true;
            }
        }

        if (Exist)
        {
            Console.WriteLine($"Vill du ta bort {FirstNameSearchAndDelete} från adressboken(Y/N)?");
            var answer = Console.ReadLine();
            switch (answer.ToLower())
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
        else
        {
            Console.WriteLine("Kontakten finns inte");
        }*/

        file.Save(JsonConvert.SerializeObject(contacts));
        Console.ReadKey();

    }
}
