namespace LogiTrack.Core.CustomExceptions
{
    public class ClientCompanyNotFoundException : Exception
    {
        public ClientCompanyNotFoundException(string message) : base(message)
        {
        }
    }
}
