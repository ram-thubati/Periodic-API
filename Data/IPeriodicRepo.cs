using Periodic.Models;

namespace Periodic.Data
{
    public interface IPeriodicRepo
    {
        //Accounts
        public void CreateAccount(Account new_acc);

        public IEnumerable<Account> GetAllAccountsByUserId(int usr_id);

        public Account GetAccountById(int usr_id, int acc_id);

        public void UpdateAccount(Account new_acc);

        public void DeleteAccount(Account acc);

        //Transactions
        public IEnumerable<Transaction> GetAllTransactionsByuserId(int user_id);
        
        public void CreateTransaction(Transaction trns);

        public Transaction GetTransactionById(int usr_id, int trns_id);

        public void DeleteTransaction(Transaction trns);

        public void UpdateTransaction(Transaction trns);


        //Scheduled
        public IEnumerable<Scheduled> GetAllScheduledByUserId(int usr_id);

        public Scheduled GetScheduledById(int usr_id, int id);

        public void UpdateSchedule(Scheduled new_sch);

        public void DeleteSchedule(Scheduled sch);

        public void CreateSchedule(Scheduled new_sch);
    }
}