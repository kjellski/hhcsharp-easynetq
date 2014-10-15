using Nancy;
using Newtonsoft.Json;

namespace EasyNetQTalk.Web
{
    public class PointModule : NancyModule
    {
        public PointModule()
            : base("api/point")
        {
            Get["/"] = x => Response.AsJson(JsonConvert.SerializeObject(PointBroadcaster.Instance.LatestPoint));
        }
    }
}