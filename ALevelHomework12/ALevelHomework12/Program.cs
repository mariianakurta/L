using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALevelHomework12;

class Program
{
    static void Main()
    {
        PhoneContacts subscribersСontents = new PhoneContacts();


        subscribersСontents.AddContacts(new Contacts { Name = "A", PhoneNumber = "+44123456789" });
        subscribersСontents.AddContacts(new Contacts { Name = "B", PhoneNumber = "+44234567890" });
        subscribersСontents.AddContacts(new Contacts { Name = "C", PhoneNumber = "+44345678901" });

        subscribersСontents.AddContacts(new Contacts { Name = "hello" });
        subscribersСontents.AddContacts(new Contacts { Name = "good" });
        subscribersСontents.AddContacts(new Contacts { Name = "morning" });

        subscribersСontents.AddContacts(new Contacts { Name = "1 A", PhoneNumber = "+12345678901" });
        subscribersСontents.AddContacts(new Contacts { Name = "2 B", PhoneNumber = "+55432109876" });
        subscribersСontents.AddContacts(new Contacts { Name = "3 C", PhoneNumber = "+81987654321" });

        subscribersСontents.AddContacts(new Contacts { Name = "А", PhoneNumber = "+380987654321" });
        subscribersСontents.AddContacts(new Contacts { Name = "Б", PhoneNumber = "+380987654322" });
        subscribersСontents.AddContacts(new Contacts { Name = "В", PhoneNumber = "+380983659322" });



        subscribersСontents.DisplayNumbers();
    }
}
