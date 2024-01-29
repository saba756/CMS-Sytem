using CMS.Model.Identity;

namespace CMS.Data
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}
