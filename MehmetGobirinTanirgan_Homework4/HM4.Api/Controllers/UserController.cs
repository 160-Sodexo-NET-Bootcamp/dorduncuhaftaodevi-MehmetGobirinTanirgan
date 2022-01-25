using HM4.Api.Dtos;
using HM4.Core.DataAccess.Uow;
using HM4.Entities.DataModels;
using HM4.Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HM4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Temsili bir controller oluşturuldu.
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await unitOfWork.Users.GetAllAsync();
            if (users.ToList().Count == 0 || users is null)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(UserCreateDto userCreateDto)
        {
            unitOfWork.Users.Add(new User
            {
                Firstname = userCreateDto.Firstname,
                Lastname = userCreateDto.Lastname,
                CreatedDate = DateTime.Now,
                Status = Status.Passive
            });

            await unitOfWork.SaveAsync();
            return Ok();
        }

    }
}
