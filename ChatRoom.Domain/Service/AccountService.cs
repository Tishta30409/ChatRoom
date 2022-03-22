﻿using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Service
{
    public class AccountService : IAccountService
    {
        private HttpClient client;

        private string route = @"/api/Account";

        public AccountService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {

                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, AccountResult result) Login(LoginDto login)
        {
            try
            {
                var content = new StringContent(login.ToString(), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route + "/Login", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<AccountResult>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, AccountResult result) Register(AccountDto account)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route + "/Register", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<AccountResult>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Update(Account account)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(account), Encoding.UTF8, "application/json");
                var response = this.client.PutAsync(this.route + "/Update", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Account>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Query(string account)
        {
            try
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Account> accounts) QueryList()
        {
            try
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Account account) Delete(int id)
        {
            try
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }




    }
}