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
                _ctx.SaveChanges();
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
                //after new Scheduled transaction is created, create future dated Transactions in transaction table
                _ctx.SaveChanges();
            }
        }

        public void CreateTransaction(Transaction trns)
        {
            if(trns.FromAccountId == 0 && trns.ToAccountId == 0)
            {
                throw new Exception("Both from and to accounts should not be empty");
            }
            else if(trns.Amount == 0)
            {
                throw new Exception("Amount cannot be Zero");
            }
            else
            {
                _ctx.Transactions.Add(trns);
                _ctx.SaveChanges();
            }
        }

        public void DeleteAccount(int acc_id)
        {
            var acc_db = this._ctx.Accounts.FirstOrDefault(x => x.Id == acc_id);
            this._ctx.Accounts.Remove(acc_db);
            _ctx.SaveChanges();
        }

        public void DeleteSchedule(Scheduled sch)
        {
            _ctx.ScheduledTransactions.Remove(sch);
            //also delete the future dated transactions
            _ctx.SaveChanges();
        }

        public void DeleteTransaction(Transaction trns)
        {
            _ctx.Transactions.Remove(trns);
            _ctx.SaveChanges();
        }

        public Account GetAccountById(int usr_id, int acc_id)
        {
            return this._ctx.Accounts.FirstOrDefault(x => x.UserId == usr_id && x.Id == acc_id);
        }

        public IEnumerable<Account> GetAllAccountsByUserId(int usr_id)
        {
            return this._ctx.Accounts.Where(x => x.UserId == usr_id);
        }

        public IEnumerable<Scheduled> GetAllScheduledByUserId(int usr_id)
        {
            return this._ctx.ScheduledTransactions.Where(x => x.UserId == usr_id);
        }

        public IEnumerable<Transaction> GetAllTransactionsByuserId(int user_id)
        {
            return this._ctx.Transactions.Where(x => x.UserId == user_id);
        }

        public Scheduled GetScheduledById(int usr_id, int id)
        {
            return this._ctx.ScheduledTransactions.FirstOrDefault(x => x.UserId == usr_id && x.Id == id);
        }

        public Transaction GetTransactionById(int usr_id, int trns_id)
        {
            return this._ctx.Transactions.FirstOrDefault(x => x.UserId == usr_id && x.Id == trns_id);
        }

        public void UpdateAccount(Account new_acc)
        {
            var existing_acc = GetAccountById(new_acc.UserId, new_acc.Id);
            if(existing_acc is null)
            {
                throw new Exception($"Account with Id {new_acc.Id} couldn't be found");
            }
            else
            {
                this._ctx.Accounts.Update(new_acc);
                this._ctx.SaveChanges();
            }
        }

        public void UpdateSchedule(Scheduled new_sch)
        {
            this._ctx.ScheduledTransactions.Update(new_sch);
            //add code here to delete all future dated transactions and re-create them to match this update

            _ctx.SaveChanges();
        }

        public void UpdateTransaction(Transaction trns)
        {
            this._ctx.Transactions.Update(trns);
            this._ctx.SaveChanges();
        }

    }
}