using Bargain.Models;
using System.Collections.Generic;

namespace Bargain.Services.Interfaces
{
    public interface IUtilityService
    {
        IEnumerable<string> GetUrls(string searchEngine, int pageNumber, string searchPage);
        string GetToken(User payload);
    }
}
