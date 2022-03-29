using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using ChatRoom.Domain.Model.DataType.Tsql;
using ChatRoom.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Service
{
    public class UserRoomService : IUserRoomService
    {
        private HttpClient client;

        private string route = @"/api/UserRoom";

        public UserRoomService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {

                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, UserRoom userRoom) JoinRoom(UserRoom userRoom)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(userRoom), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route + "/JoinRoom", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<UserRoom>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, UserRoom userRoom) LeaveRoom(string account)
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
                return ((null, JsonConvert.DeserializeObject<UserRoom>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable< UserRoom> userRooms) QueryList(int? roomID)
        {
            try
            {
                if(roomID != null)
                {
                    var content = new StringContent(JsonConvert.SerializeObject(roomID), Encoding.UTF8, "application/json");
                    var response = this.client.GetAsync(this.route + $"/QueryList?roomID={roomID}").Result;

                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }

                    var result = response.Content.ReadAsStringAsync().Result;
                    return ((null, JsonConvert.DeserializeObject<IEnumerable<UserRoom>>(result)));
                }
                else
                {
                    return (null, null);
                }
                
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

    }
}
