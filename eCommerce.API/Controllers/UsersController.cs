using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var userList = _repository.Get();

            return Ok(userList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repository.Get(id);

            if (user == null)
                return NotFound("User not found");

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _repository.Add(user);

            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User user)
        {
            var check = _repository.Get(user.Id);

            if (check == null)
                return NotFound("User not found");

            _repository.Update(user);

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);

            return Ok();
        }
    }
}