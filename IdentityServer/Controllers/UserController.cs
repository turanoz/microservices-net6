using IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer.Dtos;
using Microsoft.AspNetCore.Cors;
using Shared.Dtos;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [EnableCors("UserPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto signupDto)
        {
            
            var user = new ApplicationUser
            {
                UserName = signupDto.Email,
                Name = signupDto.Name,
                Surname = signupDto.Surname,
                Email = signupDto.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, signupDto.Password);
            await _userManager.AddToRoleAsync(user, "User");

            if (!result.Succeeded)
            {
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null) return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            var role = await _userManager.GetRolesAsync(user);

            if (user == null) return BadRequest();

            return Ok(new
            {
                Id = user.Id, UserName = user.UserName, Email = user.Email, Name = user.Name, Surname = user.Surname,Roles=role
            });
        }
    }
}