namespace API.Helpers
{
    public class LikesParams : PaginationParams
    {
        public int AppUserId { get; set; }
        public int HouseId { get; set; }
    }
}