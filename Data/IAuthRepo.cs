using Periodic.Models.Requests;


namespace Periodic.Data
{
    public interface IAuthRepo
    {
        public void SignupUser(SignupRequest sreq);

        public string LoginUser(LoginRequest lreq);

    }
}