function employeeList(inputArr) {
    let employees = [];

    for (const inputArrElement of inputArr) {
        let name = inputArrElement;
        let number = inputArrElement.length;

        let employee = {
            name,
            number
        }

        employees.push(employee);
    }

    for (const employee of employees) {
        console.log(`Name: ${employee.name} -- Personal Number: ${employee.number}`)
    }
}

employeeList(['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal']);
employeeList(['Samuel Jackson', 'Will Smith', 'Bruce Willis', 'Tom Holland']);