function schoolRegister(inputArr) {
    let register = {};

    for (const inputArrElement of inputArr) {
        let splits = inputArrElement.split(/[: ,]/);
        let studentName = splits[3];
        let studentGrade = parseInt(splits[7]);
        let averageScore = parseFloat(splits[15]);

        if (averageScore > 3) {
            if (!Object.keys(register).includes(studentGrade.toString())) {
                register[studentGrade] = {};
                register[studentGrade].studentScores = [];
                register[studentGrade].studentNames = [];
            }

            register[studentGrade].studentNames.push(studentName);
            register[studentGrade].studentScores.push(averageScore);
        }
    }

    let sortedGrades = Object.keys(register).sort((a, b) => a - b);

    for (const key of sortedGrades) {
        let currentGrade = register[key];
        let averageGradeScore = currentGrade.studentScores.reduce((a, b) => a + b) / currentGrade.studentScores.length;
        
        console.log(`${parseInt(key) + 1} Grade`);
        console.log(`List of students: ${register[key].studentNames.join(", ")}`);
        console.log(`Average annual score from last year: ${averageGradeScore.toFixed(2)}`);
        console.log();
    }
}

schoolRegister([
    "Student name: Mark, Grade: 8, Graduated with an average score: 4.75",
    "Student name: Ethan, Grade: 9, Graduated with an average score: 5.66",
    "Student name: George, Grade: 8, Graduated with an average score: 2.83",
    "Student name: Steven, Grade: 10, Graduated with an average score: 4.20",
    "Student name: Joey, Grade: 9, Graduated with an average score: 4.90",
    "Student name: Angus, Grade: 11, Graduated with an average score: 2.90",
    "Student name: Bob, Grade: 11, Graduated with an average score: 5.15",
    "Student name: Daryl, Grade: 8, Graduated with an average score: 5.95",
    "Student name: Bill, Grade: 9, Graduated with an average score: 6.00",
    "Student name: Philip, Grade: 10, Graduated with an average score: 5.05",
    "Student name: Peter, Grade: 11, Graduated with an average score: 4.88",
    "Student name: Gavin, Grade: 10, Graduated with an average score: 4.00"
]);
schoolRegister([
    'Student name: George, Grade: 5, Graduated with an average score: 2.75',
    'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
    'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
    'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
    'Student name: John, Grade: 9, Graduated with an average score: 2.90',
    'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
    'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
]);