using ChatRoom.Domain.Model.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model.StringBuildQueue
{
    public interface IStringBuildQueue
    {
        string AddMessage(History message);

        string ClearMessage();

        string MutedProcess(string nickName);

        string AddHistory(IEnumerable<History> historys);
    }
}
