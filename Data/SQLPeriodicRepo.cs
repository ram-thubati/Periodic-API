using Periodic.Models;

namespace Periodic.Data
{
    public class SQLPeriodicRepo : IPeriodicRepo
    {
        private SQLPeriodicDbContext _ctx;
        public SQLPeriodicRepo(SQLPeriodicDbContext ctx)
        {
            this._ctx = ctx;
        }

        //Check if account with same name exists for the user, if not add it.
        public void CreateAccount(Account new_acc)
        {
            var existing_acc = _ctx.Accounts.FirstOrDefault(
                            x => 
                            x.AccountName.ToLower().Trim() == new_acc.AccountName.ToLower().Trim() &&
                            x.UserId == new_acc.UserId);
            if(existing_acc is not null)
            {
                throw new Exception("Account already exists");
            } 
            else
            {
                _ctx.Accounts.Add(new_acc);
            }
        }

        public void CreateSchedule(Scheduled new_sch)
        {
            var existing_sch = _ctx.ScheduledTransactions.FirstOrDefault(
                x => x.UserId == new_sch.UserId &&
                x.TransactionName == new_sch.TransactionName
            );

            if(existing_sch is not null)
            {
                throw new Exception("A scheudle with same name already exists");
            }
            else
            {
                _ctx.ScheduledTransactions.Add(new_sch);
            }
        }

        public bool CreateTransaction(Transaction trns)
        {
            throw new NotImplementedException();
        }

        public void DeleteAccount(Account acc)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSchedule(Scheduled sch)
        {
            throw new NotImplementedException();
        }

        public void DeleteTransaction(Transaction trns)
        {
            throw new NotImplementedException();
        }

        public Account GetAccountById(int usr_id, int acc_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccountsByUserId(int usr_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Scheduled> GetAllScheduledByUserId(int usr_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAllTransactionsByuserId(int user_id)
        {
            throw new NotImplementedException();
        }

        public Scheduled GetScheduledById(int usr_id, int id)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransactionById(int usr_id, int trns_id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccount(Account new_acc)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSchedule(Scheduled new_sch)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTransaction(Transaction trns)
        {
            throw new NotImplementedException();
        }
    }
}