using ChatRoom.Domain.Action;
using ChatRoom.Domain.Model.DataType;
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
    public class UserRoomController : ApiController
    {
        private ILogger logger = LogManager.GetLogger("ChatRoom.Server");

        private IUserRoomRepository repo;

        private IHubClient hubClient;

        public UserRoomController(IUserRoomRepository repo, IHubClient hubClient)
        {
            this.repo = repo;
            this.hubClient = hubClient;
        }

        //加入房間
        [HttpPost]
        [Route("api/UserRoom/JoinRoom")]
        public HttpResponseMessage JoinRoom([FromBody] UserRoom userRoom)
        {
            try
            {
                var addResult = this.repo.JoinRoom(userRoom);

                if (addResult.userRoom != null)
                {
                    //通知更新列表
                    this.hubClient.BroadCastAction(new UpdateRoomUsersAction() 
                    { 
                        IsJoin = true,
                        UserRoom = userRoom,
                    });
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.userRoom));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request:{userRoom?.f_roomID.ToString()}");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete]
        [Route("api/UserRoom/LeaveRoom")]
        public HttpResponseMessage LeaveRoom(string account)
        {
            try
            {
                var deleteResult = this.repo.LeaveRoom(account);

                if (deleteResult.userRoom != null)
                {
                    //通知更新列表
                    this.hubClient.BroadCastAction(new UpdateRoomUsersAction()
                    {
                        IsJoin = false,
                        UserRoom = deleteResult.userRoom,
                    });
                }

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(deleteResult.userRoom));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/UserRoom/Query")]
        public HttpResponseMessage Query(string account)
        {
            try
            {
                var addResult = this.repo.Query(account);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.userRoom));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("api/UserRoom/QueryList")]
        public HttpResponseMessage QueryList(int roomID)
        {
            try
            {
                var addResult = this.repo.QueryList(roomID);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(addResult.userRooms));
                return result;
            }
            catch (Exception ex)
            {
                this.logger.Error(ex, $"{this.GetType().Name} Post Exception Request");
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
