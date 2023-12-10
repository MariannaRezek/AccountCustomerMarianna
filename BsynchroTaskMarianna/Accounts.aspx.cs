using BsynchroTaskMarianna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BsynchroTaskMarianna
{
    public partial class Accounts : System.Web.UI.Page
    {
        private readonly AccountService _accountService = new AccountService();

        protected void btnOpenAccount_Click(object sender, EventArgs e)
        {
            string customerId = txtCustomerId.Text;
            double initialCredit = Convert.ToDouble(txtInitialCredit.Text);

            var account = _accountService.OpenAccount(customerId, initialCredit);

            if (account != null)
            {
                lblResult.Text = $"Account opened successfully. Account ID: {account.Id}, Balance: {account.Balance}, Name : {account.Name}, Surname: {account.SurName}";
            }
            else
            {
                lblResult.Text = $"Account for customer {customerId} already exists.";
            }
        }

        protected void btnGetAccountInfo_Click(object sender, EventArgs e)
        {
            string accountId = txtAccountId.Text;

            var account = _accountService.GetAccountInfo(accountId);

            if (account != null)
            {
                lblResult.Text = $"Account Information - Account ID: {account.Id}, Customer ID: {account.CustomerId}, Balance: {account.Balance}, Name : {account.Name}, Surname: {account.SurName}";
            }
            else
            {
                lblResult.Text = $"Account not found for ID: {accountId}";
            }
        }
    }

}