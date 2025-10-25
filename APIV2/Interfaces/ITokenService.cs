using System;
using APIV2.Models;

namespace APIV2.Interfaces;

public interface ITokenService
{

 string CreateToken(AppUser user);
}
