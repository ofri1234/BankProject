var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/ofriBankAccount', {useNewUrlParser: true,useUnifiedTopology: true});

var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function() {
  // we're connected!
  console.log("Db is Connected");
});