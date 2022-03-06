using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Bargain.Models;
using Bargain.Services.Common;
using Bargain.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace Bargain.Services
{
    public class UtilityService : IUtilityService
    {
        private readonly IConfigService _config;

        public UtilityService (IConfigService config)
        {
            _config = config;
        }

        public IEnumerable<string> GetUrls(string searchEngine, int pageNumber, string searchPage)
        {
            var pageUri = string.Format(searchPage, searchEngine, pageNumber.ToString("00")); // Search page url

            using var client = new WebClient();

            var content = client.DownloadString(pageUri); // Call the search page and get the results in html string

            if (content.Length > 0)
            {
                // Find the html tag regular expression matched urls for processing

                var matches = Regex.Matches(content, Constants.COMMA_DELIMITER, RegexOptions.IgnoreCase);

                if (matches.Any())
                {
                    foreach (Match m in matches)
                    {
                        yield return m.Value;
                    }
                }
            }
        }

        public string GetToken(User payload)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, payload.Name),
                    new Claim(ClaimTypes.Email, payload.Email),
                    new Claim(ClaimTypes.Role, payload.Role.ToString("f"))
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
