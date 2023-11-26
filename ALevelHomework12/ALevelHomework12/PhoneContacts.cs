using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALevelHomework12
{
    public class PhoneContacts
{
    private Dictionary<string, List<Contacts>> contactsLists;

    public PhoneContacts()
    {
        contactsLists = new Dictionary<string, List<Contacts>>();
        NumbersSection();
    }

    private void NumbersSection()
    {
        contactsLists["English"] = new List<Contacts>();
        contactsLists["#"] = new List<Contacts>();
        contactsLists["Number"] = new List<Contacts>();
        contactsLists["Ukrainian"] = new List<Contacts>();
    }

    public void AddContacts(Contacts contact)
    {
        if (char.IsDigit(contact.Name.FirstOrDefault()))
        {
            contactsLists["Number"].Add(contact);
        }
        else if (EnglishNumber(contact.Name.FirstOrDefault()))
        {
            contactsLists["English"].Add(contact);
        }
        else if (UkrainianNumber(contact.Name.FirstOrDefault()))
        {
            contactsLists["Ukrainian"].Add(contact);
        }
        else
        {
            contactsLists["#"].Add(contact);
        }
    }

    private bool EnglishNumber(char example)
    {
        return (example >= 'A' && example <= 'Z') || (example >= 'a' && example <= 'z');
    }

    private bool UkrainianNumber(char secondExample)
    {
        return (secondExample >= 'А' && secondExample <= 'Я') || (secondExample >= 'а' && secondExample <= 'я');
    }

    public void DisplayNumbers()
    {
        ShowPhone("English Contacts", "English");
        ShowPhone("#", "#");
        ShowPhone("International Contacts", "Number");
        ShowPhone("Ukrainian Contacts", "Ukrainian");
    }

    private void ShowPhone(string phoneName, string spreadsheet)
    {
        var contacts = contactsLists[spreadsheet];

        Console.WriteLine($"{phoneName}:");

        if (contacts.Count == 0)
        {
            if (spreadsheet != "#" && spreadsheet != "Number")
            {
                Console.WriteLine("This spreadsheet does not contain any information.");
            }
        }
        else
        {
            Console.WriteLine("Name\t\tPhone Number");

            Console.WriteLine("----------------------------");

            foreach (var contact in contacts)
            {
                if (spreadsheet == "#")
                {
                    Console.WriteLine($"{contact.Name}");
                }
                else
                {
                    Console.WriteLine($"{contact.Name.PadRight(15)}{contact.PhoneNumber}");
                }
            }
            Console.WriteLine();
        }
    }
}

}
