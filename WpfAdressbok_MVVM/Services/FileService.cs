using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAdressbok_MVVM.MVVM.Models;

namespace WpfAdressbok_MVVM.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
        private ObservableCollection<ContactModel> contacts;

        public FileService()
        {
            ReadFromFile();
        }


        private void ReadFromFile()
        {

            try
            {
                using var sr = new StreamReader(filePath);
                contacts = JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;

            }
            catch { contacts = new ObservableCollection<ContactModel>(); }

        }

        public void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(contacts));
        }

        public void AddToList(ContactModel contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }

        public void RemoveFromList(ContactModel contact) 
        { 
            contacts.Remove(contact);
            SaveToFile();
        }

        public void UpdateList(ContactModel contact)
        {
            contacts.Add(contact);
            SaveToFile();
        }

        public ObservableCollection<ContactModel> Contacts()
        {
            return contacts;
        }
    }
}
