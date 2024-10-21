using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
namespace LogiTrack.Core.CustomExceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException() : base(VehicleNotFoundErrorMessage)
        {
        }
    }
}
