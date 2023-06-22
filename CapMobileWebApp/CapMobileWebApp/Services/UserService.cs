using CapMobileWebApp.DAL.Context;
using CapMobileWebApp.DAL.Model;
using System.Security.Claims;

namespace CapMobileWebApp.Services
{
    public class UserService
    {
        CapRetailContext _capRetailContext;

        public UserService(CapRetailContext capRetailContext)
        {
            _capRetailContext = capRetailContext;
        }

        public UserInfo GetUserInfo(string username, string password)
        {
            return _capRetailContext.UserInfo.FirstOrDefault(e => e.Username == username && e.Apassword == password);
        }
        public UserInfo GetUserInfo(ClaimsPrincipal User)
        {
            if (User != null && User.Identity.IsAuthenticated)
            {
                UserInfo LoggedInUser = new UserInfo();
                LoggedInUser.Username = User.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Name).Value;
                LoggedInUser.EmployeeName = User.Claims.FirstOrDefault(e => e.Type == "FullName").Value;
                LoggedInUser.UserId = int.Parse(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                LoggedInUser.RoleId = int.Parse(User.Claims.FirstOrDefault(e => e.Type ==ClaimTypes.Role).Value);
                LoggedInUser.Designation = User.Claims.FirstOrDefault(e => e.Type == "Designation").Value;
                return LoggedInUser;
            }
            else
            {
                return null;
            }
        }
    }
}
