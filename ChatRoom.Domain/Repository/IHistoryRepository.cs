using ChatRoom.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Repository
{
    public interface IHistoryRepository
    {
        (Exception exception, History history) Add(History history);

        (Exception exception, IEnumerable<History> historys) Delete();

        (Exception exception, IEnumerable<History> historys) Query();


    }
}
