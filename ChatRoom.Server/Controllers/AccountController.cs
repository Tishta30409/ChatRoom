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
        [Route("api/Account/AccountRegister")]
        public HttpResponseMessage AccountRegister([FromBody] AccountDto input)
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
        public HttpResponseMessage Login([FromBody] LoginDto input)
        {
            try
            {
                var queryResult = this.repo.Login(new Login()
                {
                    f_account = input.Account,
                    f_password=input.Password,
                });

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.login));

                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //取得帳號清單 - 後台
        [HttpGet]
        [Route("api/Account/GetAccountList")]
        public HttpResponseMessage GetAccountList()
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
        [Route("api/Account/AccountDelete")]
        public HttpResponseMessage AccountDelete(int input)
        {
            try
            {
                var deleteResult = this.repo.Delete(input);

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
