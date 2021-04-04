using RestSharp.Deserializers;
using System.Xml.Serialization;

namespace TechnicalTest.Models
{
    [DeserializeAs(Name = "expense")]
    public class Expense
    {
        [XmlAttribute("cost_centre")]
        public string CostCentre { get; set; }

        [DeserializeAs(Name = "total")]
        public decimal? Total { get; set; }

        [XmlAttribute("payment_method")]
        public string PaymentMethod { get; set; }
    }
}