function meetings(inputArr) {
    let scheduledMeetings = {};

    for (const element of inputArr) {
        let meeting = element.split(" ");
        const day = meeting[0];
        const name = meeting[1];

        if (scheduledMeetings.hasOwnProperty(day)) {
            console.log(`Conflict on ${day}!`);
        } else {
            scheduledMeetings[day] = name;
            console.log(`Scheduled for ${day}`);
        }
    }

    for (const [key, value] of Object.entries(scheduledMeetings)) {
        console.log(`${key} -> ${value}`);
    }
}

meetings(['Monday Peter', 'Wednesday Bill', 'Monday Tim', 'Friday Tim']);
meetings(['Friday Bob', 'Saturday Ted', 'Monday Bill', 'Monday John', 'Wednesday George']);