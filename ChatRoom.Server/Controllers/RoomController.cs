﻿using ChatRoom.Domain.Repository;
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
        [HttpGet]
        [Route("api/Room/GetRoomList")]
        public HttpResponseMessage GetRoomList()
        {
            try
            {
                var queryResult = this.repo.QueryList();

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
        [Route("api/Room/RoomAdd")]
        public HttpResponseMessage RoomAdd([FromBody] string input)
        {
            try
            {
                var addResult = this.repo.Add(input);

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
        [Route("api/Room/RoomDelete")]
        public HttpResponseMessage RoomDelete([FromBody] int input)
        {
            try
            {
                //新增房間
                var deleteResult = this.repo.Delete(input);

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
