using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using static LogiTrack.Infrastructure.Data.DataConstants.DataModelConstants.DeliveryTracking;
using static LogiTrack.Core.Constants.MessageConstants.ErrorMessages;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Delivery
{
    public class AddStatusViewModel
    {
        public int DeliveryId { get; set; }

        [StringLength(TrackingStatusMaxLength, MinimumLength = TrackingStatusMinLength, ErrorMessage = LengthErrorMessage)]
        [Required(ErrorMessage = RequiredFieldErrorMessage)]
        public string StatusUpdate { get; set; } = string.Empty;

        //[StringLength(TrackingNotesMaxLength, MinimumLength = TrackingNotesMinLength, ErrorMessage = LengthErrorMessage)]
        public string? Notes { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set;}
    }
}
