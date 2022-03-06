using System.Threading.Tasks;
using Bargain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Bargain.Repositories.Interfaces;
using Bargain.Services.Common;
using Bargain.Models;
using System;
using System.Dynamic;

namespace Bargain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUtilityService _utilityService;        
        private readonly ILogger<UserService> _logger;

        public UserService(
            IUserRepository userRepository,
            IUtilityService utilityService, 
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _utilityService = utilityService;            
            _logger = logger;
        }

        public async Task<Response<dynamic>> GetAuthUserAsync(User payload)
        {
            var existingUser = await _userRepository.FindByEmailAsync(payload);

            if (existingUser == null)
            {
                return new Response<dynamic>("User not found.");
            }

            try
            {
                existingUser.Token = _utilityService.GetToken(existingUser);

                dynamic user = new ExpandoObject();
                user.Id = existingUser.Id;                
                user.Role = existingUser.Role.ToString("f");
                user.Token = existingUser.Token;
                user.IsTradeAdmin = existingUser.IsTradeAdmin;

                return new Response<dynamic>(user);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{nameof(UserService)} {nameof(GetAuthUserAsync)} {ex.Message}");

                return new Response<dynamic>(ex.Message);
            }            
        }
    }
}
