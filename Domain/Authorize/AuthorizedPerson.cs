namespace em.Domain.Authorize
{
    public class AuthorizedPerson
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int authorizationID { get; set; }
        public DateTimeOffset? createTime { get; set; }
        public DateTimeOffset? updateTime { get; set; }
        public bool? deletedInfo { get; set; }
        public virtual Roles? roles { get; set; }
    }
}
