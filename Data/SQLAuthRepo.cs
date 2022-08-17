using Periodic.Models;
using Periodic.Helpers;
using Periodic.Data;
using Periodic.Models.Requests;
using Periodic.Secret;

namespace AuthServer.Services
{
    public class SQLAuthRepo : IAuthRepo
    {
        private UserDbContext _userContext;
        public SQLAuthRepo(UserDbContext ctx)
        {
            this._userContext = ctx;
        }

        private HashingManager hashing = new HashingManager();
        public string LoginUser(LoginRequest lreq)
        {
            var db_usr = _userContext.Users.First(x => x.UserName == lreq.UserName);
            if (db_usr != null)
            {
                var isMatch = hashing.Verify(lreq.Password, db_usr.PasswordHash);
                if (isMatch)
                {
                    return JwtAuthenticationManager.GetToken(db_usr.Id, Secrets.JwtSigningKey);
                }
                else
                {
                    throw new Exception("Incorrect Credentials");
                }
            }
            else
                throw new Exception("User doesn't exist");
        }

        public void SignupUser(SignupRequest sreq)
        {
            var db_usr = _userContext.Users.Where(x => x.UserName == sreq.UserName || x.Email == sreq.Email).ToList();
            if (db_usr.Count() > 0)
            {
                throw new Exception("A user with username and/or email address already exists");
            }
            else
            {
                var usr = new User();
                usr.UserName = sreq.UserName;
                usr.FullName = sreq.FullName;
                usr.Email = sreq.Email;
                usr.PasswordHash = hashing.HashToString(sreq.Password);
                usr.IsEnabled = false;
                usr.DateCreated = DateTime.Now;

                _userContext.Users.Add(usr);
                _userContext.SaveChanges();

            }
        }
    }
}
