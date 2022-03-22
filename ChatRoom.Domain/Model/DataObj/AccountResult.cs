using ChatRoom.Domain.Repository;

namespace ChatRoom.Domain.Model.DataObj
{
    public class AccountResult
    { 
        public ResultCode resultCode { get; set; }

        public Account account { get; set; }
    }
}
