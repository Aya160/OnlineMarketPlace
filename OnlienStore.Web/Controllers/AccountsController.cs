using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core.Identity;
using OnlineStore.Core.Services;
using OnlineStore.Web.DTOs.UsersDTO;
using OnlineStore.Web.ErrorHandeling;

namespace OnlineStore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
         readonly UserManager<ApplicationUser> userManager;
         readonly SignInManager<ApplicationUser> signInManager;
        private readonly ITokenService tokenService;

        public AccountsController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, ITokenService _tokenService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            tokenService = _tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
         var user= await userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null) return Unauthorized(new ApiResponse(400, $"{loginDTO.Email} can't be found,please Try Agin"));
          var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password,false);
            if(!result.Succeeded) return Unauthorized(new ApiResponse(400,"Invalid Password,please Try Agin"));
            return Ok(new UserDTO
            {
                Email = user.Email,
                UserName= user.UserName,
                Token = await tokenService.CreateToken(user, userManager)
            });
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO registerDTO)
        {
            ApplicationUser applicationUser = new()
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                UserName = registerDTO.UserName,
                Email = registerDTO.EmailAddress,
                PasswordHash = registerDTO.Password,
                Gender = registerDTO.Gender,
                PhoneNumber = registerDTO.PhoneNO1,
                PhoneNo2 = registerDTO.PhoneNO2,
                Address = registerDTO.Address,
            };
          var result = await userManager.CreateAsync(applicationUser, registerDTO.Password);
            if(!result.Succeeded) return BadRequest(new ApiResponse(400));
            return Ok(new UserDTO
            {
                Email = applicationUser.Email,
                UserName = applicationUser.UserName,
                Token = await tokenService.CreateToken(applicationUser, userManager)
            });
        }
    }
}
