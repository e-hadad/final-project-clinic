//using clinic;
//using Clinic.Core.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//[Route("api/[controller]")]
//[ApiController]

//public class AuthController : ControllerBase
//{
//    private readonly IConfiguration _configuration;
//    private readonly IUserService _userService;

//    public AuthController(IConfiguration configuration,IUserService userService)
//    {
//        _configuration = configuration;
//        _userService = userService;
//    }

//    [HttpPost]
//    public async Task<IActionResult>  Login([FromBody] LoginModel loginModel)
//    {

//        var user = await _userService.GetByUserNameAsync(loginModel.UserName, loginModel.Password);


//        if (user!=null)
//        {
//            var claims = new List<Claim>()
//            {
//                new Claim(ClaimTypes.Name, user.UserName),
//                new Claim(ClaimTypes.Role, user.Role.ToString())
//            };

//            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
//            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
//            var tokeOptions = new JwtSecurityToken(
//                issuer: _configuration.GetValue<string>("JWT:Issuer"),
//                audience: _configuration.GetValue<string>("JWT:Audience"),
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(6),
//                signingCredentials: signinCredentials
//            );
//            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
//            return Ok(new { Token = tokenString });
//        }
//        return Unauthorized();
//    }
//}




using clinic;
using Clinic.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;

    public AuthController(IConfiguration configuration, IUserService userService)
    {
        _configuration = configuration;
        _userService = userService;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
    {
        var user = await _userService.GetByUserNameAsync(loginModel.UserName, loginModel.Password);

        if (user != null)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }
        return Unauthorized();
    }
}