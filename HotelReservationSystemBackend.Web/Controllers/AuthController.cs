using HotelReservationSystemBackend.Business.UserManager;
using HotelReservationSystemBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystemBackend.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //private readonly IUserManager _userManager;
        //public AuthController(IUserManager userManager)
        //{
        //    _userManager = userManager;
        //}
        //public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
        //{
        //    User user = new User {
        //        Name = userDTO.Name,
        //        Email = userDTO.Email,
        //        Password = userDTO.Password,
        //        Age = userDTO.Age,
        //        Gender = userDTO.Gender,
        //        Cnic = userDTO.Cnic,
        //        Role = userDTO.Role
        //    };
        //    User? newUser = await _userManager.AddOrUpdateAsync(user);
        //    if(user == null)
        //    {
        //        return BadRequest();
        //    }
        //    return Ok(new { Status = "Succeeded", Message = "User created successfully", User = user});
        //}
    }
}
