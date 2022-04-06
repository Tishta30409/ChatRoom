using ChatRoom.Domain.Model.DataType;
using System.Collections.Generic;
using System.Text;

namespace ChatRoom.Domain.Model.StringBuildQueue
{
    public class StringBuildQueue : IStringBuildQueue
    {
        private StringBuilder sb;

        private Queue<History> historyMsg;

        public StringBuildQueue()
        {
            this.sb = new StringBuilder();
            this.historyMsg = new Queue<History>();
        }

        public string ClearMessage()
        {
            this.sb.Clear();
            this.historyMsg.Clear();

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
            this.historyMsg.Enqueue(message);

            //限制長度
            if (this.historyMsg.Count > UserConstants.ChatRoomMaxLine)
            {
                this.historyMsg.Dequeue();
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
            var newQueue = new Queue<History>();
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
