using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
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
    public class RoomService : IRoomService
    {
        private HttpClient client;

        private string route = @"/api/Room";

        public RoomService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {

                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, ResultCode resultCode) Add(string roomName)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(roomName), Encoding.UTF8, "application/json");
                var response = this.client.PostAsync(this.route + "/Add", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<ResultCode>(result)));
            }
            catch (Exception ex)
            {
                return (ex, ResultCode.DEFAULT);
            }
        }

        public (Exception exception, Room room) Update(Room room)
        {
            try
            {

                var content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
                var response = this.client.PutAsync(this.route + "/Update", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<Room>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<Room> rooms) GetList()
        {
            try
            {
                var response = this.client.GetAsync(this.route + "/GetList").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;
                return ((null, JsonConvert.DeserializeObject<IEnumerable<Room>>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, Room room) Delete(int id)
        {
            try
            {
                var response = this.client.DeleteAsync($"{this.route}/Delete?id={id}").Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result);
                }

                var result = response.Content.ReadAsStringAsync().Result;

                return ((null, JsonConvert.DeserializeObject<Room>(result)));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
