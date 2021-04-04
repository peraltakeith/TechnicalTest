namespace TechnicalTest.Helpers
{
    public static class GSTHelper
    {
        public static decimal GSTCalculator(decimal gstInclusiveAmount)
        {
            decimal _gstAmount = (gstInclusiveAmount * 3) / 23;
            return _gstAmount;
        }
    }
}