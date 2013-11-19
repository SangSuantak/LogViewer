var Utility = {
    //change date format from dd/mm/yyyy to javascript date objects
    ChangeDateFormat: function (val, char) {

        char = typeof char === "undefined" ? "/" : char;

        if (val && val != "") {
            var dts = val.split(char);
            return new Date(dts[2], dts[1] - 1, dts[0]);
        }
        else {
            return new Date();
        }
    }
};

//ReplaceAll by Fagner Brack (MIT Licensed)
//Replaces all occurrences of a substring in a string
//token = the old character/string
//newToken = the new character/string
//ignoreCase = whether to ignore character case or not, default is false
String.prototype.replaceAll = function (token, newToken, ignoreCase) {
    var str = this.toString(), i = -1, _token;
    if (typeof token === "string") {
        if (ignoreCase === true) {
            _token = token.toLowerCase();
            while ((i = str.toLowerCase().indexOf(_token, i >= 0 ? i + newToken.length : 0)) !== -1) {
                str = str.substring(0, i)
                        .concat(newToken)
                        .concat(str.substring(i + _token.length));
            }
        } else {
            return this.split(token).join(newToken);
        }
    }
    return str;
};