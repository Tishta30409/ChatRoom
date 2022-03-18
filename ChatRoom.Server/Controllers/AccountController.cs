using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.Server.Controllers
{
    public class AccountController : ApiController
    {
        private ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        private IAccountRepository repo;

        public AccountController(IAccountRepository repo)
        {
            this.repo = repo;
        }

        //註冊帳號 - CLIENT
        [HttpPost]
        [Route("api/Account/Register")]
        public HttpResponseMessage Post([FromBody] AccountDto input)
        {
            try
            {
                var addResult = this.repo.Add(new Account()
                {
                    f_account = input.Account,
                    f_password = input.Password,
                    f_nickName = input.NickName
                });

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }


                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.account));
                return result;
               
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //帳號登入 - CLIENT
        [HttpPost]
        [Route("api/Account/Login")]
        public HttpResponseMessage Post([FromBody] LoginDto input)
        {
            try
            {
                var queryResult = this.repo.Query(input.Account);

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);

                switch (queryResult.account.f_state)
                {
                    case AccountState.Locked:
                        result.Content = new StringContent(JsonConvert.SerializeObject(
                            new LoginDto()
                            { 
                                result = AccountResult.ACCOUNT_LOCKED,
                            }));
                        break;
                    default:
                        if(queryResult.account.f_password == input.Password)
                        {
                            result.Content = new StringContent(JsonConvert.SerializeObject(
                            new LoginDto()
                            {
                                result = AccountResult.SUCCESS,
                                data = queryResult.account
                            }));
                        }
                        else
                        {
                            //累積錯誤次數 失敗三次就修改帳號狀態
                            queryResult.account.f_errorTimes += 1;
                            if(queryResult.account.f_errorTimes >= 3)
                            {
                                queryResult.account.f_state = AccountState.Locked;
                            }
                            this.repo.Update(queryResult.account);

                            result.Content = new StringContent(JsonConvert.SerializeObject(
                            new LoginDto()
                            {
                                result = AccountResult.WORNG_PASSWORD,
                            })) ;
                        }
                        break;
                }

                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //取得帳號清單 - 後台
        [HttpPost]
        [Route("api/Account/GetList")]
        public HttpResponseMessage Post()
        {
            try
            {
                var queryResult = this.repo.QueryList();

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.accounts));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //刪除帳號 -client
        [HttpDelete]
        [Route("api/Account/Delete")]
        public HttpResponseMessage Delete(int input)
        {
            try
            {
                var deleteResult = this.repo.Delete(input);

                if (deleteResult.exception != null)
                {
                    throw deleteResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(deleteResult.account));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
