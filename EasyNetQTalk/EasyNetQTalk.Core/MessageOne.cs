using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNetQTalk.Core
{
    public class MessageOne : Message
    {
        public ContentOne Content { get; set; }
    }

    public class ContentOne
    {
        public int Number { get; set; }
    }
}
