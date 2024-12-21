using BookingSystem.API.Dtos;
using BookingSystem.Core.Models.Identity;
using FinalProjectApi.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.API.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : BaseApiController
    {
      
        private readonly UserManager<AppUser> _userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost("add-admin")]
        public async Task<ActionResult> AddAdmin ([FromBody]AddAdminDTo model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound(new ApiResponse(404));
            }

            var result = await _userManager.AddToRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                return Ok("User promoted to Admin");
            }

            return BadRequest( new ApiResponse(400));
        }

        [HttpPost("remove-admin")]
        public async Task<ActionResult> RemoveAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound( new ApiResponse (401));
            }

            var result = await _userManager.RemoveFromRoleAsync(user, "Admin");
            if (result.Succeeded)
            {
                return Ok("Admin role removed from user");
            }

            return BadRequest(new ApiResponse(400));
        }
    }
}
