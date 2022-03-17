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

        [HttpPost]
        [Route("api/Account/Login")]
        public HttpResponseMessage Post([FromBody] AccountDto input)
        {
            try
            {
                var queryResult = this.repo.Query(input.Account);

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult));
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
