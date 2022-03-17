using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChatRoom.Server.Controllers
{
    public class RoomController: ApiController
    {
        private ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        private IRoomRepository repo;

        public RoomController(IRoomRepository repo)
        {
            this.repo = repo;
        }

        //取得房間列表-client
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
                result.Content = new StringContent(JsonConvert.SerializeObject(queryResult.rooms));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //新增房間-後台
        [HttpPost]
        [Route("api/Account/Add")]
        public HttpResponseMessage Post([FromBody] string input)
        {
            try
            {
                var addResult = this.repo.Add(input);

                if (addResult.exception != null)
                {
                    throw addResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.room));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{input.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        //刪除房間-後台
        [HttpDelete]
        [Route("api/Account/Delete")]
        public HttpResponseMessage Delete([FromBody] int input)
        {
            try
            {
                //新增房間
                var deleteResult = this.repo.Delete(input);

                if (deleteResult.exception != null)
                {
                    throw deleteResult.exception;
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(deleteResult.room));
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
