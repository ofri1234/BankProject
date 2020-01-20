using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClient.Model.UserRelated
{
    public enum MovmentType
    {
        Income,Outcome,
    }

    public class Movment
    {
        public string _id { get; set; }
        public MovmentType MType { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Movment(MovmentType mType, int amount, DateTime date, string description = "")
        {
            MType = mType;
            Amount = amount;
            Date = date;
            Description = description;
        }

    }
}
