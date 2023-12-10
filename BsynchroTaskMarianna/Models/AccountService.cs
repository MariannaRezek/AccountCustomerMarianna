using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BsynchroTaskMarianna.Models
{
    public class AccountService
    {
        //private readonly string _jsonFilePath = "/Database/useraccounts.json";
        private readonly string _jsonFilePath = "C:\\Users\\User\\source\\repos\\BsynchroTaskMarianna\\BsynchroTaskMarianna\\Database\\useraccounts.json";
        
        public UserAccount GetAccountInfo(string accountId)
        {
            var accounts = LoadAccountsFromJson();

            var account = accounts.FirstOrDefault(a => a.Id == accountId);

            if (account == null)
            {
                // Account not found
                return null;
            }
           
            return account;
        }


        public UserAccount OpenAccount(string customerId, double initialCredit)
        {
            var accounts = LoadAccountsFromJson();

            var existingAccount = accounts.FirstOrDefault(a => a.CustomerId == customerId);
            if (existingAccount != null)
            {
                if (initialCredit != 0)
                {
                    // Add a transaction to the existing account
                    var transaction = new Transaction
                    {
                        TransactionId = Guid.NewGuid().ToString(),
                        Amount = initialCredit
                    };

                    existingAccount.Transactions.Add(transaction);
                    existingAccount.Balance += initialCredit; // Update the balance
                    SaveAccountsToJson(accounts);
                }

                return existingAccount;
            }

            var newAccount = new UserAccount
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = customerId,
                Balance = initialCredit,
                Transactions = new List<Transaction>()
            };

            if (initialCredit != 0)
            {
                var initialTransaction = new Transaction
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    Amount = initialCredit
                };

                newAccount.Transactions.Add(initialTransaction);
            }

            accounts.Add(newAccount);

            SaveAccountsToJson(accounts);

            return newAccount;
        }

        private void SaveAccountsToJson(List<UserAccount> accounts)
        {
            try
            {
                var json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
                File.WriteAllText(_jsonFilePath, json);
            }
            catch (Exception ex)
            {
                // Handle file write or serialization errors
                Console.WriteLine($"Error saving accounts to JSON file: {ex.Message}");
            }
        }

        private List<UserAccount> LoadAccountsFromJson()
        {
            try
            {
                var json = File.ReadAllText(_jsonFilePath);
                var accounts = JsonConvert.DeserializeObject<List<UserAccount>>(json);

                return accounts ?? new List<UserAccount>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading accounts from JSON file: {ex.Message}");
                return null;
            }
        }
   
    }
}