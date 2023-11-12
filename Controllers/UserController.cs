using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using appapi.DtoEntity;
using appapi.Entity;
using appapi.GenericRepository;
using appapi.Specification;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Logging;

namespace appapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserGenericRepository<UserEntity> _repo;
        private readonly IMapper _map;

        public UserController(
            ILogger<UserController> logger,
            IUserGenericRepository<UserEntity> repo,
            IMapper map
            
            )
        {
            _logger = logger;
            _repo = repo;
            _map = map;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserDto>>>GetAllUser()
        {
            //IReadOnlyList<UserEntity> users = await _repo.GetAllUsersAsync();
            var spec = new UserAndAddressSpec();
            var users = await _repo.GetAllUsersAsync(spec);
            if(users == null)return NotFound();
            return Ok(_map.Map<List<UserDto>>(users));
            
            //return Ok(users);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserEntity>>GetUser(int id)
        {
            //var user = await _repo.GetUserByIdAsync(q => q.id == id);
            var spec = new UserAndAddressSpec(id);
            var user = await _repo.GetUserByIdAsync(spec);
            if(id < 1)return BadRequest();
            if(user == null) return NotFound();
            //return Ok(_map.Map<UserDto>(user));
            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(Name ="AddUser")]
        public async Task<ActionResult<PostUserDto>>AddUser([FromBody]PostUserDto user)
        {
            var spec = new UserAndAddressSpec();
            if(user == null)return BadRequest(user);
            //if( await _repo.GetAllUsersAsync(u => u.first_name.ToLower() == user.first_name.ToLower()) != null)return BadRequest();
            

            var userEntity = _map.Map<UserEntity>(user);
            await _repo.GreateAsync(userEntity);
            return Ok(userEntity);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name ="DeleteUser")]
        public async Task<ActionResult>DeleteUser(int id)
        {
            //No auto mapper or Dto in remove/delete
            if(id < 1)return BadRequest();
            //var user = await _repo.GetUserByIdAsync(q =>q.id == id);
            var spec = new UserAndAddressSpec(id);
            var user = await _repo.GetUserByIdAsync(spec);
            if(user == null)return NotFound();
            await _repo.RemoveAsync(user);
            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name ="UpdateUser")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody]UserDto user)
        {
            if(id != user.id || user == null)return BadRequest();
            var userEntity = _map.Map<UserEntity>(user);
            await _repo.UpdateAsync(userEntity);
            return NoContent();
        }


        
    }
}