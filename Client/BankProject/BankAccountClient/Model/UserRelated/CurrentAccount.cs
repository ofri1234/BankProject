using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BankAccountClient.Model.UserRelated
{
    public class CurrentAccount :INotifyPropertyChanged
    {
        #region PropChange
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TotalMoney { get; set; }
        public List<Movment> Movments { get; set; }


        public string TotalMoneyWithComma {
            get { return "Total Balance : "+ TotalMoney.ToString("N1"); }
        }
        public string TotalMovmentWithComma
        {
            get { return "Total Movements : " + Movments.Count.ToString("N0"); }
        }
        public void ChangeProperty(string propName,object value,string updatePropName = "")
        {
            var prop = this.GetType().GetProperties().ToList().FirstOrDefault(x => x.Name.ToLower() == propName.ToLower());
            if (prop != null)
            {
                prop.SetValue(this,value);
                string updater = prop.Name;
                if (updatePropName != "")
                    updater = updatePropName;
                OnPropertyChanged(updater);
            }
        }

        public string GetFullName
        {
            get { return FirstName + " " + LastName; }
        }

        public CurrentAccount(string id, string firstName, string lastName, decimal totalMoney)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            TotalMoney = totalMoney;
        }

        public void CalcMovments(JObject movments)
        {
            Movments = new List<Movment>();
            var allMovements = movments["accDetail"]["TotalMovements"];
            for (int i = 0; i < movments["accDetail"]["MovementsCount"].ToObject<int>(); i++)
            {
                if (allMovements[i] != null)
                {
                    Movment tmpMovment = JsonConvert.DeserializeObject<Movment>(allMovements[i].ToString());
                    string mT = allMovements[i]["MovementType"].ToString();
                    tmpMovment.MType = (MovmentType)System.Enum.Parse(typeof(MovmentType), mT);
                    Movments.Add(tmpMovment);
                }
            }
        }
    }
}
