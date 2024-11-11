using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Request
{
    public class NonStandardCargoRequestViewModel
    {
        public string? Length { get; set; }
       
        public string? Width { get; set; }
        
        public string? Height { get; set; }
        public string? Description { get; set; }
        public double? Weight { get; set; }
    }
}
