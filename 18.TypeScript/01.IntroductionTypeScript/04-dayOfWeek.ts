enum DaysOfWeek {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

function dayOfWeek(day: string): number | string {
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