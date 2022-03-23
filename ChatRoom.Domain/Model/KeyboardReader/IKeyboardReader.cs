using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRoom.Domain.Model
{
    public interface IKeyboardReader
    {
        string GetInputString(string reg, bool isEncode, int length);

        string GetTempString(int length);

    }
}
