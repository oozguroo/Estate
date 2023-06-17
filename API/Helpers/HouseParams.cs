namespace API.Helpers
{
    public class HouseParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string Category { get; set; }
        public string Town { get; set; }
        public string District { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
    }
}