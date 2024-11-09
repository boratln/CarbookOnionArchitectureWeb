using Carbook.Dto.SignInDtos;
using Carbook.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Carbook.WebUI.Controllers
{
	public class SignInController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public SignInController(IHttpClientFactory? httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateSignInDto createSignInDto)
		{
			var client= _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(createSignInDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7076/api/SignIn", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData=await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
				{
					PropertyNamingPolicy=JsonNamingPolicy.CamelCase
				});
				if (tokenModel != null) { 
				JwtSecurityTokenHandler handler= new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();
					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("accessToken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var authProps = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.Expire_Date,
							IsPersistent = true
						};
						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}
	}
}
