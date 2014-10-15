using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTalk.Core
{
    public class MessageTwo : Message
    {

        public ContentTwo Content { get; set; }
    }

    public class ContentTwo
    {
        public String Text { get; set; }
    }
}
