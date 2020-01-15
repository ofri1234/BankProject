var mongoose = require('mongoose');
var userScheme = new mongoose.Schema({
    Username: String,
    Password: String,
    Banned : Boolean(false),
});
module.exports = mongoose.model('User', userScheme);
