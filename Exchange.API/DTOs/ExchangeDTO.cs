namespace Exchange.API.DTOs
{
    public class ExchangeDTO
    {
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public decimal ForexBuying { get; set; }
        public decimal ForexSelling { get; set; }
    }
}
