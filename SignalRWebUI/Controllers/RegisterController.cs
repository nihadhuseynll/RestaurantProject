using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			var appUser = new AppUser()
			{
				Name= registerDto.Name,
				SurName=registerDto.SurName,
				Email=registerDto.Mail,
				UserName=registerDto.UserName
			};
			var result=await _userManager.CreateAsync(appUser,registerDto.PassWord);
			if(result.Succeeded)
			{
				return RedirectToAction("Index","Login");
			}
			return View();
		}
	}
}
