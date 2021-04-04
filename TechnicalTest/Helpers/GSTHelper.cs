namespace TechnicalTest.Helpers
{
    public static class GSTHelper
    {
        public static decimal? GSTCalculator(decimal? gstInclusiveAmount)
        {
            return (gstInclusiveAmount * 3) / 23;
        }
    }
}