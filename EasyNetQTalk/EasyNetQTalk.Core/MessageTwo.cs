using System;

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