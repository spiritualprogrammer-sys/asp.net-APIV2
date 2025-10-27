using System;
using APIV2.Extensions;
using APIV2.Interfaces;
using APIV2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APIV2.Controllers;

[Route("api/portfolio")]
[ApiController]
public class PortfolioController: ControllerBase
{
    private readonly UserManager<AppUser> _userManager ;
    private readonly IStockRepository _stockRepository ;
    private readonly IPortfolioRepository _portfolioRepository ;
  public PortfolioController(UserManager<AppUser> userManager, IStockRepository stockRepository , IPortfolioRepository portfolioRepository)
  {
    _userManager = userManager;
    _stockRepository = stockRepository;
    _portfolioRepository = portfolioRepository;
    
  }


  [HttpGet]
  [Authorize]
  public  async Task<IActionResult> GetUserPortfolio()
    {
        var username = User.GetUsername();
        var appUser = await _userManager.FindByNameAsync(username);
        var userPortfolio = await _portfolioRepository.GetUserPortfolio(appUser);

        return Ok(userPortfolio);
        
    }
}
