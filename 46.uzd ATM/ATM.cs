using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _46.uzd_ATM
{
    public class ATM
    {

        public ATM(int initialAmountAvailble)   // konstruktors, ar ko ļauj ielikt pirmo naudu atm
        {
            AmountAvailable = initialAmountAvailble;
        }
        public int AmountAvailable { get; private set; }     // iekapsulēšana set (privāts seteris), lai no ārpuses nevar nomainīt vērtību
        public List<CustomerAccount> Accounts { get; set; } = new List<CustomerAccount>();

        public bool CheckIfAccountExists(string number)
        {
            foreach (var account in Accounts)
            {
                if (account.Number == number)
                {
                    return true;
                }
            }
            return false;
        }

        public string GetMoney(int amount, string number)
        {
            // LINQ
            var account = Accounts.FirstOrDefault(a => a.Number == number);    // jāpievieno Linq, palīdz ātrāk atrast kaut ko sarakstā, šis saucās Land expression

            // LINQ vietā varēja šo risinājumu
            //CustomerAccount custAccount;
            //foreach (var a in Accounts)
            //{
            //    if (a.Number == number) 
            //    {
            //        custAccount = a;
            //        break;
            //    }
            //}

            if (account != null)
            {
                if (AmountAvailable < amount)
                {
                    return "System error";      // te būtu jāraksta ka bankomātā nav naudas
                }

                if (account.Balance >= amount)
                {
                    AmountAvailable -= amount;      // noņem nost no bankomāta pieejamo naudas daudzumu
                    account.Balance -= amount;      // noņem no konta izņemto naudas daudzumu
                    return $"Take your {amount}";
                }
                else
                {
                    return "Not enough funds";
                }
            }
            else
            {
                return "Account does not exist";
            }

        }


    }
}
