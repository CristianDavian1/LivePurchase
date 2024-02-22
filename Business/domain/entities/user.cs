namespace Business.Domain.Entities
{
    public abstract class User 
    {
        public int UserId {get; set;}
        public string UserName {get; set;}
        public string UserEmail {get; set;}
        public string UserRol {get; set;}
        public string password {get;set;}
        public string document {get;set;}
        public string names {get; set;}
        public string lastNames {get; set;}
    }
}
