var mongoose = require('mongoose');
var Movements = require('./movement');
var userScheme = new mongoose.Schema({
    Username: String,
    Password: String,
    FirstName: String,
    LastName: String,
    Email: String,
    Banned: Boolean(false),
    TotalMovment: [],
    TotalMoney: Number,

});
userScheme.methods.NewIncome = async function (amount) {
    let movement = new Movements({
        MovementType: "Income",
        Amount: amount,
        Date: new Date()
    });
    this.TotalMoney += amount;
    this.TotalMovment.push(movement);
    this.save();

}
userScheme.methods.NewOutcome = async function (amount) {
    let movement = new Movements({
        MovementType: "Outcome",
        Amount: amount,
        Date: new Date()
    });
    this.TotalMoney -= amount;
    this.TotalMovment.push(movement);
    this.save();

}
userScheme.methods.GetAllIncomes = async function () {
        let totalMovment = this.TotalMovment.filter(x => x.MovementType == "Income");
        console.log("Incomes amount :",totalMovment.length);
        return totalMovment; 
}
userScheme.methods.GetAllOutcomes = async function () {
    let totalMovment = this.TotalMovment.find({MovementType : "Outcome"});
    console.log("Outcome amount :",totalMovment.Length);
    return totalMovment; 
}
module.exports = mongoose.model('User', userScheme);
