using ChatRoom.Domain.Model;
using ChatRoom.Domain.Model.DataObj;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Service
{
    public class HistoryService : IHistoryService
    {
        private HttpClient client;

        private string route = @"/api/History";

        public HistoryService(string serviceUri, int timeout = 5)
        {
            this.client = new HttpClient()
            {

                BaseAddress = new Uri(serviceUri),
                Timeout = TimeSpan.FromSeconds(timeout)
            };
        }

        public (Exception exception, History history) Add(History history)
        {
            try
            {
                return ((null, null));
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<History> historys) SortOut()
        {
            try
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }

        public (Exception exception, IEnumerable<History> historys) QueryList(int roomID)
        {
            try
            {
                return (null, null);
            }
            catch (Exception ex)
            {
                return (ex, null);
            }
        }
    }
}
