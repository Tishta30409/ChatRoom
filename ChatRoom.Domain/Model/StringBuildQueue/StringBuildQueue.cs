using ChatRoom.Domain.Model.DataType;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Domain.Model.StringBuildQueue
{
    public class StringBuildQueue : IStringBuildQueue
    {
        private StringBuilder sb;

        //private ConcurrentQueue<History> historyMsg;

        private ConcurrentQueue<History> historyMsg;

        public StringBuildQueue()
        {
            this.sb = new StringBuilder();
            this.historyMsg = new ConcurrentQueue<History>();
        }

        public string ClearMessage()
        {
            this.sb.Clear();
            this.historyMsg = new ConcurrentQueue<History>(); ;

            return "";
        }

        public string AddHistory(IEnumerable<History> historys)
        {

            this.ClearMessage();
            foreach (History history in historys)
            {
                this.historyMsg.Enqueue(history);
                sb.AppendLine($"{history.f_nickName}({history.f_createDateTime}): {history.f_content}");
            }

            return sb.ToString();
        }

        public string AddMessage(History message)
        {
            //lock or Concurrent QUEUE
            this.historyMsg.Enqueue(message);

            //限制長度
            if (this.historyMsg.Count > UserConstants.ChatRoomMaxLine)
            {
                this.historyMsg.TryDequeue(out History result);
            }

            //重新拼字串
            this.sb.Clear();
            foreach (History history in this.historyMsg)
            {
                this.sb.AppendLine($"{history.f_nickName}({history.f_createDateTime}) :: {history.f_content}");
            }


            return this.sb.ToString();
        }

        //禁言處理
        public string MutedProcess(string nickName)
        {

            this.sb.Clear();
            var newQueue = new ConcurrentQueue<History>();
            foreach (History history in this.historyMsg)
            {
                if (history.f_nickName != nickName)
                {
                    newQueue.Enqueue(history);
                    sb.AppendLine($"{history.f_nickName}({history.f_createDateTime}): {history.f_content}");
                }
            }
            this.historyMsg = newQueue;


            return sb.ToString();
        }
    }
}
