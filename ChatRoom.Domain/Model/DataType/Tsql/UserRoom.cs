using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model.DataType.Tsql
{
    public class UserRoom
    {
        public int f_id { get; set; }

        public string f_account { get; set; }

        public int? f_roomID { get; set; }
    }
}
