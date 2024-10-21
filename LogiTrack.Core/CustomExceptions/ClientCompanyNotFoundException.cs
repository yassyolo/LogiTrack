using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
namespace LogiTrack.Core.CustomExceptions
{
    public class ClientCompanyNotFoundException : Exception
    {
        public ClientCompanyNotFoundException() : base(ClientCompanyNotFoundErrorMessage)
        {
        }
    }
}
