"use strict";
var DaysOfWeek;
(function (DaysOfWeek) {
    DaysOfWeek[DaysOfWeek["Monday"] = 1] = "Monday";
    DaysOfWeek[DaysOfWeek["Tuesday"] = 2] = "Tuesday";
    DaysOfWeek[DaysOfWeek["Wednesday"] = 3] = "Wednesday";
    DaysOfWeek[DaysOfWeek["Thursday"] = 4] = "Thursday";
    DaysOfWeek[DaysOfWeek["Friday"] = 5] = "Friday";
    DaysOfWeek[DaysOfWeek["Saturday"] = 6] = "Saturday";
    DaysOfWeek[DaysOfWeek["Sunday"] = 7] = "Sunday";
})(DaysOfWeek || (DaysOfWeek = {}));
function dayOfWeek(day) {
    switch (day) {
        case "Monday":
            return DaysOfWeek.Monday;
        case "Tuesday":
            return DaysOfWeek.Tuesday;
        case "Wednesday":
            return DaysOfWeek.Wednesday;
        case "Thursday":
            return DaysOfWeek.Thursday;
        case "Friday":
            return DaysOfWeek.Friday;
        case "Saturday":
            return DaysOfWeek.Saturday;
        case "Sunday":
            return DaysOfWeek.Sunday;
        default:
            return "error";
    }
}
console.log(dayOfWeek("Monday")); // 1
console.log(dayOfWeek("Friday")); // 5
console.log(dayOfWeek("Invalid")); // error
//# sourceMappingURL=04-dayOfWeek.js.map