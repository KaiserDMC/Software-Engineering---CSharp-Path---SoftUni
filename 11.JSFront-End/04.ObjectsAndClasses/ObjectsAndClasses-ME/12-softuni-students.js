function softUniStudents(inputArr) {
    let softUni = {};

    for (const inputArrElement of inputArr) {
        if (inputArrElement.includes(": ")) {
            let [courseName, capacity] = inputArrElement.split(": ");

            if (!softUni.hasOwnProperty(courseName)) {
                softUni[courseName] = {
                    capacity: parseInt(capacity),
                    students: []
                }
            } else {
                softUni[courseName].capacity += parseInt(capacity);
            }
        } else {
            let leftSideString = inputArrElement.split(" with email ")[0];
            let [username, credits] = leftSideString.split("[");
            credits = credits.slice(0, credits.length - 1);
            credits = parseInt(credits);
            let rightSideString = inputArrElement.split(" with email ")[1];
            let [email, random, courseName] = rightSideString.split(" ");

            if (softUni.hasOwnProperty(courseName)) {
                let student = {
                    credits: credits,
                    userInfo: `${username}, ${email}`
                }

                if (softUni[courseName].capacity > 0) {
                    softUni[courseName].students.push(student);
                    softUni[courseName].capacity--;
                }
            }
        }
    }

    let sortedCoursesEntries = Object.entries(softUni).sort((a, b) => b[1].students.length - a[1].students.length);

    for (const [courseName, courseEntry] of sortedCoursesEntries) {
        console.log(`${courseName}: ${courseEntry.capacity} places left`);

        let sortedStudents = courseEntry.students.sort((a, b) => b.credits - a.credits);

        for (const student of sortedStudents) {
            console.log(`--- ${student.credits}: ${student.userInfo}`);
        }
    }
}

softUniStudents(['JavaBasics: 2', 'user1[25] with email user1@user.com joins C#Basics', 'C#Advanced: 3', 'JSCore: 4', 'user2[30] with email user2@user.com joins C#Basics', 'user13[50] with email user13@user.com joins JSCore', 'user1[25] with email user1@user.com joins JSCore', 'user8[18] with email user8@user.com joins C#Advanced', 'user6[85] with email user6@user.com joins JSCore', 'JSCore: 2', 'user11[3] with email user11@user.com joins JavaBasics', 'user45[105] with email user45@user.com joins JSCore', 'user007[20] with email user007@user.com joins JSCore', 'user700[29] with email user700@user.com joins JSCore', 'user900[88] with email user900@user.com joins JSCore']);
softUniStudents(['JavaBasics: 15', 'user1[26] with email user1@user.com joins JavaBasics', 'user2[36] with email user11@user.com joins JavaBasics', 'JavaBasics: 5', 'C#Advanced: 5', 'user1[26] with email user1@user.com joins C#Advanced', 'user2[36] with email user11@user.com joins C#Advanced', 'user3[6] with email user3@user.com joins C#Advanced', 'C#Advanced: 1', 'JSCore: 8', 'user23[62] with email user23@user.com joins JSCore']);