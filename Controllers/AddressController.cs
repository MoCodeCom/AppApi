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
using Microsoft.Extensions.Logging;

namespace appapi.Controllers
{
    [Route("[controller]")]
    public class AddressController : Controller
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IMapper _map;
        private readonly IUserGenericRepository<AddressEntity> _repo;

        public AddressController(
            ILogger<AddressController> logger,
            IUserGenericRepository<AddressEntity> repo,
            IMapper map
            )
        {
            _logger = logger;
            _map = map;
            _repo = repo;
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AddressDto>>>GetAllUser()
        {
            //IReadOnlyList<UserEntity> users = await _repo.GetAllUsersAsync();
            var spec = new AddressAndUserSpec();
            var address = await _repo.GetAllUsersAsync(spec);
            if(address == null)return NotFound();
            return Ok(_map.Map<List<AddressDto>>(address));
            
            //return Ok(users);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AddressDto>>GetAddress(int id)
        {
            //var user = await _repo.GetUserByIdAsync(q => q.id == id);
            var spec = new AddressAndUserSpec(id);
            var address = await _repo.GetUserByIdAsync(spec);
            if(id < 1)return BadRequest();
            if(address == null) return NotFound();
            return Ok(_map.Map<AddressDto>(address));
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost(Name ="AddAddress")]
        public async Task<ActionResult<PostAddressDto>>Addaddress([FromBody]PostAddressDto addressDto)
        {
            var spec = new UserAndAddressSpec();
            if(addressDto == null)return BadRequest(addressDto);
            //if( await _repo.GetAllUsersAsync(u => u.first_name.ToLower() == user.first_name.ToLower()) != null)return BadRequest();
            

            var address = _map.Map<AddressEntity>(addressDto);
            await _repo.GreateAsync(address);
            return Ok(address);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id:int}", Name ="DeleteAddress")]
        public async Task<ActionResult>DeleteUser(int id)
        {
            //No auto mapper or Dto in remove/delete
            if(id < 1)return BadRequest();
            //var user = await _repo.GetUserByIdAsync(q =>q.id == id);
            var spec = new AddressAndUserSpec(id);
            var address = await _repo.GetUserByIdAsync(spec);
            if(address == null)return NotFound();
            await _repo.RemoveAsync(address);
            return NoContent();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id:int}", Name ="UpdateAddress")]
        public async Task<ActionResult> UpdateAddress(int id, [FromBody]AddressDto address)
        {
            if(id != address.id || address == null)return BadRequest();
            var addressEntity = _map.Map<AddressEntity>(address);
            await _repo.UpdateAsync(addressEntity);
            return NoContent();
        }

        
    }
}