using Periodic.Models.Requests;


namespace Periodic.Data
{
    public interface IAuthRepo
    {
        public bool SignupUser(SignupRequest sreq);

        public bool LoginUser(LoginRequest lreq);

    }
}