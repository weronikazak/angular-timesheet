namespace TimeSheet.API.Helpers
{
    public class UserParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; }
        public int pageSize = 10;
        public int PageSize { 
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }
        public int UserId { get; set; }
        public string OrderBy { get; set; }
    }
}