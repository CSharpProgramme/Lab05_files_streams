using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//class that represents a data record
namespace SequentialAccessText
{
    public class Record
    {
        private int account;
        private string firstName;
        private string lastName;
        private decimal balance;

        public int Account
        {
            get { return account; }
            set { account = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        //parameterless constructor sets members to default values
        public Record() : this(0, string.Empty, string.Empty, 0M) { }

        //overloaded constructor sets members to default values
       public Record(int account, string firstName, string lastName, decimal balance)
        {
            Account = account;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }
    }

}
