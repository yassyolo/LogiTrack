using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class NonStandardCargoRequestViewModel
    {
        public int? Length { get; set; }
       
        public int? Width { get; set; }
        
        public int? Height { get; set; }
        public string? Description { get; set; }
        public double? Weight { get; set; }
    }
}
