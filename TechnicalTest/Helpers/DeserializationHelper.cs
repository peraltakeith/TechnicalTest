using RestSharp;
using RestSharp.Deserializers;

namespace TechnicalTest.Helpers
{
    public static class DeserializationHelper
    {
        public static T DeserializeXML<T>(string xml)
        {
            XmlDeserializer xmlDeserializer = new XmlDeserializer();
            return xmlDeserializer.Deserialize<T>(new RestResponse { Content = xml });
        }
    }
}