var mongoose = require('mongoose');
var movementScheme = new mongoose.Schema({
    MovementType : String,
    Amount : Number,
    Date : Date,
    Description : String,
});
module.exports = mongoose.model('Movement', movementScheme);
