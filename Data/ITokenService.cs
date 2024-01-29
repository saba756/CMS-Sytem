using CMS.Model;

namespace CMS.Data
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}
