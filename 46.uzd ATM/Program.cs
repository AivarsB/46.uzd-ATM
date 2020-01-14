using System;

namespace _46.uzd_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            var atm = new ATM((1000));      // piešķīrām sākotnējo vērtību
            //{
            //    AmountAvailable = 1000      
            //};

            atm.Accounts.Add(new CustomerAccount()
            {
                Number = "1111",
                Balance = 500
            });

            atm.Accounts.Add(new CustomerAccount()
            {
                Number = "2222",
                Balance = 199
            });

            atm.Accounts.Add(new CustomerAccount()
            {
                Number = "3333",
                Balance = 10
            });

            while (true)
            {
                Process(atm);
            }

        }

        private static void Process(ATM atm)                // ar Alt+Enter pārceļ risinājumu uz metodi
        {
            Console.WriteLine("Enter account number:");
            var accountNumber = Console.ReadLine();

            if (atm.CheckIfAccountExists(accountNumber))
            {
                Console.WriteLine("Please enter amount:");
                var amount = int.Parse(Console.ReadLine());

                Console.WriteLine(atm.GetMoney(amount, accountNumber));

            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }
    }
}
