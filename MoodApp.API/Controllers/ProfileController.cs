using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoodApp.API.DTOs;
using MoodApp.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace MoodApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<ProfileResponseDto>> GetProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            return Ok(new ProfileResponseDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ProfilePictureUrl = user.ProfilePictureUrl,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            });
        }

        [HttpPut]
        public async Task<ActionResult<ProfileResponseDto>> UpdateProfile([FromBody] UpdateProfileDto updateProfileDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            // Check if username is already taken by another user
            var existingUser = await _userManager.FindByNameAsync(updateProfileDto.Username);
            if (existingUser != null && existingUser.Id != user.Id)
                return BadRequest("Username is already taken");

            // Check if email is already taken by another user
            var existingEmail = await _userManager.FindByEmailAsync(updateProfileDto.Email);
            if (existingEmail != null && existingEmail.Id != user.Id)
                return BadRequest("Email is already taken");

            user.UserName = updateProfileDto.Username;
            user.Email = updateProfileDto.Email;
            user.FirstName = updateProfileDto.FirstName;
            user.LastName = updateProfileDto.LastName;
            user.Bio = updateProfileDto.Bio;
            user.ProfilePictureUrl = updateProfileDto.ProfilePictureUrl;
            user.UpdatedAt = DateTime.UtcNow;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new ProfileResponseDto
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ProfilePictureUrl = user.ProfilePictureUrl,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return NoContent();
        }
    }
} 