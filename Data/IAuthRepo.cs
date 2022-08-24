using Periodic.Models.Requests;
using Periodic.Models.Responses;

namespace Periodic.Data
{
    public interface IAuthRepo
    {
        public void SignupUser(SignupRequest sreq);

        public LoginResponse LoginUser(LoginRequest lreq);

    }
}