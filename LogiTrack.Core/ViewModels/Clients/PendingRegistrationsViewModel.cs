﻿using LogisticsSystem.Infrastructure.Data.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LogiTrack.Core.ViewModels.Clients
{
    public class PendingRegistrationsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;       
        public string RegistrationNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
