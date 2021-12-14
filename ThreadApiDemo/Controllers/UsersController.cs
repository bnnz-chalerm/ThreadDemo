using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MyWebApi.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ThreadApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static Random random = new Random();

        private readonly IUsersRepository _usersRepository;

        private readonly IDistributedCache _distributedCache;

        private readonly IUserService _userService;

        public UsersController(IUsersRepository usersRepository, IUserService userService, IDistributedCache distributedCache)
        {
            _usersRepository = usersRepository;
            _userService = userService;
            _distributedCache = distributedCache;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var cacheKey = $"User_{id}";
            UserDto user;
            var userBytes = await _distributedCache.GetAsync(cacheKey);
            if (userBytes == null)
            {
                user = await _usersRepository.GetUserById(id);
                userBytes = CacheHelper.Serialize(user);
                await _distributedCache.SetAsync(
                    cacheKey,
                    userBytes,
                    new DistributedCacheEntryOptions { SlidingExpiration = TimeSpan.FromMinutes(5) });
            }

            user = CacheHelper.Deserialize<UserDto>(userBytes);
            return Ok(user);
        }

        [HttpPost("GetMany")]
        public async Task<IActionResult> GetMany([FromBody] IEnumerable<int> ids)
        {
            var users = await _usersRepository.GetUsersById(ids);
            return Ok(users);
        }
    }
}
