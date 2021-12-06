using System;
using System.Collections.Generic;
using System.Text;

namespace Zaliczenie
{
    class Admin : Account
    {
        List<Account> listOfUsers = Program.accounts;
        public Admin(string name, string log, string password, bool status, bool isAdmin) : base(name, log, password, status, isAdmin)
        {

        }

        public override void Menu()
        {
            Console.WriteLine("(1) Zablokuj konto");
            Console.WriteLine("(2) Dodaj użytkownika");
            Console.WriteLine("(3) Stwórz podsumowanie");
            Console.WriteLine("(0) Wyloguj");
            choice();
        }
        public override void choice()
        {
            string choice;
            do {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BlockAccount();
                        break;
                    case "2":
                        AddAccount();
                        break;
                    case "3":
                        MakeSummary();
                        break;
                    default:
                        LogOff();
                        break;
                }
            } while (!choice.Equals("0"));
            Program.WelcomeScreen();
            Program.ChooseOption();
        }

        public void BlockAccount()
        {
            string username;
            Console.WriteLine("Które konto chcesz zablokować?");
            username = Console.ReadLine();
            foreach (Account a in listOfUsers)
            {
                if(a.log.Equals(username))
                {
                    a.status = true;
                }
            }
        }

        public void AddAccount()
        {
            string name, username, password;
            Console.WriteLine("Podaj imie:");
            name = Console.ReadLine();
            Console.WriteLine("Podaj login:");
            username = Console.ReadLine();
            Console.WriteLine("Podaj hasło:");
            password = Console.ReadLine();

            listOfUsers.Add(new Account(name, username, password, false, false));
        }

        public void MakeSummary()
        {
            double sum = 0;
            foreach (Account a in listOfUsers)
            {
                if (a == null) continue;
                sum += a.stan;
            }
            Console.WriteLine("Stan: {0}", sum);
        }
    }
}
