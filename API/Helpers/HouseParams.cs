namespace API.Helpers
{
    public class HouseParams:PaginationParams
    {
        public string Category { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}