namespace Business.Domain.Entities
{
    public abstract class User 
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        public string UserEmail {get; set;}
        public string UserRol {get; set;}
    }
}
