using System;
using System.Collections.Generic;

namespace Zaliczenie
{
    class Program
    {
        public static List<Account> accounts = new List<Account>();
        static void Main(string[] args)
        {
            accounts.Add(new Account("Janusz", "user1", "user1", false, false));
            accounts.Add(new Admin("Adam", "admin", "admin", false, true));
            accounts.Add(new Account("Marian", "user2", "user2", false, false));
            accounts.Add(new Account("Lucjan", "user3", "user3", false, false));

            WelcomeScreen();
            ChooseOption();
        }
               
        public static void WelcomeScreen()
        {
            Console.WriteLine("Witaj w aplikacji bankowej");
            Console.WriteLine("(1) Logowanie");
            Console.WriteLine("(0) Zamknij");
        }

        public static void ChooseOption()
        {
            string choose = Console.ReadLine();

            switch(choose)
            {
                case "1":
                    Logon();
                    break;
                case "0":
                    Console.WriteLine("Do widzenia");
                    break;
                default:
                    Console.WriteLine("Zła opcja");
                    break;
            }
        }

        public static void Logon()
        {
            string login, haslo;
            bool found = false;
            Account account = null;

            Console.WriteLine("Podaj login:");
            login = Console.ReadLine();
            Console.WriteLine("Podaj haslo:");
            haslo = Console.ReadLine();

            foreach(Account a in accounts)
            {
                if (a == null) continue;
                if(a.log.Equals(login))
                {
                    if(a.password.Equals(haslo))
                    {
                        account = a;
                        if (!a.status) { 
                            account.isLoggged = true;
                            found = true;
                        }
                        break;
                    }
                }
            }

            if(found)
            {
                account.Menu();
            }
            else
            {
                Console.WriteLine("Zły login lub hasło");
            }
        }

    }
}