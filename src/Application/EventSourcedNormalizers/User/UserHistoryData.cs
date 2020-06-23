namespace Application.EventSourcedNormalizers.User
{
    public class UserHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string IsAdmin { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}