namespace DAPPER_CURD.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Scheme { get; set; }
        public string Index { get; set; }
        public decimal Amount { get; set; }
        public decimal PE { get; set; }
        public decimal PB { get; set; }
        public decimal Divident { get; set; }
        public int PerentId { get; set; }
        public string FileURL { get; set; }
    }
    public class UsersList: Users
    {
        public string PerentName { get; set; }
    }
}
