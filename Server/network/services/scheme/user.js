var mongoose = require('mongoose');
var Movements = require('./movement');
var userScheme = new mongoose.Schema({
    Username: String,
    Password: String,
    Banned : Boolean(false),
    TotalMovment :[],
    TotalMoney : Number,

});
userScheme.methods.NewIncome = async function(amount){
    let movement = new Movements({
        MovementType: "Income",
        Amount : amount,
        Date : new Date()
    });
    this.TotalMoney += amount;
    this.TotalMovment.push(movement);
    this.save();
    
}
userScheme.methods.NewOutcome = async function(amount){
    let movement = new Movements({
        MovementType: "Outcome",
        Amount : amount,
        Date : new Date()
    });
    this.TotalMoney -= amount;
    this.TotalMovment.push(movement);
    this.save();

}
module.exports = mongoose.model('User', userScheme);
