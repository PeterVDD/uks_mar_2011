namespace nothinbutdotnetstore.web.core
{
    public class IncomingRequest
    {
       public static RequestCriteria is_for<Behaviour>()
       {
           return new RequestContainsCommand(typeof(Behaviour)).matches;
       } 
    }
}