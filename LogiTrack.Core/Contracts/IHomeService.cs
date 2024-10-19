using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.Contracts
{
    public interface IHomeService
    {
        Task<IdentityUser?> GetUserByEmailAsync(string email);
    }
}
