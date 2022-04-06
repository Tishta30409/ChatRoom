using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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

        public (Exception exception, ResultCode result) Register(AccountDto account)
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
                return ((null, JsonConvert.DeserializeObject<ResultCode>(result)));
            }
            catch (Exception ex)
            {
                return (ex, ResultCode.DEFAULT_ERROR);
            }
        }

        public (Exception exception, Account account) ChangePwd(AccountDto account)
        {
            try
            {
                var content = new StringContent(account.ToString(), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route + "/ChangePwd", content).Result;

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

        

        public (Exception exception, AccountResult result) Update(Account account)
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
                return ((null, JsonConvert.DeserializeObject<AccountResult>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        /// <summary>
        /// 取得帳號資料
        /// </summary>
        /// <returns></returns>
        public (Exception exception, Account account) Query(string account)
        {
            try
            {
                var response = this.client.GetAsync($"{this.route}/Get?account={account}").Result;

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

        /// <summary>
        /// 取得帳號清單
        /// </summary>
        /// <returns></returns>
        public (Exception exception, IEnumerable<Account> accounts) QueryList()
        {
            try
            {
                var response = this.client.GetAsync($"{this.route}/GetList").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<IEnumerable<Account>>(result)));
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
                var response = this.client.DeleteAsync($"{this.route}/Delete?id={id}").Result;

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




    }
}
