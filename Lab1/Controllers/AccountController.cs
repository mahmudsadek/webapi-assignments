using Lab1.DTO;
using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterUserDTO NewUser)
        {
            if (ModelState.IsValid)
            {
                //create acc
                ApplicationUser user = new ApplicationUser()
                {
                    Email = NewUser.Email,
                    UserName = NewUser.UserName,
                    PasswordHash = NewUser.Password
                };
                IdentityResult result =  await userManager.CreateAsync(user,NewUser.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Created");
                }
                return BadRequest(result.Errors);

            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserDTO LoginUser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser? userDb = await userManager.FindByNameAsync(LoginUser.UserName);
                if (userDb != null)
                {
                    //check pass
                    bool IsPassCorrect = await userManager.CheckPasswordAsync(userDb, LoginUser.Password);
                    if (IsPassCorrect)
                    { 
                        //create token
                        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
                        JwtHeader JWTHeader = new(credentials);
                        List<Claim> MyClaims = new();
                        MyClaims.Add(new Claim(ClaimTypes.Name, userDb.UserName));
                        MyClaims.Add(new Claim(ClaimTypes.NameIdentifier, userDb.Id));
                        MyClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, DateTime.Now.ToString()));
                        JwtPayload pyload = new(
                            issuer: configuration["JWT:ValidIssuer"],
                            audience: configuration["JWT:ValidAudience"],
                            claims:MyClaims,
                            expires:DateTime.Now.AddDays(1),
                            notBefore:null
                            );
                        JwtSecurityToken token = new(JWTHeader, pyload);
                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                            }
                            ) ;
                    }
                }
                return BadRequest("Invalid User Name");
            }
            return BadRequest(ModelState);
        }
    }
}
