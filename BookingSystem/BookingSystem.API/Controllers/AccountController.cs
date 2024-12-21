using AutoMapper;
using BookingSystem.API.Dtos;
using BookingSystem.Core.Models.Identity;
using BookingSystem.Core.Services.Contract;
using FinalProjectApi.Errors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace BookingSystem.API.Controllers
{
  
    public class AccountController : BaseApiController
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<IdentityUser>userManager , SignInManager<IdentityUser>signInManager , IAuthService authService , IMapper mapper)
        {
         _userManager = userManager;
         _signInManager = signInManager;
         _authService = authService;
         _mapper = mapper;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDTo>> Login(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return Unauthorized(new ApiResponse(401));

            var result = await _signInManager.CheckPasswordSignInAsync(user , model.Password , false);
            if (result.Succeeded is false) if (user == null) return Unauthorized(new ApiResponse(401));
            return Ok(new UserDTo()
            {
                DisplayName = user.UserName,
                Email = user.Email,
              Token = "This will e token "
            });

            
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDTo>> Register(RegisterDTo model)
        {
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                UserName = model.Email.Split("@")[0],
                PhoneNumber = model.PhoneNumber,    
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded is false) return BadRequest(new ApiResponse(400));
            return Ok(new UserDTo()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = "This will e token"
            });


        }

    }
}
