using DataAcces.ModelsDbAWS;

namespace Models.Responses
{
    public class GeneralResponseMessage<T>
    {
        public int Status {get; set;}
        public T Msg {get; set;}
    }

    public class UsersResponse 
    {
        public int Status {get; set;}
        public string msg {get; set;}
        public List<User> Usuarios {get; set;} = null;
    }
}