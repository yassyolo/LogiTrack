using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
namespace LogiTrack.Core.CustomExceptions
{
    public class DeliveryNotFoundException : Exception
    {
        public DeliveryNotFoundException() : base(DeliveryNotFoundErrorMessage)
        {
        }
    }
}
