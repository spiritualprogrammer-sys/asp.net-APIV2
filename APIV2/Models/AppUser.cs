using System;
using Microsoft.AspNetCore.Identity;

namespace APIV2.Models;

public class AppUser : IdentityUser
{

public List<Portfolio> portfolios { get; set; } = new List<Portfolio>();
}
