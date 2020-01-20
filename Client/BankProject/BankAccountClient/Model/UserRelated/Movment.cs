using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountClient.Model.UserRelated
{
    enum MovmentType
    {
        Income,Outcome,
    }
    class Movment
    {
        public string ID { get; set; }
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
