using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Repository;
using ChatRoom.Server.Hubs;
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

        private IHubClient hub;

        public AccountController(IAccountRepository repo, IHubClient hub)
        {
            this.repo = repo;

            this.hub = hub;
        }

        //註冊帳號 - CLIENT
        [HttpPost]
        [Route("api/Account/Register")]
        public HttpResponseMessage Register([FromBody] AccountDto input)
        {
            try
            {
                var addResult = this.repo.Add(new Account()
                {
                    f_account = input.Account,
                    f_password = input.Password,
                    f_nickName = input.NickName
                });

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.result));
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
        public HttpResponseMessage Login([FromBody] LoginDto input)
        {
            try
            {
                var queryResult = this.repo.Login(new Account()
                {
                    f_account = input.Account,
                    f_password = input.Password,
                });


                //如果登入成功才廣播訊息
                if (queryResult.result.ResultCode == ResultCode.SUCCESS && queryResult.result.Account != null)
                {
                    this.hub.BroadCastAction(new CheckConnectStateAction()
                    {
                        Account = queryResult.result.Account.f_account,
                        LoginIdentifier = queryResult.result.Account.f_loginIdentifier
                    });
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.result));

                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //更新帳號 - 後台
        [HttpPut]
        [Route("api/Account/Update")]
        public HttpResponseMessage Update([FromBody] Account account)
        {
            try
            {
                var queryResult = this.repo.Update(account);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.account));

                this.hub.BroadCastAction(new UpdateAccountAction()
                {
                    Account = queryResult.account
                }) ;

                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //取得帳號清單 - 後台
        [HttpGet]
        [Route("api/Account/Get")]
        public HttpResponseMessage Get(string account)
        {
            try
            {
                var queryResult = this.repo.Query(account);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.account));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //取得帳號清單 - 後台
        [HttpGet]
        [Route("api/Account/GetList")]
        public HttpResponseMessage GetList()
        {
            try
            {
                var queryResult = this.repo.QueryList();

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
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var deleteResult = this.repo.Delete(id);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(deleteResult.account));

                if (deleteResult.account != null)
                {
                    this.hub.BroadCastAction(new AccountDisconnectAction()
                    {
                        Account = deleteResult.account.f_account,
                    });
                }

                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{id.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
