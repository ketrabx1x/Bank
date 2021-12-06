using System;
using System.Collections.Generic;
using System.Text;

namespace Zaliczenie
{
    class Account
    {
        public string log, password;
        public string name;
        public bool status;
        public double stan = 0;
        public bool isAdmin;
        public bool isLoggged;

        public Account(string name, string log, string password, bool status, bool isAdmin)
        {
            this.log = log;
            this.password = password;
            this.name = name;
            this.status = status;
            this.isAdmin = isAdmin;
        }

        public virtual void Menu()
        {
            Console.WriteLine("(1) Wpłać pieniądze");
            Console.WriteLine("(2) Wypłać pieniądze");
            Console.WriteLine("(3) Wygeneruj podsumowanie");
            Console.WriteLine("(4) Zrób przelew");
            Console.WriteLine("(0) Wyloguj");
            choice();
        }

        public virtual void choice()
        {
            string choice;
            do
            {
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMoney();
                        break;
                    case "2":
                        GetMoney();
                        break;
                    case "3":
                        Console.WriteLine(this);
                        break;
                    case "4":
                        Console.WriteLine("Wpisz nazwę komputera do któego chcesz przesłac pieniądze");
                        string accountName = Console.ReadLine();
                        Console.WriteLine("Ile chcesz przelać?");
                        int money = Int32.Parse(Console.ReadLine());
                        MakeTransfer(accountName, money);
                        break;
                    default:
                        LogOff();
                        break;
                }
            } while (!choice.Equals("0"));
            Program.WelcomeScreen();
            Program.ChooseOption();


        }

        private void AddMoney()
        {
            if (isLoggged)
            {
                Console.WriteLine("Ile pieniędzy chcesz wpłacić");
                int money = Int32.Parse(Console.ReadLine());
                stan += money;
            }
        }

        private void GetMoney()
        {
            if (isLoggged)
            {
                Console.WriteLine("Ile pieniędzy chcesz wypłacić");
                int money = Int32.Parse(Console.ReadLine());
                stan -= money;
            }
        }
        private void MakeTransfer(string nr, int money)
        {
            stan -= money;
        }

        public void LogOff()
        {
            isLoggged = false;

        }

        public override string ToString()
        {
            return $"Imię: {name}, Stan konta: {stan}";
        }
    }
}