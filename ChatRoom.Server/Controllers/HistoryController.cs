using ChatRoom.Domain.Model.DataType;
using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
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
        [HttpGet]
        [Route("api/History/GetList")]
        public HttpResponseMessage GetList(int roomID)
        {
            try
            {
                var queryResult = this.repo.QueryList(roomID);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.historys));
                var test = JsonConvert.DeserializeObject<IEnumerable<History>>(result.Content.ReadAsStringAsync().Result);
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Get Exception Request:{roomID.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
