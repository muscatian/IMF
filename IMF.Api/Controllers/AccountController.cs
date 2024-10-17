using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using IMF.Api.Services;
using IMF.DAL.Identity;
using IMF.Api.DTO.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using System;

namespace IMF.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly JWTService _jwtService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            ILogger<AccountController> logger,
            JWTService jwtService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _jwtService = jwtService;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        [HttpGet("refresh-user-token")]
        public async Task<ActionResult<UserDTO>> RefreshUserToken()
        {
            try
            {
                var clientIp = HttpContext.Connection.RemoteIpAddress?.ToString();
                var machineName = Environment.MachineName;
                string userName = UsersService.GetLoginUser(HttpContext);

                _logger.LogInformation("Client IP: {ClientIp}, Machine Name: {MachineName}, User Name: {UserName}", clientIp, machineName, userName);


                var Name = User.FindFirst(ClaimTypes.Email)?.Value;


                var user = await _userManager.FindByNameAsync(User.FindFirst(ClaimTypes.Email)?.Value);

                if (user == null)
                    return NotFound($"{User.FindFirst(ClaimTypes.Name)?.Value} NotFound");

                return await CreateApplicationDTOAsync(user);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has been occured => {ex.Message} ");
            }
            
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user == null)
                    return Unauthorized("UserName or Password is not valid");

                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (!result.Succeeded)
                    return Unauthorized("UserName or Password is not valid");

                return await CreateApplicationDTOAsync(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has been occured => {ex.Message} ");
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            try
            {
                if (await checkEmailExistsasync(model.Email))
                    return BadRequest($"An existsing account is using {model.Email}, email address. Please try with another email address ");

                var UserToAdd = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email.ToLower(),
                    UserName = model.Email.ToLower(),
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(UserToAdd, model.Password);

                if (!result.Succeeded) return BadRequest(result.Errors);

                // Assign roles to the newly created user
                if (model.Roles != null)
                {
                    var roles = model.Roles;// new[] { "UserRole" }; // Modify this array to include desired roles
                    var roleResult = await _userManager.AddToRolesAsync(UserToAdd, roles);
                    if (!roleResult.Succeeded) return BadRequest(roleResult.Errors);
                }

                return Ok("Your account has been created you can login");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest($"An error has been occured => {ex.Message} ");
            }
            

        }

        #region Private Helper Methods
        private async Task<UserDTO> CreateApplicationDTOAsync(ApplicationUser user)
        {
            try
            {
                var roles = await _userManager.GetRolesAsync(user);

                return new UserDTO
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Jwt = await _jwtService.CreateJWTAsync(user),
                    Roles = roles
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new UserDTO { };
            }
        }

        private async Task<bool> checkEmailExistsasync(string email)
        {
            try
            {
                return await _userManager.Users.AnyAsync(x => x.Email.ToLower() == email.ToLower());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        #endregion
    }
}
