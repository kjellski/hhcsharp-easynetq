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