const User = require('./scheme/user');
module.exports = {
    Login: async (data, socket) => {
        data = JSON.parse(data);
        let res = { status: false };
        let user = await GetUser(data.Username);
        if (user) {
            if (user.Password == data.Password) {
                res.status = true;
                let mUser = Copy(user);
                //Saves User to global list
                mUser.Session = socket;
                global.TotalUsers.push(mUser);
                //Give Player his date
                res.accDetail = {};
                res.accDetail.ID = user._id;
                res.accDetail.FirstName = user.FirstName;
                res.accDetail.LastName = user.LastName;
                res.accDetail.TotalMoney = user.TotalMoney;
                res.accDetail.TotalMovements = user.TotalMovment;
                res.accDetail.MovementsCount = user.TotalMovment.length;
            }
            else {
                res.err = "Username or password is not correct";
            }
        }
        else {
            res.err = "User does not exist!";
        }
        socket.emit('LoginRes', res);
    }
}
let GetUser = async function (username) {
    try {
        let user = await User.findOne({ Username: username });
        return user;
    } catch (error) {

    }
    return null;

}
let Copy = function (mainObj) {
    let objCopy = {}; // objCopy will store a copy of the mainObj
    let key;

    for (key in mainObj) {
        objCopy[key] = mainObj[key]; // copies each property to the objCopy object
    }
    return objCopy;
}