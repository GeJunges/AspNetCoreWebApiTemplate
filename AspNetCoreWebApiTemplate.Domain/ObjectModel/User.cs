namespace AspNetCoreWebApiTemplate.Domain.ObjectModel
{
    public class User : IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
