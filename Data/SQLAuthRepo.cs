using Periodic.Models;
using Periodic.Helpers;
using Periodic.Data;
using Periodic.Models.Requests;
using Periodic.Secret;

namespace Periodic.Data
{
    public class SQLAuthRepo : IAuthRepo
    {
        private SQLPeriodicDbContext _userContext;
        public SQLAuthRepo(SQLPeriodicDbContext ctx)
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
                    string role = db_usr.IsAdmin? "Administrator" : "User";
                    
                    return JwtAuthenticationManager.GetToken(db_usr.Id, role, Secrets.JwtSigningKey);
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
                usr.IsAdmin = false;
                usr.DateCreated = DateTime.Now;

                _userContext.Users.Add(usr);
                _userContext.SaveChanges();

            }
        }
    }
}
