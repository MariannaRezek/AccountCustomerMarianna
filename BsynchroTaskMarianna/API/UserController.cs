using BsynchroTaskMarianna.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BsynchroTaskMarianna.API
{
    public class UserController : ApiController
    {
        private readonly AccountService _accountService;

        public UserController(AccountService accountService)//, UserService userService)
        {
            _accountService = accountService;
            // _userService = userService;
        }

        [HttpPost]
        public UserAccount openAccount(string customerId, double initialCredit)
        {
            var account = _accountService.OpenAccount(customerId, initialCredit);

            // Return the newly created account
            return account;
        }





        [HttpGet]
        public UserAccount GetUserAccountInfo(string accountId)
        {

            var acc = _accountService.GetAccountInfo(accountId);
            return acc;
        }
    }
}