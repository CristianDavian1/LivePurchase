using DataAcces.ModelsDb;

namespace Models.Responses
{
    public class GeneralResponseMessage
    {
        public int Status {get; set;}
        public string Msg {get; set;} = "";
    }

    public class UsersResponse 
    {
        public int Status {get; set;}
        public string msg {get; set;}
        public List<User> Usuarios {get; set;} = null;
    }
}