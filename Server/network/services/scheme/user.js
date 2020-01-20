var mongoose = require('mongoose');
var Movements = require('./movement');
const movementTypes = { Income: 'Income', Outcome: 'Outcome' };
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
userScheme.methods.NewIncome = async function (amount,desc) {
    let movement = new Movements({
        MovementType: movementTypes.Income,
        Amount: amount,
        Date: new Date(),
        Description : desc
    });
    this.TotalMoney += amount;
    this.TotalMovment.push(movement);
    this.save();

}
userScheme.methods.NewOutcome = async function (amount,desc) {
    let movement = new Movements({
        MovementType: movementTypes.Outcome,
        Amount: amount,
        Date: new Date(),
        Description : desc
    });
    this.TotalMoney -= amount;
    this.TotalMovment.push(movement);
    this.save();

}
userScheme.methods.GetAllIncomes = async function () {
    let totalMovment = this.TotalMovment.filter(x => x.MovementType == movementTypes.Income);
    return totalMovment;
}
userScheme.methods.GetAllOutcomes = async function () {
    let totalMovment = this.TotalMovment.filter(x => x.MovementType == movementTypes.Outcome);
    return totalMovment;
}
module.exports = mongoose.model('User', userScheme);
