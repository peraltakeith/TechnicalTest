using RestSharp.Deserializers;

namespace TechnicalTest.Models
{
    [DeserializeAs(Name = "expense")]
    public class Expense
    {
        [DeserializeAs(Name = "cost_centre")]
        public string CostCentre { get; set; }

        [DeserializeAs(Name = "total")]
        public decimal? Total { get; set; }

        [DeserializeAs(Name = "payment_method")]
        public string PaymentMethod { get; set; }
    }
}