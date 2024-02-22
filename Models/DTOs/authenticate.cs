
namespace Models.DTOs
{
    public class RequestAuthenticate
    {
        public string userEmail {get; set;} = null!;
        public string password {get; set;} = null!;
    }
}