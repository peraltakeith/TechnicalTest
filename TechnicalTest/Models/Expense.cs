using RestSharp.Deserializers;
using System.Xml.Serialization;

namespace TechnicalTest.Models
{
    [DeserializeAs(Name = "expense")]
    public class Expense
    {
        public Expense()
        {
            CostCentre = "UNKNOWN";   
        }

        [XmlAttribute("cost_centre")]
        public string CostCentre { get; set; }

        [DeserializeAs(Name = "total")]
        public decimal? Total { get; set; }

        [XmlAttribute("payment_method")]
        public string PaymentMethod { get; set; }
        public decimal? GST { get; set; }
        public decimal? TotalExcludingGST { get; set; }
    }
}