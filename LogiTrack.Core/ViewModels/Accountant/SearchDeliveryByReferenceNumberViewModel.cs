using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Accountant
{
    public class SearchDeliveryByReferenceNumberViewModel
    {
        [Required(ErrorMessage = "Reference number is required.")]
        public string ReferenceNumber { get; set; } = string.Empty;
    }
}
