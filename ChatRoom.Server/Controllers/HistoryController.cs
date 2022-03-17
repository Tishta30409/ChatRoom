using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.Server.Controllers
{
    public class HistoryController: ApiController
    {
        private ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        private IHistoryRepository repo;

        public HistoryController(IHistoryRepository repo)
        {
            this.repo = repo;
        }

        //要求10筆歷史資料
        [HttpPost]
        [Route("api/History/GetList")]
        public HttpResponseMessage Post([FromBody] int roomID)
        {
            try
            {
                var queryResult = this.repo.QueryList(roomID);

                if (queryResult.exception != null)
                {
                    throw queryResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(JsonConvert.SerializeObject(queryResult.historys)));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{roomID.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                throw;
            }

        }
    }
}
